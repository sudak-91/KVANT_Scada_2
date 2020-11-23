using KVANT_Scada_2.UDT.Tech_cam;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.DB.Entity
{
    public class OpenCamTable:OpenCam
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Stage_1_stage { get; set; }
        public bool Access { get; set; }
        public bool Stage_1_Return { get; set; }
        public bool Stage_1_done { get; set; }
        public bool Heat_cam { get; set; }

    }
}
