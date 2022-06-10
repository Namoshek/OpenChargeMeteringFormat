using System.Runtime.Serialization;

namespace OpenChargeMeteringFormat.Types
{
    public enum ETimeSynchronizationState
    {
        [EnumMember(Value = "U")]
        Unknown = 0,

        [EnumMember(Value = "I")]
        Informative = 1,

        [EnumMember(Value = "S")]
        Synchronized = 2,

        [EnumMember(Value = "R")]
        Relative = 3,
    }
}
