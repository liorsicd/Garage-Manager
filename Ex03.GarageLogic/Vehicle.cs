using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_Model;
        private readonly string r_LicenseNumber;
        private float m_RemainingEnergyPercentage;
        private List<Wheel> wheels;
        private readonly EnergySource r_Engine;



    }
}
