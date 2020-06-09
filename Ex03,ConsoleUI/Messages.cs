using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_ConsoleUI
{
    public class Messages
    {
        private static string[] m_MessagesAddVehicle = 
            { 
                "Please enter license number",
            "Please enter owner name",
            "Please enter owner phone number",
            "Please enter vehicle type",
            "Please enter vehicle energy source",
            "Please enter vehicle model",
            "Please enter wheel ManufacturerName",
            "Please enter car color",
            "Please enter car num of doors",
            "Please enter engine volume",
            "Please enter license type",
            "Please enter cargo volume",
            "Please enter yes if carrying dangerous materials, else no", "Please enter owner current amount of energy",
            "Please enter fuel type",
            "Please enter current air pressure",
            "Please enter current energy amount"
            };

        private static string[] m_ErrorMessagesToUser =
            {
            "Invalid input, please try again",
            "Invalid String number, should contain only numbers",
            "Invalid Vehicle Type, please try again",
            "Not valid name, please try again",
            "Garage is empty, No vehicles to display",
            "Invalid type of energy, please tey again",
            "Invalid fuel type, please try again",
            "Invalid num of doors, please try again",
            "Invalid color, please try again",
            "Invalid license type, please try again",
            "Not valid energy, please try again",
            };

        private static string[] m_MessagesServiceUser =
            {
                "Refueled your vehicle successfully.",
                "Recharged your vehicle successfully.",
                "Inflated your wheels to maximum.",
                "Please enter amount to add",
                "Thank you for using the garage management program, Bye Bye!"
            };



        public enum eAddVehicle
        {
            EnterLicenseNumber,
            OwnerName,
            PhoneNumber,
            VehicleType,
            EnergySource,
            VehicleModel,
            WheelManufacturerName,
            CarColor,
            NumOfDoors,
            EngineVolume,
            LicenseType,
            CargoVolume,
            IsDangerous,
            FuelType,
            CurrentAirPressure,
            CurrentEnergyAmount
        }


        public enum eErrorMessagesToUser
        {
            InvalidInput = 0,
            InvalidStringNum = 1,
            InvalidVehicleType = 2,
            InvalidName = 3,
            GarageIsEmpty = 4,
            InvalidEnergy = 5,
            InvalidFuelType = 6,
            InvalidNumDoors = 7,
            InvalidColor = 8,
            InvalidLicenseType = 9
    }



        public static string GetErrorMessage(eErrorMessagesToUser i_Messages)
    {
        return m_ErrorMessagesToUser[(int)i_Messages];
    }



        public static string GetMessageAddVehicle(eAddVehicle i_Messages)
        {
            return m_MessagesAddVehicle[(int)i_Messages];
        }
    }
}

