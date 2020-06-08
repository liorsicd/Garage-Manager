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

        private Display m_Display;

        private Messages m_Messeges;


        public GarageManager()
        {
            this.m_Garage = new Garage();
            this.m_VehicleAdder = new VehicleAdder();
            this.m_Display = new Display();
            this.m_Messeges = new Messages();
        }

        public void AddVehicle()
        {

        }

    }
}
