using FluentResults;

namespace OpenChargeMeteringFormat.Errors
{
    /// <summary>
    /// This error describes a malformed OCMF message. Either the overall format or one of the OCMF components is invalid.
    /// A valid message as described by the OCMF specification has the format: <c>OCMF|{payload}|{signature}</c>
    /// where <c>{payload}</c> is a JSON object containing the OCMF payload and <c>{signature}</c> is a JSON object
    /// containing the signature for verification of the payload.
    /// </summary>
    public class InputIsNotAnOpenChargeMeteringFormatMessage : Error
    {
        /// <summary>
        /// Creates a new error instance.
        /// </summary>
        public InputIsNotAnOpenChargeMeteringFormatMessage(string error) : base(error)
        {
        }
    }
}
