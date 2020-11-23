using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.DB.Entity
{
    public class CrioPump
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool iAuto_mode { get; set; }
        public bool iCommand_manual { get; set; }
        public bool sPower_On { get; set; }
        public bool sBlocked { get; set; }
        public bool sTurn_On { get; set; }
        public bool sAuto_mode { get; set; }
        public bool sError { get; set; }
    }
}
