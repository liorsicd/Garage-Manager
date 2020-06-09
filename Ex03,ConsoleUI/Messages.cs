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
            "Not valid input, please try again",
            "Not valid name, please try again",
            "Not valid energy, please try again",
            "Garage is empty, No vehicles to display",
            };


        //"Press the number of the desired filter and then press enter",
        //"Refueled your vehicle successfully.",
        //"Recharged your vehicle successfully.", 
        //"Inflated your wheels to maximum.",
        //"Please enter amount to add",
        //"Thank you for using the garage management program, Bye Bye!"


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

            FuelType = 15
        }


        InvalidInput = 3,
            InvalidName = 4,
            EnterAmountToAdd = 5,
            GarageIsEmpty = 6,
            ShowLicenseByFilter = 7,
            RefuelSuccess = 8,
            RechargeSuccess = 9,
            ReInflateToMaxSuccess = 10,
            InvalidEnergy = 11,
            GoodBye = 12
        }



        public enum eErrorMessagesToUser
        {
            WelcomeUser = 0,
            Menu = 1,
            EnterLicenseNumber = 2,
            InvalidInput = 3,
            InvalidName = 4,
            EnterAmountToAdd = 5,
            GarageIsEmpty = 6,
            ShowLicenseByFilter = 7,
            RefuelSuccess = 8,
            RechargeSuccess = 9,
            ReInflateToMaxSuccess = 10,
            InvalidEnergy = 11,
            GoodBye = 12
        }
        public static string GetMessage(eMessagesToUser i_Messages)
    {
        return m_MessagesToUser[(int)i_Messages];
    }
    }
}

