using System.Runtime.Serialization;

namespace OpenChargeMeteringFormat.Types
{
    public enum EIdentificationFlag
    {
        [EnumMember(Value = "RFID_NONE")]
        RFID_None = 0,

        [EnumMember(Value = "RFID_PLAIN")]
        RFID_Plain = 1,

        [EnumMember(Value = "RFID_RELATED")]
        RFID_Related = 2,

        [EnumMember(Value = "RFID_PSK")]
        RFID_PreSharedKey = 3,

        [EnumMember(Value = "OCPP_NONE")]
        OCPP_None = 10,

        [EnumMember(Value = "OCPP_RS")]
        OCPP_RemoteStart = 11,

        [EnumMember(Value = "OCPP_AUTH")]
        OCPP_Authorize = 12,

        [EnumMember(Value = "OCPP_RS_TLS")]
        OCPP_RemoteStartWithTls = 13,

        [EnumMember(Value = "OCPP_AUTH_TLS")]
        OCPP_AuthorizeWithTls = 14,

        [EnumMember(Value = "OCPP_CACHE")]
        OCPP_AuthorizationCache = 15,

        [EnumMember(Value = "OCPP_WHITELIST")]
        OCPP_Whitelist = 16,

        [EnumMember(Value = "OCPP_CERTIFIED")]
        OCPP_Certified = 17,

        [EnumMember(Value = "ISO15118_NONE")]
        ISO15118_None = 20,

        [EnumMember(Value = "ISO15118_PNC")]
        ISO15118_PlugAndCharge = 21,

        [EnumMember(Value = "PLMN_NONE")]
        PLMN_None = 30,

        [EnumMember(Value = "PLMN_RING")]
        PLMN_Ring = 31,

        [EnumMember(Value = "PLMN_SMS")]
        PLMN_SMS = 32,
    }
}
