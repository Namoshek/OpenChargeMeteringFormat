using System.Runtime.Serialization;

namespace OpenChargeMeteringFormat.Types
{
    public enum EIdentificationType
    {
        [EnumMember(Value = "NONE")]
        None = 0,

        [EnumMember(Value = "DENIED")]
        Denied = 1,

        [EnumMember(Value = "UNDEFINED")]
        Undefined = 2,

        [EnumMember(Value = "ISO14443")]
        ISO14443 = 10,

        [EnumMember(Value = "ISO15693")]
        ISO15693 = 11,

        [EnumMember(Value = "EMAID")]
        EMAID = 20,

        [EnumMember(Value = "EVCCID")]
        EVCCID = 21,

        [EnumMember(Value = "EVCOID")]
        EVCOID = 30,

        [EnumMember(Value = "ISO7812")]
        ISO7812 = 40,

        [EnumMember(Value = "CARD_TXN_NR")]
        CardTransactionNumber = 50,

        [EnumMember(Value = "CENTRAL")]
        Central = 60,

        [EnumMember(Value = "CENTRAL_1")]
        Central1 = 61,

        [EnumMember(Value = "CENTRAL_2")]
        Central2 = 62,

        [EnumMember(Value = "LOCAL")]
        Local = 70,

        [EnumMember(Value = "LOCAL_1")]
        Local1 = 71,

        [EnumMember(Value = "LOCAL_2")]
        Local2 = 72,

        [EnumMember(Value = "PHONE_NUMBER")]
        PhoneNumber = 80,

        [EnumMember(Value = "KEY_CODE")]
        KeyCode = 90,
    }
}
