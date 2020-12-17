
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opc.Ua;
using Opc.Ua.Client;

namespace KVANT_Scada_2.UDT.Valve
{
    
    ///<summaray>
    ///Класс ValveStatus является представлением 
    ///OPC DataType "ns=3;s=DT_\"valve\".\"Status\"
    ///</summaray>
    public class ValveStatus
    {
        public bool Auto_mode { get; set; }
        public bool Opened { get; set; }
        public bool Closed { get; set; }
        public bool Opening { get; set; }
        public bool Closing { get; set; }
        public bool Blocked { get; set; }
        public bool Serviced { get; set; }
        private string Path;

        public ValveStatus(string path)
        {
            Path = path;

        }
        public  void  ReadValue(ref Session session)
        {
            DataValue opcAuto = session.ReadValue(NodeId.Parse(Path+".\"Auto_mode\""));
            DataValue opcOpened = session.ReadValue(NodeId.Parse(Path + ".\"Opened\""));
            DataValue opcClosed = session.ReadValue(NodeId.Parse(Path + ".\"Closed\""));
            DataValue opcOpening = session.ReadValue(NodeId.Parse(Path + ".\"Opening\""));
            DataValue opcClosing = session.ReadValue(NodeId.Parse(Path + ".\"Closing\""));
            DataValue opcBlocked = session.ReadValue(NodeId.Parse(Path + ".\"Blocked\""));
            DataValue opcServiced = session.ReadValue(NodeId.Parse(Path + ".\"Serviced\""));
            this.Auto_mode =(bool) opcAuto.Value;
            this.Blocked = (bool)opcBlocked.Value;
            this.Closed = (bool)opcClosed.Value;
            this.Closing = (bool)opcClosing.Value;
            this.Opened = (bool)opcOpened.Value;
            this.Opening = (bool)opcOpening.Value;
            this.Serviced = (bool)opcServiced.Value;
            


        }
      

    }
}
