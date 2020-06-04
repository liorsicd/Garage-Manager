using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleGenerator
    {
        private Vehicle m_Vehicle;

        // all vehicle params as data members


        public void CreateVehicle(Vehicle.eTypeOfVehicle i_VehicleType, EnergySource.eEnergyTypes i_EngineType)
        {
            Vehicle createdVehicle = null;

            switch(i_VehicleType)
            {
                case Vehicle.eTypeOfVehicle.Truck:
                    createdVehicle = new Truck();
                    break;
                case Vehicle.eTypeOfVehicle.Car:
                    switch(i_EngineType)
                    {
                        case EnergySource.eEnergyTypes.Fuel:
                            createdVehicle = new Car(new FuelEngine());
                            break;
                        case EnergySource.eEnergyTypes.Electric:
                            createdVehicle = new Car( new ElectricEngine());
                            break;
                    }

                    break;

                case Vehicle.eTypeOfVehicle.Motorcycle:
                    
                    switch(i_EngineType)
                    {
                        case EnergySource.eEnergyTypes.Fuel:
                            createdVehicle = new Motorcycle(new FuelEngine());
                            break;
                        case EnergySource.eEnergyTypes.Electric:
                            createdVehicle = new Motorcycle(new ElectricEngine());
                            break;
                    }

                    break;
            }

            m_Vehicle = createdVehicle;
        }

        public void SetParameters(Vehicle.eTypeOfVehicle i_VehicleType)
        {
            switch(i_VehicleType)
            {
                case Vehicle.eTypeOfVehicle.Truck:
                    //call to truck params func
                    break;

            }
        }
    }
}
