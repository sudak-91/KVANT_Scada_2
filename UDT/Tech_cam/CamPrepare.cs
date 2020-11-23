using Opc.UaFx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.UDT.Tech_cam
{
    [OpcDataType("ns=3;s=DT_\"Cam_Prepare\"")]
    [OpcDataTypeEncoding("ns=3;s=TE_\"Cam_Prepare\"")]
    public class CamPrepare
    {
        public float Open_FVV_B_pressure { get; set; }
        public float Open_SHV_pressure { get; set; }
        public float Finally_pressure { get; set; }
        public UInt16 Stage_0_Cam_prepare_Stage { get; set; }
        public bool Access { get; set; }
        public bool Stage_0_Cam_prepare_Complite { get; set; }
        public bool Return_ERROR { get; set; }

    }
}
