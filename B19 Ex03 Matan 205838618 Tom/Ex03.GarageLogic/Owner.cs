namespace Ex03.GarageLogic
{
    internal class Owner
    {
        private string m_OwnerName;
        private string m_OwnerPhone;

        public Owner(string i_OwnerName, string i_OwnerPhone)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhone = i_OwnerPhone;
        }

        public string Name
        {
            get { return m_OwnerName; }
            set { m_OwnerName = value; }
        }

        public string Phone
        {
            get { return m_OwnerPhone; }
            set { m_OwnerPhone = value; }
        }

        public override string ToString()
        {
            string toShow = string.Format(
@"Owner Name: {0}
Owner Phone: {1}
", 
m_OwnerName, 
m_OwnerPhone);

            return toShow;
        }
    }
}
