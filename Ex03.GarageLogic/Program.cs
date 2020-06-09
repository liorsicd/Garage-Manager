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
            v1.SetEnergySource(EnergySource.eEnergyTypes.Fuel);
            List <MethodInfo> l1 = v1.GetVehicleSetters();
            List <MethodInfo> l2 = v1.GetEnergySourceSetters();

            foreach(var p in l1)
            {
                Console.WriteLine(p.Name + " " + p.GetParameters().Length);
            }

            foreach(var p in l2)
            {
                Console.WriteLine(p.Name + " " + p.GetParameters().Length);
            }

            Console.ReadLine();
        }
    }
}
