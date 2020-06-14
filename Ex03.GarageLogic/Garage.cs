using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, VehicleInGarage> r_VehiclesInGarages;

        public Garage()
        {
            this.r_VehiclesInGarages = new Dictionary<string, VehicleInGarage>();
        }

        public bool IsVehicleExist(string i_LicenseNumber)
        {
            return this.r_VehiclesInGarages.TryGetValue(i_LicenseNumber, out VehicleInGarage currentVehicleInGarage);
            
        }

        public void InsertVehicle(VehicleInGarage i_VehicleInGarage)
        {
            this.r_VehiclesInGarages.Add(i_VehicleInGarage.Vehicle.LicenseNumber, i_VehicleInGarage);
            ChangeVehicleStatus(i_VehicleInGarage.Vehicle.LicenseNumber, VehicleInGarage.eStatus.InRepair);
        }

        public List<string> GetListOfVehiclesInGarage(VehicleInGarage.eStatus i_Status)
        {

            List<string> list = new List<string>();
            foreach(KeyValuePair<string, VehicleInGarage> v in this.r_VehiclesInGarages)
            {
                if(v.Value.Status == i_Status)
                {
                    list.Add(v.Key);
                }
            }

            return list;
        }


        private bool getVehicleInGarage(string i_LicenseNumber, out VehicleInGarage i_CurrentVehicleInGarage)
        {
            return this.r_VehiclesInGarages.TryGetValue(i_LicenseNumber, out i_CurrentVehicleInGarage);
        }

        public bool ChangeVehicleStatus(string i_LicenseNumber, VehicleInGarage.eStatus i_Status)
        {
            bool returnValue = false;
            if(getVehicleInGarage(i_LicenseNumber, out VehicleInGarage currentVehicleInGarage))
            {
                currentVehicleInGarage.Status = i_Status;
                returnValue = true;
            }

            return returnValue;
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

        public void AddFuel(string i_LicenseNumber, float i_FuelToAdd, FuelEngine.eFuelType i_Type)
        {
            if(getVehicleInGarage(i_LicenseNumber, out VehicleInGarage currentVehicleInGarage))
            {
                if(currentVehicleInGarage.Vehicle.EnergySource.EnergyType != EnergySource.eEnergyTypes.Fuel)
                {
                    throw new ArgumentException("wrong operation for this energy source");
                }

                if(!((FuelEngine)currentVehicleInGarage.Vehicle.EnergySource).checkFuelType(i_Type))
                {
                    throw new ArgumentException("not correct fuel type");
                }

                currentVehicleInGarage.Vehicle.EnergySource.FillEnergy(i_FuelToAdd);
            }

            currentVehicleInGarage.Vehicle.UpdateRemainingEnergy();

        }

        public void Recharge(string i_LicenseNumber, float i_MinutesToAdd)
        {
            
            if(getVehicleInGarage(i_LicenseNumber, out VehicleInGarage currentVehicleInGarage))
            {
                if(currentVehicleInGarage.Vehicle.EnergySource.EnergyType != EnergySource.eEnergyTypes.Electric)
                {
                    throw new ArgumentException("wrong operation for this energy source");
                }

                currentVehicleInGarage.Vehicle.EnergySource.FillEnergy(i_MinutesToAdd / 60);
            }

            currentVehicleInGarage.Vehicle.UpdateRemainingEnergy();

        }

        public bool ShowVehicleDetails(string i_LicenseNumber, out string o_Details)
        {
            o_Details = " ";
            bool returnValue = false;
            if(getVehicleInGarage(i_LicenseNumber, out VehicleInGarage currentVehicleInGarage))
            {
                returnValue = true;
                o_Details = string.Format(
                    "License Number: {1}{0}Owner Name: {2}{0}Status: {3}{0}{4}",
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

