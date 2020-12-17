
using Opc.Ua;
using Opc.Ua.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.UDT.ION
{

    ///<summaray>
    ///Класс IonOutput Feedback является представлением 
    ///OPC DataType "ns=3;s=DT_\"Ion_DB\".\"Output_FeedBack\"
    ///</summaray>
    public class IonOutputFeedBack
    {
        public float Anod_I { get; set; }
        public float Anod_U { get; set; }
        public float Anod_P { get; set; }
        public float Heat_I { get; set; }
        public float Heat_U { get; set; }
        public float Heat_P { get; set; }
        private  string Path;
        public IonOutputFeedBack(string path)
        {
            Path = path;
        }

        public  void ReadValue(ref Session session)
        {
            DataValue opcAnod_I = session.ReadValue(NodeId.Parse(Path + ".\"Anod_I\""));
            DataValue opcAnod_U = session.ReadValue(NodeId.Parse(Path + ".\"Anod_U\""));
            DataValue opcAnod_P = session.ReadValue(NodeId.Parse(Path + ".\"Anod_P\""));
            DataValue opcHeat_I = session.ReadValue(NodeId.Parse(Path + ".\"Heat_I\""));
            DataValue opcHeat_U = session.ReadValue(NodeId.Parse(Path + ".\"Heat_U\""));
            DataValue opcHeat_P = session.ReadValue(NodeId.Parse(Path + ".\"Heat_P\""));
            this.Anod_I = float.Parse(opcAnod_I.Value.ToString());
            this.Anod_P = float.Parse(opcAnod_P.Value.ToString());
            this.Anod_U = float.Parse(opcAnod_U.Value.ToString());
            this.Heat_I = float.Parse(opcHeat_I.Value.ToString());
            this.Heat_P = float.Parse(opcHeat_I.Value.ToString());
            this.Heat_U = float.Parse(opcHeat_I.Value.ToString());
          
        }
    }
}
