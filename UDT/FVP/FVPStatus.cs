using Opc.Ua;
using Opc.Ua.Client;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.UDT.FVP
{
   
    public class FVPStatus
    {
        public bool Remote {get;set;}
        public bool Auto_mode {get;set;}
        public bool Start {get;set;}
        public bool Manual_start{get;set;}
        public bool Power_On {get;set;}
        public bool Turn_On{get;set;}
        public bool Block {get;set;}
        private static string Path;

        public FVPStatus(string path)
        {
            Path = path;
        }
        public static void ReadValue(ref Session session, ref FVPStatus fs)
        {
            DataValue opcRemote = session.ReadValue(NodeId.Parse(Path + ".\"Remote\""));
            DataValue opcAutoMode = session.ReadValue(NodeId.Parse(Path + ".\"Auto_mode\""));
            DataValue opcStart = session.ReadValue(NodeId.Parse(Path + ".\"Start\""));
            DataValue opcManualStart = session.ReadValue(NodeId.Parse(Path + ".\"Manual_start\""));
            DataValue opcPowerOn = session.ReadValue(NodeId.Parse(Path + ".\"Power_on\""));
            DataValue opcTurnOn = session.ReadValue(NodeId.Parse(Path + ".\"Turn_on\""));
            DataValue opcBlock = session.ReadValue(NodeId.Parse(Path + ".\"Block\""));
            fs.Auto_mode = (bool)opcAutoMode.Value;
            fs.Block = (bool)opcBlock.Value;
            fs.Manual_start = (bool)opcManualStart.Value;
            fs.Power_On = (bool)opcPowerOn.Value;
            fs.Remote = (bool)opcRemote.Value;
            fs.Start = (bool)opcStart.Value;
            fs.Turn_On = (bool)opcTurnOn.Value;



        }
        public static void WriteInput(ref Session session, ref FVPStatus fs)
        {
            WriteValueCollection nodesToWrite = new WriteValueCollection();


            WriteValue bRemote = new WriteValue();
            bRemote.NodeId = new NodeId(Path + ".\"Remote\"");
            bRemote.AttributeId = Attributes.Value;
            bRemote.Value = new DataValue();
            bRemote.Value.Value = (bool)fs.Remote;
            nodesToWrite.Add(bRemote);


            WriteValue bAutoMode = new WriteValue();
            bAutoMode.NodeId = new NodeId(Path + ".\"Auto_mode\"");
            bAutoMode.AttributeId = Attributes.Value;
            bAutoMode.Value = new DataValue();
            bAutoMode.Value.Value = (bool)fs.Auto_mode;
            nodesToWrite.Add(bAutoMode);

            WriteValue bManCommand = new WriteValue();
            bManCommand.NodeId = new NodeId(Path + ".\"Manual_start\"");
            bManCommand.AttributeId = Attributes.Value;
            bManCommand.Value = new DataValue();
            bManCommand.Value.Value = (bool)fs.Manual_start;
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
