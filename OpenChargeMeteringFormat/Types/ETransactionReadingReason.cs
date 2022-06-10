using System.Runtime.Serialization;

namespace OpenChargeMeteringFormat.Types
{
    public enum ETransactionReadingReason
    {
        [EnumMember(Value = "B")]
        BeginOfTransaction = 0,

        [EnumMember(Value = "C")]
        Charging = 1,

        [EnumMember(Value = "X")]
        ChargingException = 2,

        [EnumMember(Value = "E")]
        EndOfTransaction = 3,

        [EnumMember(Value = "L")]
        EndOfTransactionWithLocalStop = 4,

        [EnumMember(Value = "R")]
        EndOfTransactionWithRemoteStop = 5,

        [EnumMember(Value = "A")]
        EndOfTransactionByAbortion = 6,

        [EnumMember(Value = "P")]
        EndOfTransactionByPowerLoss = 7,

        [EnumMember(Value = "S")]
        Suspended = 8,

        [EnumMember(Value = "T")]
        TariffChanged = 9,
    }
}
