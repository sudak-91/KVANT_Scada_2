using KVANT_Scada_2.DB.Entity;
using KVANT_Scada_2.UDT;
using KVANT_Scada_2.UDT.Crio;
using KVANT_Scada_2.UDT.DiscreteValue;
using KVANT_Scada_2.UDT.ELI_Shutter;
using KVANT_Scada_2.UDT.FVP;
using KVANT_Scada_2.UDT.IntValue;
using KVANT_Scada_2.UDT.ION;
using KVANT_Scada_2.UDT.Tech_cam;
using KVANT_Scada_2.UDT.Valve;
using Opc.Ua.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.Objects
{


    public class OPCObjects
    {

     
        public static ValveStatus BAV_3_status, FVV_S_Status, FVV_B_Status, CPV_Status, SHV_Status;
        public static ValveInput BAV_3_input, FVV_S_Input, FVV_B_Input, CPV_Input, SHV_Input;
        public static CamPrepare camPrepare;
        public static CrioPumpStart CrioPumpStart;
        public static OpenCam openCam;
        public static StopCrio StopCrio;
        public static StopFVP StopFVP;
        public static IonInputCommand IonInputCommnd;
        public static IonInputSetPoint IonInputSetPoint;
        public static IonOutputFeedBack IonOutputFeedBack;
        public static IonStatus IonStatus;
        public static FVPStatus FVPStatus;
        public static CrioInput CrioInput;
        public static CrioStatus CrioStatus;
        public static Shutter EliShutter;
        public static Session session;
        public static object SQLLocker;
        public static object OPCLocker;
        public static List<AnalogValue> AnalogValues;
        public static List<DiscreteValue> DiscreteValues;
        public static List<IntValue> IntValues;
        public static Dictionary<int, ValveInput> ValvesInput;
        public static Dictionary<int, ValveStatus> ValvesStatus;
        public static AnalogValue SFT01_FT, SFT02_FT, SFT03_FT, SFT04_FT,
                                   SFT05_FT, SFT06_FT, SFT07_FT, SFT08_FT,
                                   SFT09_FT, SFT10_FT, FT_TT_1, FT_TT_2, FT_TT_3,
                                    RRG_9A1_feedback, RRG_9A2_feedback,
                                    RRG_9A3_feedback, RRG_9A4_feedback,
                                    TE_1, Pneumatic_Pressure, Crio_Pressure,
                                    Camera_Pressure, Main_Pressure, Crio_Temperature,
                                    PreHeat_Temp_SP, HeatAssist_Temp_SP,
                                    PreHeat_Timer_SP, HeatAssist_Timer_SP,
                                    ManualSetTemp, BLM_Speed, BLM_Speed_SP,
                                    K_RRG1, K_RRG2, K_RRG3, K_RRG4, RRG_Pressure_SP, PidHeatMode;
        public static DiscreteValue PreHeat_Done, HeatAssist_Done, PreHeat_Start,
                                    HeatAssist_Flag, Heat_Done, HeatAssist_TempDone,
                                    Heat_Assit_On, BLM_Start, BLM_Stop, BLM_Remote_Control_Done,
                                    BLM_Run, Alarm_Open_door, Alarm_Water_CRIO,
                                    Alarm_Hight_Pne_Press, Alarm_Low_One_Presse,
                                    Alarm_Crio_power_failure, Alarm_Qartz_power_failure,
                                    Alarm_ELI_Power_failure, Alarm_FloatHeater_power_failure,
                                    Alarm_Ion_power_failure, Alarm_FVP_power_failure,
                                    Alarm_Indexer_power_failure, Alarm_SSP_power_failure,
                                    Alarm_TV1_power_failure, Alarm_Water_SECOND, Alarm_Hight_Crio_Temp,
                                    Crio_start_signal, Alarm_manual_stop, StartProcessSignal, StopProcessSignal,
                                    ELI_complete, ELI_access, ELI_block, SSP_on, SSP_turn_on;
        public static IntValue PreHeat_Stage;
        public static IntValue HeatAssist_Stage;
        public static IntValue Tech_cam_STAGE;
        public static IntValue FullCycleStage;
        public static User user;



        #region constructor
        private static OPCObjects instance;
        private OPCObjects()
        {
            
            AnalogValues = new List<AnalogValue>();
            DiscreteValues = new List<DiscreteValue>();
            ValvesInput = new Dictionary<int, ValveInput>();
            ValvesStatus = new Dictionary<int, ValveStatus>();
            SFT01_FT = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.SFT01_FT_path);
            SFT02_FT = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.SFT02_FT_path);
            SFT03_FT = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.SFT03_FT_path);
            SFT04_FT = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.SFT04_FT_path);
            SFT05_FT = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.SFT05_FT_path);
            SFT06_FT = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.SFT06_FT_path); 
            SFT07_FT = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.SFT07_FT_path); 
            SFT08_FT = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.SFT08_FT_path);
            SFT09_FT = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.SFT09_FT_path);
            SFT10_FT = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.SFT10_FT_path);
            FT_TT_1 = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.FT_TT_1_path);
            FT_TT_2 = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.FT_TT_2_path);
            FT_TT_3 = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.FT_TT_3_path);
            K_RRG1 = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.K_RRG1_path);
            K_RRG2 = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.K_RRG2_path);
            K_RRG3 = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.K_RRG3_path);
            K_RRG4 = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.K_RRG4_path);
            PidHeatMode = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.PidHeatMode_path);
            RRG_Pressure_SP = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.RRG_Pressure_SP);
            RRG_9A1_feedback = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.RRG_9A1_feedback_path);
            RRG_9A2_feedback = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.RRG_9A2_feedback_path);
            RRG_9A3_feedback = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.RRG_9A3_feedback_path);
            RRG_9A4_feedback = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.RRG_9A4_feedback_path);
            TE_1 = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.TE_1_path);
            Pneumatic_Pressure = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.PneumaticPressure_path);
            Crio_Pressure = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.CrioPressure_path);
            Camera_Pressure = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.CameraPressure_path); 
            Main_Pressure = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.MainPressure_path);
            Crio_Temperature = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.CrioTemperature_path);
            PreHeat_Temp_SP = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.PreHeat_Temp_SP_path);
            HeatAssist_Temp_SP = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.HeatAssist_Temp_SP_path);
            PreHeat_Timer_SP = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.PreHeat_Timer_SP_path);
            HeatAssist_Timer_SP = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.Heat_Assist_Timer_SP_path);
            ManualSetTemp = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.ManualSetTemp_path); 
            BLM_Speed = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.BLM_Speed_path);
            BLM_Speed_SP = new AnalogValue(OPCUAWorker.OPCUAWorkerPaths.BLM_Speed_SP_path);
            PreHeat_Done = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.PreHeat_Done_path);
            HeatAssist_Done = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.HeatAssist_Done_path);
            PreHeat_Start = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.PreHeat_Start_path);
            HeatAssist_Flag = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.HeatAssist_Flag_path); 
            Heat_Done = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.HeatAssist_Done_path);
            HeatAssist_TempDone = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.HeatAssist_TempDone_path);
            Heat_Assit_On = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.Heat_Assist_ON_path);
            BLM_Start = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.BLM_Start_path);
            BLM_Stop = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.BLM_Stop_path);
            BLM_Remote_Control_Done = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.BLM_Remote_Control_Done_path);
            BLM_Run = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.BLM_Run_path);
            Alarm_Open_door = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.Alarm_Open_door_path);
            Alarm_Water_CRIO = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.Alarm_Water_CRIO_path);
            Alarm_Hight_Pne_Press = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.Alarm_Hight_Pne_Presse_path);
            Alarm_Low_One_Presse = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.Alarm_Low_One_Presse_path);
            Alarm_Crio_power_failure = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.Alarm_Crio_power_failure_path);
            Alarm_Qartz_power_failure = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.Alarm_Qartz_power_filure_path);
            Alarm_ELI_Power_failure = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.Alarm_ELI_power_failure_path);
            Alarm_FloatHeater_power_failure = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.Alarm_FloatHeater_power_failure_path);
            Alarm_Ion_power_failure = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.Alarm_Ion_power_failure_path);
            Alarm_FVP_power_failure = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.Alarm_FVP_power_failure_path);
            Alarm_Indexer_power_failure = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.Alarm_Indexer_power_failure_path);
            Alarm_SSP_power_failure = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.Alarm_SSP_power_failure_path);
            Alarm_TV1_power_failure = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.Alarm_TV1_power_failure_path);
            Alarm_Water_SECOND = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.Alarm_Water_SECOND_path);
            Alarm_Hight_Crio_Temp = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.Alarm_Hight_Crio_Temp_path);
            Crio_start_signal = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.Crio_start_signal_path);
            Alarm_manual_stop = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.Alarm_manual_Stop_path);
            StartProcessSignal = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.StartProcessSignal_path);
            StopProcessSignal = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.StopProcessSignal_path);
            ELI_block = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.ELI_block_path);
            ELI_complete = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.ELI_complete_path);
            ELI_access = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.ELI_access_path);
            PreHeat_Stage = new IntValue(OPCUAWorker.OPCUAWorkerPaths.PreHeat_Stage_path);
            HeatAssist_Stage = new IntValue(OPCUAWorker.OPCUAWorkerPaths.HeatAssist_Stage_path);
            Tech_cam_STAGE = new IntValue(OPCUAWorker.OPCUAWorkerPaths.Tech_cam_STAGE_path);
            FullCycleStage = new IntValue(OPCUAWorker.OPCUAWorkerPaths.FullCycleStage_path);
            IntValues = new List<IntValue>();
            FVPStatus = new FVPStatus(OPCUAWorker.OPCUAWorkerPaths.FVPStatus_path);
            OPCLocker = new object();
            SQLLocker = new object();
            BAV_3_status = new ValveStatus(OPCUAWorker.OPCUAWorkerPaths.BAV_3_Status_path);
            FVV_S_Status = new ValveStatus(OPCUAWorker.OPCUAWorkerPaths.FVV_S_Status_path);
            FVV_B_Status = new ValveStatus(OPCUAWorker.OPCUAWorkerPaths.FVV_B_Status_path);
            CPV_Status = new ValveStatus(OPCUAWorker.OPCUAWorkerPaths.CPV_Status_path); 
            SHV_Status = new ValveStatus(OPCUAWorker.OPCUAWorkerPaths.SHV_Status_path);
            BAV_3_input = new ValveInput(OPCUAWorker.OPCUAWorkerPaths.BAV_3_Input_path); 
            FVV_S_Input = new ValveInput(OPCUAWorker.OPCUAWorkerPaths.FVV_S_Input_path); 
            FVV_B_Input = new ValveInput(OPCUAWorker.OPCUAWorkerPaths.FVV_B_Input_path); 
            CPV_Input = new ValveInput(OPCUAWorker.OPCUAWorkerPaths.CPV_Input_path); 
            SHV_Input = new ValveInput(OPCUAWorker.OPCUAWorkerPaths.SHV_Input_path);
            camPrepare = new CamPrepare(OPCUAWorker.OPCUAWorkerPaths.CamPrepare_path);
            CrioPumpStart = new CrioPumpStart(OPCUAWorker.OPCUAWorkerPaths.CrioPumpStart_path);
            openCam = new OpenCam(OPCUAWorker.OPCUAWorkerPaths.OpenCam_path);
            StopCrio = new StopCrio();
            StopFVP = new StopFVP();
            IonInputCommnd = new IonInputCommand(OPCUAWorker.OPCUAWorkerPaths.IonInputCommand_path);
            IonInputSetPoint = new IonInputSetPoint(OPCUAWorker.OPCUAWorkerPaths.IonInputSetPoint_path);
            IonOutputFeedBack = new IonOutputFeedBack(OPCUAWorker.OPCUAWorkerPaths.IonOutputFeedBack_path);
            IonStatus = new IonStatus(OPCUAWorker.OPCUAWorkerPaths.IonStatus_path);
            FVPStatus = new FVPStatus(OPCUAWorker.OPCUAWorkerPaths.FVPStatus_path);
            CrioInput = new CrioInput(OPCUAWorker.OPCUAWorkerPaths.Crio_pump_Input_path);
            CrioStatus = new CrioStatus(OPCUAWorker.OPCUAWorkerPaths.Crio_pump_Status_path);
            SSP_on = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.SSP_ON_path);
            SSP_turn_on = new DiscreteValue(OPCUAWorker.OPCUAWorkerPaths.SSP_turn_on_path);
            EliShutter = new Shutter(OPCUAWorker.OPCUAWorkerPaths.EliShutterPath);

            user = new User();
        }

        public static OPCObjects createObjects()
        {
            if (instance == null)
            {
                instance = new OPCObjects();
            }
            return instance;
        }
        #endregion

        #region Tech_cam
        public void set_camPrepare(CamPrepare obj)
        {
            camPrepare = obj;
        }
        public CamPrepare get_camPrepare()
        {
            return camPrepare;
        }

        public void set_CrioPumpStart(CrioPumpStart obj)
        {
           CrioPumpStart = obj;
        }
        public CrioPumpStart GetCrioPumpStart()
        {
            return CrioPumpStart;
        }

        public void SetOpenCam(OpenCam obj)
        {
            openCam = obj;
        }
        public OpenCam GetOpenCam()
        {
            return openCam;
        }

        public void SetStopCrio(StopCrio obj)
        {
            StopCrio = obj;
        }
        public StopCrio GetStopCrio()
        {
            return StopCrio;
        }

        public void SetStopFvp(StopFVP obj)
        {
            StopFVP = obj;
        }
        public StopFVP GetStopFVP()
        {
            return StopFVP;
        }
        #endregion
        #region ION
        public void SetIonInputCommand(IonInputCommand obj)
        {
            IonInputCommnd = obj;
        }
        public IonInputCommand GetIonInputCommand()
        {
            return IonInputCommnd;
        }
        public void SetIonInputSetPoint(IonInputSetPoint obj)
        {
            IonInputSetPoint = obj;
        }
        public IonInputSetPoint GetIonInputSetPoint()
        {
            return IonInputSetPoint;
        }
        public void SetIonOutputFeedBack(IonOutputFeedBack obj)
        {
            IonOutputFeedBack = obj;
        }
        public IonOutputFeedBack GetIonOutputFeedBack()
        {
            return IonOutputFeedBack;
        }
        public void SetIonStatus(IonStatus obj)
        {
           IonStatus = obj;
        }
        public IonStatus GetIonStatus()
        {
            return IonStatus;
        }
        #endregion
        public void setSQLLocker(object obj)
        {
           SQLLocker = obj;
        }
        public object getSQLLocker()
        {
            return SQLLocker;
        }
        public void setOPCLocker(object obj)
        {
            OPCLocker = obj;
        }
        public object getOPCLocker()
        {
            return OPCLocker;
        }

      

        public void SetFVPStatus(FVPStatus obj)
        {
            FVPStatus = obj;
        }
        public FVPStatus GetFVPStatus()
        {
            return FVPStatus;
        }

        public void SetCrioInput(CrioInput obj)
        {
            CrioInput = obj;
        }
        public CrioInput GetCrioInput()
        {
            return CrioInput;
        }

        public void SetCrioStatus(CrioStatus obj)
        {
            CrioStatus = obj;
        }
        public CrioStatus GetCrioStatus()
        {
            return CrioStatus;
        }

       
        public void setBAV_3_Status(ValveStatus obj)
        {
            BAV_3_status = obj;
        }
        public ValveStatus getBAV_3_Status()
        {
            return BAV_3_status;
        }

        public void setBAV_3_Input(ValveInput obj)
        {
            BAV_3_input = obj;
        }
        public ValveInput getBAV_3_Input()
        {
            return BAV_3_input;
        }

        public void set_FVV_S_Status(ValveStatus obj)
        {
            FVV_S_Status = obj;
        }
        public ValveStatus get_FVV_S_Status()
        {
            return FVV_S_Status;
        }
        public void set_FVV_S_Input(ValveInput obj)
        {
            FVV_S_Input = obj;
        }
        public ValveInput get_FVV_S_Input()
        {
            return FVV_S_Input;
        }


        public void set_FVV_B_Status(ValveStatus obj)
        {
            FVV_B_Status = obj;
        }
        public ValveStatus get_FVV_B_Status()
        {
            return FVV_B_Status;
        }
        public void set_FVV_B_Input(ValveInput obj)
        {
            FVV_B_Input = obj;
        }
        public ValveInput get_FVV_B_Input()
        {
            return FVV_B_Input;
        }

        public void set_CVP_Status(ValveStatus obj)
        {
            CPV_Status = obj;
        }
        public ValveStatus get_CVP_Status()
        {
            return CPV_Status;
        }
        public void set_CVP_Input(ValveInput obj)
        {
            CPV_Input = obj;
        }
        public ValveInput get_CVP_Input()
        {
            return CPV_Input;
        }


        public void set_SHV_Status(ValveStatus obj)
        {
            SHV_Status = obj;
        }
        public ValveStatus get_SHV_Status()
        {
            return SHV_Status;
        }
        public void set_SHV_Input(ValveInput obj)
        {
            SHV_Input = obj;
        }
        public ValveInput get_SHV_Input()
        {
            return SHV_Input;
        }
        public void SetFT_TT_1 (AnalogValue obj)
        {
            FT_TT_1 = obj;
        }
        public AnalogValue GetFT_TT_1()
        {
            return FT_TT_1;
        }
        public void SetFT_TT_2(AnalogValue obj)
        {
            FT_TT_2 = obj;
        }
        public AnalogValue GetFT_TT_2()
        {
            return FT_TT_2;
        }
        public void SetFT_TT_3(AnalogValue obj)
        {
            FT_TT_3 = obj;
        }
        public AnalogValue GetFT_TT_3()
        {
            return FT_TT_3;
        }
        public void SetHeatAssist_Temp_SP(AnalogValue obj)
        {
            HeatAssist_Temp_SP = obj;
        }
        public AnalogValue GetHeatAssist_Temp_SP()
        {
            return HeatAssist_Temp_SP;
        }
        public void SetHeatAssist_Timer_SP(AnalogValue obj)
        {
            HeatAssist_Timer_SP = obj;
        }
        public AnalogValue GetHeatAssist_Timer_SP()
        {
            return HeatAssist_Timer_SP;
        }
        public void SetMainPres(AnalogValue obj)
        {
            Main_Pressure = obj;
        }
        public AnalogValue GetMainPres()
        {
            return Main_Pressure;
        }
        public void SetManualSetTemp(AnalogValue obj)
        {
            ManualSetTemp = obj;
        }
        public AnalogValue GetManualSetTemp()
        {
            return ManualSetTemp;
        }
        public void SetPneumaticPres(AnalogValue obj)
        {
            Pneumatic_Pressure = obj;
        }
        public AnalogValue GetPneumaticPres()
        {
            return Pneumatic_Pressure;
        }
        public void SetPreHeat_Temp_SP (AnalogValue obj)
        {
            PreHeat_Temp_SP = obj;
        }
        public AnalogValue GetPreHeat_Temp_SP()
        {
            return PreHeat_Temp_SP;
        }
        public void SetPreHeat_Timer_SP(AnalogValue obj)
        {
            PreHeat_Timer_SP = obj;
        }
        public AnalogValue GetPreHeat_Timer_SP()
        {
            return PreHeat_Timer_SP;
        }



    }
}
