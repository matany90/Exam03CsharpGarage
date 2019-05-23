namespace Ex03.GarageLogic
{
    internal class VehicleInGarage
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

        public override string ToString()
        {
            string toShow = string.Format(
@"Owner Details:
{0}
Vehicle Status: 
{1}

Vehicle Info:
{2}
", 
m_Owner.ToString(), 
m_VehicleState, 
m_Vehicle.ToString());

            return toShow;
        }
    }
}
