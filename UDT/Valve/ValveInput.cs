using Opc.Ua;
using Opc.Ua.Client;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.UDT.Valve
{
  

    ///<summaray>
    ///Класс ValveInput является представлением 
    ///OPC DataType "ns=3;s=DT_\"valve\".\"Input\"
    ///</summaray>
    public class ValveInput
    {
        public bool Service_mode { get; set; }
        public bool Auto_mode { get; set; }
        public bool Man_command { get; set; }
        public bool Open_close { get; set; } 
        public bool Block { get; set; }
        public bool Opened_signal { get; set; }
        public bool Closed_signal { get; set; }
        private string Path;
        

        public ValveInput(string path)
        {
            Path = path;
        }

        public  void WriteValveInput(ref Session session)
        {
            WriteValueCollection nodesToWrite = new WriteValueCollection();

           
            WriteValue bServiceMode = new WriteValue();
            bServiceMode.NodeId = new NodeId(Path+".\"ServiceMode\"");
            bServiceMode.AttributeId = Attributes.Value;
            bServiceMode.Value = new DataValue();
            bServiceMode.Value.Value = (bool)this.Service_mode;
            nodesToWrite.Add(bServiceMode);

            
            WriteValue bAutoMode = new WriteValue();
            bAutoMode.NodeId = new NodeId(Path + ".\"AutoMode\"");
            bAutoMode.AttributeId = Attributes.Value;
            bAutoMode.Value = new DataValue();
            bAutoMode.Value.Value = (bool)this.Auto_mode;
            nodesToWrite.Add(bAutoMode);

            WriteValue bManCommand = new WriteValue();
            bManCommand.NodeId = new NodeId(Path + ".\"ManCommand\"");
            bManCommand.AttributeId = Attributes.Value;
            bManCommand.Value = new DataValue();
            bManCommand.Value.Value = (bool)this.Man_command;
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
        public string getpath()
        {
            return this.Path;
        }


    }

}
