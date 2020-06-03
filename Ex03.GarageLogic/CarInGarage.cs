using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class CarInGarage
    {
        public enum eStatus
        {
            InRepair, 
            Repaired,
            Payed
        }

        private Vehicle m_Vehicle;
        private readonly string r_OwnerName;
        private readonly string r_PhoneNumber;
        private eStatus m_status;


    }
}
