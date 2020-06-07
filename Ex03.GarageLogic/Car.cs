using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{

    public class Car : Vehicle
    {
        private const int k_NumOfWheels = 4;
        private const int k_MaximumWheelPressure = 32;

        private const float k_MaxFuelAmount = 60;
        private const float k_MaxElectricAmount = 2.1f;

        private eCarColor m_CarColor;
        private eNumOfDoors m_NumOfDoors;

        public Car(Vehicle.eTypeOfVehicle i_Type)
            : base(i_Type)
        {
        }

        public void SetNumOfDoors(eNumOfDoors i_numOfDoors)
        {
            this.m_NumOfDoors = i_numOfDoors;
        }

        public void SetColor(eCarColor i_CarColor)
        {
            this.m_CarColor = i_CarColor;
        }

        public enum eCarColor
        {
            Red,
            Black,
            White,
            Silver
        }

        public float GetMaxFuelAmount()
        {
            return k_MaxFuelAmount;
        }

        public enum eNumOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }


    }
}
