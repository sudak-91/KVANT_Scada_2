using KVANT_Scada_2.UDT;
using KVANT_Scada_2.UDT.Crio;
using KVANT_Scada_2.UDT.DiscreteValue;
using KVANT_Scada_2.UDT.FVP;
using KVANT_Scada_2.UDT.IntValue;
using KVANT_Scada_2.UDT.ION;
using KVANT_Scada_2.UDT.Tech_cam;
using KVANT_Scada_2.UDT.Valve;
using Opc.UaFx.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.Objects
{


    public class OPCObjects
    {

        public static OpcClient client;
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
        public static AnalogInput AnalogInput;
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
                                    K_RRG1, K_RRG2, K_RRG3, K_RRG4;
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
                                    Crio_start_signal, Alarm_manual_stop, StartProcessSignal, StopProcessSignal;
        public static IntValue PreHeat_Stage;
        public static IntValue HeatAssist_Stage;
        public static IntValue Tech_cam_STAGE;
        public static IntValue FullCycleStage;



        #region constructor
        private static OPCObjects instance;
        private OPCObjects()
        {
            camPrepare = new CamPrepare();
            AnalogValues = new List<AnalogValue>();
            DiscreteValues = new List<DiscreteValue>();
            ValvesInput = new Dictionary<int, ValveInput>();
            ValvesStatus = new Dictionary<int, ValveStatus>();
            SFT01_FT = new AnalogValue();
            SFT02_FT = new AnalogValue();
            SFT03_FT = new AnalogValue();
            SFT04_FT = new AnalogValue();
            SFT05_FT = new AnalogValue();
            SFT06_FT = new AnalogValue(); 
            SFT07_FT = new AnalogValue(); 
            SFT08_FT = new AnalogValue();
            SFT09_FT = new AnalogValue();
            SFT10_FT = new AnalogValue();
            FT_TT_1 = new AnalogValue();
            FT_TT_2 = new AnalogValue();
            FT_TT_3 = new AnalogValue();
            K_RRG1 = new AnalogValue();
            K_RRG2 = new AnalogValue();
            K_RRG3 = new AnalogValue();
            K_RRG4 = new AnalogValue();
            RRG_9A1_feedback = new AnalogValue();
            RRG_9A2_feedback = new AnalogValue();
            RRG_9A3_feedback = new AnalogValue();
            RRG_9A4_feedback = new AnalogValue();
            TE_1 = new AnalogValue();
            Pneumatic_Pressure = new AnalogValue();
            Crio_Pressure = new AnalogValue();
            Camera_Pressure = new AnalogValue(); 
            Main_Pressure = new AnalogValue();
            Crio_Temperature = new AnalogValue();
            PreHeat_Temp_SP = new AnalogValue();
            HeatAssist_Temp_SP = new AnalogValue();
            PreHeat_Timer_SP = new AnalogValue();
            HeatAssist_Timer_SP = new AnalogValue();
            ManualSetTemp = new AnalogValue(); 
            BLM_Speed = new AnalogValue();
            BLM_Speed_SP = new AnalogValue();
            PreHeat_Done = new DiscreteValue();
            HeatAssist_Done = new DiscreteValue();
            PreHeat_Start = new DiscreteValue();
            HeatAssist_Flag = new DiscreteValue(); 
            Heat_Done = new DiscreteValue();
            HeatAssist_TempDone = new DiscreteValue();
            Heat_Assit_On = new DiscreteValue();
            BLM_Start = new DiscreteValue();
            BLM_Stop = new DiscreteValue();
            BLM_Remote_Control_Done = new DiscreteValue();
            BLM_Run = new DiscreteValue();
            Alarm_Open_door = new DiscreteValue();
            Alarm_Water_CRIO = new DiscreteValue();
            Alarm_Hight_Pne_Press = new DiscreteValue();
            Alarm_Low_One_Presse = new DiscreteValue();
            Alarm_Crio_power_failure = new DiscreteValue();
            Alarm_Qartz_power_failure = new DiscreteValue();
            Alarm_ELI_Power_failure = new DiscreteValue();
            Alarm_FloatHeater_power_failure = new DiscreteValue();
            Alarm_Ion_power_failure = new DiscreteValue();
            Alarm_FVP_power_failure = new DiscreteValue();
            Alarm_Indexer_power_failure = new DiscreteValue();
            Alarm_SSP_power_failure = new DiscreteValue();
            Alarm_TV1_power_failure = new DiscreteValue();
            Alarm_Water_SECOND = new DiscreteValue();
            Alarm_Hight_Crio_Temp = new DiscreteValue();
            Crio_start_signal = new DiscreteValue();
            Alarm_manual_stop = new DiscreteValue();
            StartProcessSignal = new DiscreteValue();
            StartProcessSignal = new DiscreteValue();
            PreHeat_Stage = new IntValue();
            HeatAssist_Stage = new IntValue();
            Tech_cam_STAGE = new IntValue();
            FullCycleStage = new IntValue();
            IntValues = new List<IntValue>();
            FVPStatus = new FVPStatus();
            IonInputSetPoint = new IonInputSetPoint();
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

        public void SetAnalogInput(AnalogInput obj)
        {
            AnalogInput = obj;
        }
        public AnalogInput GetAnalogInput()
        {
            return AnalogInput;
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

        public void set_OpcClient(OpcClient client)
        {
            client = client;
        }
        public OpcClient get_OpcClietn()
        {
            return client;
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
