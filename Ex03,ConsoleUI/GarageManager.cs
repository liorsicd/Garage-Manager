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
            string licenseNumber;
            float minToCharge = 0;
            do
            {
                Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.EnterLicenseNumber));
                Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.TimeToCharge));
            }
            while (this.m_userInputValidation.IsValidStringNumber(out licenseNumber)
                   && this.m_userInputValidation.IsValidFloat(out minToCharge));
            {
                this.m_Garage.Recharge(licenseNumber, minToCharge);
            }
        }


        public void RefuelVehicle()
        {
            FuelEngine.eFuelType fuelType;
            string licenseNumber = string.Empty;
            float amount = 0;
            do
            {
                Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.EnterLicenseNumber));
                Display.WriteEnum(typeof(FuelEngine.eFuelType));
                Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.FuelToAdd));
            }
            while(this.m_userInputValidation.IsValidFuelType(out fuelType)
                  && this.m_userInputValidation.IsValidStringNumber(out licenseNumber)
                  && this.m_userInputValidation.IsValidFloat(out amount));
            {
                this.m_Garage.AddFuel(licenseNumber, amount, fuelType);
            }
        }

        public void ChangeStatus()
        {

            VehicleInGarage.eStatus status = VehicleInGarage.eStatus.OutOfGarage;
            string licenseNumber;

            do
            {
                Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.ChangeStatus));
                Display.WriteEnum(typeof(VehicleInGarage.eStatus));
                Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.EnterLicenseNumber));

            }
            while(this.m_userInputValidation.IsValidStringNumber(out licenseNumber)
                  && this.m_userInputValidation.IsValidStatus(out status));
            {
                this.m_Garage.ChangeVehicleStatus(licenseNumber, status);
            }
        }

        //??
        public void DisplayLicenseNumbersList()
        {
            List<string> licenseNumbers;

                this.m_Garage.GetListOfVehiclesInGarage();
        }





        public void InflateTires()
        {
            string licenseNumber;
            do
            {
                Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.EnterLicenseNumber));
            }
            while (this.m_userInputValidation.IsValidStringNumber(out licenseNumber));
            {
                this.m_Garage.AddAir(licenseNumber);
            }
        }




        public void PrintVehicleDetails()
        {
            string licenseNumber;
            do
            {
                Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.EnterLicenseNumber));
            }
            while(this.m_userInputValidation.IsValidStringNumber(out licenseNumber));
            {
                this.m_Garage.ShowVehicleDetails(licenseNumber);
            }
        }
    }
}

