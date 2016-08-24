using System;
using System.Collections.Generic;
using System.Reflection;

namespace Common.Ioc
{
    public interface IContainer
    {

        IDictionary<string, object> RegisteredObjects { get; }
        T Resolve<T>(string name) where T : class;
        object Resolve(Type type);

        object Resolve(string name, Type type);

        void Register<T>(string name, params object[] parameterValue);

        void Register(string name, Type type, params object[] parameterValue );

        IEnumerable<T> ResolveAll<T>();

        IEnumerable<object> ResolveAll(Type targetType);

    }
}
