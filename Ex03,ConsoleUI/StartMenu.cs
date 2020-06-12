using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_ConsoleUI
{
    public class StartMenu
    {
        private GarageManager m_GarageManager;
        private UserInputValidation m_UserInputValidation;

        public StartMenu(GarageManager i_GarageManager)
        {
            this.m_GarageManager = i_GarageManager;
            this.m_UserInputValidation = new UserInputValidation();
        }

        public enum eMenu
        {
            AddVehicle,
            ChangeStatus,
            InflateTires,
            ChargeElectricVehicle,
            RefuelVehicle,
            PrintVehicleDetails,
            DisplayLicenseNumbersList,
            Quit
        }


        public void Show()
        {
            object choice;
            do
            {
                Display.Write(Messages.GetGeneralMessage(Messages.eGeneralMessages.StartMenu));
                Display.WriteStringArray(Messages.GetMenuMessages());
            }
            while(!this.m_UserInputValidation.IsValidOption(typeof(eMenu), out choice));

            switch((eMenu)choice)
            {
                case eMenu.AddVehicle:
                    this.m_GarageManager.AddVehicle();
                    break;
                case eMenu.ChangeStatus:
                    this.m_GarageManager.ChangeStatus();
                    break;
                case eMenu.InflateTires:
                    this.m_GarageManager.InflateTires();
                    break;
                case eMenu.ChargeElectricVehicle:
                    this.m_GarageManager.ChargeElectricVehicle();
                    break;
                case eMenu.RefuelVehicle:
                    this.m_GarageManager.RefuelVehicle();
                    break;
                case eMenu.PrintVehicleDetails:
                    this.m_GarageManager.PrintVehicleDetails();
                    break;
                case eMenu.DisplayLicenseNumbersList:
                    this.m_GarageManager.DisplayLicenseNumbersList();
                    break;
                case eMenu.Quit:
                    Environment.Exit(0);
                    break;

            }
        }


    }


}
