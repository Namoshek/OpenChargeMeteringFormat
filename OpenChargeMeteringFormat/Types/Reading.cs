using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OpenChargeMeteringFormat.Converters;

namespace OpenChargeMeteringFormat.Types
{
    /// <summary>
    /// Specification: <see href="https://github.com/SAFE-eV/OCMF-Open-Charge-Metering-Format/blob/master/OCMF-de.md#ablesungen"/>
    /// </summary>
    public partial class Reading
    {
        /// <summary>
        /// The metering device system time when the reading was made.
        /// </summary>
        [JsonProperty(PropertyName = "TM", Required = Required.Always)]
        [JsonConverter(typeof(TimeWithSynchronizationStateConverter))]
        public TimeWithSynchronizationState Time { get; set; }

        /// <summary>
        /// A transaction related reason for the reading. Only relevant if the reading has transaction context.
        /// </summary>
        [JsonProperty(PropertyName = "TX", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ETransactionReadingReason TransactionReadingReason { get; set; }

        /// <summary>
        /// The value of the reading.
        /// </summary>
        [JsonProperty(PropertyName = "RV", Required = Required.Always)]
        public decimal ReadingValue { get; set; }

        /// <summary>
        /// The identification of the reading value, i.e. OBIS code.
        /// </summary>
        [JsonProperty(PropertyName = "RI", NullValueHandling = NullValueHandling.Ignore)]
        public string ReadingIdentification { get; set; }

        /// <summary>
        /// The unit of the reading value.
        /// </summary>
        [JsonProperty(PropertyName = "RU", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public EReadingUnit ReadingUnit { get; set; }

        /// <summary>
        /// The current type of the reading, i.e. AC or DC.
        /// </summary>
        [JsonProperty(PropertyName = "RT", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public EReadingCurrentType ReadingCurrentType { get; set; }

        /// <summary>
        /// Gives information which part of the transaction data cannot be used for billing anymore.
        /// </summary>
        [JsonProperty(PropertyName = "EF", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ReadingErrorFlagsConverter))]
        public EReadingErrorFlag[] ErrorFlags { get; set; }

        /// <summary>
        /// The status of the meter while reading the value.
        /// </summary>
        [JsonProperty(PropertyName = "ST", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public EReadStatus ReadStatus { get; set; }
    }
}
