using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{

    public class Car : Vehicle
    {
        private const int k_numOfWheels = 4;
        private const int k_MaximumWheelPressure = 32;
        private readonly eCarColor r_CarColor;
        private readonly eNumOfDoors r_NumOfDoors;



        public Car(EnergySource i_Engine) : base(i_Engine)
        {
            Wheels = new List<Wheel>(k_numOfWheels);
            for (int i = 0; i < k_numOfWheels; i++)
            {
                Wheels.Add(new Wheel(k_numOfWheels));
            }
        }

        public enum eCarColor
        {
            Red,
            Black,
            White,
            Silver
        }

        public enum eNumOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }


        public eCarColor Color
        {
            get
            {
                return r_CarColor;
            }
        }

        public eNumOfDoors Doors
        {
            get
            {
                return r_NumOfDoors;
            }
        }
    }
}
