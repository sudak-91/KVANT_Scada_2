using Opc.Ua;
using Opc.Ua.Client;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.UDT.Crio
{
   
    public class CrioInput
    {
        public bool Auto_mode { get; set; }
        public bool Command_manual { get; set; }
        public bool Command_auto { get; set; }
        public bool Block { get; set; }
        public bool Power_on { get; set; }
        public bool Switch_on { get; set; }
        private static string Path;
        public CrioInput(string path)
        {
            Path = path;
        }
        public static void WriteCrioInput(ref Session session, ref CrioInput ci)
        {
            WriteValueCollection nodesToWrite = new WriteValueCollection();


            WriteValue bAutoMode = new WriteValue();
            bAutoMode.NodeId = new NodeId(Path + ".\"Auto_mode\"");
            bAutoMode.AttributeId = Attributes.Value;
            bAutoMode.Value = new DataValue();
            bAutoMode.Value.Value = (bool)ci.Auto_mode;
            nodesToWrite.Add(bAutoMode);


            

            WriteValue bManCommand = new WriteValue();
            bManCommand.NodeId = new NodeId(Path + ".\"Command_manual\"");
            bManCommand.AttributeId = Attributes.Value;
            bManCommand.Value = new DataValue();
            bManCommand.Value.Value = (bool)ci.Command_manual;
            nodesToWrite.Add(bManCommand);

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
