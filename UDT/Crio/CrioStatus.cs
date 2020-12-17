using Opc.Ua;
using Opc.Ua.Client;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.UDT.Crio
{
   
    public class CrioStatus
    {
        public bool Power_On { get; set; }
        public bool Blocked { get; set; }
        public bool Turn_On { get; set; }
        public bool Auto_mode { get; set; }
        public bool Error { get; set; }
        private  string Path;
        public CrioStatus(string path)
        {
            Path = path;
        }
        public  void ReadStatus(ref Session session)
        {
            DataValue opcPowerOn = session.ReadValue(NodeId.Parse(Path + ".\"Power_ON\""));
            DataValue opcBlcoked = session.ReadValue(NodeId.Parse(Path + ".\"Blocked\""));
            DataValue opcTurnOn = session.ReadValue(NodeId.Parse(Path + ".\"Turn_ON\""));
            DataValue opcAutoMode= session.ReadValue(NodeId.Parse(Path + ".\"Automode\""));
            DataValue opcError = session.ReadValue(NodeId.Parse(Path + ".\"Error\""));

            this.Auto_mode = (bool)opcAutoMode.Value;
            this.Blocked = (bool)opcBlcoked.Value;
            this.Error = (bool)opcError.Value;
            this.Power_On = (bool)opcPowerOn.Value;
            this.Turn_On = (bool)opcTurnOn.Value;

        }
    }

}
