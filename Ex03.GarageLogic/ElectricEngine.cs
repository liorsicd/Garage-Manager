using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{

    public class ElectricEngine : EnergySource
    {


        public ElectricEngine(EnergySource.eEnergyTypes i_EnergyType)
            : base(i_EnergyType)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }



}
