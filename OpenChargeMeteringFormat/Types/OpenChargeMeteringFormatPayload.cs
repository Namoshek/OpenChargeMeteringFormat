using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OpenChargeMeteringFormat.Types
{
    /// <summary>
    /// Specification: <see href="https://github.com/SAFE-eV/OCMF-Open-Charge-Metering-Format/blob/master/OCMF-de.md#nutzdatensektion"/>
    /// </summary>
    public class OpenChargeMeteringFormatPayload
    {
        #region general information
        /// <summary>
        /// Version of the data format in the visualization.
        /// </summary>
        [JsonProperty(PropertyName = "FV", NullValueHandling = NullValueHandling.Ignore)]
        public string FormatVersion { get; set; }

        /// <summary>
        /// The model identifier of the device which produced or recorded this data, given by the manufacturer.
        /// </summary>
        [JsonProperty(PropertyName = "GI", NullValueHandling = NullValueHandling.Ignore)]
        public string GatewayIdentification { get; set; }

        /// <summary>
        /// The serial number of the device which produced or recorded this data.
        /// </summary>
        [JsonProperty(PropertyName = "GS", NullValueHandling = NullValueHandling.Ignore)]
        public string GatewaySerialNumber { get; set; }

        /// <summary>
        /// The software version of the device which produced or recorded this data.
        /// </summary>
        [JsonProperty(PropertyName = "GV", NullValueHandling = NullValueHandling.Ignore)]
        public string GatewayVersion { get; set; }
        #endregion

        #region pagination
        /// <summary>
        /// <para>
        /// The pagination of the whole data set which is covered by one signature. Format: <c>{indicator}{number}</c>
        /// </para>
        /// <para>
        /// The <c>indicator</c> may be one of the following options:
        /// - <c>F</c> for Fiscal, which is used for transaction independent readings (optional)
        /// - <c>T</c> for Transaction, which is used for readings during transactions (mandatory)
        /// </para>
        /// </summary>
        [JsonProperty(PropertyName = "PG", Required = Required.Always)]
        public string Pagination { get; set; }
        #endregion

        #region meter identification
        /// <summary>
        /// The name or an identification of the vendor / manufacturer of the metering device.
        /// </summary>
        [JsonProperty(PropertyName = "MV", NullValueHandling = NullValueHandling.Ignore)]
        public string MeterVendor { get; set; }

        /// <summary>
        /// The identification of the metering device model.
        /// </summary>
        [JsonProperty(PropertyName = "MM", NullValueHandling = NullValueHandling.Ignore)]
        public string MeterModel { get; set; }

        /// <summary>
        /// The serial number of the metering device.
        /// </summary>
        [JsonProperty(PropertyName = "MS", NullValueHandling = NullValueHandling.Ignore)]
        public string MeterSerialNumber { get; set; }

        /// <summary>
        /// The software version of the metering device firmware.
        /// </summary>
        [JsonProperty(PropertyName = "MF", NullValueHandling = NullValueHandling.Ignore)]
        public string MeterFirmwareVersion { get; set; }
        #endregion

        #region user attribution
        /// <summary>
        /// Whether the data could be associated with a user.
        /// </summary>
        [JsonProperty(PropertyName = "IS", Required = Required.Always)]
        public bool IdentificationStatus { get; set; }

        /// <summary>
        /// The status of the user attribution.
        /// </summary>
        [JsonProperty(PropertyName = "IL", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public EIdentificationLevel? IdentificationLevel { get; set; }

        /// <summary>
        /// Details regarding the user attribution.
        /// </summary>
        [JsonProperty(PropertyName = "IF", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public EIdentificationFlag[] IdentificationFlags { get; set; } = new EIdentificationFlag[0];

        /// <summary>
        /// The type of identification.
        /// </summary>
        [JsonProperty(PropertyName = "IT", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public EIdentificationType IdentificationType { get; set; }

        /// <summary>
        /// The identification data itself, e.g. a HEX encoded UID.
        /// </summary>
        [JsonProperty(PropertyName = "ID", NullValueHandling = NullValueHandling.Ignore)]
        public string IdentificationData { get; set; }
        #endregion

        #region charge point
        /// <summary>
        /// The type of identification given in the field <see cref="ChargePointIdentification"/>.
        /// </summary>
        [JsonProperty(PropertyName = "CT", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public EChargePointIdentificationType? ChargePointIdentificationType { get; set; }

        /// <summary>
        /// The identification of the charge point where this data has been recorded at.
        /// </summary>
        [JsonProperty(PropertyName = "CI", NullValueHandling = NullValueHandling.Ignore)]
        public string ChargePointIdentification { get; set; }
        #endregion

        #region metering data
        /// <summary>
        /// The readings made by the metering device, each with time, value and other parameters.
        /// A readin may also indicate an error.
        /// </summary>
        [JsonProperty(PropertyName = "RD", Required = Required.Always)]
        public Reading[] Readings { get; set; }
        #endregion
    }
}
