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

        protected int k_NumOfWheels;
        protected int k_MaximumWheelPressure;
        private string m_Model;

        protected float k_MaxElectricAmount;
        protected float k_MaxFuelAmount;

        private string m_LicenseNumber;
        private EnergySource m_EnergySource;
        private float m_RemainingEnergyPercentage;
        private List<Wheel> m_Wheels;
        private readonly eTypeOfVehicle r_Type;

        protected Vehicle(eTypeOfVehicle i_Type)
        {
            this.r_Type = i_Type;
        }

        public void setWheels()
        {
            Wheels = new List<Wheel>(k_NumOfWheels);
            for(int i = 0; i < k_NumOfWheels; i++)
            {
                Wheels[i] = new Wheel(k_MaximumWheelPressure);
            }
        }

        public void SetMaxAmountOfEnergy()
        {
            switch(this.EnergySource.EnergyType)
            {
                case EnergySource.eEnergyTypes.Electric:
                    this.EnergySource.MaxAmountOfEnergy = this.MaxElectricAmount;
                    break;
                case EnergySource.eEnergyTypes.Fuel:
                    this.EnergySource.MaxAmountOfEnergy = this.MaxFuelAmount;
                    break;
            }
        }


        public string Model
        {
            get
            {
                return this.m_Model;
            }
            set
            {
                this.m_Model = value;
            }
        }

        public string LicenseNumber
        {
            set
            {
                this.m_Model = value;
            }
            get
            {
                return this.m_LicenseNumber;
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
                this.m_EnergySource = value;
            }
            
            get
            {
                return this.m_EnergySource;
            }
        }

        public eTypeOfVehicle TypeVehicle
        {
            get
            {
                return this.r_Type;
            }
        }

        public float MaxFuelAmount
        {
            get
            {
                return k_MaxFuelAmount;
            }
        }

        public float MaxElectricAmount
        {
            get
            {
                return k_MaxElectricAmount;
            }
        }
    }
}
