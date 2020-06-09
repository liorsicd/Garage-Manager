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

        private Display m_Display;

        private Messages m_Messages;

        private UserInputValidtaion m_Validtaion;
        public VehicleAdder()
        {
            this.m_Factory = new VehicleFactory();
            this.m_Display = new Display();
            this.m_Messages = new Messages();
            this.m_Validtaion = new UserInputValidtaion();
        }

        public void Start()
        {
            Vehicle.eTypeOfVehicle vehicleType;
            do
            {
                m_Display.Write(this.m_Messages); //vic type
            }
            while(!this.m_Validtaion.IsValidVehicleType(out vehicleType));
            m_Factory.CreateVehicle(vehicleType);

            

            string licenseNumber;
            do
            {
                m_Display.Write(this.m_Messages); //get model
            }
            while(!this.m_Validtaion.IsValidName(out licenseNumber));
            string model;
            do
            {
                m_Display.Write(this.m_Messages); //get model
            }
            while(!this.m_Validtaion.IsValidLicenseNumber(out model));


            m_Factory.SetVehicleParams(licenseNumber, model);
            

            


            EnergySource.eEnergyTypes energyType;
            do
            {
                m_Display.Write(this.m_Messages); //get energy source
            }
            while(!this.m_Validtaion.IsValidEnergySource(out energyType));

            this.m_Factory.SetEnergySource(energyType);

        }

        private void RuntObjectsSetters(Object i_Obj)
        {
            List<MethodInfo> setters = this.m_Factory.getSetters(i_Obj);
            foreach(MethodInfo s in setters)
            {
                ParameterInfo[] paramArr = s.GetParameters();
                for(int i=0;i<paramArr.Length; i++)
                {
                    paramArr[i] = this.getParameterFromUser(paramArr[i]);
                }

                s.Invoke(this.m_Factory.GetVehicle(), paramArr);
            }

        }

        private ParameterInfo getParameterFromUser(ParameterInfo i_Parameter)
        {
            object returnValue = null;
            switch(i_Parameter.Name)
            {
                case "i_CarColor":
                    //returnValue = new Car.eCarColor();
                    do
                    {
                        m_Display.Write(this.m_Messages); //get car color
                    }
                    while(!this.m_Validtaion.IsValidCarColor(out returnValue));
                    break;
                case "i_NumOfDoors":
                    //returnValue = new Car.eNumOfDoors();
                    do
                    {
                        m_Display.Write(this.m_Messages); //get car color
                    }
                    while(!this.m_Validtaion.IsValidNumOfDoors(out returnValue));
                    break;

                case "i_ManufacturerName":
                    do
                    {
                        m_Display.Write(this.m_Messages); //ManufacturerName
                    }
                    while(!this.m_Validtaion.IsValidName(out returnValue));
                    break;
                case "i_EngineVolume":
                    do
                    {
                        m_Display.Write(this.m_Messages); //get engine vol
                    }
                    while(!this.m_Validtaion.IsValidInteger(out returnValue));
                    break;

                case "i_LicenseType":
                    do
                    {
                        m_Display.Write(this.m_Messages); //get license type
                    }
                    while(!this.m_Validtaion.IsValidStringNumber(out returnValue));
                    break;

                case "i_CargoVolume":
                    do
                    {
                        m_Display.Write(this.m_Messages); //get cargo volume
                    }
                    while(!this.m_Validtaion.IsValidFloat(out returnValue));
                    break;

                case "i_IsDangerous":
                    do
                    {
                        m_Display.Write(this.m_Messages); //get is dangerous
                    }
                    while(!this.m_Validtaion.IsValidBoolAnswer(out returnValue));
                    break;
            }


            return (ParameterInfo) returnValue;
        }
    }

}
