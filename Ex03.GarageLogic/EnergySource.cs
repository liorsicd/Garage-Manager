using System;

namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        private eEnergyTypes m_EnergyType;
        protected float m_CurrentAmountOfEnergy;
        protected float m_MaxAmountOfEnergy;

        public enum eEnergyTypes
        {
            Fuel,
            Electric
        }

        protected EnergySource(eEnergyTypes i_EnergyType)
        {
            this.m_EnergyType = i_EnergyType;
        }

        public eEnergyTypes EnergyType
        {
            get
            {
                return m_EnergyType;
            }

            set
            {
                m_EnergyType = value;
            }
        }

        public float CurrentAmountOfEnergy
        {
            get
            {
                return m_CurrentAmountOfEnergy;
            }
        }

        public void SetCurrentAmountOfEnergy(float i_CurrentAmountOfEnergy)
        {
            FillEnergy(i_CurrentAmountOfEnergy);
        }

        public float MaxAmountOfEnergy
        {
            get
            {
                return m_MaxAmountOfEnergy;
            }
        }

        public void InitMaxAmountOfEnergy(Vehicle i_Vehicle)
        {
            switch(m_EnergyType)
            {
                case eEnergyTypes.Fuel:
                    this.m_MaxAmountOfEnergy = i_Vehicle.GetMaxFuelAmount();
                    break;
                case eEnergyTypes.Electric:
                    this.m_MaxAmountOfEnergy = i_Vehicle.GetMaxElectricAmount();
                    break;
            }
        }

        public void FillEnergy(float i_AmountOfEnergy)
        {
            if(i_AmountOfEnergy + this.CurrentAmountOfEnergy > this.m_MaxAmountOfEnergy)
            {
                throw new ValueOutOfRangeException(
                    "Max energy to fill is " + m_MaxAmountOfEnergy,
                    this.m_MaxAmountOfEnergy,
                    0);
            }

            m_CurrentAmountOfEnergy += i_AmountOfEnergy;
        }

        public override string ToString()
        {
            return string.Format(
                "Engine type: {1}{0}Current amount of energy {2}{0}Maximum amount of energy {3}{0}",
                Environment.NewLine,
                this.m_EnergyType,
                this.m_CurrentAmountOfEnergy,
                this.m_MaxAmountOfEnergy);
        }
    }
}
