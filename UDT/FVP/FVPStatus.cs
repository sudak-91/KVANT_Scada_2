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
        private  string Path;

        public FVPStatus(string path)
        {
            Path = path;
        }
        public  void ReadValue(ref Session session)
        {
            DataValue opcRemote = session.ReadValue(NodeId.Parse(Path + ".\"Remote\""));
            DataValue opcAutoMode = session.ReadValue(NodeId.Parse(Path + ".\"Auto_mode\""));
            DataValue opcStart = session.ReadValue(NodeId.Parse(Path + ".\"Start\""));
            DataValue opcManualStart = session.ReadValue(NodeId.Parse(Path + ".\"Manual_start\""));
            DataValue opcPowerOn = session.ReadValue(NodeId.Parse(Path + ".\"Power_on\""));
            DataValue opcTurnOn = session.ReadValue(NodeId.Parse(Path + ".\"Turn_on\""));
            DataValue opcBlock = session.ReadValue(NodeId.Parse(Path + ".\"Block\""));
            this.Auto_mode = (bool)opcAutoMode.Value;
            this.Block = (bool)opcBlock.Value;
            this.Manual_start = (bool)opcManualStart.Value;
            this.Power_On = (bool)opcPowerOn.Value;
            this.Remote = (bool)opcRemote.Value;
            this.Start = (bool)opcStart.Value;
            this.Turn_On = (bool)opcTurnOn.Value;



        }
        public  void WriteInput(ref Session session)
        {
            WriteValueCollection nodesToWrite = new WriteValueCollection();


            WriteValue bRemote = new WriteValue();
            bRemote.NodeId = new NodeId(Path + ".\"Remote\"");
            bRemote.AttributeId = Attributes.Value;
            bRemote.Value = new DataValue();
            bRemote.Value.Value = (bool)this.Remote;
            nodesToWrite.Add(bRemote);


            WriteValue bAutoMode = new WriteValue();
            bAutoMode.NodeId = new NodeId(Path + ".\"Auto_mode\"");
            bAutoMode.AttributeId = Attributes.Value;
            bAutoMode.Value = new DataValue();
            bAutoMode.Value.Value = (bool)this.Auto_mode;
            nodesToWrite.Add(bAutoMode);

            WriteValue bManCommand = new WriteValue();
            bManCommand.NodeId = new NodeId(Path + ".\"Manual_start\"");
            bManCommand.AttributeId = Attributes.Value;
            bManCommand.Value = new DataValue();
            bManCommand.Value.Value = (bool)this.Manual_start;
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
