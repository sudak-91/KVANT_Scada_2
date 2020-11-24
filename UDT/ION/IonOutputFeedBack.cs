using Opc.UaFx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.UDT.ION
{
    [OpcDataType("ns=3;s=TD_\"IonOutpuFeedback\"")]
    [OpcDataTypeEncoding("ns=3;s=TE_\"IonOutpuFeedback\"")]
    ///<summaray>
    ///Класс IonOutput Feedback является представлением 
    ///OPC DataType "ns=3;s=DT_\"Ion_DB\".\"Output_FeedBack\"
    ///</summaray>
    public class IonOutputFeedBack
    {
        public float Anod_I { get; set; }
        public float Anod_U { get; set; }
        public float Anod_P { get; set; }
        public float Heat_I { get; set; }
        public float Heat_U { get; set; }
        public float Heat_P { get; set; }
    }
}
