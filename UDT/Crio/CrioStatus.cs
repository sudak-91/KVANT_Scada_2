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
        private static string Path;
        public CrioStatus(string path)
        {
            Path = path;
        }
        public static void ReadStatus(ref Session session, ref CrioStatus cs)
        {
            DataValue opcPowerOn = session.ReadValue(NodeId.Parse(Path + ".\"Power_ON\""));
            DataValue opcBlcoked = session.ReadValue(NodeId.Parse(Path + ".\"Blocked\""));
            DataValue opcTurnOn = session.ReadValue(NodeId.Parse(Path + ".\"Turn_ON\""));
            DataValue opcAutoMode= session.ReadValue(NodeId.Parse(Path + ".\"Automode\""));
            DataValue opcError = session.ReadValue(NodeId.Parse(Path + ".\"Error\""));

            cs.Auto_mode = (bool)opcAutoMode.Value;
            cs.Blocked = (bool)opcBlcoked.Value;
            cs.Error = (bool)opcError.Value;
            cs.Power_On = (bool)opcPowerOn.Value;
            cs.Turn_On = (bool)opcTurnOn.Value;

        }
    }

}
