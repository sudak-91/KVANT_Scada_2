using Opc.UaFx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.UDT.ION
{
    [OpcDataType("ns=3;s=TD_\"InputSetPoint\"")]
   
    [OpcDataTypeEncoding("ns=3;s=TE_\"InputSetPoint\"")]
    ///<summaray>
    ///Класс IonInputSetPoint является представлением 
    ///OPC DataType "ns=3;s=DT_\"Ion_DB\".\"Input_Set_Point\"
    ///</summaray>
    public class IonInputSetPoint
    {
        public float Anod_I_SP { get; set; }
        public float Anod_U_SP { get; set; }
        public float Anod_P_SP { get; set; }
        public float Heat_I_SP { get; set; }
        public float Heat_U_SP { get; set; }
        public float Heat_P_SP { get; set; }
    }
}
