using System.Runtime.Serialization;

namespace OpenChargeMeteringFormat.Types
{
    /// <summary>
    /// Specification: <see href="https://github.com/SAFE-eV/OCMF-Open-Charge-Metering-Format/blob/master/OCMF-de.md#typ"/>
    /// </summary>
    public enum EIdentificationType
    {
        /// <summary>
        /// No user identification given.
        /// </summary>
        [EnumMember(Value = "NONE")]
        None = 0,

        /// <summary>
        /// The user identification is currently not retrievable, e.g. due to 2-factor authentication.
        /// </summary>
        [EnumMember(Value = "DENIED")]
        Denied = 1,

        /// <summary>
        /// The identification type is not further specified.
        /// </summary>
        [EnumMember(Value = "UNDEFINED")]
        Undefined = 2,

        /// <summary>
        /// UID of an RFID-card as specified by ISO-14443 (4 or 7 bytes represented in HEX).
        /// </summary>
        [EnumMember(Value = "ISO14443")]
        ISO14443 = 10,

        /// <summary>
        /// UID of an RFID-card as specified by ISO-15693 (8 bytes represented in HEX).
        /// </summary>
        [EnumMember(Value = "ISO15693")]
        ISO15693 = 11,

        /// <summary>
        /// Electro Mobility Account ID as per ISO/IEC 15118 (string, 14 or 15 characters long).
        /// </summary>
        [EnumMember(Value = "EMAID")]
        EMAID = 20,

        /// <summary>
        /// The ID of an electric vehicle as per SO/IEC 15118 (string, max 6 characters long).
        /// </summary>
        [EnumMember(Value = "EVCCID")]
        EVCCID = 21,

        /// <summary>
        /// Electric Vehicle Contract ID as per DIN 91286.
        /// </summary>
        [EnumMember(Value = "EVCOID")]
        EVCOID = 30,

        /// <summary>
        /// Identification Card Format as per ISO/IEC 7812 (i.e. credit and debit cards).
        /// </summary>
        [EnumMember(Value = "ISO7812")]
        ISO7812 = 40,

        /// <summary>
        /// Transaction number of a credit or debit card used to pay for a session.
        /// </summary>
        [EnumMember(Value = "CARD_TXN_NR")]
        CardTransactionNumber = 50,

        /// <summary>
        /// Centrally generated ID, no format specified (e.g. UUID). Used for OCPP 2.0.
        /// </summary>
        [EnumMember(Value = "CENTRAL")]
        Central = 60,

        /// <summary>
        /// Centrally generated ID for session starts using an SMS, no format specified (used up until OCPP 1.6).
        /// </summary>
        [EnumMember(Value = "CENTRAL_1")]
        Central1 = 61,

        /// <summary>
        /// Centrally generated ID for session starts by the operator, no format specified (used up until OCPP 1.6).
        /// </summary>
        [EnumMember(Value = "CENTRAL_2")]
        Central2 = 62,

        /// <summary>
        /// Locally generated ID, no format specified (e.g. UUID). Used for OCPP 2.0.
        /// </summary>
        [EnumMember(Value = "LOCAL")]
        Local = 70,

        /// <summary>
        /// Locally by the charge point generated ID, no format specified (used up until OCPP 1.6).
        /// </summary>
        [EnumMember(Value = "LOCAL_1")]
        Local1 = 71,

        /// <summary>
        /// Locally generated ID, no format specified (used up until OCPP 1.6).
        /// </summary>
        [EnumMember(Value = "LOCAL_2")]
        Local2 = 72,

        /// <summary>
        /// An international phone number, starting with a leading <c>+</c> for the international area code.
        /// </summary>
        [EnumMember(Value = "PHONE_NUMBER")]
        PhoneNumber = 80,

        /// <summary>
        /// A private key-code which uniquely identifies a user. No format specified.
        /// </summary>
        [EnumMember(Value = "KEY_CODE")]
        KeyCode = 90,
    }
}
