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



            List<MethodInfo> m1 = v1.getSetters();

            foreach(MethodInfo m in m1)
            {
                ParameterInfo[] p = m.GetParameters();
                ParameterInfo[] answer = new ParameterInfo[p.Length];

                foreach(ParameterInfo prameter in p)
                {

                }
            }
            Console.ReadLine();
        }
    }
}
