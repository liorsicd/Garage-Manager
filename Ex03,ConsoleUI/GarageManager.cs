using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_ConsoleUI
{
    using Ex03.GarageLogic;

    public class GarageManager
    {
        private Garage m_Garage;

        private VehicleAdder m_VehicleAdder;





        public GarageManager()
        {
            this.m_Garage = new Garage();
            this.m_VehicleAdder = new VehicleAdder();
        }

        public void AddVehicle()
        {
            this.m_VehicleAdder.Start();
            
            this.m_Garage.InsertVehicle(this.m_VehicleAdder.GetNewVehicle());
        }

    }
}
