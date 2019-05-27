using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Ex03.GarageLogic
{
    public static class ConstructorReflection
    {
        ////Uses reflection to get the list of parameters types
        public static Type[] GetConstructorParametersTypes(Type i_Type, List<string> i_ParametersDescription)
        {
            ParameterInfo[] paramInfo = getConstructorParamsInfo(i_Type.GetConstructors());
            Type[] typesArray = new Type[paramInfo.Length];

            for (int i = 0; i < paramInfo.Length; i++)
            {
                typesArray[i] = paramInfo[i].ParameterType;
                i_ParametersDescription.Add(paramInfo[i].Name.Substring(2)); ////Substring Remove "i_" from parameter.Name
            }

            return typesArray;
        }

        ////Takes ParameterInfo[] of the constructor that receives the largest number of parameters
        private static ParameterInfo[] getConstructorParamsInfo(ConstructorInfo[] i_ConstructorsInfo)
        {
            ConstructorInfo constructorWithlargestNumberOfParameters = i_ConstructorsInfo[0];

            foreach (ConstructorInfo constructorInfo in i_ConstructorsInfo)
            {
                if (constructorInfo.GetParameters().Length > constructorWithlargestNumberOfParameters.GetParameters().Length)
                {
                    constructorWithlargestNumberOfParameters = constructorInfo;
                }
            }

            return constructorWithlargestNumberOfParameters.GetParameters();
        }
    }
}
