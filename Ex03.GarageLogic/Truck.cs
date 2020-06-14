using System;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const int k_NumOfWheels = 16;
        private const int k_MaximumWheelPressure = 28;
        private const float k_MaxFuelAmount = 120;
        private const float k_MaxElectricAmount = -1;
        private bool m_IsDangerous;
        private float m_CargoVolume;

        public Truck(Vehicle.eTypeOfVehicle i_Type)
            : base(i_Type)
        {
            this.m_NumOfWheels = k_NumOfWheels;
            this.m_MaximumWheelPressure = k_MaximumWheelPressure;
        }

        public void SetIsDangerous(bool i_IsDangerous)
        {
            m_IsDangerous = i_IsDangerous;
        }

        public void SetCargoVolume(float i_CargoVolume)
        {
            this.m_CargoVolume = i_CargoVolume;
        }

        public override float GetMaxFuelAmount()
        {
            return k_MaxFuelAmount;
        }

        public override float GetMaxElectricAmount()
        {
            return k_MaxElectricAmount;
        }

        public override string ToString()
        {
            return string.Format(
                "{3}Cargo Volume {1}{0}the truck is: {2}Carrying dangerous materials{0}",
                Environment.NewLine,
                this.m_CargoVolume,
                !this.m_IsDangerous ? "not" : string.Empty,
                base.ToString());
        }
    }
}
