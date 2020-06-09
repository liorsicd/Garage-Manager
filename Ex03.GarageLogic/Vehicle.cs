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
        
        private string m_LicenseNumber;
        private EnergySource m_EnergySource;
        private float m_RemainingEnergyPercentage;
        private List<Wheel> m_Wheels;
        private readonly eTypeOfVehicle r_Type;

        protected Vehicle(eTypeOfVehicle i_Type)
        {
            this.r_Type = i_Type;
        }

        public void SetVehicleParams(string i_LicenseNumber, string i_Model)
        {
            this.m_LicenseNumber = i_LicenseNumber;
            this.m_Model = i_Model;
        }

        public void SetWheels(string i_ManufacturerName )
        {
            Wheels = new List<Wheel>(k_NumOfWheels);
            for(int i = 0; i < k_NumOfWheels; i++)
            {
                Wheels[i] = new Wheel(k_MaximumWheelPressure, i_ManufacturerName);
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

        public abstract float GetMaxElectricAmount();

        public abstract float GetMaxFuelAmount();

        public override string ToString()
        {
            return String.Format(
                "License Number: {1}{0} Model Name: {2}{0}{3}",
                Environment.NewLine,
                this.m_LicenseNumber,
                this.m_Model,
                this.m_Wheels[0]);
        }
    }
}
