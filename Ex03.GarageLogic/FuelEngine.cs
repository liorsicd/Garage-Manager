using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelEngine : EnergySource
    {
        public enum eFuelType
        {

        }

        private readonly eFuelType r_fuelType;
        private readonly float MaxFuelAmount;
        private float currentFuelAmount;
    }
}
