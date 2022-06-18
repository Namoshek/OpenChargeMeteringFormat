using System.Runtime.Serialization;

namespace OpenChargeMeteringFormat.Types
{
    /// <summary>
    /// Specification: <see href="https://github.com/SAFE-eV/OCMF-Open-Charge-Metering-Format/blob/master/OCMF-de.md#signaturdaten"/>
    /// </summary>
    public enum ESignatureEncoding
    {
        /// <summary>
        /// The signature data is in HEX representation.
        /// </summary>
        [EnumMember(Value = "hex")]
        Hex = 0,

        /// <summary>
        /// The signature data is base64 encoded.
        /// </summary>
        [EnumMember(Value = "base64")]
        Base64 = 1,
    }
}
