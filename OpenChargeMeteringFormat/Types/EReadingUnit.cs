using System.Runtime.Serialization;

namespace OpenChargeMeteringFormat.Types
{
    /// <summary>
    /// Specification: <see href="https://github.com/SAFE-eV/OCMF-Open-Charge-Metering-Format/blob/master/OCMF-de.md#einheiten"/>
    /// </summary>
    public enum EReadingUnit
    {
        /// <summary>
        /// Watthours
        /// </summary>
        [EnumMember(Value = "Wh")]
        Watthour = 0,

        /// <summary>
        /// Kilowatthours, i.e. <c>Wh / 1000</c>
        /// </summary>
        [EnumMember(Value = "kWh")]
        KiloWatthour = 1,
    }
}
