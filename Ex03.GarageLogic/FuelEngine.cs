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
        private float r_MaxFuelAmount;
        private float m_CurrentFuelAmount;

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

        public void SeteFuelType (eFuelType i_fuelType)
        {
            this.r_FuelType = i_fuelType;
        }

        public void SetMaxFuelAmount(float i_MaxFuelAmount)
        {
            
        }

        public void SetCurrentFuelAmount(float i_CurrentFuelAmount)
        {
            this.m_CurrentFuelAmount = i_CurrentFuelAmount;
        }

        public void AddFuel(eFuelType i_FuelType, float i_AmountOfFuel)
        {
            if (i_FuelType != r_FuelType)
            {
                throw new ArgumentException(string.Format("The gas type dose not match the car vehicle fuel type. chosen vehicle fuel type is: {0}", r_FuelType));
            }

            FillEnergy(i_AmountOfFuel);
        }


    }
}
