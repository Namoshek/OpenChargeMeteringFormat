using FluentResults;

namespace OpenChargeMeteringFormat.Errors
{
    /// <summary>
    /// This error describes a malformed signature. Either the signature in the OCMF string is no valid JSON,
    /// or it lacks required properties as described in the OCMF specification.
    /// </summary>
    public class SignatureHasAnInvalidFormat : Error
    {
        /// <summary>
        /// Creates a new error instance.
        /// </summary>
        public SignatureHasAnInvalidFormat() : base("The signature has an invalid format or lacks required fields.")
        {
        }
    }
}
