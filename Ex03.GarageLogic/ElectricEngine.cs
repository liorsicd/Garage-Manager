using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{

    public class ElectricEngine : EnergySource
    {
        private float m_RemaningHours;
        private float MaxHours;


        public ElectricEngine(EnergySource.eEnergyTypes i_EnergyType)
            : base(i_EnergyType)
        {
        }

    }

    

    // public float CurrentFuelAmount
    // {
    //     get
    //     {
    //         return m_CurrentFuelAmount;
    //     }
    //     set
    //     {
    //         m_CurrentFuelAmount = value;
    //     }
    // }
    // public void Charge(float i_AmountOfHoursToAdd)
    //  {
    //     FillEnergy(i_AmountOfHoursToAdd);
    // }




}
