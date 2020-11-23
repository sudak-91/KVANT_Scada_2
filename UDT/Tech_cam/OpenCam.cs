using Opc.UaFx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.UDT.Tech_cam
{
    [OpcDataType("ns=3;s=DT_\"Open_Cam\"")]
    [OpcDataTypeEncoding("ns=3;s=TE_\"Open_Cam\"")]
    ///<summaray>
    ///Класс OpenCam является представлением 
    ///OPC DataType "ns=3;s=DT_\"Open_Cam\"
    ///</summaray>
    public class OpenCam
    {
        public UInt16 Stage_1_stage { get; set; }
        public bool Access { get; set; }
        public bool Stage_1_Return { get; set; }
        public bool Stage_1_done { get; set; }
        public bool Heat_cam { get; set; }

    }
}
