namespace Ex03_ConsoleUI
{
    public class Messages
    {
        private static readonly string[] sr_MessagesAddVehicle = 
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
            "Please enter Y if carrying dangerous materials, else N", 
            "Please enter current amount of energy",
            "Please enter fuel type",
            "Please enter current air pressure",
            "Please enter amount Of liters to fuel",
            "Please enter the amount of time to charge",
            "Please change the status of a vehicle"
            };

        private static readonly string[] sr_ErrorMessagesToUser =
            {
            "Invalid input, please try again",
            "Invalid String number, should contain only numbers",
            "Not valid name, please try again",
            "this vehicle is already exist in the garage",
            "this vehicle not exist in the garage",
            "No vehicles in this status"
            };

        private static readonly string[] sr_GeneralMessages =
            {
                "Please enter status of vehicle to show",
                "Welcome to Garage main menu\n Please Choose one of the options",
                "Operation Succeed"
            };

        private static readonly string[] sr_MenuMessages =
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
            InvalidInput,
            InvalidStringNum,
            InvalidName,
            VehicleExist,
            VehicleNotExist,
            VehicleStatus
        }

        public enum eGeneralMessages
        {
            ChooseStatus,
            StartMenu,
            Success
        }

        public static string[] GetMenuMessages()
        {
            return sr_MenuMessages;
        }

        public static string GetErrorMessage(eErrorMessagesToUser i_Messages)
        {
        return sr_ErrorMessagesToUser[(int)i_Messages];
        }

        public static string GetMessageAddVehicle(eAddVehicle i_Messages)
        {
            return sr_MessagesAddVehicle[(int)i_Messages];
        }

        public static string GetGeneralMessage(eGeneralMessages i_Messages)
        {
            return sr_GeneralMessages[(int)i_Messages];
        }
    }
}

