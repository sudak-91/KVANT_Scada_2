using KVANT_Scada_2.UDT.Tech_cam;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.DB.Entity
{
    public class CrioPumpStartTable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public float Crio_pressure_check_SP { get; set; }
        public float Crio_pressure_calc_value { get; set; }
        public float Crio_pressure_diff { get; set; }
        public float Temperature_SP { get; set; }
        public int Stage_0_Stage { get; set; }
        public bool Access { get; set; }
        public bool Return_error { get; set; }
        public bool Stage_0_CompliteP { get; set; }
    }
}
