using System.Runtime.Serialization;

namespace OpenChargeMeteringFormat.Types
{
    /// <summary>
    /// Specification: <see href="https://github.com/SAFE-eV/OCMF-Open-Charge-Metering-Format/blob/master/OCMF-de.md#ablesungen"/>
    /// </summary>
    public enum ETransactionReadingReason
    {
        /// <summary>
        /// The reading was created at the begin of the transaction.
        /// </summary>
        [EnumMember(Value = "B")]
        BeginOfTransaction = 0,

        /// <summary>
        /// The reading was created during an active transaction (intermediate reading).
        /// </summary>
        [EnumMember(Value = "C")]
        Charging = 1,

        /// <summary>
        /// An error has occurred during the transaction, but the transaction is not aborted.
        /// Time and/or energy measured are unusable (from this reading on, inclusive).
        /// </summary>
        [EnumMember(Value = "X")]
        ChargingException = 2,

        /// <summary>
        /// The reading was created at the end of the transaction.
        /// </summary>
        [EnumMember(Value = "E")]
        EndOfTransaction = 3,

        /// <summary>
        /// The reading was created at the end of the transaction. The transaction was stopped locally.
        /// </summary>
        [EnumMember(Value = "L")]
        EndOfTransactionWithLocalStop = 4,

        /// <summary>
        /// The reading was created at the end of the transaction. The transaction was stopped remotely.
        /// </summary>
        [EnumMember(Value = "R")]
        EndOfTransactionWithRemoteStop = 5,

        /// <summary>
        /// The reading was created at the end of the transaction. The transaction was aborted due to an error.
        /// </summary>
        [EnumMember(Value = "A")]
        EndOfTransactionByAbortion = 6,

        /// <summary>
        /// The reading was created at the end of the transaction. The transaction was terminated due to power loss.
        /// </summary>
        [EnumMember(Value = "P")]
        EndOfTransactionByPowerLoss = 7,

        /// <summary>
        /// The transaction is still active, but the vehicle is currently not being charged (informative).
        /// </summary>
        [EnumMember(Value = "S")]
        Suspended = 8,

        /// <summary>
        /// The tariff changed.
        /// </summary>
        [EnumMember(Value = "T")]
        TariffChanged = 9,
    }
}
