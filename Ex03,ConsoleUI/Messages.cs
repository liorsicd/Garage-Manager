using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_ConsoleUI
{
    public class Messages
    {
        private static string[] m_MessagesToUser = 
            {
            @"Welcome to the garage. How we can serve you today?",
            "Press the number of the desired option and then press enter:",
            "Please enter license number", 
            "Not valid input, please try again",
            "Not valid name, please try again",
            "Garage is empty, No vehicles to display",
            "Press the number of the desired filter and then press enter",
            "Refueled your vehicle successfully.",
            "Recharged your vehicle successfully.", 
            "Inflated your wheels to maximum.",
            "Please enter amount to add",
            "Not valid energy, please try again",
            "Thank you for using the garage management program, Bye Bye!"
            };



    public enum eMessagesToUser
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

