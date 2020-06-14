using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        private readonly Vehicle m_Vehicle;
        private readonly string r_OwnerName;
        private readonly string r_PhoneNumber;
        private eStatus m_status;
       
        public enum eStatus
        {
            OutOfGarage = 0,
            InRepair = 1,
            Repaired = 2,
            Payed = 3
        }

        public VehicleInGarage(string i_OwnerName, string i_PhoneNumber,  Vehicle i_Vehicle)
        {
            this.r_OwnerName = i_OwnerName;
            this.r_PhoneNumber = i_PhoneNumber;
            this.m_Vehicle = i_Vehicle;
            this.m_status = eStatus.OutOfGarage;
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
        }
    }
}
