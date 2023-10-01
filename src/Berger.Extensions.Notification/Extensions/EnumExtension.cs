namespace Berger.Extensions.Notification
{
    public static class EnumExtension
    {
        public static bool IsEnumValid(this Enum value)
        {
            if (Enum.IsDefined(value.GetType(), value))
                return true;

            return false;
        }
        public static bool IsEnumValid<TEnum>(this int value)
        {
            if (Enum.IsDefined(typeof(TEnum), value))
                return true;

            return false;
        }
    }
}