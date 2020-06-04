using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_Model;
        private readonly string r_LicenseNumber;
        private float m_RemainingEnergyPercentage;
        private List<Wheel> m_Wheels;
        private EnergySource m_Engine;

        public Vehicle()
        {
            r_Model = string.Empty;
            r_LicenseNumber = string.Empty;
            m_RemainingEnergyPercentage = 0;
            m_Wheels = new List<Wheel>();
            m_Engine = null;
        }

        public string Model
        {
            get
            {
                return r_Model;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        public float RemainingEnergyPercentage
        {
            get
            {
                return m_RemainingEnergyPercentage;
            }
            set
            {
                m_RemainingEnergyPercentage = value;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }

            set
            {
                m_Wheels = value;
            }
        }
        public EnergySource EnergySource
        {
            set
            {
                m_Engine = value;
            }
            get
            {
                return m_Engine;
            }
        }
    }
}
