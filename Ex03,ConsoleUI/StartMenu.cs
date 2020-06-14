using System;

namespace Ex03_ConsoleUI
{
    public class StartMenu
    {
        private readonly GarageManager r_GarageManager;
        private readonly UserInputValidation r_UserInputValidation;

        public StartMenu(GarageManager i_GarageManager)
        {
            this.r_GarageManager = i_GarageManager;
            this.r_UserInputValidation = new UserInputValidation();
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
            while(!this.r_UserInputValidation.IsValidOption(typeof(eMenu), out choice));
            Display.Clear();
            switch((eMenu)choice)
            {
                case eMenu.AddVehicle:
                    this.r_GarageManager.AddVehicle();
                    break;
                case eMenu.ChangeStatus:
                    this.r_GarageManager.ChangeStatus();
                    break;
                case eMenu.InflateTires:
                    this.r_GarageManager.InflateTires();
                    break;
                case eMenu.ChargeElectricVehicle:
                    this.r_GarageManager.ChargeElectricVehicle();
                    break;
                case eMenu.RefuelVehicle:
                    this.r_GarageManager.RefuelVehicle();
                    break;
                case eMenu.PrintVehicleDetails:
                    this.r_GarageManager.PrintVehicleDetails();
                    break;
                case eMenu.DisplayLicenseNumbersList:
                    this.r_GarageManager.DisplayLicenseNumbersList();
                    break;
                case eMenu.Quit:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
