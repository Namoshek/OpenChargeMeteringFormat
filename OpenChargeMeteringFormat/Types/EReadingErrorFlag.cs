using System.Runtime.Serialization;

namespace OpenChargeMeteringFormat.Types
{
    /// <summary>
    /// Specification: <see href="https://github.com/SAFE-eV/OCMF-Open-Charge-Metering-Format/blob/master/OCMF-de.md#ablesungen"/>
    /// </summary>
    public enum EReadingErrorFlag
    {
        /// <summary>
        /// The energy component of the reading(s) is not usable anymore.
        /// </summary>
        [EnumMember(Value = "E")]
        Energy = 0,

        /// <summary>
        /// The time component of the reading(s) is not usable anymore.
        /// </summary>
        [EnumMember(Value = "t")]
        Time = 1,
    }
}
