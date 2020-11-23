using KVANT_Scada_2.UDT.Valve;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.DB
{
    
    public class Valves
    {   
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string PathInput { get; set; }
        public string PathStatus { get; set; }
        public bool viService_mode { get; set; }
        public bool viAuto_mode { get; set; }
        public bool viMan_command { get; set; }
        public bool vsAuto_mode { get; set; }
        public bool vsOpened { get; set; }
        public bool vsClosed { get; set; }
        public bool vsOpening { get; set; }
        public bool vsClosing { get; set; }
        public bool vsBlocked { get; set; }
        public bool vsServiced { get; set; }
    }
}
