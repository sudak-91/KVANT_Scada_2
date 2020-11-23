using KVANT_Scada_2.UDT.ION;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.DB.Entity
{
    public class Ion 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool icStart { get; set; }
        public bool icStop { get; set; }
        public bool icManual_Start { get; set; }
        public bool icManual_Stop { get; set; }
        public bool icAuto_mod { get; set; }
        public bool icReset_error { get; set; }
        public float Anod_I_SP { get; set; }
        public float Anod_U_SP { get; set; }
        public float Anod_P_SP { get; set; }
        public float Heat_I_SP { get; set; }
        public float Heat_U_SP { get; set; }
        public float Heat_P_SP { get; set; }
        public float Anod_I { get; set; }
        public float Anod_U { get; set; }
        public float Anod_P { get; set; }
        public float Heat_I { get; set; }
        public float Heat_U { get; set; }
        public float Heat_P { get; set; }
        public bool sAuto_mode { get; set; }
        public bool sPower_on { get; set; }
        public bool sTurn_On { get; set; }
        public bool sInterlock { get; set; }
        public bool sFailure { get; set; }
        public bool sPower_Failure { get; set; }
        public bool sTemperature_Failure { get; set; }
        public bool sRepeat_Failure { get; set; }
        public bool sFilament_Failure { get; set; }
        public bool sTurn_off { get; set; }
        public bool sEmergancy_Stop { get; set; }
        public bool sPower_Stop { get; set; }
        public bool sTemperature_Stop { get; set; }
        public bool sOther_Failure { get; set; }
    }
}
