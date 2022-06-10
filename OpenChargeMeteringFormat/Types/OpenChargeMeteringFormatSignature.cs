using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OpenChargeMeteringFormat.Types
{
    public class OpenChargeMeteringFormatSignature
    {
        /// <summary>
        /// The algorithm used to create the signature.
        /// </summary>
        [JsonProperty(PropertyName = "SA")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ESignatureAlgorithm Algorithm { get; set; } = ESignatureAlgorithm.ECDSA_secp256r1_SHA256;

        /// <summary>
        /// The signature encoding describes how the signature data is encoded.
        /// </summary>
        [JsonProperty(PropertyName = "SE", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ESignatureEncoding Encoding { get; set; } = ESignatureEncoding.Hex;

        /// <summary>
        /// The mime type describes how to interprete the signature data.
        /// </summary>
        [JsonProperty(PropertyName = "SM", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ESignatureMimeType MimeType { get; set; }

        /// <summary>
        /// The actual signature data as described by the other parameters (or their defaults).
        /// </summary>
        [JsonProperty(PropertyName = "SD", Required = Required.Always)]
        public string Data { get; set; }
    }
}
