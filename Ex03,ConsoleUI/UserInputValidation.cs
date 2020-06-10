using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_ConsoleUI
{

    using Ex03.GarageLogic;

    public class UserInputValidation
    {
        public bool IsValidVehicleType(out Vehicle.eTypeOfVehicle o_VehicleType)
        {
            
            string vehicleType = Display.Read();
            bool returnValue = vehicleType.Length > 0;
          
            
            if(!Enum.TryParse(vehicleType, out o_VehicleType))
            {
                Display.Write(i_Msg: Messages.GetErrorMessage(Messages.eErrorMessagesToUser.InvalidVehicleType));
                returnValue = false;
            }
            
            return returnValue;
        }

        public bool IsValidName(out string o_Name)
        {
            o_Name = Display.Read();

            bool returnValue = o_Name.Length > 0;
            foreach(char letter in o_Name)
            {
                if(!char.IsLetter(letter))
                {
                    returnValue = false;
                    Display.Write(Messages.GetErrorMessage(Messages.eErrorMessagesToUser.InvalidName));
                    break;
                }
            }

            return returnValue;
        }

        public bool IsValidStringNumber(out string o_StringNum)
        {
            o_StringNum = Display.Read();
            bool returnValue = o_StringNum.Length > 0;
            foreach(char letter in o_StringNum)
            {
                if(!char.IsDigit(letter))
                {
                    Display.Write(Messages.GetErrorMessage(Messages.eErrorMessagesToUser.InvalidStringNum));
                    returnValue = false;
                    break;
                }
            }

            return returnValue;
        }

        public bool IsValidEnergySource(out EnergySource.eEnergyTypes o_EnergySource)
        {
            string energySource = Display.Read();
            bool returnValue = energySource.Length > 0;

            if (!Enum.TryParse(energySource, out o_EnergySource))
            {
                Display.Write(i_Msg: Messages.GetErrorMessage(Messages.eErrorMessagesToUser.InvalidEnergy));
                returnValue = false;
            }

            return returnValue;
        }

        public bool IsValidCarColor(out Car.eCarColor o_CarColor)
        {
            string color = Display.Read();
            bool returnValue = color.Length > 0;
            
            if (!Enum.TryParse(color, out o_CarColor))
            {
                Display.Write(i_Msg: Messages.GetErrorMessage(Messages.eErrorMessagesToUser.InvalidColor));
                returnValue = false;
            }

            return returnValue;
        }

        public bool IsValidNumOfDoors(out Car.eNumOfDoors o_CarDoors)
        {
            string doors = Display.Read();
            bool returnValue = doors.Length > 0;

            if(!Enum.TryParse(doors, out o_CarDoors))
            {
                Display.Write(i_Msg: Messages.GetErrorMessage(Messages.eErrorMessagesToUser.InvalidNumDoors));
                returnValue = false;
            }

            return returnValue;
        }

        public bool IsValidFuelType(out FuelEngine.eFuelType o_FuelType)
        {
            string fuelType = Display.Read();
            bool returnValue = fuelType.Length > 0;
            
            if (!Enum.TryParse(fuelType, out o_FuelType))
            {
                Display.Write(i_Msg: Messages.GetErrorMessage(Messages.eErrorMessagesToUser.InvalidFuelType));
                returnValue = false;
            }

            return returnValue;
        }

        public bool IsValidLicenseType(out Motorcycle.eLicenseType o_LicenseType)
        {
            string licenseType = Display.Read();
            bool returnValue = licenseType.Length > 0;

            if (!Enum.TryParse(licenseType, out o_LicenseType))
            {
                Display.Write(i_Msg: Messages.GetErrorMessage(Messages.eErrorMessagesToUser.InvalidLicenseType));
                returnValue = false;
            }

            return returnValue;

        }

        public bool IsValidInteger(out int o_ValidInteger)
        {
            string userInput = Display.Read();
            bool returnValue = userInput.Length > 0;
            if (!int.TryParse(userInput, out o_ValidInteger))
            {
               Display.Write(Messages.GetErrorMessage(Messages.eErrorMessagesToUser.InvalidInput));
               returnValue = false;
            }

            return returnValue;
        }



        public bool IsValidFloat(out float o_ValidFloat)
        {
            string userInput = Display.Read();
            bool returnValue = userInput.Length > 0;
            if(!float.TryParse(userInput, out o_ValidFloat))
            {
                Display.Write(Messages.GetErrorMessage(Messages.eErrorMessagesToUser.InvalidInput));
                returnValue = false;
            }

            return returnValue;
        }

        public bool IsValidBoolAnswer(out bool o_ValidChar)
        {
            string userInput = Display.Read();
            bool returnValue = userInput.Length > 0;
            o_ValidChar = false; 
            
            if(!userInput.Equals("Y") && !userInput.Equals("N"))
            {
                Display.Write(Messages.GetErrorMessage(Messages.eErrorMessagesToUser.InvalidInput));
                returnValue = false;
            }

            if(returnValue && userInput.Equals("Y"))
            {
                o_ValidChar = true;
            }

            return returnValue;
        }
    }
}


