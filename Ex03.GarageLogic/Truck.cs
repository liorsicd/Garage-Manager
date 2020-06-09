using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const int k_NumOfWheels = 16;
        private const int k_MaximumWheelPressure = 28;
        private const float k_MaxFuelAmount = 120;
        private const float k_MaxElectricAmount = -1;
        private bool b_IsDangerous;
        private float m_CargoVolume;

        public Truck(Vehicle.eTypeOfVehicle i_Type)
            : base(i_Type)
        {
        }

        public void SetIsdangerous(bool i_IsDangerous)
        {
            b_IsDangerous = i_IsDangerous;
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
            return String.Format(
                "{3} Cargo Volume {1}{0}, the truck is: {2} carrying dangerous materials{0}",
                Environment.NewLine,
                this.m_CargoVolume,
                !this.b_IsDangerous ? "not" : String.Empty,
                base.ToString());
        }
    }
}
