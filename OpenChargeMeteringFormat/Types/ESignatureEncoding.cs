using System.Runtime.Serialization;

namespace OpenChargeMeteringFormat.Types
{
    public enum ESignatureEncoding
    {
        [EnumMember(Value = "hex")]
        Hex = 0,

        [EnumMember(Value = "base64")]
        Base64 = 1,
    }
}
