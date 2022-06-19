using System;

namespace OpenChargeMeteringFormat.Types
{
    /// <summary>
    /// Represents an OCMF message as described
    /// <see href="https://github.com/SAFE-eV/OCMF-Open-Charge-Metering-Format/blob/master/OCMF-de.md#datenformat">in the specification</see>.
    /// </summary>
    public class OpenChargeMeteringFormatMessage
    {
        /// <summary>
        /// The raw payload of the OCMF message as it can be found in the message.
        /// The payload is the first part after the protocol identifier.
        /// </summary>
        public string RawPayload { get; }

        /// <summary>
        /// The raw signature of the OCMF message as it can be found in the message.
        /// The signature is the second part after the protocol identifier.
        /// </summary>
        public string RawSignature { get; }

        /// <summary>
        /// The payload of the OCMF message, i.e. the first part after the protocol identifier.
        /// </summary>
        public OpenChargeMeteringFormatPayload Payload { get; }

        /// <summary>
        /// The signature of the OCMF message, i.e. the second part after the protocol identifier.
        /// </summary>
        public OpenChargeMeteringFormatSignature Signature { get; }

        /// <summary>
        /// Creates a new OCMF message.
        /// </summary>
        /// <param name="rawPayload"></param>
        /// <param name="rawSignature"></param>
        /// <param name="payload"></param>
        /// <param name="signature"></param>
        public OpenChargeMeteringFormatMessage(
            string rawPayload,
            string rawSignature,
            OpenChargeMeteringFormatPayload payload,
            OpenChargeMeteringFormatSignature signature)
        {
            RawPayload = rawPayload ?? throw new ArgumentNullException(nameof(rawPayload));
            RawSignature = rawSignature ?? throw new ArgumentNullException(nameof(rawSignature));
            Payload = payload ?? throw new ArgumentNullException(nameof(payload));
            Signature = signature ?? throw new ArgumentNullException(nameof(signature));
        }
    }
}
