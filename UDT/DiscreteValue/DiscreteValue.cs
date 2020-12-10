using Opc.Ua;
using Opc.Ua.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.UDT.DiscreteValue
{
    ///<summaray>
    ///Класс DiscreteValue является представлением 
    ///Целочисленной переменной OPC сервера.
    ///</summaray>
    ///<value name = "Path">Путь к переменной в OPC Сервере </value>
    ///<value name = "Value">Значение переменной </value>
    public class DiscreteValue
    {
        public string Path { get; set; }
        public bool Value { get; set; }

        public DiscreteValue(string path)
        {
            Path = path;
        }


        public void ReadValue(ref Session session)
        {
            DataValue opcValue = session.ReadValue(NodeId.Parse(Path));
            Value = (bool)opcValue.Value;
        }
        public void WriteValue(ref Session session)
        {
            WriteValueCollection nodesToWrite = new WriteValueCollection();
            WriteValue bManStart = new WriteValue();
            bManStart.NodeId = new NodeId(Path);
            bManStart.AttributeId = Attributes.Value;
            bManStart.Value = new DataValue();
            bManStart.Value.Value = (bool)Value;
            nodesToWrite.Add(bManStart);

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
