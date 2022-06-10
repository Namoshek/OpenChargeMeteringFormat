using System;

namespace OpenChargeMeteringFormat.Types
{
    public class TimeWithSynchronizationState
    {
        public DateTimeOffset Timestamp { get; set; }

        public ETimeSynchronizationState SynchronizationState { get; set; }
    }
}
