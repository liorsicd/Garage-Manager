using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    using System.Diagnostics.Eventing.Reader;

    public class ElectricEngine : EnergySource
    {
        private float m_RemaningHours;
        private readonly float MaxHours;
    }

    public float CurrentFuelAmount
    {
        get
        {
            return m_CurrentFuelAmount;
        }
        set
        {
            m_CurrentFuelAmount = value;
        }
    }
    public void Charge(float i_AmountOfHoursToAdd)
     {
        FillEnergy(i_AmountOfHoursToAdd);
    }




}
