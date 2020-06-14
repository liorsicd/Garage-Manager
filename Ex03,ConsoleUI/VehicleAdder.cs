using System;
using System.Collections.Generic;
using System.Reflection;
using Ex03.GarageLogic;

namespace Ex03_ConsoleUI
{
    public class VehicleAdder
    {
        private readonly VehicleFactory r_Factory;
        private readonly UserInputValidation r_Validation;
        private bool m_IsReady;

        public VehicleAdder()
        {
            this.r_Factory = new VehicleFactory();
            this.r_Validation = new UserInputValidation();
            this.m_IsReady = false;
        }

        public void Start(string i_LicenseNumber)
        {
            setVehicleParams();
            setEnergySourceParams();
            SetVehicleLicenseNumber(i_LicenseNumber);
            setVehicleInGarageParams();
            m_IsReady = true;
        }

        public VehicleInGarage GetNewVehicle()
        {
            return this.m_IsReady ? this.r_Factory.GetVehicleInGarage() : null;
        }

        public void SetVehicleLicenseNumber(string i_LicenseNumber)
        {
            this.r_Factory.SetLicenseNumber(i_LicenseNumber);
        }

        private void setVehicleInGarageParams()
        {
            Display.Clear();
            string ownerName;
            do
            {
                Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.OwnerName));
            }
            while(!this.r_Validation.IsValidName(out ownerName));

            string phoneNumber;
            Display.Clear();
            do
            {
                Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.PhoneNumber)); 
            }
            while(!this.r_Validation.IsValidStringNumber(out phoneNumber));

            this.r_Factory.InitVehicleInGarage(ownerName, phoneNumber);
        }

        private void setVehicleParams()
        {
            GetInput:
            Display.Clear();
            object vehicleType;
            do
            {
                Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.VehicleType)); 
                Display.WriteEnum(typeof(Vehicle.eTypeOfVehicle));
            }
            while(!this.r_Validation.IsValidOption(typeof(Vehicle.eTypeOfVehicle), out vehicleType));

            try
            {
                this.r_Factory.CreateVehicle((Vehicle.eTypeOfVehicle) vehicleType);
            }
            catch(ArgumentException e)
            {
                Display.Write(e.Message);
                Display.Wait();
                goto GetInput;
            }
            
            runtObjectsSetters(this.r_Factory.GetVehicleSetters(), typeof(Vehicle));
        }

        private void setEnergySourceParams()
        {
            GetInput:
            Display.Clear();
            
                object energyType;
                do
                {
                    Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.EnergySource));
                    Display.WriteEnum(typeof(EnergySource.eEnergyTypes));
                }
                while(!this.r_Validation.IsValidOption(typeof(EnergySource.eEnergyTypes), out energyType));

                try
                {
                    this.r_Factory.SetEnergySource((EnergySource.eEnergyTypes)energyType);
                }
                catch(ArgumentException e)
                {
                    Display.Write(e.Message);
                    Display.Wait();
                    goto GetInput;
                }

                runtObjectsSetters(this.r_Factory.GetEnergySourceSetters(), typeof(EnergySource));
                this.r_Factory.GetVehicle().UpdateRemainingEnergy();
        }

        private void runtObjectsSetters(List<MethodInfo> i_Setters, Type i_Type)
        {
            foreach(MethodInfo s in i_Setters)
            {
                ParameterInfo[] paramArr = s.GetParameters();
                object[] returnParams = new object[paramArr.Length];
                GetParameters:
                for(int i = 0; i < paramArr.Length; i++)
                {
                    Display.Clear();
                    returnParams[i] = this.getParameterFromUser(paramArr[i]);
                }

                try
                {
                    this.r_Factory.RunSetter(s, returnParams, i_Type);
                }
                catch(Exception e)
                {
                    Display.Write(e.InnerException?.Message);
                    Display.Wait();
                    goto GetParameters;
                }
            }
        }

        private object getParameterFromUser(ParameterInfo i_Parameter)
        {
            object returnValue;
            
            switch(i_Parameter.Name)
            {
                case "i_LicenseNumber":
                    string licenseNumber;
                    do
                    {
                        Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.EnterLicenseNumber)); 
                    }
                    while(!this.r_Validation.IsValidStringNumber(out licenseNumber));
                    returnValue = licenseNumber;
                    break;

                case "i_Model":
                    string model;
                    do
                    {
                        Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.VehicleModel)); 
                    }
                    while(!this.r_Validation.IsValidName(out model));

                    returnValue = model;
                    break;

                case "i_ManufacturerName":
                    string manufacturerName;
                    do
                    {
                        Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.WheelManufacturerName)); 
                    }
                    while(!this.r_Validation.IsValidName(out manufacturerName));

                    returnValue = manufacturerName;
                    break;

                case "i_CarColor":
                    object color;
                    do
                    {
                        Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.CarColor)); 
                        Display.WriteEnum(typeof(Car.eCarColor));
                    }
                    while(!this.r_Validation.IsValidOption(typeof(Car.eCarColor), out color));
                    returnValue = (Car.eCarColor) color;
                    break;
                case "i_NumOfDoors":
                    object numOfDoors;
                    do
                    {
                        Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.NumOfDoors)); 
                        Display.WriteEnum(typeof(Car.eNumOfDoors));
                    }
                    while(!this.r_Validation.IsValidOption(typeof(Car.eNumOfDoors), out numOfDoors));
                    returnValue = (Car.eNumOfDoors)numOfDoors;
                    break;

                case "i_EngineVolume":
                    int engineVol;
                    do
                    {
                        Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.EngineVolume)); 
                    }
                    while(!this.r_Validation.IsValidInteger(out engineVol));
                    returnValue = engineVol;
                    break;

                case "i_LicenseType":
                    object licenseType;
                    do
                    {
                        Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.LicenseType)); 
                        Display.WriteEnum(typeof(Motorcycle.eLicenseType));
                    }
                    while(!this.r_Validation.IsValidOption(typeof(Motorcycle.eLicenseType), out licenseType));

                    returnValue = (Motorcycle.eLicenseType)licenseType;
                    break;

                case "i_CargoVolume":
                    float cargoVol;
                    do
                    {
                        Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.CargoVolume));
                    }
                    while(!this.r_Validation.IsValidFloat(out cargoVol));

                    returnValue = cargoVol;
                    break;

                case "i_IsDangerous":
                    bool isDan;
                    do
                    {
                        Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.IsDangerous)); 
                    }
                    while(!this.r_Validation.IsValidBoolAnswer(out isDan));

                    returnValue = isDan;
                    break;

                case "i_CurrentAmountOfEnergy":
                    float currentAmount;
                    do
                    {
                        Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.CurrentEnergyAmount)); 
                    }
                    while(!this.r_Validation.IsValidFloat(out currentAmount));

                    returnValue = currentAmount;
                    break;

                case "i_FuelType":
                    object fuelType;
                    do
                    {
                        Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.FuelType)); 
                        Display.WriteEnum(typeof(FuelEngine.eFuelType));
                    }
                    while(!this.r_Validation.IsValidOption(typeof(FuelEngine.eFuelType), out fuelType));

                    returnValue = (FuelEngine.eFuelType)fuelType;
                    break;

                case "i_CurrentAirPressure":
                    float currentAir;
                    do
                    {
                        Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.CurrentAirPressure)); 
                    }
                    while(!this.r_Validation.IsValidFloat(out currentAir));
                    returnValue = currentAir;
                    break;

                default:
                    returnValue = null;
                    break;
            }

            return returnValue;
        }
    }
}
