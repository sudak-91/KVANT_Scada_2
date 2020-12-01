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
    [OpcDataType("ns=3;s=TD_\"valve\".\"Status\"")]
    [OpcDataTypeEncoding("ns=3;s=TE_\"valve\".\"Status\"")]
    ///<summaray>
    ///Класс ValveStatus является представлением 
    ///OPC DataType "ns=3;s=DT_\"valve\".\"Status\"
    ///</summaray>
    public class ValveStatus
    {
        public bool Auto_mode { get; set; }
        public bool Opened { get; set; }
        public bool Closed { get; set; }
        public bool Opening { get; set; }
        public bool Closing { get; set; }
        public bool Blocked { get; set; }
        public bool Serviced { get; set; }
      

    }
}
