using System.Runtime.Serialization;

namespace OpenChargeMeteringFormat.Types
{
    public enum EReadingCurrentType
    {
        [EnumMember(Value = "AC")]
        AC = 0,

        [EnumMember(Value = "DC")]
        DC = 1,
    }
}
