using Opc.UaFx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.UDT.Crio
{
    [OpcDataType("ns=3;s=DT_\"Crio_pump\".\"Status\"")]
    [OpcDataTypeEncoding("ns=3;s=TE_\"Crio_pump\".\"Status\"")]
    public class CrioStatus
    {
        public bool Power_On { get; set; }
        public bool Blocked { get; set; }
        public bool Turn_On { get; set; }
        public bool Auto_mode { get; set; }
        public bool Error { get; set; }
    }
}
