using Opc.UaFx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.UDT.ION
{
    [OpcDataType("ns=3;s=DT_\"Ion_DB\".\"Status\"")]
    [OpcDataTypeEncoding("ns=3;s=TE_\"Ion_DB\".\"status\"")]
    ///<summaray>
    ///Класс IonStatus является представлением 
    ///OPC DataType "ns=3;s=DT_\"Ion_DB\".\"Status\"
    ///</summaray>
    public class IonStatus
    {
        public bool Auto_mode {get;set;}
        public bool Power_on { get; set;}
        public bool Turn_On { get; set; }
        public bool Interlock { get; set; }
        public bool Failure { get; set; }
        public bool Power_Failure { get; set; }
        public bool Temperature_Failure { get; set; }
        public bool Repeat_Failure { get; set; }
        public bool Filament_Failure { get; set; }
        public bool Turn_off { get; set; }
        public bool Emergancy_Stop { get; set; }
        public bool Power_Stop { get; set; }
        public bool Temperature_Stop { get; set; }
        public bool Other_Failure { get; set; }

    }
}
