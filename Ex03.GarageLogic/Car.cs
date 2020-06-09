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

        public void SetNumOfDoors(eNumOfDoors i_NumOfDoors)
        {
            this.m_NumOfDoors = i_NumOfDoors;
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

        public override float GetMaxFuelAmount()
        {
            return k_MaxFuelAmount;
        }

        public override float GetMaxElectricAmount()
        {
            return k_MaxElectricAmount;
        }

        public enum eNumOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }

        public override string ToString()
        {
            return String.Format(
                "{3} Car Color: {1}{0}, Number Of Doors: {2}{0}",
                Environment.NewLine,
                this.m_CarColor,
                this.m_NumOfDoors,
                base.ToString());
        }
    }
}
