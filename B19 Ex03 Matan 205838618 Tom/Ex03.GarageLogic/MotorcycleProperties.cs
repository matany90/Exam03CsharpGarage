﻿using System;

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

        public eLicenseTypes LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        public int EngineVolume
        {
            get { return m_EngineVolume; }
            set { m_EngineVolume = value; }
        }
    }
}