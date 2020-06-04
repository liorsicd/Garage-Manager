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
        private readonly float r_CargoVolume;


        public Truck () : base() { }

        public bool Isdangerous
        {
            get
            {
                return b_IsDangerous;
            }

            set
            {
                b_IsDangerous = value;
            }
        }

        public float CargoVolume
        {
            get
            {
                return r_CargoVolume;
            }
        }
    }
}
