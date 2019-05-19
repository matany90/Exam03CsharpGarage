using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Owner
    {
        private string m_OwnerName;
        private string m_OwnerPhone;
        private eVehicleStatus m_VehicleStatus;

        public Owner(string i_OwnerName, string i_OwnerPhone, eVehicleStatus i_VehicleStatus)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhone = i_OwnerPhone;
            m_VehicleStatus = i_VehicleStatus;
        }
    }
}
