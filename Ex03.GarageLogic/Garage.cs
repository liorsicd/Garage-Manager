using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, VehicleInGarage> m_VehiclesInGarages;

        public Garage()
        {
            this.m_VehiclesInGarages = new Dictionary<string, VehicleInGarage>();
        }

        public bool IsVehicleExist(string i_LicenseNumber)
        {
            return m_VehiclesInGarages.TryGetValue(i_LicenseNumber, out VehicleInGarage currentVehicleInGarage);
            ;
        }

        public void InsertVehicle(VehicleInGarage i_VehicleInGarage)
        {
            this.m_VehiclesInGarages.Add(i_VehicleInGarage.Vehicle.LicenseNumber, i_VehicleInGarage);
        }

        public List<string> GetListOfVehiclesInGarage()
        {
            return new List<string>(this.m_VehiclesInGarages.Keys);
        }

        private bool getVehicleInGarage(string i_LicenseNumber, out VehicleInGarage i_CurrentVehicleInGarage)
        {
            return this.m_VehiclesInGarages.TryGetValue(i_LicenseNumber, out i_CurrentVehicleInGarage);
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, VehicleInGarage.eStatus i_Status)
        {
            
            if(getVehicleInGarage(i_LicenseNumber, out VehicleInGarage currentVehicleInGarage))
            {
                currentVehicleInGarage.Status = i_Status;
            }
        }

        public void AddAir(string i_LicenseNumber)
        {
            if(getVehicleInGarage(i_LicenseNumber, out VehicleInGarage currentVehicleInGarage))
            {
                foreach(Wheel w in currentVehicleInGarage.Vehicle.Wheels)
                {
                    w.AddAir(w.MaxAirPressure - w.CurrentAirPressure);
                }
            }
        }

        public bool AddFuel(string i_LicenseNumber, float i_FuelToAdd, FuelEngine.eFuelType i_Type)
        {
            bool returnValue = false;

            if(getVehicleInGarage(i_LicenseNumber, out VehicleInGarage currentVehicleInGarage))
            {
                if((currentVehicleInGarage.Vehicle.EnergySource as FuelEngine).checkFuelType(i_Type))
                {
                    returnValue = currentVehicleInGarage.Vehicle.EnergySource.FillEnergy(i_FuelToAdd);
                }
            }

            currentVehicleInGarage.Vehicle.UpdateRemaningEnergy();

            return returnValue;
        }

        public bool Recharge(string i_LicenseNumber, float i_MinutesToAdd)
        {
            bool returnValue = false;
            if(getVehicleInGarage(i_LicenseNumber, out VehicleInGarage currentVehicleInGarage))
            {
                returnValue = currentVehicleInGarage.Vehicle.EnergySource.FillEnergy(i_MinutesToAdd / 60);
            }

            currentVehicleInGarage.Vehicle.UpdateRemaningEnergy();

            return returnValue;
        }

        public string ShowVehicleDetails(string i_LicenseNumber)
        {
            string returnValue = "Vehicle not found";
            if(getVehicleInGarage(i_LicenseNumber, out VehicleInGarage currentVehicleInGarage))
            {
                returnValue = string.Format(
                    "License Number: {1}{0} Owner Name: {2}{0} Status: {3}{0}{4}",
                    Environment.NewLine,
                    currentVehicleInGarage.Vehicle.LicenseNumber,
                    currentVehicleInGarage.OwnerName,
                    currentVehicleInGarage.Status,
                    currentVehicleInGarage.Vehicle);
            }

            return returnValue;
        }


    }


}

