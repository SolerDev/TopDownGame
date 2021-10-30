using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Extensions
{
    public static class ComponentX
    {
        public static T GetCopyOf<T>(this Component copy, T original) where T : Component
        {
            var type = copy.GetType();
            if (type != original.GetType())
                return null; // type mis-match

            var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default | BindingFlags.DeclaredOnly;

            CopyProperties();
            CopyFields();

            return copy as T;





            void CopyFields()
            {
                var fieldsInfo = type.GetFields(flags);
                foreach (var fieldInfo in fieldsInfo)
                    fieldInfo.SetValue(copy, fieldInfo.GetValue(original));
            }

            void CopyProperties()
            {
                var propertiesInfo = type.GetProperties(flags);
                foreach (var propertyInfo in propertiesInfo.Where(p => p.CanWrite))
                {
                    try
                    {
                        propertyInfo.SetValue(copy, propertyInfo.GetValue(original, null), null);
                    }
                    catch
                    {
                        // In case of NotImplementedException being thrown. For some reason specifying that exception didn't seem to catch it, so I didn't catch anything specific.
                    }
                }
            }
        }
    }
}