using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    using System.Reflection;

    public class Program
    {
        public static void Main()
        {
            VehicleFactory v1  = new VehicleFactory();
            v1.CreateVehicle(Vehicle.eTypeOfVehicle.Car);
        }
    }
}
