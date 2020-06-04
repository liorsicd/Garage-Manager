using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleGenerator
    {
       public enum eTypeOfVehicle 
       {
            Car,
            Motorcycle,
            Truck,
       }



        public Vehicle CreateVehicle(eTypeOfVehicle i_VehicleType, EnergySource.eEnergyTypes i_EngineType)
        {
            Vehicle createdVehicle = null;

            switch(i_VehicleType)
                    {
                        case (eTypeOfVehicle.Truck):
                            createdVehicle = new Truck();
                            break;
                        case (eTypeOfVehicle.Car):
                            createdVehicle = new Car();
                            if (i_EngineType == EnergySource.eEnergyTypes.Fuel)
                                    {
                                        createdVehicle.EnergySource = i_EngineType;
                                    }
                            else
                            {
                                
                            }
                            break;
                    }


    }
}
