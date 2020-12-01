using Opc.UaFx;
using Opc.UaFx.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.UDT.Valve
{
    [OpcDataType("ns=3;s=DT_\"ValveInput\"")]
    [OpcDataTypeEncoding("ns=3;s=TE_\"ValveInput\"")]

    ///<summaray>
    ///Класс ValveInput является представлением 
    ///OPC DataType "ns=3;s=DT_\"valve\".\"Input\"
    ///</summaray>
    public class ValveInput
    {
        public bool Service_mode { get; set; }
        public bool Auto_mode { get; set; }
        public bool Man_command { get; set; }
        public bool Open_close { get; set; } 
        public bool Block { get; set; }
        public bool Opened_signal { get; set; }
        public bool Closed_signal { get; set; }

}

}
