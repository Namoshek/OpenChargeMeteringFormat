using System.Runtime.Serialization;

namespace OpenChargeMeteringFormat.Types
{
    public enum ESignatureMimeType
    {
        [EnumMember(Value = "application/x-der")]
        ASN_1 = 0,
    }
}
