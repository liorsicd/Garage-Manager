using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string r_ManufacturerName;
        private readonly float r_MaxAirPressure;
        private float m_CurrentAirPressure;
        
        public Wheel(float i_MaxAirPressure, string i_ManufacturerName)
        {
            r_MaxAirPressure = i_MaxAirPressure;
            this.r_ManufacturerName = i_ManufacturerName;
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
                //EXCEPTION
            }
            else
            {
                m_CurrentAirPressure += i_AirToAdd;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Manufacturer Name: {1}{0} Current Air Pressure {2}{0} maximum Air Pressure",
                Environment.NewLine,
                this.m_CurrentAirPressure,
                this.r_MaxAirPressure);
        }
    }
}
