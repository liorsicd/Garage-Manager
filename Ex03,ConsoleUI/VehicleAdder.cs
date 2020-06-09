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
                Display.Write(this.m_Messages); //get energy source
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

                this.m_Factory.RunSetter(s,paramArr);
            }
        }



        private ParameterInfo getParameterFromUser(ParameterInfo i_Parameter)
        {
            object returnValue = null;
            switch(i_Parameter.Name)
            {
                case "i_LicenseNumber":
                    do
                    {
                        Display.Write(this.m_Messages); //get LicenseNumber
                    }
                    while(!this.m_Validtaion.IsValidStringNumber(out returnValue));
                    break;

                case "i_Model":
                    do
                    {
                        Display.Write(this.m_Messages); //get model
                    }
                    while(!this.m_Validtaion.IsValidName(out returnValue));
                    break;

                case "i_ManufacturerName":
                    do
                    {
                        Display.Write(this.m_Messages); //ManufacturerName
                    }
                    while(!this.m_Validtaion.IsValidName(out returnValue));
                    break;

                case "i_CarColor":
                    //returnValue = new Car.eCarColor();
                    do
                    {
                        Display.Write(this.m_Messages); //get car color
                    }
                    while(!this.m_Validtaion.IsValidCarColor(out returnValue));
                    break;
                case "i_NumOfDoors":
                    //returnValue = new Car.eNumOfDoors();
                    do
                    {
                        Display.Write(this.m_Messages); //get car color
                    }
                    while(!this.m_Validtaion.IsValidNumOfDoors(out returnValue));
                    break;

                case "i_EngineVolume":
                    do
                    {
                        Display.Write(this.m_Messages); //get engine vol
                    }
                    while(!this.m_Validtaion.IsValidInteger(out returnValue));
                    break;

                case "i_LicenseType":
                    do
                    {
                        Display.Write(this.m_Messages); //get license type
                    }
                    while(!this.m_Validtaion.IsValidStringNumber(out returnValue));
                    break;

                case "i_CargoVolume":
                    do
                    {
                        Display.Write(this.m_Messages); //get cargo volume
                    }
                    while(!this.m_Validtaion.IsValidFloat(out returnValue));
                    break;

                case "i_IsDangerous":
                    do
                    {
                        Display.Write(this.m_Messages); //get is dangerous
                    }
                    while(!this.m_Validtaion.IsValidBoolAnswer(out returnValue));
                    break;
            }

            return (ParameterInfo) returnValue;
        }
    }

}
