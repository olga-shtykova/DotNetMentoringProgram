using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Task2
{
    public static class ObjectExtensions
    {
        public static void SetReadOnlyProperty(this object obj, string propertyName, object newValue)
        {
            var t = obj.GetType();
            var prop = t.GetProperty(propertyName);

            // Setter for the property will work only in case of readonly-automatic property.
            prop.DeclaringType.GetField($"<{propertyName}>k__BackingField",
               BindingFlags.Instance | BindingFlags.NonPublic).SetValue(obj, newValue);
        }

        public static void SetReadOnlyField(this object obj, string fieldName, object newValue)
        {
            var t = obj.GetType();

            if (t.GetField(fieldName) != null) 
            {
                FieldInfo field = t.GetField(fieldName);
                field.SetValue(obj, newValue);
            }
            else
            {
                throw new ArgumentNullException();
            }            
        }
    }
}
