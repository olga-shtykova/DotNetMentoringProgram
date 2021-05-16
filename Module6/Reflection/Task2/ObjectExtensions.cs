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

            prop.DeclaringType.GetField($"<{propertyName}>k__BackingField",
               BindingFlags.Instance | BindingFlags.NonPublic).SetValue(obj, newValue);
        }

        public static void SetReadOnlyField(this object obj, string filedName, object newValue)
        {
            var t = obj.GetType();

            FieldInfo field = t.GetField(filedName);

            field.SetValue(obj, newValue);
        }
    }
}
