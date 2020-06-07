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
        private bool b_IsDangerous;
        private float m_CargoVolume;

        public Truck(Vehicle.eTypeOfVehicle i_Type)
            : base(i_Type)
        {
        }
        public void SetIsdangerous(bool i_Isdangerous)
        {
            b_IsDangerous = i_Isdangerous;
        }

        public  void SetCargoVolume(float i_CargoVolume)
        {
            this.m_CargoVolume = i_CargoVolume;

        }
    }
}
