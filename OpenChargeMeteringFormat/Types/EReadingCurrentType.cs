using System.Runtime.Serialization;

namespace OpenChargeMeteringFormat.Types
{
    /// <summary>
    /// Specification: <see href="https://github.com/SAFE-eV/OCMF-Open-Charge-Metering-Format/blob/master/OCMF-de.md#stromart"/>
    /// </summary>
    public enum EReadingCurrentType
    {
        /// <summary>
        /// Alternating Current
        /// </summary>
        [EnumMember(Value = "AC")]
        AC = 0,

        /// <summary>
        /// Direct Current
        /// </summary>
        [EnumMember(Value = "DC")]
        DC = 1,
    }
}
