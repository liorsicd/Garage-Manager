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
        private readonly Garage r_Garage;


        private readonly UserInputValidation r_UserInputValidation;

        public GarageManager()
        {
            this.r_Garage = new Garage();
            this.r_UserInputValidation = new UserInputValidation();
        }

        public void AddVehicle()
        {
            VehicleAdder vehicleAdder = new VehicleAdder();

            Display.Clear();
            string licenseNumber;
            do
            {
                Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.EnterLicenseNumber));
            }
            while(!this.r_UserInputValidation.IsValidStringNumber(out licenseNumber) );
            if(this.r_Garage.IsVehicleExist(licenseNumber))
            {
                Display.Write(Messages.GetErrorMessage(Messages.eErrorMessagesToUser.VehicleExist));
            }
            else
            {
                vehicleAdder.Start(licenseNumber);
                this.r_Garage.InsertVehicle(vehicleAdder.GetNewVehicle());

                Display.Clear();
                Display.Write(Messages.GetGeneralMessage(Messages.eGeneralMessages.Success));
            }

            Display.PressToContinue();
            Display.Clear();
        }

        private bool getLicenseNumber(out string o_LicenseNumber)
        {
            bool returnValue = false;
            do
            {
                Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.EnterLicenseNumber));
            }
            while(!this.r_UserInputValidation.IsValidStringNumber(out o_LicenseNumber));

            if(!this.r_Garage.IsVehicleExist(o_LicenseNumber))
            {
                Display.Write(Messages.GetErrorMessage(Messages.eErrorMessagesToUser.VehicleNotExist));
            }
            else
            {
                returnValue = true;
            }

            return returnValue;
        }

        public void ChargeElectricVehicle()
        {
            bool success = false;
            while(!success)
            {
                success = this.getLicenseNumber(out string licenseNumber);
                if(!success)
                {
                    break;
                }

                float minToCharge = 0;
                do
                {
                    Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.TimeToCharge));
                }
                while(!this.r_UserInputValidation.IsValidFloat(out minToCharge));

                if(!this.r_Garage.Recharge(licenseNumber, minToCharge))
                {
                    Display.Write(Messages.GetErrorMessage(Messages.eErrorMessagesToUser.InvalidInput));
                    success = false;
                }
                else
                {
                    Display.Write(Messages.GetGeneralMessage(Messages.eGeneralMessages.Success));
                }
            }
            Display.PressToContinue();
            Display.Clear();

        }

        public void RefuelVehicle()
        {
            bool success = false;
            while(!success)
            {

                success = this.getLicenseNumber(out string licenseNumber);
                if(!success)
                {
                    break;
                }

                object fuelType;
                do
                {
                    Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.FuelType));
                    Display.WriteEnum(typeof(FuelEngine.eFuelType));

                }
                while(!this.r_UserInputValidation.IsValidOption(typeof(FuelEngine.eFuelType), out fuelType));
                
                float amount = 0;
                do
                {
                    Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.FuelToAdd));
                }
                while(!this.r_UserInputValidation.IsValidFloat(out amount));

                if(!this.r_Garage.AddFuel(licenseNumber, amount, (FuelEngine.eFuelType)fuelType))
                {
                    Display.Write(Messages.GetErrorMessage(Messages.eErrorMessagesToUser.InvalidInput));
                    success = false;
                }
                else
                {
                    Display.Write(Messages.GetGeneralMessage(Messages.eGeneralMessages.Success));
                }
            }

            Display.PressToContinue();
            Display.Clear();
        }

        public void ChangeStatus()
        {
            bool success = false;
            while(!success)
            {
                success = this.getLicenseNumber(out string licenseNumber);
                if(!success)
                {
                    break;
                }

                object status;
                do
                {
                    Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.ChangeStatus));
                    Display.WriteEnum(typeof(VehicleInGarage.eStatus));
                }
                while(!this.r_UserInputValidation.IsValidOption(typeof(VehicleInGarage.eStatus), out status));

                if(!this.r_Garage.ChangeVehicleStatus(licenseNumber, (VehicleInGarage.eStatus)status))
                {
                    Display.Write(Messages.GetErrorMessage(Messages.eErrorMessagesToUser.InvalidInput));
                    success = false;
                }

            }
            Display.Write(Messages.GetGeneralMessage(Messages.eGeneralMessages.Success));
            Display.PressToContinue();
            Display.Clear();
        }

        public void DisplayLicenseNumbersList()
        {
            object status;
            Display.Write(Messages.GetGeneralMessage(Messages.eGeneralMessages.ChooseStatus)); 
            do
            { 
                Display.WriteEnum(typeof(VehicleInGarage.eStatus));

            }
            while(!this.r_UserInputValidation.IsValidOption(typeof(VehicleInGarage.eStatus), out status));

            Display.WriteList(this.r_Garage.GetListOfVehiclesInGarage((VehicleInGarage.eStatus)status));
            Display.PressToContinue();
            Display.Clear();

        }


        public void InflateTires()
        {
            bool success = false;
            while(!success)
            {
                success = this.getLicenseNumber(out string licenseNumber);
                if(!success)
                {
                    break;
                }

                if(!this.r_Garage.AddAir(licenseNumber))
                {
                    Display.Write(Messages.GetErrorMessage(Messages.eErrorMessagesToUser.InvalidInput));
                    success = false;
                }
                else
                {
                    
                    Display.Write(Messages.GetGeneralMessage(Messages.eGeneralMessages.Success));
                }
            }
            Display.PressToContinue();
            Display.Clear();
        }


        public void PrintVehicleDetails()
        {
            bool success = false;
            string details = null;
            while(!success)
            {
                success = this.getLicenseNumber(out string licenseNumber);
                if(!success)
                {
                    break;
                }

                if(!this.r_Garage.ShowVehicleDetails(licenseNumber, out details))
                {
                    Display.Write(Messages.GetErrorMessage(Messages.eErrorMessagesToUser.InvalidInput));
                    success = false;
                }
            }
            Display.Write(details);
            Display.PressToContinue();
            Display.Clear();
        }
    }
}

