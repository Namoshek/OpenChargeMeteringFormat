using System.Runtime.Serialization;

namespace OpenChargeMeteringFormat.Types
{
    public enum ESignatureAlgorithm
    {
        [EnumMember(Value = "ECDSA-secp192k1-SHA256")]
        ECDSA_secp192k1_SHA256 = 0,

        [EnumMember(Value = "ECDSA-secp256k1-SHA256")]
        ECDSA_secp256k1_SHA256 = 1,

        [EnumMember(Value = "ECDSA-secp192r1-SHA256")]
        ECDSA_secp192r1_SHA256 = 2,

        [EnumMember(Value = "ECDSA-secp256r1-SHA256")]
        ECDSA_secp256r1_SHA256 = 3,

        [EnumMember(Value = "ECDSA-brainpool256r1-SHA256")]
        ECDSA_brainpool256r1_SHA256 = 4,

        [EnumMember(Value = "ECDSA-secp384r1-SHA256")]
        ECDSA_secp384r1_SHA256 = 5,

        [EnumMember(Value = "ECDSA-brainpool384r1-SHA256")]
        ECDSA_brainpool384r1_SHA256 = 6,
    }
}
