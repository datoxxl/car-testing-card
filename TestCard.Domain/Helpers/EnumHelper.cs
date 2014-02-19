using System;
using System.ComponentModel;
using System.Reflection;

namespace TestCard.Domain.Helpers
{
    public static class EnumHelper
    {
        private const char ENUM_SEPERATOR_CHARACTER = ',';
        public static string GetDescription(Enum value)
        {
            // Check for Enum that is marked with FlagAttribute
            var entries = value.ToString().Split(ENUM_SEPERATOR_CHARACTER);
            var description = new string[entries.Length];
            for (var i = 0; i < entries.Length; i++)
            {
                var entry = entries[i].Trim();

                FieldInfo fi = value.GetType().GetField(entry);
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes.Length > 0)
                {
                    entry = attributes[0].Description.Trim();
                }

                var localizedValue = Properties.Resources.GeneralResource.ResourceManager.GetString(entry) ?? entry;
                description[i] = localizedValue;
            }

            return String.Join(", ", description);
        }
    }
}