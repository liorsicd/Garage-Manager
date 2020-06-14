namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        private readonly Vehicle r_Vehicle;
        private readonly string r_OwnerName;
        private readonly string r_PhoneNumber;
        private eStatus m_Status;
       
        public enum eStatus
        {
            InRepair,
            Repaired,
            Payed
        }

        public VehicleInGarage(string i_OwnerName, string i_PhoneNumber,  Vehicle i_Vehicle)
        {
            this.r_OwnerName = i_OwnerName;
            this.r_PhoneNumber = i_PhoneNumber;
            this.r_Vehicle = i_Vehicle;
            this.m_Status = eStatus.InRepair;
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
                return this.m_Status;
            }
            set
            {
                this.m_Status = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return this.r_Vehicle;
            }
        }
    }
}
