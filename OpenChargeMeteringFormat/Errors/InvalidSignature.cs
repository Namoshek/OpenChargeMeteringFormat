using FluentResults;

namespace OpenChargeMeteringFormat.Errors
{
    /// <summary>
    /// This error describes an invalid OCMF signature. If this error occurrs, it means the OCMF message has been tampered with.
    /// </summary>
    public class InvalidSignature : Error
    {
        /// <summary>
        /// Creates a new error instance.
        /// </summary>
        public InvalidSignature(string message = null) : base(message ?? "The signature is invalid.")
        {
        }
    }
}
