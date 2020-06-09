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
            o_VehicleType = (Vehicle.eTypeOfVehicle)Enum.Parse(typeof(Vehicle.eTypeOfVehicle), vehicleType);
            
            if(!Enum.IsDefined(typeof(Vehicle.eTypeOfVehicle), vehicleType))
            {
                Display.Write(i_Msg: Messages.GetMessage(Messages.eMessagesToUser.InvalidInput));
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
                    Messages.GetMessage(Messages.eMessagesToUser.InvalidName);
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
                    Messages.GetMessage(Messages.eMessagesToUser.InvalidInput);
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
            o_EnergySource = (EnergySource.eEnergyTypes)Enum.Parse(typeof(EnergySource.eEnergyTypes), energySource);
            
            if (!Enum.IsDefined(typeof(EnergySource.eEnergyTypes), energySource))
            {
                Display.Write(i_Msg: Messages.GetMessage(Messages.eMessagesToUser.InvalidEnergy));
                returnValue = false;
            }

            return returnValue;
        }

        public bool IsValidCarColor(out Car.eCarColor o_CarColor)
        {
            string color = Display.Read();
            bool returnValue = color.Length > 0;
            o_CarColor = (Car.eCarColor)Enum.Parse(typeof(Car.eCarColor), color);
            
            if (!Enum.IsDefined(typeof(Car.eCarColor), color))
            {
                Display.Write(i_Msg: Messages.GetMessage(Messages.eMessagesToUser.InvalidInput));
                returnValue = false;
            }

            return returnValue;
        }

        public bool IsValidNumOfDoors(out Car.eNumOfDoors o_CarDoors)
        {
            string doors = Display.Read();
            bool returnValue = doors.Length > 0;
            o_CarDoors = (Car.eNumOfDoors)Enum.Parse(typeof(Car.eNumOfDoors), doors);
            
            if (!Enum.IsDefined(typeof(Car.eNumOfDoors), doors))
            {
                Display.Write(i_Msg: Messages.GetMessage(Messages.eMessagesToUser.InvalidInput));
                returnValue = false;
            }

            return returnValue;
        }

        public bool IsValidFuelType(out FuelEngine.eFuelType o_FuelType)
        {
            string fuelType = Display.Read();
            bool returnValue = fuelType.Length > 0;
            o_FuelType = (FuelEngine.eFuelType)Enum.Parse(typeof(FuelEngine.eFuelType), fuelType);
            
            if (!Enum.IsDefined(typeof(FuelEngine.eFuelType), fuelType))
            {
                Display.Write(i_Msg: Messages.GetMessage(Messages.eMessagesToUser.InvalidInput));
                returnValue = false;
            }

            return returnValue;
        }

        public bool IsValidLicenseType(out Motorcycle.eLicenseType o_LicenseType)
        {
            string licenseType = Display.Read();
            bool returnValue = licenseType.Length > 0;
            o_LicenseType = (Motorcycle.eLicenseType)Enum.Parse(typeof(Motorcycle.eLicenseType), licenseType);
            
            if (!Enum.IsDefined(typeof(Motorcycle.eLicenseType), licenseType))
            {
                Display.Write(i_Msg: Messages.GetMessage(Messages.eMessagesToUser.InvalidInput));
                returnValue = false;
            }

            return returnValue;

        }

        public bool IsValidInteger(out int o_ValidInteger)
        {
            string userInput = Display.Read();
            bool returnValue = userInput > 0;
            if (!int.TryParse(userInput, out o_ValidInteger))
            {
                Messages.GetMessage(Messages.eMessagesToUser.InvalidInput);
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
                Messages.GetMessage(Messages.eMessagesToUser.InvalidInput);
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
                Messages.GetMessage(Messages.eMessagesToUser.InvalidInput);
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


