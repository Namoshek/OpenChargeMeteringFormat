using System;
using System.Collections.Generic;
using System.Text;

namespace OpenChargeMeteringFormat.Types
{
    public class OpenChargeMeteringFormatMessage
    {
        public OpenChargeMeteringFormatPayload Payload { get; set; }

        public OpenChargeMeteringFormatSignature Signature { get; set; }
    }
}
