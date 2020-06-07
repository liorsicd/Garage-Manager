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
        private  eLicenseType m_LicenseType;
        private  int m_EngineVolume;

        public Motorcycle(Vehicle.eTypeOfVehicle i_Type)
            : base(i_Type)
        {
        }

        public enum eLicenseType
        {
            A = 1,
            A1 = 2,
            AA = 3,
            B = 4
        }


        public void SetEngineVolume(int i_EngineVolume)
        {
            this.m_EngineVolume = i_EngineVolume;
        }



        public void setLicenseType(eLicenseType i_LicenseType)
        {
            this.m_LicenseType = i_LicenseType;
        }
    }
}
