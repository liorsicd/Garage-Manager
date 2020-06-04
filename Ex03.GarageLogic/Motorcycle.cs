using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {

        //test for commit 
        public enum eLicenseType
        {
            a,
            b,
            c
        }
        private const int k_numOfWheels = 2;
        private readonly eLicenseType r_licenseType;
        private readonly int m_EngineVolume;
    }
}
