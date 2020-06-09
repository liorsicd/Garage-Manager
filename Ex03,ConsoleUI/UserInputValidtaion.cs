using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_ConsoleUI
{

    using Ex03.GarageLogic;

    public class UserInputValidtaion
    {
        public bool IsValidVehicleType(out Vehicle.eTypeOfVehicle o_VehicleType)
        {
            string vehicleType = Display.Read();
            o_VehicleType = (Vehicle.eTypeOfVehicle)Enum.Parse(typeof(Vehicle.eTypeOfVehicle), vehicleType);
            bool returnValue = true;
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
            bool returnValue = true;
            o_StringNum = Display.Read();
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
            string energeSource = Display.Read();
            o_EnergySource = (EnergySource.eEnergyTypes)Enum.Parse(typeof(EnergySource.eEnergyTypes), energeSource);
            bool returnValue = true;
            if (!Enum.IsDefined(typeof(EnergySource.eEnergyTypes), energeSource))
            {
                Display.Write(i_Msg: Messages.GetMessage(Messages.eMessagesToUser.InvalidEnergy));
                returnValue = false;
            }

            return returnValue;
        }

        public bool IsValidCarColor(out Car.eCarColor o_CarColor)
        {
            string color = Display.Read();
            o_CarColor = (Car.eCarColor)Enum.Parse(typeof(Car.eCarColor), color);
            bool returnValue = true;
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
            o_CarDoors = (Car.eNumOfDoors)Enum.Parse(typeof(Car.eNumOfDoors), doors);
            bool returnValue = true;
            if (!Enum.IsDefined(typeof(Car.eNumOfDoors), doors))
            {
                Display.Write(i_Msg: Messages.GetMessage(Messages.eMessagesToUser.InvalidInput));
                returnValue = false;
            }

            return returnValue;
        }


        public bool IsValidInteger(out int o_ValidInteger)

        {
            bool returnValue = true;
            string userInput = Display.Read();
            if (!int.TryParse(userInput, out o_ValidInteger))
            {
                Messages.GetMessage(Messages.eMessagesToUser.InvalidInput);
                returnValue = false;
            }

            return returnValue;
        }


        public bool IsValidFloat(out float o_ValidFloat)
        {
            bool returnValue = true;
            string userInput = Display.Read();
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
        o_ValidChar = false; 
        bool returnValue = true;

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


