using KVANT_Scada_2.UDT.Tech_cam;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.DB.Entity
{
    public class StopCrioTable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Stage_2_Stage { get; set; }
        public bool Access { get; set; }
        public bool Stage_2_Return { get; set; }
        public bool Stage_2_done { get; set; }
    }
}
