using Opc.Ua;
using Opc.Ua.Client;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.UDT
{
    ///<summaray>
    ///Класс AnalogValue является представлением 
    ///Целочисленной переменной OPC сервера.
    ///</summaray>
    ///<value name = "Path">Путь к переменной в OPC Сервере </value>
    ///<value name = "Value">Значение переменной </value>
    public class AnalogValue
    {
        public string Path { get; set; }
        public float Value { get; set; }

        public AnalogValue(string path)
        {
            Path = path;
        }
        public void ReadValue(ref Session session)
        {
            DataValue opcValue = session.ReadValue(NodeId.Parse(Path));
            Value = float.Parse(opcValue.Value.ToString());
        }
        public void WriteValue(ref Session session)
        {
            WriteValueCollection nodesToWrite = new WriteValueCollection();
            WriteValue bManStart = new WriteValue();
            bManStart.NodeId = new NodeId(Path);
            bManStart.AttributeId = Attributes.Value;
            bManStart.Value = new DataValue();
            bManStart.Value.Value = (float)Value;
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
