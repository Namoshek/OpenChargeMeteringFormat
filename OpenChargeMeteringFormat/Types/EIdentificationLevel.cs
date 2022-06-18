using System.Runtime.Serialization;

namespace OpenChargeMeteringFormat.Types
{
    /// <summary>
    /// Specification: <see href="https://github.com/SAFE-eV/OCMF-Open-Charge-Metering-Format/blob/master/OCMF-de.md#status--fehler"/>
    /// </summary>
    public enum EIdentificationLevel
    {
        /// <summary>
        /// No user identification is given. If there is other information regarding a user present, it has no meaning.
        /// </summary>
        [EnumMember(Value = "NONE")]
        None = 0,

        /// <summary>
        /// The user identification happened unprotected, e.g. using an RFID-UID.
        /// </summary>
        [EnumMember(Value = "HEARSAY")]
        Hearsay = 10,

        /// <summary>
        /// The user identification happened somewhat secured, e.g. by authorization via backend.
        /// Note: This does not imply that the identification should be fully trusted.
        /// </summary>
        [EnumMember(Value = "TRUSTED")]
        Trusted = 11,

        /// <summary>
        /// The user correlation was verified using the signature component and special measures.
        /// </summary>
        [EnumMember(Value = "VERIFIED")]
        Verified = 12,

        /// <summary>
        /// The user correlation was verified using the signature component and a cryptographic signature,
        /// which certifies the correlation.
        /// </summary>
        [EnumMember(Value = "CERTIFIED")]
        Certified = 13,

        /// <summary>
        /// The user was correlated using a secure attribute, e.g. a secure RFID-card, ISO-15118 with Plug &amp; Charge, etc.).
        /// </summary>
        [EnumMember(Value = "SECURE")]
        Secure = 14,

        /// <summary>
        /// Error: UIDs do not match.
        /// </summary>
        [EnumMember(Value = "MISMATCH")]
        Mismatch = 20,

        /// <summary>
        /// Error: certificate invalid.
        /// </summary>
        [EnumMember(Value = "INVALID")]
        Invalid = 21,

        /// <summary>
        /// Error: referenced trust certificate is not valid anymore.
        /// </summary>
        [EnumMember(Value = "OUTDATED")]
        Outdated = 22,

        /// <summary>
        /// The certificate could not be tested successfully (no matching trust certificate found).
        /// </summary>
        [EnumMember(Value = "UNKNOWN")]
        Unknown = 23,
    }
}
