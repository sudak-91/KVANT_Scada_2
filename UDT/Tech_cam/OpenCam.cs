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
        private static string Path;
        public OpenCam(string path)
        {
            Path = path;
        }
        public static void ReadValue(ref Session session, ref OpenCam cp)
        {
            DataValue opcStage_0_Cam_prepare_stage = session.ReadValue(NodeId.Parse(Path + ".\"Stage_1_stage\""));
            DataValue opcComplete = session.ReadValue(NodeId.Parse(Path + ".\"Stage_1_done\""));
            DataValue opcAccess = session.ReadValue(NodeId.Parse(Path + ".\"Access\""));
            DataValue opcHeat_cam = session.ReadValue(NodeId.Parse(Path + ".\"Heat_cam\""));

            cp.Stage_1_stage = (UInt16)opcStage_0_Cam_prepare_stage.Value;
            cp.Stage_1_done = (bool)opcComplete.Value;
            cp.Access = (bool)opcAccess.Value;
            cp.Heat_cam = (bool)opcHeat_cam.Value;

        }
        public static void WriteInput(ref Session session, ref OpenCam cp)
        {
            WriteValueCollection nodesToWrite = new WriteValueCollection();


            WriteValue bServiceMode = new WriteValue();
            bServiceMode.NodeId = new NodeId(Path + ".\"Heat_cam\"");
            bServiceMode.AttributeId = Attributes.Value;
            bServiceMode.Value = new DataValue();
            bServiceMode.Value.Value = (bool)cp.Heat_cam;
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
