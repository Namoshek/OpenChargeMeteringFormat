namespace OpenChargeMeteringFormat.Types
{
    /// <summary>
    /// Represents an OCMF message as described
    /// <see href="https://github.com/SAFE-eV/OCMF-Open-Charge-Metering-Format/blob/master/OCMF-de.md#datenformat">in the specification</see>.
    /// </summary>
    public class OpenChargeMeteringFormatMessage
    {
        /// <summary>
        /// The payload of the OCMF message, i.e. the first part after the protocol identifier.
        /// </summary>
        public OpenChargeMeteringFormatPayload Payload { get; set; }

        /// <summary>
        /// The signature of the OCMF message, i.e. the second part after the protocol identifier.
        /// </summary>
        public OpenChargeMeteringFormatSignature Signature { get; set; }
    }
}
