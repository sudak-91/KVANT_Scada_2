using Opc.Ua;
using Opc.Ua.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.UDT.ELI_Shutter
{
    public class Shutter
    {
        public bool AutoMode { get; set; }
        public bool ManualOpen { get; set; }
        public bool ManualClose { get; set; }
        public bool Closed { get; set; }
        public bool Opened { get; set; }
        public string Path;
        public Shutter(string path)
        {
            Path = path;
        }
        public void ReadValue(ref Session session)
        {
            DataValue opcAutoMode = session.ReadValue(NodeId.Parse(Path + ".\"Auto_MOD\""));
            DataValue opcManualOpen = session.ReadValue(NodeId.Parse(Path + ".\"manual_open\""));
            DataValue opcManualClose = session.ReadValue(NodeId.Parse(Path + ".\"manual_close\""));
            DataValue opcClosed = session.ReadValue(NodeId.Parse(Path + ".\"Opened\""));
            DataValue opcOpened = session.ReadValue(NodeId.Parse(Path + ".\"Closed\""));
        }
        public void WriteValue(ref Session session)
        {
            WriteValueCollection nodesToWrite = new WriteValueCollection();


            WriteValue bAutoMode = new WriteValue();
            bAutoMode.NodeId = new NodeId(Path + ".\"Auto_MOD\"");
            bAutoMode.AttributeId = Attributes.Value;
            bAutoMode.Value = new DataValue();
            bAutoMode.Value.Value = (bool)this.AutoMode;
            nodesToWrite.Add(bAutoMode);

            WriteValue bManualOpen = new WriteValue();
            bManualOpen.NodeId = new NodeId(Path + ".\"manual_open\"");
            bManualOpen.AttributeId = Attributes.Value;
            bManualOpen.Value = new DataValue();
            bManualOpen.Value.Value = (bool)this.AutoMode;
            nodesToWrite.Add(bManualOpen);

            WriteValue bManualClose = new WriteValue();
            bManualClose.NodeId = new NodeId(Path + ".\"manual_open\"");
            bManualClose.AttributeId = Attributes.Value;
            bManualClose.Value = new DataValue();
            bManualClose.Value.Value = (bool)this.AutoMode;
            nodesToWrite.Add(bManualClose);

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
