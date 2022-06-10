using System.Runtime.Serialization;

namespace OpenChargeMeteringFormat.Types
{
    public enum EReadingErrorFlag
    {
        [EnumMember(Value = "E")]
        Energy = 0,

        [EnumMember(Value = "t")]
        Time = 1,
    }
}
