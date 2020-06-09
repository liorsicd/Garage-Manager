﻿using System;
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

        private UserInputValidtaion m_Validtaion;

        private bool m_IsReady;

        public VehicleAdder()
        {
            this.m_Factory = new VehicleFactory();
            this.m_Validtaion = new UserInputValidtaion();
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
                Display.Write(this.m_Messages); //get name
            }
            while(!this.m_Validtaion.IsValidName(out ownerName));

            string phoneNumber;
            do
            {
                Display.Write(this.m_Messages); //get phone
            }
            while(!this.m_Validtaion.IsValidName(out phoneNumber));



            this.m_Factory.InitVehicleInGarage(ownerName, phoneNumber);
        }

        private void setVehicleParams()
        {
            Vehicle.eTypeOfVehicle vehicleType;
            do
            {
                Display.Write(this.m_Messages); //vic type
            }
            while(!this.m_Validtaion.IsValidVehicleType(out vehicleType));

            this.m_Factory.CreateVehicle(vehicleType);

            runtObjectsSetters(this.m_Factory.GetVehicleSetters());

        }

        private void setEnergySourceParams()
        {
            EnergySource.eEnergyTypes energyType;
            do
            {
                Display.Write(Messages.GetMessage()); //get energy source
            }
            while(!this.m_Validtaion.IsValidEnergySource(out energyType));

            this.m_Factory.SetEnergySource(energyType);

            runtObjectsSetters(this.m_Factory.GetEnergySourceSetters());
        }


        private void runtObjectsSetters(List<MethodInfo> i_Setters)
        {
            foreach(MethodInfo s in i_Setters)
            {
                ParameterInfo[] paramArr = s.GetParameters();
                for(int i = 0; i < paramArr.Length; i++)
                {
                    paramArr[i] = this.getParameterFromUser(paramArr[i]);
                }

                this.m_Factory.RunSetter(s, paramArr);
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
                        Display.Write(Messages); //get LicenseNumber
                    }
                    while(!this.m_Validtaion.IsValidStringNumber(out licenseNumber));
                    returnValue = licenseNumber;
                    break;

                case "i_Model":
                    string model;
                    do
                    {
                        Display.Write(Messages); //get model
                    }
                    while(!this.m_Validtaion.IsValidName(out model));

                    returnValue = model;
                    break;

                case "i_ManufacturerName":
                    string manufacturerName;
                    do
                    {
                        Display.Write(Messages); //ManufacturerName
                    }
                    while(!this.m_Validtaion.IsValidName(out manufacturerName));

                    returnValue = manufacturerName;
                    break;

                case "i_CarColor":
                    Car.eCarColor color;
                    do
                    {
                        Display.Write(Messages); //get car color
                    }
                    while(!this.m_Validtaion.IsValidCarColor(out color));
                    returnValue = color;
                    break;
                case "i_NumOfDoors":
                    Car.eNumOfDoors numOfDoors;
                    do
                    {
                        Display.Write(Messages); //get car color
                    }
                    while(!this.m_Validtaion.IsValidNumOfDoors(out numOfDoors));
                    returnValue = numOfDoors;
                    break;

                case "i_EngineVolume":
                    int engineVol;
                    do
                    {
                        Display.Write(Messages); //get engine vol
                    }
                    while(!this.m_Validtaion.IsValidInteger(out engineVol));
                    returnValue = engineVol;
                    break;

                case "i_LicenseType":
                    Motorcycle.eLicenseType licenseType;
                    do
                    {
                        Display.Write(Messages); //get license type
                    }
                    while(!this.m_Validtaion.IsValidLicenseType(out licenseType));

                    returnValue = licenseType;
                    break;

                case "i_CargoVolume":
                    float cargoVol;
                    do
                    {
                        Display.Write(Messages); //get cargo volume
                    }
                    while(!this.m_Validtaion.IsValidFloat(out cargoVol));

                    returnValue = cargoVol;
                    break;

                case "i_IsDangerous":
                    bool isDan;
                    do
                    {
                        Display.Write(Messages); //get is dangerous
                    }
                    while(!this.m_Validtaion.IsValidBoolAnswer(out isDan));

                    returnValue = isDan;
                    break;

                case "i_CurrentAmountOfEnergy":
                    float currentAmount;
                        do
                        {
                            Display.Write(Messages); //get current amount
                        }
                        while(!this.m_Validtaion.IsValidFloat(out currentAmount));

                        returnValue = currentAmount;
                        break;

                case "i_fuelType":
                    FuelEngine.eFuelType fuelType;
                    do
                    {
                        Display.Write(Messages); //get fuelType
                    }
                    while(!this.m_Validtaion.IsValidFuelType(out fuelType));

                    returnValue = fuelType;
                    break;

                default:
                    returnValue = null;
                    break;
            }

            return (ParameterInfo) returnValue;
        }
    }

}
