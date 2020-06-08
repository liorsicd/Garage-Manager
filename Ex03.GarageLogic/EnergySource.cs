using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public EnergySource(eEnergyTypes i_EnergyType)
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

            set
            {
                m_CurrentAmountOfEnergy = value;
            }
        }

        public float MaxAmountOfEnergy
        {
            get
            {
                return m_MaxAmountOfEnergy;
            }

            set
            {
                m_MaxAmountOfEnergy = value;
            }
        }

        public void SetMaxAmountOfEnergy(Vehicle i_Vehicle)
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

        public bool FillEnergy(float i_AmountOfEnergy)
        {
            bool returnValue = false;

            if(!(i_AmountOfEnergy + this.CurrentAmountOfEnergy > this.m_MaxAmountOfEnergy))
            {
                m_CurrentAmountOfEnergy += i_AmountOfEnergy;
                returnValue = true;
            }

            return returnValue;
        }

        public override string ToString()
        {
            return string.Format(
                "Engine type: {1}{0} current amount of energy {2}{0}, maximum amount of energy {3}{0}",
                Environment.NewLine,
                this.m_EnergyType,
                this.m_CurrentAmountOfEnergy,
                this.m_MaxAmountOfEnergy);
        }
    }
}
