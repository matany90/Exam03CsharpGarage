using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            m_CurrentAirPressure = i_CurrentAirPressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public void AddAirPressure(float i_AirPressureToAdd)
        {
            if (m_CurrentAirPressure + i_AirPressureToAdd > m_MaxAirPressure)
            {
                throw new ValueOutOfRangeException("Error");//TODO:: add exepction
            }
            else
            {
                m_CurrentAirPressure += i_AirPressureToAdd; 
            }          
        }

        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
        }

        public string ManufactorName
        {
            get { return m_ManufacturerName; }
        }
    }
}
