using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_ConsoleUI
{
    using System.Runtime.InteropServices.WindowsRuntime;

    using Ex03.GarageLogic;

    public class UserInputValidation
    {
        private int getChoiceFromUser()
        {
            string userInput = Display.Read();
            int choice;
            while(!(userInput.Length > 0) || !int.TryParse(userInput, out choice))
            {
                Display.Write(Messages.GetErrorMessage(Messages.eErrorMessagesToUser.InvalidInput));
                userInput = Display.Read();
            }

            return choice;
        }


        public bool IsValidOption(Type i_EnumType, out object o_Obj)
        {
            int choice = this.getChoiceFromUser();
            bool returnValue = true;
            if(!Enum.IsDefined(i_EnumType, choice))
            {
                Display.Write(Messages.GetErrorMessage(Messages.eErrorMessagesToUser.InvalidInput));
                returnValue = false;
            }

            o_Obj = choice;
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


        public bool IsValidInteger(out int o_ValidInteger)
        {
            string userInput = Display.Read();
            bool returnValue = userInput.Length > 0;
            if (!int.TryParse(userInput, out o_ValidInteger) || o_ValidInteger < 0)
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
            if(!float.TryParse(userInput, out o_ValidFloat) || o_ValidFloat < 0)
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


