using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eColorType
        {
            green,
            blue
        }

        public enum eNumOfDoors
        {
            two = 2,
        }
        private const int k_numOfWheels = 4;
        private readonly eColorType r_ColorType;
        private readonly eNumOfDoors r_NumOfDoors;
       


        
        
    }
}
