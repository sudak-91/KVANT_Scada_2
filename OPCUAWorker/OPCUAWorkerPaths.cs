using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.OPCUAWorker
{
    ///<summaray>
    ///Класс OPCUAWorekerPath содержит пути ко всем Node
    ///
    ///</summaray>

    public class OPCUAWorkerPaths
    {
        public static string BAV_3_Status_path = "ns=3;s=\"Valve_DB\".\"BAV_3\".\"Status\"";
        public static string BAV_3_Input_path = "ns=3;s=\"Valve_DB\".\"BAV_3\".\"Input\"";
        public static string FVV_S_Status_path = "ns=3;s=\"Valve_DB\".\"FVV_S\".\"Status\"";
        public static string FVV_S_Input_path = "ns=3;s=\"Valve_DB\".\"FVV_S\".\"Input\"";
        public static string FVV_B_Status_path = "ns=3;s=\"Valve_DB\".\"FVV_B\".\"Status\"";
        public static string FVV_B_Input_path = "ns=3;s=\"Valve_DB\".\"FVV_B\".\"Input\"";
        public static string CPV_Status_path = "ns=3;s=\"Valve_DB\".\"CPV\".\"Status\"";
        public static string CPV_Input_path = "ns=3;s=\"Valve_DB\".\"CPV\".\"Input\"";
        public static string SHV_Status_path = "ns=3;s=\"Valve_DB\".\"SHV\".\"Status\"";
        public static string SHV_Input_path = "ns=3;s=\"Valve_DB\".\"SHV\".\"Input\"";
        public static string Crio_pump_Input_path = "ns=3;s=\"Crio_DB\".\"Crio\".\"Input\"";
        public static string Crio_pump_Status_path = "ns=3;s=\"Crio_DB\".\"Crio\".\"Status\"";
        public static string StopFVP_path = "ns=3;s=\"Tech_Cam_Logic\".\"Stage_3_Stop_FVP\"";
        public static string StopCrio_path = "ns=3;s=\"Tech_Cam_Logic\".\"Stop_Crio\"";
        public static string OpenCam_path = "ns=3;s=\"Tech_Cam_Logic\".\"Stage_1_Open_Cam\"";
        public static string CrioPumpStart_path = "ns=3;s=\"Tech_Cam_Logic\".\"Stage_0_Cheking_crio_pump\"";
        public static string CamPrepare_path = "ns=3;s=\"Tech_Cam_Logic\".\"Stage_0_Cam_prepare\"";
        public static string IonStatus_path = "ns=3;s=\"Ion_DB\".\"Status\"";
        public static string IonOutputFeedBack_path = "ns=3;s=\"Ion_DB\".\"Output_FeedBack\"";
        public static string IonInputSetPoint_path = "ns=3;s=\"Ion_DB\".\"Input_Set_point\"";
        public static string IonInputCommand_path = "ns=3;s=\"Ion_DB\".\"Input Command\"";
        public static string FVPStatus_path = "ns=3;s=\"FVP_DB\".\"FVP\".\"Status\"";




        public static string SFT01_FT_path = "ns=3;s=\"ain_db\".\"1SFT1_FT\".\"Value\"";
        public static string SFT02_FT_path = "ns=3;s=\"ain_db\".\"1SFT2_FT\".\"Value\"";
        public static string SFT03_FT_path = "ns=3;s=\"ain_db\".\"1SFT3_FT\".\"Value\"";
        public static string SFT04_FT_path = "ns=3;s=\"ain_db\".\"1SFT4_FT\".\"Value\"";
        public static string SFT05_FT_path = "ns=3;s=\"ain_db\".\"1SFT5_FT\".\"Value\"";
        public static string SFT06_FT_path = "ns=3;s=\"ain_db\".\"1SFT6_FT\".\"Value\"";
        public static string SFT07_FT_path = "ns=3;s=\"ain_db\".\"1SFT7_FT\".\"Value\"";
        public static string SFT08_FT_path = "ns=3;s=\"ain_db\".\"1SFT8_FT\".\"Value\"";
        public static string SFT09_FT_path = "ns=3;s=\"ain_db\".\"1SFT9_FT\".\"Value\"";
        public static string SFT10_FT_path = "ns=3;s=\"ain_db\".\"1SFT10_FT\".\"Value\"";
        public static string FT_TT_1_path = "ns=3;s=\"ain_db\".\"FT_TT_1\".\"Value\"";
        public static string FT_TT_2_path = "ns=3;s=\"ain_db\".\"FT_TT_2\".\"Value\"";
        public static string FT_TT_3_path = "ns=3;s=\"ain_db\".\"FT_TT_3\".\"Value\"";
        public static string RRG_9A1_feedback_path = "ns=3;s=\"ain_db\".\"RRG_9A1_feedback\".\"Value\"";
        public static string RRG_9A2_feedback_path = "ns=3;s=\"ain_db\".\"RRG_9A2_feedback\".\"Value\"";
        public static string RRG_9A3_feedback_path = "ns=3;s=\"ain_db\".\"RRG_9A3_feedback\".\"Value\"";
        public static string RRG_9A4_feedback_path = "ns=3;s=\"ain_db\".\"RRG_9A4_feedback\".\"Value\"";
        public static string TE_1_path = "ns=3;s=\"ain_db\".\"1TE1\".\"Value\"";
        public static string RRG_Pressure_SP = "ns=3;s=\"PID_DB\".\"Setpoint\"";
        public static string PneumaticPressure_path = "ns=3;s=\"ain_db\".\"Pne_Press\".\"Value\"";
        public static string CrioPressure_path = "ns=3;s=\"WRG_APG_Pressure\".\"Crio_press\".\"OUT\"";
        public static string CameraPressure_path = "ns=3;s=\"WRG_APG_Pressure\".\"Cam_press\".\"OUT\"";
        public static string MainPressure_path = "ns=3;s=\"WRG_APG_Pressure\".\"Main_pressure\".\"OUT\"";
        public static string CrioTemperature_path = "ns=3;s=\"EDI500\".\"EDI500\".\"Temp\"";
        public static string PreHeat_Temp_SP_path = "ns=3;s=\"Heat_DB\".\"PreHeat_Temp_SP\"";
        public static string HeatAssist_Temp_SP_path = "ns=3;s=\"Heat_DB\".\"HeatAssist_Temp_SP\"";
        public static string PreHeat_Timer_SP_path = "ns=3;s=\"Heat_DB\".\"PreHeat_Timer_SP\"";
        public static string Heat_Assist_Timer_SP_path = "ns=3;s=\"Heat_DB\".\"Heat_Assist_Timer_SP\"";
        public static string PreHeat_Timer_path = "ns=3;s=\"Heat_DB\".\"PreHeat_Timer\"";
        public static string HeatAssist_Timer_path = "ns=3;s=\"Heat_DB\".\"HeatAssist_Timer\"";
        public static string PreHeat_Stage_path = "ns=3;s=\"Heat_DB\".\"PreHeat_Stage\"";
        public static string HeatAssist_Stage_path = "ns=3;s=\"Heat_DB\".\"HeatAssist_Stage\"";
        public static string PreHeat_Done_path = "ns=3;s=\"Heat_DB\".\"PreHeat_Done\"";
        public static string HeatAssist_Done_path = "ns=3;s=\"Heat_DB\".\"HeatAssist_Done\"";
        public static string PreHeat_Start_path = "ns=3;s=\"Heat_DB\".\"PreHeat_Start\"";
        public static string HeatAssist_Flag_path = "ns=3;s=\"Heat_DB\".\"HeatAssist_Flag\"";
        public static string Heat_Done_path = "ns=3;s=\"Heat_DB\".\"Heat_Done\"";
        public static string HeatAssist_TempDone_path = "ns=3;s=\"Heat_DB\".\"HeatAssist_TempDone\"";
        public static string Heat_Assist_ON_path = "ns=3;s=\"Heat_DB\".\"Heat_Assist_ON\"";
        public static string ManualSetTemp_path = "ns=3;s=\"TEMP_PID_DB\".\"Manual_Value\"";
        public static string BLM_Speed_path = "ns=3;s=\"DRIVER_COMMAND\".\"Speed\"";
        public static string BLM_Start_path = "ns=3;s=\"DRIVER_COMMAND\".\"Start\"";
        public static string BLM_Stop_path = "ns=3;s=\"DRIVER_COMMAND\".\"Stop\"";
        public static string BLM_Remote_Control_Done_path = "ns=3;s=\"DRIVER_COMMAND\".\"Remote_Control_Done\"";
        public static string BLM_Speed_SP_path = "ns=3;s=\"DRIVER_COMMAND\".\"Speed-SP\"";
        public static string BLM_Run_path = "ns=3;s=\"DRIVER_COMMAND\".\"Run\"";
        public static string Alarm_Open_door_path = "ns=3;s=\"Alarm_DB\".\"Open_door\"";
        public static string Alarm_Water_CRIO_path = "ns=3;s=\"Alarm_DB\".\"Water_CRIO\"";
        public static string Alarm_Hight_Pne_Presse_path = "ns=3;s=\"Alarm_DB\".\"Hight_Pne_Presse\"";
        public static string Alarm_Low_One_Presse_path = "ns=3;s=\"Alarm_DB\".\"Low_One_Presse\"";
        public static string Alarm_Crio_power_failure_path = "ns=3;s=\"Alarm_DB\".\"Crio_power_failure\"";
        public static string Alarm_Qartz_power_filure_path = "ns=3;s=\"Alarm_DB\".\"Qartz_power_filure\"";
        public static string Alarm_ELI_power_failure_path = "ns=3;s=\"Alarm_DB\".\"ELI_power_failure\"";
        public static string Alarm_FloatHeater_power_failure_path = "ns=3;s=\"Alarm_DB\".\"FloatHeater_power_failure\"";
        public static string Alarm_FVP_power_failure_path = "ns=3;s=\"Alarm_DB\".\"FVP_power_failure\"";
        public static string Alarm_Ion_power_failure_path = "ns=3;s=\"Alarm_DB\".\"Ion_power_failure\"";
        public static string Alarm_Indexer_power_failure_path = "ns=3;s=\"Alarm_DB\".\"Indexer_power_failure\"";
        public static string Alarm_SSP_power_failure_path = "ns=3;s=\"Alarm_DB\".\"SSP_power_failure\"";
        public static string Alarm_TV1_power_failure_path = "ns=3;s=\"Alarm_DB\".\"TV1_power_failure\"";
        public static string Alarm_Water_SECOND_path = "ns=3;s=\"Alarm_DB\".\"Water_SECOND\"";
        public static string Alarm_Hight_Crio_Temp_path = "ns=3;s=\"Alarm_DB\".\"Hight_Crio_Temp\"";
        public static string Tech_cam_STAGE_path = "ns=3;s=\"Tech_Cam_Logic\".\"STAGE\"";
        public static string Crio_start_signal_path = "ns=3;s=\"Tech_Cam_Logic\".\"Crio_start_signal\"";
        public static string Alarm_manual_Stop_path = "ns=3;s=\"Tech_Cam_Logic\".\"Alarm_manual_Stop\"";
        public static string K_RRG1_path = "ns=3;s=\"RRG_DB\".\"K_RRG1\"";
        public static string K_RRG2_path = "ns=3;s=\"RRG_DB\".\"K_RRG2\"";
        public static string K_RRG3_path = "ns=3;s=\"RRG_DB\".\"K_RRG3\"";
        public static string K_RRG4_path = "ns=3;s=\"RRG_DB\".\"K_RRG4\"";
        public static string StartProcessSignal_path = "ns=3;s=\"ELI_DB\".\"Start_signal\"";
        public static string StopProcessSignal_path = "ns=3;s=\"ELI_DB\".\"Manual_stop\"";
        public static string FullCycleStage_path = "ns=3;s=\"ELI_DB\".\"Full_Cycle_Satge\"";
        public static string PidHeatMode_path = "ns=3;s=\"TEMP_PID_DB\".\"Mode_real\"";
    }
}
