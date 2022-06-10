using System.Runtime.Serialization;

namespace OpenChargeMeteringFormat.Types
{
    public enum EReadStatus
    {
        [EnumMember(Value = "N")]
        NotPresent = 0,

        [EnumMember(Value = "G")]
        Ok = 1,

        [EnumMember(Value = "T")]
        Timeout = 2,

        [EnumMember(Value = "D")]
        Disconnected = 3,

        [EnumMember(Value = "R")]
        NotFound = 4,

        [EnumMember(Value = "M")]
        Manipulated = 5,

        [EnumMember(Value = "X")]
        Exchanged = 6,

        [EnumMember(Value = "I")]
        Incompatible = 7,

        [EnumMember(Value = "O")]
        OutOfRange = 8,

        [EnumMember(Value = "S")]
        Substitute = 9,

        [EnumMember(Value = "E")]
        OtherError = 10,

        [EnumMember(Value = "F")]
        ReadError = 11,
    }
}
