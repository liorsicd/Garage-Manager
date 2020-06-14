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
            
        }

        public void InsertVehicle(VehicleInGarage i_VehicleInGarage)
        {
            this.m_VehiclesInGarages.Add(i_VehicleInGarage.Vehicle.LicenseNumber, i_VehicleInGarage);
            ChangeVehicleStatus(i_VehicleInGarage.Vehicle.LicenseNumber, VehicleInGarage.eStatus.InRepair);
        }

        public List<string> GetListOfVehiclesInGarage(VehicleInGarage.eStatus i_status)
        {
            List<string> list = new List<string>();
            foreach (KeyValuePair<string, VehicleInGarage> v in this.m_VehiclesInGarages)
            {
                if(v.Value.Status == i_status)
                {
                    list.Add(v.Key);
                }
            }

            return list;
        }


        private bool getVehicleInGarage(string i_LicenseNumber, out VehicleInGarage i_CurrentVehicleInGarage)
        {
            return this.m_VehiclesInGarages.TryGetValue(i_LicenseNumber, out i_CurrentVehicleInGarage);
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

        public bool AddAir(string i_LicenseNumber)
        {
            bool returnValue = false;
            if(getVehicleInGarage(i_LicenseNumber, out VehicleInGarage currentVehicleInGarage))
            {
                returnValue = true;
                foreach(Wheel w in currentVehicleInGarage.Vehicle.Wheels)
                {
                    w.AddAir(w.MaxAirPressure - w.CurrentAirPressure);
                }
            }

            return returnValue;
        }

        public bool AddFuel(string i_LicenseNumber, float i_FuelToAdd, FuelEngine.eFuelType i_Type)
        {
            bool returnValue = false;

            if(getVehicleInGarage(i_LicenseNumber, out VehicleInGarage currentVehicleInGarage))
            {
                if(((FuelEngine)currentVehicleInGarage.Vehicle.EnergySource).checkFuelType(i_Type))
                {
                    returnValue = currentVehicleInGarage.Vehicle.EnergySource.FillEnergy(i_FuelToAdd);
                }
                else
                {
                    throw new ArgumentException("not correct fuel type");
                }
            }

            currentVehicleInGarage.Vehicle.UpdateRemainingEnergy();

            return returnValue;
        }

        public bool Recharge(string i_LicenseNumber, float i_MinutesToAdd)
        {
            bool returnValue = false;
            if(getVehicleInGarage(i_LicenseNumber, out VehicleInGarage currentVehicleInGarage))
            {
                returnValue = currentVehicleInGarage.Vehicle.EnergySource.FillEnergy(i_MinutesToAdd / 60);
            }

            currentVehicleInGarage.Vehicle.UpdateRemainingEnergy();

            return returnValue;
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

