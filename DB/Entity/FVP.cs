using KVANT_Scada_2.UDT.FVP;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.DB.Entity
{
    public class FVP
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool Remote { get; set; }
        public bool Auto_mode { get; set; }
        public bool Start { get; set; }
        public bool Manual_start { get; set; }
        public bool Power_On { get; set; }
        public bool Turn_On { get; set; }
        public bool Block { get; set; }
    }
}
