using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public enum eTypeOfVehicle
        {
            Car,

            Motorcycle,

            Truck,
        }


        private readonly string r_Model;
        private string r_LicenseNumber;
        private float m_RemainingEnergyPercentage;
        private List<Wheel> m_Wheels;
        private readonly EnergySource r_Engine;

        public Vehicle(EnergySource i_Engine)
        {
            this.r_Engine = i_Engine;
            r_LicenseNumber = string.Empty;
            m_RemainingEnergyPercentage = 0;
            m_Wheels = null;

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
            
            get
            {
                return this.r_Engine;
            }
        }
    }
}
