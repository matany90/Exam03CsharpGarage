using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleParametersTypes
    {
        private Type[] m_ParameterTypes;
        private string[] m_ParameterDescription;

        public VehicleParametersTypes(Type[] i_ParameterTypes, string[] i_ParameterDescription)
        {
            m_ParameterTypes = i_ParameterTypes;
            m_ParameterDescription = i_ParameterDescription;
        }
        public Type[] ParameterTypes
        {
            get { return m_ParameterTypes; }
            set { m_ParameterTypes = value; }
        }

        public string[] ParameterDescription
        {
            get { return m_ParameterDescription; }
            set { m_ParameterDescription = value; }
        }
    }
}
