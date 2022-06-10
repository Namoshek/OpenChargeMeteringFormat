using Newtonsoft.Json;
using OpenChargeMeteringFormat.Types;

namespace OpenChargeMeteringFormat
{
    public class OpenChargeMeteringFormatParser
    {
        /// <summary>
        /// Parses the given <paramref name="message"/> as <see cref="OpenChargeMeteringFormatMessage"/>.
        /// </summary>
        /// <param name="message"></param>
        public static OpenChargeMeteringFormatMessage ParseMessage(string message)
        {
            if (!IsValidMessage(message))
            {
                return null;
            }

            var parts = message.Split('|');

            return new OpenChargeMeteringFormatMessage
            {
                Payload = ParsePayload(parts[1]),
                Signature = ParseSignature(parts[2]),
            };
        }

        /// <summary>
        /// Determines whether the given <paramref name="message"/> is valid. A valid signature begins with <c>OCMF</c>
        /// and contains two JSON objects, one with the payload and one with the signature itself.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool IsValidMessage(string message)
        {
            if (message == null)
            {
                return false;
            }

            if (!message.StartsWith("OCMF"))
            {
                return false;
            }

            var parts = message.Split('|');

            if (parts.Length != 3)
            {
                return false;
            }

            if (!(IsValidPayload(parts[1]) && IsValidSignature(parts[2])))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Parses the given <paramref name="payload"/> as <see cref="OpenChargeMeteringFormatPayload"/>.
        /// </summary>
        /// <param name="payload"></param>
        private static OpenChargeMeteringFormatPayload ParsePayload(string payload)
        {
            return JsonConvert.DeserializeObject<OpenChargeMeteringFormatPayload>(payload);
        }

        /// <summary>
        /// Parses the given <paramref name="signature"/> as <see cref="OpenChargeMeteringFormatSignature"/>.
        /// </summary>
        /// <param name="signature"></param>
        private static OpenChargeMeteringFormatSignature ParseSignature(string signature)
        {
            return JsonConvert.DeserializeObject<OpenChargeMeteringFormatSignature>(signature);
        }

        /// <summary>
        /// Determines whether the given <paramref name="payload"/> contains a valid payload object.
        /// </summary>
        /// <param name="payload"></param>
        private static bool IsValidPayload(string payload)
        {
            try
            {
                return ParsePayload(payload) != null;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Determines whether the given <paramref name="signature"/> contains a valid signature object.
        /// </summary>
        /// <param name="signature"></param>
        private static bool IsValidSignature(string signature)
        {
            try
            {
                return ParseSignature(signature) != null;
            }
            catch
            {
                return false;
            }
        }
    }
}
