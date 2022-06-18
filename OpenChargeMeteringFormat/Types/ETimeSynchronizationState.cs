using System.Runtime.Serialization;

namespace OpenChargeMeteringFormat.Types
{
    /// <summary>
    /// Specification: <see href="https://github.com/SAFE-eV/OCMF-Open-Charge-Metering-Format/blob/master/OCMF-de.md#status-der-zeit"/>
    /// </summary>
    public enum ETimeSynchronizationState
    {
        /// <summary>
        /// The time is unknown or the clock is unsynchronized.
        /// </summary>
        [EnumMember(Value = "U")]
        Unknown = 0,

        /// <summary>
        /// The clock is informative (best effort).
        /// </summary>
        [EnumMember(Value = "I")]
        Informative = 1,

        /// <summary>
        /// The clock is synchronized (most accurate).
        /// </summary>
        [EnumMember(Value = "S")]
        Synchronized = 2,

        /// <summary>
        /// The time was measured relatively, i.e. the start of the session was recorded using an <see cref="Informative"/> clock
        /// and the time since was measured with a calibration law accurate timer.
        /// </summary>
        [EnumMember(Value = "R")]
        Relative = 3,
    }
}
