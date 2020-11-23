using Opc.UaFx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.UDT.Tech_cam
{
    [OpcDataType("ns=3;s=DT_\"Stop_FVP\"")]
    [OpcDataTypeEncoding("ns=3;s=TE_\"Stop_FVP\"")]
    public class StopFVP
    {
        public bool Access { get; set; }
        public bool Stage_3_Return { get; set; }
        public bool Stage_3_Done { get; set; }

    }
}
