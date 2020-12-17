using Opc.Ua;
using Opc.Ua.Client;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.UDT.Tech_cam
{
    
    ///<summaray>
    ///Класс CamPrepare является представлением 
    ///OPC DataType "ns=3;s=DT_\"Cam_Prepare\"
    ///</summaray>
    public class CamPrepare
    {
        public float Open_FVV_B_pressure { get; set; }
        public float Open_SHV_pressure { get; set; }
        public float Finally_pressure { get; set; }
        public UInt16 Stage_0_Cam_prepare_Stage { get; set; }
        public bool Access { get; set; }
        public bool Stage_0_Cam_prepare_Complite { get; set; }
        public bool Return_ERROR { get; set; }
        private static string Path;
        public CamPrepare(string path)
        {
            Path = path;
        }

        public void ReadValue(ref Session session)
        {
            DataValue opcStage_0_Cam_prepare_stage = session.ReadValue(NodeId.Parse(Path + ".\"Stage_0_Cam_prepare_Stage\""));
            DataValue opcComplete = session.ReadValue(NodeId.Parse(Path + ".\"Stage_0_Cam_prepare_Complite\""));
            DataValue opcAccess = session.ReadValue(NodeId.Parse(Path + ".\"Access\""));
        
            this.Stage_0_Cam_prepare_Stage = (UInt16)opcStage_0_Cam_prepare_stage.Value;
            this.Stage_0_Cam_prepare_Complite = (bool)opcComplete.Value;
            this.Access = (bool)opcAccess.Value;



        }
    }
}
