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
            Car = 0,

            Motorcycle = 1,

            Truck = 2,
        }

        protected int k_NumOfWheels;
        protected int k_MaximumWheelPressure;
        private string m_Model;
        
        private string m_LicenseNumber;
        private EnergySource m_EnergySource;
        private float m_RemainingEnergyPercentage;
        private List<Wheel> m_Wheels;
        private readonly eTypeOfVehicle r_Type;

        protected Vehicle(eTypeOfVehicle i_Type)
        {
            this.r_Type = i_Type;
        }


        public void SetVehicleModel(string i_Model)
        {
            this.m_Model = i_Model;
        }

        public void SetWheels(string i_ManufacturerName, float i_CurrentAirPressure)
        {
            this.m_Wheels = new List<Wheel>(k_NumOfWheels);
            for(int i = 0; i < k_NumOfWheels; i++)
            {
                this.m_Wheels.Add(new Wheel(k_MaximumWheelPressure, i_ManufacturerName, i_CurrentAirPressure));
            }
        }


        public void UpdateRemainingEnergy()
        {
            this.m_RemainingEnergyPercentage =
                this.m_EnergySource.CurrentAmountOfEnergy / this.m_EnergySource.MaxAmountOfEnergy * 100;
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
                this.m_LicenseNumber = value;
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

        public abstract float GetMaxElectricAmount();

        public abstract float GetMaxFuelAmount();

        public override string ToString()
        {
            return String.Format(
                "Model Name: {1}{0}{2}{3}",
                Environment.NewLine,
                this.m_Model,
                this.m_Wheels[0],
                this.m_EnergySource);
        }
    }
}
