using System;

namespace SitulClasei.Common.Extensions
{
	//TOD: check this preserve
	[Foundation.Preserve(AllMembers = true)]
    public static class EnumExtensions
    {
        public static int ToInt(this Enum source)
        {
            return Convert.ToInt32(source);
        }

        public static T ToEnum<T>(this int source) where T : struct
        {
            T parsedValue;
            var success = Enum.TryParse(source.ToString(), true, out parsedValue);

            return success ? parsedValue : default(T);
        }

        public static T ToEnum<T>(this string source) where T : struct
        {
            T parsedValue;
            var success = Enum.TryParse(source, true, out parsedValue);

            return success ? parsedValue : default(T);
        }
    }
}