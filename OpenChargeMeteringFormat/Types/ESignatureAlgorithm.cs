using System.Runtime.Serialization;

namespace OpenChargeMeteringFormat.Types
{
    /// <summary>
    /// Specification: <see href="https://github.com/SAFE-eV/OCMF-Open-Charge-Metering-Format/blob/master/OCMF-de.md#signatur-methoden"/>
    /// </summary>
    public enum ESignatureAlgorithm
    {
        /// <summary>
        /// <para>Algorithm: ECDSA</para>
        /// <para>Curve: secp192k1</para>
        /// <para>Key length: 192 bit</para>
        /// <para>Hash algorithm: SHA-256</para>
        /// <para>Block length: 48</para>
        /// </summary>
        [EnumMember(Value = "ECDSA-secp192k1-SHA256")]
        ECDSA_secp192k1_SHA256 = 0,

        /// <summary>
        /// <para>Algorithm: ECDSA</para>
        /// <para>Curve: secp256k1</para>
        /// <para>Key length: 256 bit</para>
        /// <para>Hash algorithm: SHA-256</para>
        /// <para>Block length: 64</para>
        /// </summary>
        [EnumMember(Value = "ECDSA-secp256k1-SHA256")]
        ECDSA_secp256k1_SHA256 = 1,

        /// <summary>
        /// <para>Algorithm: ECDSA</para>
        /// <para>Curve: secp192r1</para>
        /// <para>Key length: 192 bit</para>
        /// <para>Hash algorithm: SHA-256</para>
        /// <para>Block length: 48</para>
        /// </summary>
        [EnumMember(Value = "ECDSA-secp192r1-SHA256")]
        ECDSA_secp192r1_SHA256 = 2,

        /// <summary>
        /// <para>Algorithm: ECDSA</para>
        /// <para>Curve: secp256r1, NIST P-256, ANSI X9.62 elliptic curve prime256v1</para>
        /// <para>Key length: 256 bit</para>
        /// <para>Hash algorithm: SHA-256</para>
        /// <para>Block length: 64</para>
        /// </summary>
        [EnumMember(Value = "ECDSA-secp256r1-SHA256")]
        ECDSA_secp256r1_SHA256 = 3,

        /// <summary>
        /// <para>Algorithm: ECDSA</para>
        /// <para>Curve: brainpool256r1</para>
        /// <para>Key length: 256 bit</para>
        /// <para>Hash algorithm: SHA-256</para>
        /// <para>Block length: 64</para>
        /// </summary>
        [EnumMember(Value = "ECDSA-brainpool256r1-SHA256")]
        ECDSA_brainpool256r1_SHA256 = 4,

        /// <summary>
        /// <para>Algorithm: ECDSA</para>
        /// <para>Curve: secp384r1, NIST P-384, ANSI X9.62 elliptic curve prime384v1</para>
        /// <para>Key length: 384 bit</para>
        /// <para>Hash algorithm: SHA-256</para>
        /// <para>Block length: 96</para>
        /// </summary>
        [EnumMember(Value = "ECDSA-secp384r1-SHA256")]
        ECDSA_secp384r1_SHA256 = 5,

        /// <summary>
        /// <para>Algorithm: ECDSA</para>
        /// <para>Curve: brainpool384r1</para>
        /// <para>Key length: 384 bit</para>
        /// <para>Hash algorithm: SHA-256</para>
        /// <para>Block length: 96</para>
        /// </summary>
        [EnumMember(Value = "ECDSA-brainpool384r1-SHA256")]
        ECDSA_brainpool384r1_SHA256 = 6,
    }
}
