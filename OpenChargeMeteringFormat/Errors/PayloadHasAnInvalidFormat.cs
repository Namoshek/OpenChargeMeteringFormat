using FluentResults;

namespace OpenChargeMeteringFormat.Errors
{
    /// <summary>
    /// This error describes a malformed payload. Either the payload in the OCMF string is no valid JSON,
    /// or it lacks required properties as described in the OCMF specification.
    /// </summary>
    public class PayloadHasAnInvalidFormat : Error
    {
        /// <summary>
        /// Creates a new error instance.
        /// </summary>
        public PayloadHasAnInvalidFormat() : base("The payload has an invalid format or lacks required fields.")
        {
        }
    }
}
