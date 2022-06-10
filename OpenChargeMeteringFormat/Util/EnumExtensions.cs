using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace OpenChargeMeteringFormat.Util
{
    internal static class EnumExtensions
    {
        public static string GetEnumMemberValue<T>(T value) where T : struct, IConvertible
        {
            return typeof(T).GetTypeInfo().DeclaredMembers
                .SingleOrDefault(x => x.Name == value.ToString())?.GetCustomAttribute<EnumMemberAttribute>(false)?.Value;
        }

        public static T? GetEnumByValue<T>(string value) where T : struct, IConvertible
        {
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .FirstOrDefault(e => GetEnumMemberValue(e) == value);
        }
    }
}
