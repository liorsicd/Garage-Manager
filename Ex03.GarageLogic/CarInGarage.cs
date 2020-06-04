using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class CarInGarage
    {
        private Vehicle m_Vehicle;
        private readonly string r_OwnerName;
        private readonly string r_PhoneNumber;
        private eStatus m_status;
       
        public enum eStatus
        {
            InRepair = 1,
            Repaired = 2,
            Payed = 3
        }

        public string PhoneNumber
        {
            get
            {
                return r_PhoneNumber;
            }
        }

        public string OwnerName
        {
            get
            {
                return r_OwnerName;
            }
        }

        public eStatus Status
        {
            get
            {
                return m_status;
            }
            set
            {
                m_status = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
            set
            {
                m_Vehicle = value;
            }
        }
    }
}
