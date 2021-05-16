using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Task1.DoNotChange;

namespace Task1
{
    public class Container
    {
        private readonly IDictionary<Type, Type> _registeredTypes = new Dictionary<Type, Type>();

        public void AddAssembly(Assembly assembly)
        {
            foreach (var t in assembly.ExportedTypes)
            {
                var importCtorAttribute = t.GetCustomAttribute<ImportConstructorAttribute>();
                var importAttribute = GetImportAttributeProperties(t);

                if (importCtorAttribute != null || importAttribute.Any())
                {
                    _registeredTypes.Add(t, t);
                }

                var exportAttributes = t.GetCustomAttributes<ExportAttribute>();
                foreach (var exportAttribute in exportAttributes)
                {                    
                    if (exportAttribute.Contract == null)
                    {
                        _registeredTypes.Add(t, t);                        
                    }
                    else
                    {
                        _registeredTypes.Add(exportAttribute.Contract, t);                       
                    }
                }
            }
        }                

        public void AddType(Type type)
        {
            _registeredTypes.Add(type, type);
        }

        public void AddType(Type type, Type baseType)        
        {
            _registeredTypes.Add(baseType, type);            
        }

        public T Get<T>()
        {
            return (T)GetInstance(typeof(T));
        }

        private object GetInstance(Type type)
        {
            if (!_registeredTypes.ContainsKey(type))
            {
                throw new Exception("Cannot create instance.");
            }

            Type dependentType = _registeredTypes[type];

            var constructor = dependentType.GetConstructors()
                .OrderByDescending(c => c.GetParameters().Length)
                .First();

            var args = constructor.GetParameters()
               .Select(param => GetInstance(param.ParameterType))
               .ToArray();

            object instance = Activator.CreateInstance(dependentType, args);

            Resolve(dependentType, instance);

            return instance;
        }

        private void Resolve(Type type, object instance)
        {
            var propertiesInfo = GetImportAttributeProperties(type);

            foreach (var p in propertiesInfo)
            {
                var property = GetInstance(p.PropertyType);
                p.SetValue(instance, property);
            }
        }

        private IEnumerable<PropertyInfo> GetImportAttributeProperties(Type type)
        {
            return type.GetProperties().Where(p => p.GetCustomAttribute<ImportAttribute>() != null);
        }
    }
}