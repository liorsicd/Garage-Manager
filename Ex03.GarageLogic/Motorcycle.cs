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

        private const float k_MaxFuelAmount = 7;
        private const float k_MaxElectricAmount = 1.2f;
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        public Motorcycle(Vehicle.eTypeOfVehicle i_Type)
            : base(i_Type)
        {
            base.k_NumOfWheels = k_NumOfWheels;
            base.k_MaximumWheelPressure = k_MaximumWheelPressure;
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



        public void SetLicenseType(eLicenseType i_LicenseType)
        {
            this.m_LicenseType = i_LicenseType;
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
                "{3}License Type: {1}{0}Engine Volume: {2}{0}",
                Environment.NewLine,
                this.m_LicenseType,
                this.m_EngineVolume,
                base.ToString());
        }
    }
}
