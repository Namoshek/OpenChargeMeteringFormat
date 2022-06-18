using System.Runtime.Serialization;

namespace OpenChargeMeteringFormat.Types
{
    /// <summary>
    /// Specification: <see href="https://github.com/SAFE-eV/OCMF-Open-Charge-Metering-Format/blob/master/OCMF-de.md#details"/>
    /// </summary>
    public enum EIdentificationFlag
    {
        /// <summary>
        /// No user correlation by RFID.
        /// </summary>
        [EnumMember(Value = "RFID_NONE")]
        RFID_None = 0,

        /// <summary>
        /// User correlation by external RFID reader.
        /// </summary>
        [EnumMember(Value = "RFID_PLAIN")]
        RFID_Plain = 1,

        /// <summary>
        /// User correlation by protected RFID reader.
        /// </summary>
        [EnumMember(Value = "RFID_RELATED")]
        RFID_Related = 2,

        /// <summary>
        /// A pre-shared key has been used for the user correlation, e.g. with a protected RFID card.
        /// </summary>
        [EnumMember(Value = "RFID_PSK")]
        RFID_PreSharedKey = 3,

        /// <summary>
        /// No user correlation by OCPP.
        /// </summary>
        [EnumMember(Value = "OCPP_NONE")]
        OCPP_None = 10,

        /// <summary>
        /// User correlation by OCPP <c>RemoteStart</c>.
        /// </summary>
        [EnumMember(Value = "OCPP_RS")]
        OCPP_RemoteStart = 11,

        /// <summary>
        /// User correlation by OCPP <c>Authorize</c>.
        /// </summary>
        [EnumMember(Value = "OCPP_AUTH")]
        OCPP_Authorize = 12,

        /// <summary>
        /// User correlation by OCPP <c>RemoteStart</c> via TLS.
        /// </summary>
        [EnumMember(Value = "OCPP_RS_TLS")]
        OCPP_RemoteStartWithTls = 13,

        /// <summary>
        /// User correlation by OCPP <c>Authorize</c> via TLS.
        /// </summary>
        [EnumMember(Value = "OCPP_AUTH_TLS")]
        OCPP_AuthorizeWithTls = 14,

        /// <summary>
        /// User correlation by authorization cache as described in OCPP.
        /// </summary>
        [EnumMember(Value = "OCPP_CACHE")]
        OCPP_AuthorizationCache = 15,

        /// <summary>
        /// User correlation by whitelist as described in OCPP.
        /// </summary>
        [EnumMember(Value = "OCPP_WHITELIST")]
        OCPP_Whitelist = 16,

        /// <summary>
        /// User correlation by certificate of a backend.
        /// </summary>
        [EnumMember(Value = "OCPP_CERTIFIED")]
        OCPP_Certified = 17,

        /// <summary>
        /// No user correlation via ISO-15118.
        /// </summary>
        [EnumMember(Value = "ISO15118_NONE")]
        ISO15118_None = 20,

        /// <summary>
        /// User correlation using Plug &amp; Charge as defined by ISO-15118.
        /// </summary>
        [EnumMember(Value = "ISO15118_PNC")]
        ISO15118_PlugAndCharge = 21,

        /// <summary>
        /// No user correlation via PLMN (Public Land Mobile Network).
        /// </summary>
        [EnumMember(Value = "PLMN_NONE")]
        PLMN_None = 30,

        /// <summary>
        /// A call via PLMN (Public Land Mobile Network) was received.
        /// </summary>
        [EnumMember(Value = "PLMN_RING")]
        PLMN_Ring = 31,

        /// <summary>
        /// An SMS via PLMN (Public Land Mobile Network) was received.
        /// </summary>
        [EnumMember(Value = "PLMN_SMS")]
        PLMN_SMS = 32,
    }
}
