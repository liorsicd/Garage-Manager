using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public enum eTypeOfVehicle
        {
            Car,
            Motorcycle,
            Truck
        }

        private readonly eTypeOfVehicle r_Type;
        protected int m_NumOfWheels;
        protected int m_MaximumWheelPressure;
        private string m_Model;
        private string m_LicenseNumber;
        private EnergySource m_EnergySource;
        private float m_RemainingEnergyPercentage;
        private List<Wheel> m_Wheels;

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
            this.m_Wheels = new List<Wheel>(this.m_NumOfWheels);
            for(int i = 0; i < this.m_NumOfWheels; i++)
            {
                this.m_Wheels.Add(new Wheel(this.m_MaximumWheelPressure, i_ManufacturerName, i_CurrentAirPressure));
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
            return string.Format(
                "Type: {5}{0}Model Name: {1}{0}{2}{0}Remaining Energy Percentage: {3}%{0}{4}",
                Environment.NewLine,
                this.m_Model,
                this.m_Wheels[0],
                this.m_RemainingEnergyPercentage,
                this.m_EnergySource,
                this.r_Type);
        }
    }
}
