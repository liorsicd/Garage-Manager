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
            if(this.getLicenseNumber(out string licenseNumber))
            {
                float minToCharge = 0;
                do
                {
                    Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.TimeToCharge));
                }
                while(!this.r_UserInputValidation.IsValidFloat(out minToCharge));

                try
                {
                    r_Garage.Recharge(licenseNumber, minToCharge);
                    Display.Write(Messages.GetGeneralMessage(Messages.eGeneralMessages.Success));
                }
                catch(Exception e)
                {
                    Display.Write(e.Message);
                }
            }
            Display.PressToContinue();
            Display.Clear();

        }

        public void RefuelVehicle()
        {
            if(this.getLicenseNumber(out string licenseNumber))
            {
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

                    try
                    {
                        this.r_Garage.AddFuel(licenseNumber, amount, (FuelEngine.eFuelType)fuelType);
                        Display.Write(Messages.GetGeneralMessage(Messages.eGeneralMessages.Success));
                    }
                    catch(Exception e)
                    {
                        Display.Write(e.Message);
                    }
            }
            
            Display.PressToContinue();
            Display.Clear();
        }

        public void ChangeStatus()
        {
            if(this.getLicenseNumber(out string licenseNumber))
            {
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

            List<string> vehiclesList = this.r_Garage.GetListOfVehiclesInGarage((VehicleInGarage.eStatus)status);
            if(vehiclesList.Count > 0)
            {
                Display.WriteList(vehiclesList);
            }
            else
            {
                Display.Write(Messages.GetErrorMessage(Messages.eErrorMessagesToUser.VehicleStatus));
            }

            Display.PressToContinue();
            Display.Clear();
        }


        public void InflateTires()
        {
            
            if(this.getLicenseNumber(out string licenseNumber))
            {
                try
                {
                    this.r_Garage.AddAir(licenseNumber);
                    Display.Write(Messages.GetGeneralMessage(Messages.eGeneralMessages.Success));
                }
                catch (ValueOutOfRangeException e)
                {
                    Display.Write(e.Message);
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

