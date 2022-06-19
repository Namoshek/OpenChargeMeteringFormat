using FluentResults;

namespace OpenChargeMeteringFormat.Errors
{
    /// <summary>
    /// This error describes a failed verification process of a signature.
    /// </summary>
    public class SignatureVerificationFailed : Error
    {
        /// <summary>
        /// Creates a new error instance.
        /// </summary>
        public SignatureVerificationFailed() : base("The signature verification failed.")
        {
        }
    }
}
