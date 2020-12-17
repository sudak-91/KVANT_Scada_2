
using Opc.Ua;
using Opc.Ua.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.UDT.ION
{

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
        private  string Path;
        public IonInputSetPoint(string path)
        {
            Path = path;   
        }
        public void ReadValue(ref Session session)
        {
            DataValue opcAnod_I = session.ReadValue(NodeId.Parse(Path + ".\"Anod_I_SP\""));
            DataValue opcAnod_U = session.ReadValue(NodeId.Parse(Path + ".\"Anod_U_SP\""));
            DataValue opcAnod_P = session.ReadValue(NodeId.Parse(Path + ".\"Anod_P_SP\""));
            DataValue opcHeat_I = session.ReadValue(NodeId.Parse(Path + ".\"Heat_I_SP\""));
            DataValue opcHeat_U = session.ReadValue(NodeId.Parse(Path + ".\"Heat_U_SP\""));
            DataValue opcHeat_P = session.ReadValue(NodeId.Parse(Path + ".\"Heat_P_SP\""));
            this.Anod_I_SP = (float)opcAnod_I.Value;
            this.Anod_P_SP = (float)opcAnod_P.Value;
            this.Anod_U_SP = (float)opcAnod_U.Value;
            this.Heat_I_SP = (float)opcHeat_I.Value;
            this.Heat_P_SP = (float)opcHeat_P.Value;
            this.Heat_U_SP = (float)opcHeat_U.Value;

        }
        public  void WriteInput(ref Session session, ref IonInputSetPoint cp)
        {
            WriteValueCollection nodesToWrite = new WriteValueCollection();


            WriteValue bAnodISp = new WriteValue();
            bAnodISp.NodeId = new NodeId(Path + ".\"Anod_I_SP\"");
            bAnodISp.AttributeId = Attributes.Value;
            bAnodISp.Value = new DataValue();
            bAnodISp.Value.Value = (float)cp.Anod_I_SP;
            nodesToWrite.Add(bAnodISp);

            WriteValue bAnodUSp = new WriteValue();
            bAnodUSp.NodeId = new NodeId(Path + ".\"Anod_U_SP\"");
            bAnodUSp.AttributeId = Attributes.Value;
            bAnodUSp.Value = new DataValue();
            bAnodUSp.Value.Value = (float)cp.Anod_U_SP;
            nodesToWrite.Add(bAnodUSp);

            WriteValue bAnodPSp = new WriteValue();
            bAnodPSp.NodeId = new NodeId(Path + ".\"Anod_P_SP\"");
            bAnodPSp.AttributeId = Attributes.Value;
            bAnodPSp.Value = new DataValue();
            bAnodPSp.Value.Value = (float)cp.Anod_P_SP;
            nodesToWrite.Add(bAnodPSp);


            WriteValue bHeatISp = new WriteValue();
            bHeatISp.NodeId = new NodeId(Path + ".\"Heat_I_SP\"");
            bHeatISp.AttributeId = Attributes.Value;
            bHeatISp.Value = new DataValue();
            bHeatISp.Value.Value = (float)cp.Heat_I_SP;
            nodesToWrite.Add(bHeatISp);

            WriteValue bHeatUSp = new WriteValue();
            bHeatUSp.NodeId = new NodeId(Path + ".\"Heat_U_SP\"");
            bHeatUSp.AttributeId = Attributes.Value;
            bHeatUSp.Value = new DataValue();
            bHeatUSp.Value.Value = (float)cp.Heat_U_SP;
            nodesToWrite.Add(bHeatUSp);

            WriteValue bHeatPSp = new WriteValue();
            bHeatPSp.NodeId = new NodeId(Path + ".\"Heat_P_SP\"");
            bHeatPSp.AttributeId = Attributes.Value;
            bHeatPSp.Value = new DataValue();
            bHeatPSp.Value.Value = (float)cp.Heat_P_SP;
            nodesToWrite.Add(bHeatPSp);



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
