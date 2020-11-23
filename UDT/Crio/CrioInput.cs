using Opc.UaFx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.UDT.Crio
{
    [OpcDataType("ns=3;s=DT_\"Crio_pump\".\"Input\"")]
    [OpcDataTypeEncoding("ns=3;s=TE_\"Crio_pump\".\"Input\"")]
    public class CrioInput
    {
        public bool Auto_mode { get; set; }
        public bool Command_manual { get; set; }

        public CrioInput() { }
    }
}
