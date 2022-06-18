using System.Runtime.Serialization;

namespace OpenChargeMeteringFormat.Types
{
    /// <summary>
    /// Specification: <see href="https://github.com/SAFE-eV/OCMF-Open-Charge-Metering-Format/blob/master/OCMF-de.md#signaturdaten"/>
    /// </summary>
    public enum ESignatureMimeType
    {
        /// <summary>
        /// The signature is stored as ASN.1 encoded <c>.der</c>-file.
        /// </summary>
        [EnumMember(Value = "application/x-der")]
        ASN_1 = 0,
    }
}
