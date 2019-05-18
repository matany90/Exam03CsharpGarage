using System;

namespace Ex03.GarageLogic
{
    class MotorcycleProperties
    {
        protected eLicenseTypes m_LicenseType;
        protected int m_EngineVolume;

        public MotorcycleProperties(eLicenseTypes i_LicenseType, int i_EngineVolume)
        {
            m_LicenseType = i_LicenseType;
            m_EngineVolume = i_EngineVolume;
        }
    }
}