using FluentResults;

namespace OpenChargeMeteringFormat.Errors
{
    /// <summary>
    /// This error describes a malformed public key. Either the public key is not in HEX format,
    /// or its length does not match the expectation.
    /// </summary>
    public class InvalidPublicKey : Error
    {
        /// <summary>
        /// Creates a new error instance.
        /// </summary>
        public InvalidPublicKey(string message = null) : base(message ?? "The provided public key has an invalid format.")
        {
        }
    }
}
