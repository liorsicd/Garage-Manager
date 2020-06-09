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
                //menu
            @"Welcome to the garage. How we can serve you today?",
            "Please enter license number",
            "Please enter owner name",
            "Please enter owner phone number",
            "Please enter owner vehicle type",
            "Please enter owner type of engine",
            "Please enter owner vehicle model",
            "Please enter owner vehicle energy source",
            "Please enter owner wheel ManufacturerName",
            "Please enter owner car color",
            "Please enter owner car num of doors",
            "Please enter owner engine volume",
            "Please enter owner license type",
            "Please enter owner cargo volume",
            "Please enter yes if carrying dangerous materials, else no", "Please enter owner current amount of energy",
            "Please enter owner fuel type",
            "Please enter owner current air pressure"
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
            WelcomeUser = 0,
            EnterLicenseNumber = 1,
            OwnerName = 2,
            PhoneNumber = 3,
            VehicleType = 4,
            TypeOfEngine = 5,
            VehicleModel = 6,
            EnergySource = 7,
            WheelManufacturerName = 8,
            CarColor = 9,
            NumOfDoors = 10,
            EngineVolume = 11,
            LicenseType = 12,
            CargoVolume = 13,
            IsDangerous = 14,
            FuelType = 15,
            CurrentAirPressure = 16,
            CurrentEnergyAmount = 17
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

