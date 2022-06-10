using System.Runtime.Serialization;

namespace OpenChargeMeteringFormat.Types
{
    public enum EIdentificationLevel
    {
        [EnumMember(Value = "NONE")]
        None = 0,

        [EnumMember(Value = "HEARSAY")]
        Hearsay = 10,

        [EnumMember(Value = "TRUSTED")]
        Trusted = 11,

        [EnumMember(Value = "VERIFIED")]
        Verified = 12,

        [EnumMember(Value = "CERTIFIED")]
        Certified = 13,

        [EnumMember(Value = "SECURE")]
        Secure = 14,

        [EnumMember(Value = "MISMATCH")]
        Mismatch = 20,

        [EnumMember(Value = "INVALID")]
        Invalid = 21,

        [EnumMember(Value = "OUTDATED")]
        Outdated = 22,

        [EnumMember(Value = "UNKNOWN")]
        Unknown = 23,
    }
}
