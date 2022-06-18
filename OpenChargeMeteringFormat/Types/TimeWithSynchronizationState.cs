using System;

namespace OpenChargeMeteringFormat.Types
{
    /// <summary>
    /// Specification: <see href="https://github.com/SAFE-eV/OCMF-Open-Charge-Metering-Format/blob/master/OCMF-de.md#ablesungen"/>
    /// </summary>
    public class TimeWithSynchronizationState
    {
        /// <summary>
        /// The date and time at which a reading was created.
        /// </summary>
        public DateTimeOffset Timestamp { get; set; }

        /// <summary>
        /// The synchronization state of the clock when the reading was created.
        /// </summary>
        public ETimeSynchronizationState SynchronizationState { get; set; }
    }
}
