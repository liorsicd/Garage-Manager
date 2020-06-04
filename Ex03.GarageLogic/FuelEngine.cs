using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ex03.GarageLogic
{
    public class FuelEngine : EnergySource
    {
        private readonly eFuelType r_FuelType;
        private readonly float r_MaxFuelAmount;
        private float m_CurrentFuelAmount;
        public enum eFuelType
        {
            Soler = 1,
            Octan95 = 2,
            Octan96 = 3,
            Octan98 = 4
        }


        public eFuelType fuelType
        {
            get
            {
                return r_FuelType;
            }
        }

        public float MaxFuelAmount
        {
            get
            {
                return r_MaxFuelAmount;
            }
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
