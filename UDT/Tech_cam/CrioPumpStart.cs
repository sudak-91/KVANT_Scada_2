
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
    ///Класс CrioPumpStart является представлением 
    ///OPC DataType "ns=3;s=DT_\"CP_check\"""
    ///</summaray>
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
        private static string Path;
        public CrioPumpStart(string path)
        {
            Path = path;
        }
        public void ReadValue(ref Session session)
        {
            DataValue opcStage_0_Cam_prepare_stage = session.ReadValue(NodeId.Parse(Path + ".\"Stage_0_Stage\""));
            DataValue opcComplete = session.ReadValue(NodeId.Parse(Path + ".\"Stage_0_Complite\""));
            DataValue opcAccess = session.ReadValue(NodeId.Parse(Path + ".\"Access\""));

            this.Stage_0_Stage = (UInt16)opcStage_0_Cam_prepare_stage.Value;
            this.Stage_0_CompliteP = (bool)opcComplete.Value;
            this.Access = (bool)opcAccess.Value;

        }
        public  void WriteInput(ref Session session)
        {
            WriteValueCollection nodesToWrite = new WriteValueCollection();


            WriteValue bServiceMode = new WriteValue();
            bServiceMode.NodeId = new NodeId(Path + ".\"Stage_0_Stage\"");
            bServiceMode.AttributeId = Attributes.Value;
            bServiceMode.Value = new DataValue();
            bServiceMode.Value.Value = (UInt16)this.Stage_0_Stage;
            nodesToWrite.Add(bServiceMode);

       


            // String Node - Objects\CTT\Scalar\Scalar_Static\String


            // Write the node attributes
            StatusCodeCollection results = null;
            DiagnosticInfoCollection diagnosticInfos;
            Console.WriteLine("Writing nodes...");

            // Call Write Service
            session.Write(null,
                            nodesToWrite,
                            out results,
                            out diagnosticInfos);

        }


    }
}
