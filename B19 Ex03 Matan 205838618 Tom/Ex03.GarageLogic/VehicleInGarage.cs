namespace Ex03.GarageLogic
{
    class VehicleInGarage
    {
        private Vehicle m_Vehicle;
        private eVehicleConditions m_VehicleState;

        public VehicleInGarage(Vehicle i_Vehicle)
        {
            m_Vehicle = i_Vehicle;
            m_VehicleState = eVehicleConditions.InRepair;
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
