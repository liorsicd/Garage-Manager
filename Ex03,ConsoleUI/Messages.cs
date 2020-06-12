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
            "Please enter yes if carrying dangerous materials, else no", 
            "Please enter owner current amount of energy",
            "Please enter fuel type",
            "Please enter current air pressure",
            "Please enter amount Of liters to fuel",
            "Please enter the amount of time to charge",
            "Please change the status of a vehicle"
            };

        private static string[] m_ErrorMessagesToUser =
            {
            "Invalid input, please try again",
            "Invalid String number, should contain only numbers",
            "Not valid name, please try again",
            // "Garage is empty, No vehicles to display",
            // "Invalid type of energy, please tey again",
            // "Invalid fuel type, please try again",
            // "Invalid num of doors, please try again",
            // "Invalid color, please try again",
            // "Invalid license type, please try again",
            // "Not valid energy, please try again",
            // "Not valid status, please try again",
            };


        private static string[] m_GeneralMessages =
            {
                "Please enter status of vehicle to show",
                "Welcome to Garage main menu\n Please Choose one of the options"
                
            };

        private static string[] m_MenuMessages =
            {
                "Add Vehicle",
                "Change Vehicle Status",
                "Inflate Tires",
                "Charge Electric Vehicle",
                "Refuel Vehicle",
                "Show Vehicle Details",
                "Display License Numbers List",
                "Quit"
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
            CurrentEnergyAmount,
            FuelType,
            CurrentAirPressure,
            FuelToAdd,
            TimeToCharge,
            ChangeStatus
        }


        public enum eErrorMessagesToUser
        {
            InvalidInput = 0,
            InvalidStringNum = 1,
            InvalidName = 2,
        }


        public enum eGeneralMessages
        {
            ChooseStatus,
            StartMenu
        }


        public static string[] GetMenuMessages()
        {
            return m_MenuMessages;
        }

        public static string GetErrorMessage(eErrorMessagesToUser i_Messages)
    {
        return m_ErrorMessagesToUser[(int)i_Messages];
    }

        public static string GetMessageAddVehicle(eAddVehicle i_Messages)
        {
            return m_MessagesAddVehicle[(int)i_Messages];
        }

        public static string GetGeneralMessage(eGeneralMessages i_Messages)
        {
            return m_GeneralMessages[(int)i_Messages];
        }
    }
}

