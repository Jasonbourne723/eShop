using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnet.ConsoleTest
{
    public static class MyIoc
    {
        private static Dictionary<Type, Type> _dic = new Dictionary<Type, Type>();


        public static void Add<T1, T2>()
        {
            _dic.Add(typeof(T1), typeof(T2));
        }

        public static T1 GetService<T1>()
        {
            return (T1)GetInstence(typeof(T1));
        }


        private static object GetInstence(Type serviceType)
        {
            Type implType;
            if (_dic.TryGetValue(serviceType, out implType))
            {
                var constructors = implType.GetConstructors(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                var constructor = constructors.OrderByDescending(x => x.GetParameters().Length).FirstOrDefault();  //获取参数最多的构造函数

                var parameters = constructor.GetParameters();  //构造函数参数

                var objecs = new object[parameters.Length];    //实例化参数

                if (parameters != null && parameters.Length > 0)
                {
                    for (int j = 0; j < parameters.Length; j++)
                    {
                        objecs[j] = GetInstence(parameters[j].ParameterType);
                    }
                }
                return constructor.Invoke(objecs);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
