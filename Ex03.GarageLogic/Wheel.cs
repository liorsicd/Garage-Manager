using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;

        //constructor
        public Wheel(float i_MaxAirPressure, string i_ManufacturerName, float i_CurrentAirPressure)
        {
            r_ManufacturerName = i_ManufacturerName;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaxAirPressure = i_MaxAirPressure;
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



    }
}
