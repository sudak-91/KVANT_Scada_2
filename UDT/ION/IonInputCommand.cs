using Opc.UaFx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.UDT.ION
{
    [OpcDataType("ns=3;s=DT_\"Ion_DB\".\"Input Command\"")]
    [OpcDataTypeEncoding("ns=3;s=TE_\"Ion_DB\".\"Input Command\"")]
    ///<summaray>
    ///Класс IonInputCommand является представлением 
    ///OPC DataType "ns=3;s=DT_\"Ion_DB\".\"Input Command\"
    ///</summaray>
    public class IonInputCommand
    {
        public bool Start {get;set;}
        public bool Stop {get;set;}
        public bool Manual_Start{get;set;}
        public bool Manual_Stop{get;set;}
        public bool Auto_mod {get;set;}
        public bool Reset_error{get;set;}
    }
}
