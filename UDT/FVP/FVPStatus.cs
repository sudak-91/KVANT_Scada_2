using Opc.UaFx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.UDT.FVP
{
    [OpcDataType("ns=3;s=DT_\"FVP_UDT\".\"Status\"")]
    [OpcDataTypeEncoding("ns=3;s=TE_\"FVP_UDT\".\"Status\"")]
    public class FVPStatus
    {
        public bool Remote {get;set;}
        public bool Auto_mode {get;set;}
        public bool Start {get;set;}
        public bool Manual_start{get;set;}
        public bool Power_On {get;set;}
        public bool Turn_On{get;set;}
        public bool Block {get;set;}
    }
}
