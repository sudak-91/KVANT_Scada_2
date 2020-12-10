
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
    ///Класс IonInputCommand является представлением 
    ///OPC DataType "ns=3;s=DT_\"Ion_DB\".\"Input Command\"
    ///</summaray>
    public class IonInputCommand
    {
        public bool Start {get;set;}
        public bool Stop {get;set;}
        public bool Manual_Start{get;set;}
        public bool Manual_Stop{get;set;}
        public bool Auto_mod {get;set;}
        public bool Reset_error{get;set;}
        private static string Path;
        public IonInputCommand(string path)
        {
            Path = path;
        }

        public static void WriteInput(ref Session session, ref IonInputCommand cp)
        {
            WriteValueCollection nodesToWrite = new WriteValueCollection();


            WriteValue bManStart = new WriteValue();
            bManStart.NodeId = new NodeId(Path + ".\"Manual_Start\"");
            bManStart.AttributeId = Attributes.Value;
            bManStart.Value = new DataValue();
            bManStart.Value.Value = (bool)cp.Manual_Start;
            nodesToWrite.Add(bManStart);

            WriteValue bManStop = new WriteValue();
            bManStop.NodeId = new NodeId(Path + ".\"Manual_Stop\"");
            bManStop.AttributeId = Attributes.Value;
            bManStop.Value = new DataValue();
            bManStop.Value.Value = (bool)cp.Manual_Stop;
            nodesToWrite.Add(bManStop);

            WriteValue bAutoMode = new WriteValue();
            bAutoMode.NodeId = new NodeId(Path + ".\"Auto_mod\"");
            bAutoMode.AttributeId = Attributes.Value;
            bAutoMode.Value = new DataValue();
            bAutoMode.Value.Value = (bool)cp.Auto_mod;
            nodesToWrite.Add(bAutoMode);


            WriteValue bResetError = new WriteValue();
            bResetError.NodeId = new NodeId(Path + ".\"Reset_Error\"");
            bResetError.AttributeId = Attributes.Value;
            bResetError.Value = new DataValue();
            bResetError.Value.Value = (bool)cp.Reset_error;
            nodesToWrite.Add(bResetError);

            


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
