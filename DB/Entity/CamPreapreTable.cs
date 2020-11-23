using KVANT_Scada_2.UDT.Tech_cam;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.DB.Entity
{
    public class CamPreapreTable
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }

        public float Open_FVV_B_pressure { get; set; }
        public float Open_SHV_pressure { get; set; }
        public float Finally_pressure { get; set; }
        public int Stage_0_Cam_prepare_Stage { get; set; }
        public bool Access { get; set; }
        public bool Stage_0_Cam_prepare_Complite { get; set; }
        public bool Return_ERROR { get; set; }
    }
}
