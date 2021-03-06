using System;
using FluentResults;
using Newtonsoft.Json;
using OpenChargeMeteringFormat.Errors;
using OpenChargeMeteringFormat.Types;

namespace OpenChargeMeteringFormat
{
    /// <summary>
    /// A parser for the <see href="https://github.com/SAFE-eV/OCMF-Open-Charge-Metering-Format">OCMF protocol</see>.
    /// </summary>
    public static class OpenChargeMeteringFormatParser
    {
        /// <summary>
        /// Parses the given <paramref name="message"/> as <see cref="OpenChargeMeteringFormatMessage"/>.
        /// </summary>
        /// <param name="message"></param>
        public static Result<OpenChargeMeteringFormatMessage> ParseMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return Result.Fail(new InputIsNotAnOpenChargeMeteringFormatMessage("The message may not be null or empty."));
            }

            if (!message.StartsWith("OCMF"))
            {
                return Result.Fail(new InputIsNotAnOpenChargeMeteringFormatMessage("The message does not start with the required 'OCMF' prefix."));
            }

            var parts = message.Split('|');

            if (parts.Length != 3)
            {
                return Result.Fail(new InputIsNotAnOpenChargeMeteringFormatMessage("The message is malformed. It does not contain 3 parts."));
            }

            var payloadResult = ParsePayload(parts[1]);
            if (payloadResult.IsFailed)
            {
                return payloadResult.ToResult<OpenChargeMeteringFormatMessage>();
            }

            var signatureResult = ParseSignature(parts[2]);
            if (signatureResult.IsFailed)
            {
                return signatureResult.ToResult<OpenChargeMeteringFormatMessage>();
            }

            return Result.Ok(new OpenChargeMeteringFormatMessage(
                rawPayload: parts[1],
                rawSignature: parts[2],
                payload: payloadResult.Value,
                signature: signatureResult.Value));
        }

        /// <summary>
        /// Determines whether the given <paramref name="message"/> is valid. A valid signature begins with <c>OCMF</c>
        /// and contains two JSON objects, one with the payload and one with the signature itself.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool IsValidMessage(string message)
        {
            return ParseMessage(message).IsSuccess;
        }

        /// <summary>
        /// Parses the given <paramref name="payload"/> as <see cref="OpenChargeMeteringFormatPayload"/>.
        /// </summary>
        /// <param name="payload"></param>
        private static Result<OpenChargeMeteringFormatPayload> ParsePayload(string payload)
        {
            try
            {
                return Result.Ok(JsonConvert.DeserializeObject<OpenChargeMeteringFormatPayload>(payload));
            }
            catch (Exception ex)
            {
                return Result.Fail(new PayloadHasAnInvalidFormat().CausedBy(ex));
            }
        }

        /// <summary>
        /// Parses the given <paramref name="signature"/> as <see cref="OpenChargeMeteringFormatSignature"/>.
        /// </summary>
        /// <param name="signature"></param>
        private static Result<OpenChargeMeteringFormatSignature> ParseSignature(string signature)
        {
            try
            {
                return Result.Ok(JsonConvert.DeserializeObject<OpenChargeMeteringFormatSignature>(signature));
            }
            catch (Exception ex)
            {
                return Result.Fail(new SignatureHasAnInvalidFormat().CausedBy(ex));
            }
        }
    }
}
