using System;

namespace Berger.Extensions.Notifications.Extensions
{
    public static class EnumExtension
    {
        public static bool IsEnumValid(this Enum value)
        {
            if (Enum.IsDefined(value.GetType(), value))
                return true;

            return false;
        }

        public static bool IsEnumValid<TEnum>(this int enumValue)
        {
            if (Enum.IsDefined(typeof(TEnum), enumValue))
            {
                return true;
            }

            return false;
        }
    }
}