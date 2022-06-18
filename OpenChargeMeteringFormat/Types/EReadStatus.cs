using System.Runtime.Serialization;

namespace OpenChargeMeteringFormat.Types
{
    /// <summary>
    /// Specification: <see href="https://github.com/SAFE-eV/OCMF-Open-Charge-Metering-Format/blob/master/OCMF-de.md#zustand--fehler-des-z%C3%A4hlers"/>
    /// </summary>
    public enum EReadStatus
    {
        /// <summary>
        /// A meter is not present or could not be found.
        /// </summary>
        [EnumMember(Value = "N")]
        NotPresent = 0,

        /// <summary>
        /// The meter is in working condition (good).
        /// </summary>
        [EnumMember(Value = "G")]
        Ok = 1,

        /// <summary>
        /// A timeout occurred while communicating with the meter.
        /// </summary>
        [EnumMember(Value = "T")]
        Timeout = 2,

        /// <summary>
        /// The meter has been disconnected from the signature component.
        /// </summary>
        [EnumMember(Value = "D")]
        Disconnected = 3,

        /// <summary>
        /// The meter was removed (it was found previously).
        /// </summary>
        [EnumMember(Value = "R")]
        NotFound = 4,

        /// <summary>
        /// A manipulation of the meter was noticed.
        /// </summary>
        [EnumMember(Value = "M")]
        Manipulated = 5,

        /// <summary>
        /// The meter has been changed (serial number does not match previously known one).
        /// </summary>
        [EnumMember(Value = "X")]
        Exchanged = 6,

        /// <summary>
        /// The meter version or its API is not compatible with the signature component.
        /// </summary>
        [EnumMember(Value = "I")]
        Incompatible = 7,

        /// <summary>
        /// The measured value of the reading is out of the supported range.
        /// </summary>
        [EnumMember(Value = "O")]
        OutOfRange = 8,

        /// <summary>
        /// A replacement value was calculated.
        /// </summary>
        [EnumMember(Value = "S")]
        Substitute = 9,

        /// <summary>
        /// Another, not further specified error has occurred.
        /// </summary>
        [EnumMember(Value = "E")]
        OtherError = 10,

        /// <summary>
        /// Meter register could not be read successfully. The read value is invalid.
        /// </summary>
        [EnumMember(Value = "F")]
        ReadError = 11,
    }
}
