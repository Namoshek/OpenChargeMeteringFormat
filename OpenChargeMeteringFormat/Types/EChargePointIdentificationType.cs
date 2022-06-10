using System.Runtime.Serialization;

namespace OpenChargeMeteringFormat.Types
{
    public enum EChargePointIdentificationType
    {
        [EnumMember(Value = "EVSEID")]
        EVSEID = 0,

        [EnumMember(Value = "CBIDC")]
        CBIDC = 1,
    }
}
