using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private const int k_NumOfWheels = 2;
        private const int k_MaximumWheelPressure = 30;
        private readonly eLicenseType r_licenseType;
        private readonly int m_EngineVolume;

        //counstructor
        public Motorcycle(EnergySource i_EnergySource)
        {

        }

        public enum eLicenseType
        {
            A = 1,
            A1 = 2,
            AA = 3,
            B = 4
        }


        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }
        }

        public eLicenseType LicenseType
        {
            get
            {
                return r_licenseType;
            }

        }
    }
}
