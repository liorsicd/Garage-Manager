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

        private VehicleInGarage m_VehicleInGarage;

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
                default:
                    throw new ArgumentException("not a valid vehicle type");
            }

            this.m_VehicleSetters = this.getSetters(this.m_Vehicle);
        }

        public void SetEnergySource(EnergySource.eEnergyTypes i_EnergySource)
        {
            switch(i_EnergySource)
            {
                case EnergySource.eEnergyTypes.Electric:
                    this.m_Vehicle.EnergySource = new ElectricEngine(EnergySource.eEnergyTypes.Electric);
                    break;
                case EnergySource.eEnergyTypes.Fuel:
                    this.m_Vehicle.EnergySource = new FuelEngine(EnergySource.eEnergyTypes.Fuel);
                    break;
                default:
                    throw new ArgumentException("not a valid energy source type");
            }
            
            this.m_Vehicle.EnergySource.InitMaxAmountOfEnergy(this.m_Vehicle);
            this.m_EnergySourceSetters = this.getSetters(this.m_Vehicle.EnergySource);
        }


        private List<MethodInfo> getSetters(object i_Obj)
        {
            MethodInfo[] allSetters = i_Obj.GetType().GetMethods();
            List<MethodInfo> objSetters  = new List<MethodInfo>();
            
            foreach(MethodInfo setter in allSetters)
            {
                if(setter.Name.Contains("Set"))
                {
                    objSetters.Add(setter);
                }
            }

            return objSetters;
        }

        public List<MethodInfo> GetVehicleSetters()
        {
            return this.m_VehicleSetters;
        }

        public List<MethodInfo> GetEnergySourceSetters()
        {
            return this.m_EnergySourceSetters;
        }

        public void RunVehicleSetter(MethodInfo i_Setter, ParameterInfo[] i_Params)
        {
            i_Setter.Invoke(this.m_Vehicle, i_Params);
        }

        public void RunSetter(MethodInfo i_Setter, ParameterInfo[] i_Params, Type i_Type)
        {
            if(i_Type == typeof(Vehicle))
            {
                i_Setter.Invoke(this.m_Vehicle, i_Params);
            }
            else if(i_Type == typeof(EnergySource))
            {
                i_Setter.Invoke(this.m_Vehicle.EnergySource, i_Params);
            }
        }

        public VehicleInGarage GetVehicleInGarage()
        {
            return this.m_VehicleInGarage;
        }
    }
}
