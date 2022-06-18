using System.Runtime.Serialization;

namespace OpenChargeMeteringFormat.Types
{
    /// <summary>
    /// Specification: <see href="https://github.com/SAFE-eV/OCMF-Open-Charge-Metering-Format/blob/master/OCMF-de.md#zuordnung-des-ladepunktes-1"/>
    /// </summary>
    public enum EChargePointIdentificationType
    {
        /// <summary>
        /// An EVSE ID, i.e. a unique public charge point identifier.
        /// </summary>
        [EnumMember(Value = "EVSEID")]
        EVSEID = 0,

        /// <summary>
        /// A combination of charge box identifier and connector id, separated by a space. Example: <c>MY_CHARGER 2</c>.
        /// </summary>
        [EnumMember(Value = "CBIDC")]
        CBIDC = 1,
    }
}
