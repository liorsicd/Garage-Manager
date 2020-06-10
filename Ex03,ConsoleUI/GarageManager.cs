using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_ConsoleUI
{
    using Ex03.GarageLogic;

    public class GarageManager
    {
        private Garage m_Garage;

        private VehicleAdder m_VehicleAdder;

        private UserInputValidation m_userInputValidation;

        public GarageManager()
        {
            this.m_Garage = new Garage();
            this.m_VehicleAdder = new VehicleAdder();
            this.m_userInputValidation = new UserInputValidation();
        }

        public void AddVehicle()
        {
            this.m_VehicleAdder.Start();

            this.m_Garage.InsertVehicle(this.m_VehicleAdder.GetNewVehicle());
        }

        public void ChargeElectricVehicle()
        {
            bool success = false;
            while(!success)
            {
                string licenseNumber;
                do
                {
                    Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.EnterLicenseNumber));
                }
                while(this.m_userInputValidation.IsValidStringNumber(out licenseNumber));



                float minToCharge = 0;
                do
                {
                    Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.TimeToCharge));
                }
                while(this.m_userInputValidation.IsValidFloat(out minToCharge));

                if(!m_Garage.Recharge(licenseNumber, minToCharge))
                {
                    Display.Write(Messages.GetErrorMessage(Messages.eErrorMessagesToUser.InvalidInput));
                }
                else
                {
                    success = true;
                }
            }

        }

        public void RefuelVehicle()
        {
            bool success = false;
            while(!success)
            {

                object fuelType;
                string licenseNumber = string.Empty;
                float amount = 0;
                do
                {
                    Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.EnterLicenseNumber));

                }
                while(this.m_userInputValidation.IsValidOption(typeof(FuelEngine.eFuelType), out fuelType));

                do
                {
                    Display.WriteEnum(typeof(FuelEngine.eFuelType));
                }
                while(this.m_userInputValidation.IsValidStringNumber(out licenseNumber));


                do
                {
                    Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.FuelToAdd));
                }
                while(this.m_userInputValidation.IsValidFloat(out amount));

                if(!m_Garage.AddFuel(licenseNumber, amount, (FuelEngine.eFuelType)fuelType))
                {
                    Display.Write(Messages.GetErrorMessage(Messages.eErrorMessagesToUser.InvalidInput));
                }
                else
                {
                    success = true;
                }
            }
        }

        public void ChangeStatus()
        {
            bool success = false;
            while(!success)
            {
                object status;
                string licenseNumber;

                do
                {
                    Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.EnterLicenseNumber));

                }
                while(this.m_userInputValidation.IsValidStringNumber(out licenseNumber));

                do
                {
                    Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.ChangeStatus));
                    Display.WriteEnum(typeof(VehicleInGarage.eStatus));
                }
                while(this.m_userInputValidation.IsValidOption(typeof(VehicleInGarage.eStatus), out status));

                if(!this.m_Garage.ChangeVehicleStatus(licenseNumber, (VehicleInGarage.eStatus)status))
                {
                    Display.Write(Messages.GetErrorMessage(Messages.eErrorMessagesToUser.InvalidInput));
                }
                else
                {
                    success = true;
                }
            }
        }

        public void DisplayLicenseNumbersList()
        {
            object status;
            Display.Write(Messages); //// choose status of vehicle
            do
            { 
                Display.WriteEnum(typeof(VehicleInGarage.eStatus));

            }
            while(!this.m_userInputValidation.IsValidOption(typeof(VehicleInGarage.eStatus), out status));

            Display.Write(this.m_Garage.GetListOfVehiclesInGarage((VehicleInGarage.eStatus)status).ToString());
        }



        public void InflateTires()
        {
            bool success = false;
            while(!success)
            {
                string licenseNumber;
                do
                {
                    Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.EnterLicenseNumber));
                }
                while(!this.m_userInputValidation.IsValidStringNumber(out licenseNumber));

                if(!this.m_Garage.AddAir(licenseNumber))
                {
                    Display.Write(Messages.GetErrorMessage(Messages.eErrorMessagesToUser.InvalidInput));
                }
                else
                {
                    success = true;
                }
            }
        }

        public void PrintVehicleDetails()
        {
            bool success = false;
            string details = null;
            while(!success)
            {
                string licenseNumber;
                do
                {
                    Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.EnterLicenseNumber));
                }
                while(this.m_userInputValidation.IsValidStringNumber(out licenseNumber));

                
                if(!this.m_Garage.ShowVehicleDetails(licenseNumber, out details))
                {
                    Display.Write(Messages.GetErrorMessage(Messages.eErrorMessagesToUser.InvalidInput));
                }
                else
                {
                    success = true;
                }
            }
            Display.Write(details);
        }
    }
}

