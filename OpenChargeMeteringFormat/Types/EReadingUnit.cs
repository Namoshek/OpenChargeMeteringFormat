using System.Runtime.Serialization;

namespace OpenChargeMeteringFormat.Types
{
    public enum EReadingUnit
    {
        [EnumMember(Value = "Wh")]
        Watthour = 0,

        [EnumMember(Value = "kWh")]
        KiloWatthour = 1,
    }
}
