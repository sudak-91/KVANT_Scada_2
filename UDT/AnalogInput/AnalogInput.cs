using Opc.UaFx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.UDT
{
    public class AnalogInput
    {
        public OpcValue SFT01_FT { get; set; }
        public OpcValue SFT02_FT { get; set; }
        public OpcValue SFT03_FT { get; set; }
        public OpcValue SFT04_FT { get; set; }
        public OpcValue SFT05_FT { get; set; }
        public OpcValue SFT06_FT { get; set; }
        public OpcValue SFT07_FT { get; set; }
        public OpcValue SFT08_FT { get; set; }
        public OpcValue SFT09_FT { get; set; }
        public OpcValue SFT10_FT { get; set; }
        public OpcValue FT_TT_1 { get; set; }
        public OpcValue FT_TT_2 { get; set; }
        public OpcValue FT_TT_3 { get; set; }
        public OpcValue RRG_9A1_feedback { get; set; }
        public OpcValue RRG_9A2_feedback { get; set; }
        public OpcValue RRG_9A3_feedback { get; set; }
        public OpcValue RRG_9A4_feedback { get; set; }
        public OpcValue TE_1 { get; set; }
        public OpcValue PneumaticPressure { get; set; }
        public OpcValue CrioPressure { get; set; }
        public OpcValue CameraPressure { get; set; }
        public OpcValue MainPressure { get; set; }
        public OpcValue CrioTemperature { get; set; }

        public OpcValue PreHeat_Temp_SP { get; set; }
        public OpcValue HeatAssist_Temp_SP { get; set; }
        public OpcValue PreHeat_Timer_SP { get; set; }
        public OpcValue Heat_Assist_Timer_SP { get; set; }

        public OpcValue PreHeat_Timer { get; set; }
        public OpcValue HeatAssist_Timer { get; set; }

       
        public OpcValue PreHeat_Stage { get; set; }
        public OpcValue HeatAssist_Stage { get; set; }
        

        public OpcValue PreHeat_Done { get; set; }
        public OpcValue HeatAssist_Done { get; set; }
        public OpcValue PreHeat_Start { get; set; }
        public OpcValue HeatAssist_Flag { get; set; }
        public OpcValue Heat_Done { get; set; }
        public OpcValue HeatAssist_TempDone { get; set; }
        public OpcValue Heat_Assist_ON { get; set; }

        public OpcValue ManualSetTemp { get; set; }

        public OpcValue BLM_Speed { get; set; }
        
        public OpcValue BLM_Start { get; set; }
        public OpcValue BLM_Stop { get; set; }
        public OpcValue BLM_Remote_Control_Done { get; set; }
        
        public OpcValue BLM_Speed_SP { get; set; }

        public OpcValue BLM_Run { get; set; }
        public OpcValue Alarm_Open_door { get; set; }
        public OpcValue Alarm_Water_CRIO { get; set; }
        public OpcValue Alarm_Hight_Pne_Presse { get; set; }
        public OpcValue Alarm_Low_One_Presse { get; set; }
        public OpcValue Alarm_Crio_power_failure { get; set; }

        public OpcValue Alarm_Qartz_power_filure { get; set; }
        public OpcValue Alarm_ELI_power_failure { get; set; }
        public OpcValue Alarm_FloatHeater_power_failure { get; set; }
        public OpcValue Alarm_FVP_power_failure { get; set; }
        public OpcValue Alarm_Ion_power_failure { get; set; }
        public OpcValue Alarm_Indexer_power_failure { get; set; }
        public OpcValue Alarm_SSP_power_failure { get; set; }
        public OpcValue Alarm_TV1_power_failure { get; set; }
        public OpcValue Alarm_Water_SECOND { get; set; }
        public OpcValue Alarm_Hight_Crio_Temp { get; set; }
        
        public OpcValue Tech_cam_STAGE { get; set; }
        
        public OpcValue Crio_start_signal { get; set; }
        public OpcValue Alarm_manual_Stop { get; set; }



    }
}
