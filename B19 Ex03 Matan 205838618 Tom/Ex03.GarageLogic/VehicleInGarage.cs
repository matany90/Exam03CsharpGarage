namespace Ex03.GarageLogic
{
    class VehicleInGarage
    {
        private Vehicle m_Vehicle;
        private Owner m_Owner;
        private eVehicleConditions m_VehicleState;

        public VehicleInGarage(Vehicle i_Vehicle, Owner i_Owner)
        {
            m_Vehicle = i_Vehicle;
            m_Owner = i_Owner;
            m_VehicleState = eVehicleConditions.InRepair;
        }

        public Owner Owner
        {
            get
            {
                return m_Owner;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
        }

        public eVehicleConditions VehicleState
        {
            get
            {
                return m_VehicleState;
            }
            set
            {
                m_VehicleState = value;
            }
        }
    }
}
