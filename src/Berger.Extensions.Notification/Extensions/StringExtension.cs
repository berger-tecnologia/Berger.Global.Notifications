namespace Berger.Extensions.Notification
{
    public static class StringExtension
    {
        public static string ToFormat(this string message, params object[] parameter)
        {
            return string.Format(message, parameter);
        }
    }
}