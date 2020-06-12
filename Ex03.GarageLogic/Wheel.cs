using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly float r_MaxAirPressure;
        private string r_ManufacturerName;
        private float m_CurrentAirPressure;
        
        public Wheel(float i_MaxAirPressure, string i_ManufacturerName, float i_CurrentAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
            this.r_ManufacturerName = i_ManufacturerName;
            AddAir(i_CurrentAirPressure);
        }
        
        public string ManufacturerName
        {
            get
            {
                return r_ManufacturerName;
            }
        }
        public float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public void AddAir(float i_AirToAdd)
        {
            if (i_AirToAdd + m_CurrentAirPressure > r_MaxAirPressure || i_AirToAdd < 0)
            {
                throw new ValueOutOfRangeException("Maximum air pressure: " + this.r_MaxAirPressure, r_MaxAirPressure, 0);
            }
            else
            {
                m_CurrentAirPressure += i_AirToAdd;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Wheel Manufacturer Name: {1}{0}Current Air Pressure: {2}{0}Maximum Air Pressure:{3}{0}",
                Environment.NewLine,
                this.r_ManufacturerName,
                this.m_CurrentAirPressure,
                this.r_MaxAirPressure);
        }
    }
}
