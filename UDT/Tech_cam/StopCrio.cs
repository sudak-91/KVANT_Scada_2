
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.UDT.Tech_cam
{

    ///<summaray>
    ///Класс StopCrio является представлением 
    ///OPC DataType "ns=3;s=DT_\"Stopcr\"
    ///</summaray>
    public class StopCrio
    {
        public UInt16 Stage_2_Stage { get; set; }
        public bool Access { get; set; }
        public bool Stage_2_Return { get; set; }
        public bool Stage_2_done { get; set; }

    }
}
