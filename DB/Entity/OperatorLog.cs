using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.DB.Entity
{
    public class OperatorLog
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Action { get; set; }
        public DateTime dateTime { get; set; }
    }
}
