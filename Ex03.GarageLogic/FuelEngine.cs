using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ex03.GarageLogic
{
    public class FuelEngine : EnergySource
    {
        private eFuelType r_FuelType;

        public enum eFuelType
        {
            Soler = 1,

            Octan95 = 2,

            Octan96 = 3,

            Octan98 = 4
        }

        public FuelEngine(EnergySource.eEnergyTypes i_EnergyType)
            : base(i_EnergyType)
        {
        }

        public void SetFuelType (eFuelType i_fuelType)
        {
            this.r_FuelType = i_fuelType;
        }

        public bool checkFuelType(eFuelType i_FuelType)
        {
            return this.r_FuelType == i_FuelType;
        }

        public override string ToString()
        {
            return string.Format("{1} Fuel Type: {2}{0}", Environment.NewLine, base.ToString(), this.r_FuelType);
        }
    }
}
