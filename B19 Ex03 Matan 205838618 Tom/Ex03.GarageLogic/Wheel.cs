namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            if (i_CurrentAirPressure > i_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(null, i_MaxAirPressure, 0);
            }

            m_ManufacturerName = i_ManufacturerName;
            m_CurrentAirPressure = i_CurrentAirPressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public void AddAirPressure(float i_AirPressureToAdd)
        {
            if (m_CurrentAirPressure + i_AirPressureToAdd > m_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(null, m_MaxAirPressure, 0f);
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

        public override string ToString()
        {
            string wheelInfo = string.Format(
@"Wheel's Manufacturer Name: {0}
Wheel's Current Air Pressure: {1}
Wheel's Max Air Pressure: {2}", 
m_ManufacturerName, 
m_CurrentAirPressure, 
m_MaxAirPressure);

            return wheelInfo;
        }
    }
}
