using System;

namespace Ex03.GarageLogic
{
    public class FuelEngine : EnergySource
    {
        private eFuelType m_FuelType;

        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        public FuelEngine(EnergySource.eEnergyTypes i_EnergyType)
            : base(i_EnergyType)
        {
        }

        public void SetFuelType(eFuelType i_FuelType)
        {
            this.m_FuelType = i_FuelType;
        }

        public bool CheckFuelType(eFuelType i_FuelType)
        {
            return this.m_FuelType == i_FuelType;
        }

        public override string ToString()
        {
            return string.Format("{1}Fuel Type: {2}{0}", Environment.NewLine, base.ToString(), this.m_FuelType);
        }
    }
}
