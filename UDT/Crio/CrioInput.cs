using Opc.UaFx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.UDT.Crio
{
    [OpcDataType("ns=3;s=DT_\"CrioInput\"")]
    [OpcDataTypeEncoding("ns=3;s=TE_\"CrioInput\"")]
    public class CrioInput
    {
        public bool Auto_mode { get; set; }
        public bool Command_manual { get; set; }
        public bool Command_auto { get; set; }
        public bool Block { get; set; }
        public bool Power_on { get; set; }
        public bool Switch_on { get; set; }

    }
}
