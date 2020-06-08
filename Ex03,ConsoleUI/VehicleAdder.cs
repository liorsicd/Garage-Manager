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

            List<MethodInfo> setters = this.m_Factory.getSetters();

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


            m_Factory.SetVehicleParams(licenseNumber,model);

            EnergySource.eEnergyTypes energyType;
            do
            {
                m_Display.Write(this.m_Messages); //get energy source
            }
            while(!this.m_Validtaion.IsValidEnergySource(out energyType));

            this.m_Factory.SetEnergySource(energyType);


            foreach(MethodInfo s in setters)
            {
                ParameterInfo[] paramArr = s.GetParameters();
                foreach(ParameterInfo p in paramArr)
                {
                    this.getParameterFromUser(p);
                }
            }
        }

        private Object getParameterFromUser(ParameterInfo i_Parameter)
        {
            object returnValue;
            switch(i_Parameter.Name)
            {
                case "m_CarColor":
                    Car.eCarColor carColor;
                    do
                    {
                        
                    }
                    while(!this.m_Validtaion.IsValidEnergySource(out returnValue));
                    break;
            }
        }



    }

}
