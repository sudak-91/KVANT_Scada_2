using Opc.UaFx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.UDT.Tech_cam
{
    [OpcDataType("ns=3;s=DT_\"CP_check\"")]
    [OpcDataTypeEncoding("ns=3;s=TE_\"CP_check\"")]
    public class CrioPumpStart
    {
        public float Crio_pressure_check_SP { get; set; }
        public float Crio_pressure_calc_value { get; set; }
        public float Crio_pressure_diff { get; set; }
        public float Temperature_SP { get; set; }
        public UInt16 Stage_0_Stage { get; set; }
        public bool Access { get; set; }
        public bool Return_error { get; set; }
        public bool Stage_0_CompliteP { get; set; }

    }
}
