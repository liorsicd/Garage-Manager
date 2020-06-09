using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_ConsoleUI
{
    internal class Messages
    {
        private String[] m_MessagesToUser = new String [11];

        m_MessagesToUser = {
            @"Welcome to the garage. How we can serve you today?"
                ,"Press the number of the desired option and then press enter:",
            "Please enter license number", "Please try again",
            "Garage is empty, No vehicles to display", "Press the number of the desired filter and then press enter",
            "Refueled your vehicle successfully.","Recharged your vehicle succesfully.", "Inflated your wheels to maximum.",
            "Please enter amount to add","Thank you for using the garage managment program, Bye Bye!"};



    public enum eMessagesToUser
        {
            WelcomeUser,
            Menu,
            EnterLicenseNumber,
            PleaseTryAgain,
            EnterAmountToAdd,
            GarageIsEmpty,
            ShowLicenseByFilter,
            RefuelSuccess,
            RechargeSuccess,
            ReInflateToMaxSuccess,
            GoodBye,
        }
    

    }
}

