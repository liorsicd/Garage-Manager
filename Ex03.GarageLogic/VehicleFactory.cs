using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public class VehicleFactory
    {
        private Vehicle m_Vehicle;

        private List<MethodInfo> m_VehicleSetters;
        private List<MethodInfo> m_EnergySourceSetters;

        public Type GetVehicleType()
        {
            return this.m_Vehicle.GetType();
        }

        public void CreateVehicle(Vehicle.eTypeOfVehicle i_VehicleType)
        {
            switch(i_VehicleType)
            {
                case Vehicle.eTypeOfVehicle.Truck:
                    this.m_Vehicle = new Truck(i_VehicleType);
                    break;
                case Vehicle.eTypeOfVehicle.Car:
                    this.m_Vehicle = new Car(i_VehicleType);
                    break;
                case Vehicle.eTypeOfVehicle.Motorcycle:
                    this.m_Vehicle = new Motorcycle(i_VehicleType);
                    break;
            }

            MethodInfo[] setters = this.m_Vehicle.GetType().GetMethods();
            
            foreach(MethodInfo setter in setters)
            {
                if(setter.Name.Contains("Set"))
                {
                    this.m_VehicleSetters.Add(setter);
                }
            }
        }

        public void SetVehicleParams(string i_LicenseNumber, string i_Model)
        {
            this.m_Vehicle.LicenseNumber = i_LicenseNumber;
            this.m_Vehicle.Model = i_Model;
        }


        public void SetEnergySource(EnergySource.eEnergyTypes i_EnergySource)
        {
            // maybe send type of vic to construtor
            switch(i_EnergySource)
            {
                case EnergySource.eEnergyTypes.Electric:
                    this.m_Vehicle.EnergySource = new ElectricEngine(EnergySource.eEnergyTypes.Electric);
                    break;
                case EnergySource.eEnergyTypes.Fuel:
                    this.m_Vehicle.EnergySource = new FuelEngine(EnergySource.eEnergyTypes.Fuel);
                    break;
            }
            
            this.m_Vehicle.EnergySource.SetMaxAmountOfEnergy(this.m_Vehicle);
        }


        // all inputs from user
        public List<MethodInfo> getSetters()
        {

            return this.m_Setters;
        }

        public void SetParams(MethodInfo i_Method, ParameterInfo[] i_Params)
        {
            i_Method.Invoke(this.m_Vehicle, i_Params);
        }


        public Vehicle GetVehicle()
        { 
            return this.m_Vehicle;
        }
        
        //
        // public ParameterInfo[] GetParams(object i_Obj, MethodInfo i_Method)
        // {
        //     Type typeOfObj = i_Obj.GetType();
        //     ParameterInfo[] parameters = i_Method.GetParameters();
        //     return parameters;
        // }
    }


}
