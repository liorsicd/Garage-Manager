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
        private float m_CurrentAmountOfEnergy;
        private float m_MaxAmountOfEnergy;

        public enum eEnergyTypes
        {
            Fuel,
            Electric
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

        public void FillEnergy(float i_AmountOfEnergy)
        {
            if (i_AmountOfEnergy < 0 || i_AmountOfEnergy + m_CurrentAmountOfEnergy > m_MaxAmountOfEnergy)
            {
                //exception
            }
            else
            {
                m_CurrentAmountOfEnergy += i_AmountOfEnergy;
            }
        }
    }
}
