using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_ConsoleUI
{
    using System.Reflection;

    using Ex03.GarageLogic;

    public class VehicleAdder
    {
        private VehicleFactory m_Factory;

        private UserInputValidation m_Validation;

        private bool m_IsReady;

        public VehicleAdder()
        {
            this.m_Factory = new VehicleFactory();
            this.m_Validation = new UserInputValidation();
            this.m_IsReady = false;
        }

        public void Start()
        {
            setVehicleParams();
            setEnergySourceParams();
            setVehicleInGarageParams();
            m_IsReady = true;
        }
        
        public VehicleInGarage GetNewVehicle()
        {
            return this.m_IsReady ? this.m_Factory.GetVehicleInGarage() : null;
        }

        private void setVehicleInGarageParams()
        {
            string ownerName;
            do
            {
                Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.OwnerName)); 
            }
            while(!this.m_Validation.IsValidName(out ownerName));

            string phoneNumber;
            do
            {
                Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.PhoneNumber)); 
            }
            while(!this.m_Validation.IsValidName(out phoneNumber));



            this.m_Factory.InitVehicleInGarage(ownerName, phoneNumber);
        }

        private void setVehicleParams()
        {
            Vehicle.eTypeOfVehicle vehicleType;
            do
            {
                Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.VehicleType)); 
                Display.WriteEnum(typeof(Vehicle.eTypeOfVehicle));
            }
            while(!this.m_Validation.IsValidVehicleType(out vehicleType));

            try
            {
                this.m_Factory.CreateVehicle(vehicleType);
            }
            catch(ArgumentException e)
            {
                Display.Write(e.Message);
                this.setVehicleParams();
            }
            

            runtObjectsSetters(this.m_Factory.GetVehicleSetters(), typeof(Vehicle));

        }

        private void setEnergySourceParams()
        {
            EnergySource.eEnergyTypes energyType;
            do
            {
                Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.EnergySource)); 
                Display.WriteEnum(typeof(EnergySource.eEnergyTypes));
            }
            while(!this.m_Validation.IsValidEnergySource(out energyType));

            try
            {
                this.m_Factory.SetEnergySource(energyType);
            }
            catch(ArgumentException e)
            {
                Display.Write(e.Message);
                this.setEnergySourceParams();
            }
            
            runtObjectsSetters(this.m_Factory.GetEnergySourceSetters(), typeof(EnergySource));
        }


        private void runtObjectsSetters(List<MethodInfo> i_Setters, Type i_Type)
        {
            foreach(MethodInfo s in i_Setters)
            {
                ParameterInfo[] paramArr = s.GetParameters();
                for(int i = 0; i < paramArr.Length; i++)
                {
                    paramArr[i] = this.getParameterFromUser(paramArr[i]);
                }

                this.m_Factory.RunSetter(s, paramArr, i_Type);
            }
        }

        private ParameterInfo getParameterFromUser(ParameterInfo i_Parameter)
        {
            object returnValue;
            switch(i_Parameter.Name)
            {
                case "i_LicenseNumber":
                    string licenseNumber;
                    do
                    {
                        Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.EnterLicenseNumber)); //get LicenseNumber
                    }
                    while(!this.m_Validation.IsValidStringNumber(out licenseNumber));
                    returnValue = licenseNumber;
                    break;

                case "i_Model":
                    string model;
                    do
                    {
                        Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.VehicleModel)); //get model
                    }
                    while(!this.m_Validation.IsValidName(out model));

                    returnValue = model;
                    break;

                case "i_ManufacturerName":
                    string manufacturerName;
                    do
                    {
                        Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.WheelManufacturerName)); //ManufacturerName
                    }
                    while(!this.m_Validation.IsValidName(out manufacturerName));

                    returnValue = manufacturerName;
                    break;

                case "i_CarColor":
                    Car.eCarColor color;
                    do
                    {
                        Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.CarColor)); 
                        Display.WriteEnum(typeof(Car.eCarColor));
                    }
                    while(!this.m_Validation.IsValidCarColor(out color));
                    returnValue = color;
                    break;
                case "i_NumOfDoors":
                    Car.eNumOfDoors numOfDoors;
                    do
                    {
                        Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.NumOfDoors)); 
                        Display.WriteEnum(typeof(Car.eNumOfDoors));
                    }
                    while(!this.m_Validation.IsValidNumOfDoors(out numOfDoors));
                    returnValue = numOfDoors;
                    break;

                case "i_EngineVolume":
                    int engineVol;
                    do
                    {
                        Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.EngineVolume)); 
                    }
                    while(!this.m_Validation.IsValidInteger(out engineVol));
                    returnValue = engineVol;
                    break;

                case "i_LicenseType":
                    Motorcycle.eLicenseType licenseType;
                    do
                    {
                        Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.LicenseType)); 
                        Display.WriteEnum(typeof(Motorcycle.eLicenseType));
                    }
                    while(!this.m_Validation.IsValidLicenseType(out licenseType));

                    returnValue = licenseType;
                    break;

                case "i_CargoVolume":
                    float cargoVol;
                    do
                    {
                        Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.CargoVolume)); //get cargo volume
                    }
                    while(!this.m_Validation.IsValidFloat(out cargoVol));

                    returnValue = cargoVol;
                    break;

                case "i_IsDangerous":
                    bool isDan;
                    do
                    {
                        Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.IsDangerous)); //get is dangerous
                    }
                    while(!this.m_Validation.IsValidBoolAnswer(out isDan));

                    returnValue = isDan;
                    break;

                case "i_CurrentAmountOfEnergy":
                    float currentAmount;
                        do
                        {
                            Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.CurrentEnergyAmount)); //get current amount
                        }
                        while(!this.m_Validation.IsValidFloat(out currentAmount));

                        returnValue = currentAmount;
                        break;

                case "i_FuelType":
                    FuelEngine.eFuelType fuelType;
                    do
                    {
                        Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.FuelType)); 
                        Display.WriteEnum(typeof(FuelEngine.eFuelType));
                    }
                    while(!this.m_Validation.IsValidFuelType(out fuelType));

                    returnValue = fuelType;
                    break;

                case "i_CurrentAirPressure":
                    float currentAir;
                    do
                    {
                        Display.Write(Messages.GetMessageAddVehicle(Messages.eAddVehicle.CurrentAirPressure)); 
                    }
                    while(!this.m_Validation.IsValidFloat(out currentAir));
                    returnValue = currentAir;
                    break;

                default:
                    returnValue = null;
                    break;
            }
            
            return returnValue as ParameterInfo;
        }
    }

}
