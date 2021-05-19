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
            // To insert dependency directly to the field is not the best practice. 
            // However, declaration of "Import Attribute" allows import for the fields as well.
            var typesToResolve = assembly.GetTypes()
                .Where(t => t.IsDefined(typeof(ImportConstructorAttribute)) ||
                 t.IsDefined(typeof(ExportAttribute)) ||
                    t.GetProperties().Any(p => p.IsDefined(typeof(ImportAttribute))) ||
                t.GetFields().Any(f => f.IsDefined(typeof(ImportAttribute))))
                .ToList();

            foreach (var t in typesToResolve)
            {
                var exportAttribute = t.GetCustomAttribute<ExportAttribute>();
                if (exportAttribute != null && exportAttribute.Contract != null)
                    AddType(t, exportAttribute.Contract);
                AddType(t);
            }
        }                

        public void AddType(Type type)
        {
            if (_registeredTypes.ContainsKey(type))
                GetInstance(type);
            
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
                throw new ArgumentException($"Cannot create instance of {type.FullName}. The dependency was not provided.");
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
            var propertiesInfo = type.GetProperties()
                .Where(p => p.GetCustomAttribute<ImportAttribute>() != null);

            foreach (var p in propertiesInfo)
            {
                var property = GetInstance(p.PropertyType);
                p.SetValue(instance, property);
            }

            var fieldsInfo = type.GetFields()
                .Where(p => p.GetCustomAttribute<ImportAttribute>() != null);

            foreach (var p in fieldsInfo)
            {
                var property = GetInstance(p.FieldType);
                p.SetValue(instance, property);
            }
        }
    }
}