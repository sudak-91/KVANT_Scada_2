using Opc.UaFx.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KVANT_Scada_2.UDT.Valve;
using KVANT_Scada_2.Objects;
using KVANT_Scada_2.UDT.Crio;
using KVANT_Scada_2.UDT.Tech_cam;
using KVANT_Scada_2.UDT.ION;
using KVANT_Scada_2.UDT.FVP;
using KVANT_Scada_2.UDT;
using KVANT_Scada_2.DB;
using KVANT_Scada_2.DB.Entity;
using System.Threading;
using Opc.UaFx;
using KVANT_Scada_2.UDT.DiscreteValue;
using KVANT_Scada_2.UDT.IntValue;
using System.Windows.Controls;

namespace KVANT_Scada_2.OPCUAWorker
{
    ///<summaray>
    ///Класс OPCUAWoreker реализует логику обмена данными с OPC сервером
    ///
    ///</summaray>
    ///<value name = "timer">Таймер запуска циклической задачи обновления данных</value>
    ///<value name = "OPCLocker">Блокировщик потока для работы с данными OPC сервер</value>
    ///<value name = "client">Экземпляр клааса OpcClient</value>
    ///<value name = "opcobjects">Список всех OPC объектов</value>
    public class OPCUAWorker
    {
        Timer timer;
        object OPCLocker;
        TimerCallback OpcInnerTimer;
        OpcClient client;
        public delegate void OPCHandler(string text);


        OPCHandler _opcHandler;
        public event OPCHandler OPCNotify;
        public OPCObjects opcobjects;
        
        public OPCUAWorker()
        {
            opcobjects = OPCObjects.createObjects();
        }
        public void RegisterHandler(OPCHandler opcHandler)
        {
            _opcHandler = opcHandler;
        }
        ///<summaray>
        ///Метод  ReadAnalogValue осуществляет чтение данных OPC node
        ///и преобразования в тип float
        ///</summaray>
        ///<param name="analogValue">Ссылка на объект AnalogValue</param>
        ///<param name="Path">Путь до Node</param>
        ///<param name="client">OpcClient</param>
        private static void ReadAnalogValue(ref AnalogValue analogValue, string Path, OpcClient client)
        {
            OpcValue var = client.ReadNode(Path);
            analogValue.Path = Path;
            analogValue.Value = float.Parse(var.ToString());

        }
        ///<summaray>
        ///Метод  ReadDiscreteValue осуществляет чтение данных OPC node
        ///и преобразования в тип bool
        ///</summaray>
        ///<param name="discreteValue">Ссылка на объект DiscreteValue</param>
        ///<param name="Path">Путь до Node</param>
        ///<param name="client">OpcClient</param>

        private static void ReadDiscreteValue(ref DiscreteValue discreteValue, string Path, OpcClient client)
        {
            OpcValue var = client.ReadNode(Path);
            discreteValue.Path = Path;
            discreteValue.Value = (bool)var.Value;
        }
        ///<summaray>
        ///Метод  ReadIntegerValue осуществляет чтение данных OPC node
        ///и преобразования в тип int
        ///</summaray>
        ///<param name="intValue">Ссылка на объект DiscreteValue</param>
        ///<param name="Path">Путь до Node</param>
        ///<param name="client">OpcClient</param>
        private static void ReadIntegerValue(ref IntValue intValue, string Path, OpcClient client )
        {
            OpcValue var = client.ReadNode(Path);
            intValue.Path = Path;
            intValue.Value = int.Parse(var.ToString());
        }
        ///<summaray>
        ///Метод  ReadAnalogValues осуществляет чтение всех Node аналогового типа в проекте
        ///</summaray>
        ///<param name="client">OpcClient</param>
        public static void ReadAnalogValues(OpcClient client)
        {
            ReadAnalogValue(ref Objects.OPCObjects.BLM_Speed_SP, OPCUAWorkerPaths.BLM_Speed_SP_path, client);
            ReadAnalogValue(ref Objects.OPCObjects.Camera_Pressure, OPCUAWorkerPaths.CameraPressure_path, client);
            ReadAnalogValue(ref Objects.OPCObjects.Crio_Pressure, OPCUAWorkerPaths.CrioPressure_path, client);
            ReadAnalogValue(ref Objects.OPCObjects.Crio_Temperature, OPCUAWorkerPaths.CrioTemperature_path, client);
            ReadAnalogValue(ref Objects.OPCObjects.FT_TT_1, OPCUAWorkerPaths.FT_TT_1_path, client);
            ReadAnalogValue(ref Objects.OPCObjects.FT_TT_2, OPCUAWorkerPaths.FT_TT_2_path, client);
            ReadAnalogValue(ref Objects.OPCObjects.FT_TT_3, OPCUAWorkerPaths.FT_TT_3_path, client);
            ReadAnalogValue(ref Objects.OPCObjects.HeatAssist_Temp_SP, OPCUAWorkerPaths.HeatAssist_Temp_SP_path, client);
            ReadAnalogValue(ref Objects.OPCObjects.HeatAssist_Timer_SP, OPCUAWorkerPaths.Heat_Assist_Timer_SP_path, client);
            ReadAnalogValue(ref Objects.OPCObjects.Main_Pressure, OPCUAWorkerPaths.MainPressure_path, client);
            ReadAnalogValue(ref Objects.OPCObjects.ManualSetTemp, OPCUAWorkerPaths.ManualSetTemp_path, client);
            ReadAnalogValue(ref Objects.OPCObjects.Pneumatic_Pressure, OPCUAWorkerPaths.PneumaticPressure_path, client);
            ReadAnalogValue(ref Objects.OPCObjects.PreHeat_Temp_SP, OPCUAWorkerPaths.PreHeat_Temp_SP_path, client);
            ReadAnalogValue(ref Objects.OPCObjects.PreHeat_Timer_SP, OPCUAWorkerPaths.PreHeat_Timer_SP_path, client);
            ReadAnalogValue(ref Objects.OPCObjects.BLM_Speed, OPCUAWorkerPaths.BLM_Speed_path, client);
            ReadAnalogValue(ref Objects.OPCObjects.RRG_9A1_feedback, OPCUAWorkerPaths.RRG_9A1_feedback_path, client);
            ReadAnalogValue(ref Objects.OPCObjects.RRG_9A2_feedback, OPCUAWorkerPaths.RRG_9A2_feedback_path, client);
            ReadAnalogValue(ref Objects.OPCObjects.RRG_9A3_feedback, OPCUAWorkerPaths.RRG_9A3_feedback_path, client);
            ReadAnalogValue(ref Objects.OPCObjects.RRG_9A4_feedback, OPCUAWorkerPaths.RRG_9A4_feedback_path, client);
            ReadAnalogValue(ref OPCObjects.SFT01_FT, OPCUAWorkerPaths.SFT01_FT_path, client);
            ReadAnalogValue(ref OPCObjects.SFT02_FT, OPCUAWorkerPaths.SFT02_FT_path, client);
            ReadAnalogValue(ref OPCObjects.SFT03_FT, OPCUAWorkerPaths.SFT03_FT_path, client);
            ReadAnalogValue(ref OPCObjects.SFT04_FT, OPCUAWorkerPaths.SFT04_FT_path, client);
            ReadAnalogValue(ref OPCObjects.SFT05_FT, OPCUAWorkerPaths.SFT05_FT_path, client);
            ReadAnalogValue(ref OPCObjects.SFT06_FT, OPCUAWorkerPaths.SFT06_FT_path, client);
            ReadAnalogValue(ref OPCObjects.SFT07_FT, OPCUAWorkerPaths.SFT07_FT_path, client);
            ReadAnalogValue(ref OPCObjects.SFT08_FT, OPCUAWorkerPaths.SFT08_FT_path, client);
            ReadAnalogValue(ref OPCObjects.SFT09_FT, OPCUAWorkerPaths.SFT09_FT_path, client);
            ReadAnalogValue(ref OPCObjects.SFT10_FT, OPCUAWorkerPaths.SFT10_FT_path, client);
            ReadAnalogValue(ref OPCObjects.TE_1, OPCUAWorkerPaths.TE_1_path, client);
            ReadAnalogValue(ref OPCObjects.K_RRG1, OPCUAWorkerPaths.K_RRG1_path, client);
            ReadAnalogValue(ref OPCObjects.K_RRG2, OPCUAWorkerPaths.K_RRG2_path, client);
            ReadAnalogValue(ref OPCObjects.K_RRG3, OPCUAWorkerPaths.K_RRG3_path, client);
            ReadAnalogValue(ref OPCObjects.K_RRG4, OPCUAWorkerPaths.K_RRG4_path, client);

        }
        ///<summaray>
        ///Метод  ReadDiscreteValues осуществляет чтение всех Node дискретного типа в проекте
        ///</summaray>
        ///<param name="client">OpcClient</param>
        public static void ReadDiscretValues(OpcClient client)
        {
            ReadDiscreteValue(ref OPCObjects.Alarm_Crio_power_failure, OPCUAWorkerPaths.Alarm_Crio_power_failure_path, client);
            ReadDiscreteValue(ref OPCObjects.Alarm_ELI_Power_failure, OPCUAWorkerPaths.Alarm_Crio_power_failure_path, client);
            ReadDiscreteValue(ref OPCObjects.Alarm_FloatHeater_power_failure, OPCUAWorkerPaths.Alarm_FloatHeater_power_failure_path, client);
            ReadDiscreteValue(ref OPCObjects.Alarm_FVP_power_failure, OPCUAWorkerPaths.Alarm_FVP_power_failure_path, client);
            ReadDiscreteValue(ref OPCObjects.Alarm_Hight_Crio_Temp, OPCUAWorkerPaths.Alarm_Hight_Crio_Temp_path, client);
            ReadDiscreteValue(ref OPCObjects.Alarm_Hight_Pne_Press, OPCUAWorkerPaths.Alarm_Hight_Pne_Presse_path, client);
            ReadDiscreteValue(ref OPCObjects.Alarm_Indexer_power_failure, OPCUAWorkerPaths.Alarm_Indexer_power_failure_path, client);
            ReadDiscreteValue(ref OPCObjects.Alarm_Ion_power_failure, OPCUAWorkerPaths.Alarm_Ion_power_failure_path, client);
            ReadDiscreteValue(ref OPCObjects.Alarm_Low_One_Presse, OPCUAWorkerPaths.Alarm_Low_One_Presse_path, client);
            ReadDiscreteValue(ref OPCObjects.Alarm_manual_stop, OPCUAWorkerPaths.Alarm_manual_Stop_path, client);
            ReadDiscreteValue(ref OPCObjects.Alarm_Open_door, OPCUAWorkerPaths.Alarm_Open_door_path, client);
            ReadDiscreteValue(ref OPCObjects.Alarm_Qartz_power_failure, OPCUAWorkerPaths.Alarm_Qartz_power_filure_path, client);
            ReadDiscreteValue(ref OPCObjects.Alarm_SSP_power_failure, OPCUAWorkerPaths.Alarm_SSP_power_failure_path, client);
            ReadDiscreteValue(ref OPCObjects.Alarm_TV1_power_failure, OPCUAWorkerPaths.Alarm_TV1_power_failure_path, client);
            ReadDiscreteValue(ref OPCObjects.Alarm_Water_CRIO, OPCUAWorkerPaths.Alarm_Water_CRIO_path, client);
            ReadDiscreteValue(ref OPCObjects.Alarm_Water_SECOND, OPCUAWorkerPaths.Alarm_Water_SECOND_path, client);
            ReadDiscreteValue(ref OPCObjects.BLM_Remote_Control_Done, OPCUAWorkerPaths.BLM_Remote_Control_Done_path, client);
            ReadDiscreteValue(ref OPCObjects.BLM_Run, OPCUAWorkerPaths.BLM_Run_path, client);
            ReadDiscreteValue(ref OPCObjects.BLM_Start, OPCUAWorkerPaths.BLM_Start_path, client);
            ReadDiscreteValue(ref OPCObjects.BLM_Stop, OPCUAWorkerPaths.BLM_Stop_path, client);
            ReadDiscreteValue(ref OPCObjects.Crio_start_signal, OPCUAWorkerPaths.Crio_start_signal_path, client);
            ReadDiscreteValue(ref OPCObjects.HeatAssist_Done, OPCUAWorkerPaths.HeatAssist_Done_path, client);
            ReadDiscreteValue(ref OPCObjects.HeatAssist_Flag, OPCUAWorkerPaths.HeatAssist_Flag_path, client);
            ReadDiscreteValue(ref OPCObjects.HeatAssist_TempDone, OPCUAWorkerPaths.HeatAssist_TempDone_path, client);
            ReadDiscreteValue(ref OPCObjects.Heat_Assit_On, OPCUAWorkerPaths.Heat_Assist_ON_path, client);
            ReadDiscreteValue(ref OPCObjects.Heat_Done, OPCUAWorkerPaths.Heat_Done_path, client);
            ReadDiscreteValue(ref OPCObjects.PreHeat_Done, OPCUAWorkerPaths.PreHeat_Done_path, client);
            ReadDiscreteValue(ref OPCObjects.PreHeat_Start, OPCUAWorkerPaths.PreHeat_Start_path, client);
            ReadDiscreteValue(ref OPCObjects.StartProcessSignal, OPCUAWorkerPaths.StartProcessSignal_path, client);
            //ReadDiscreteValue(ref OPCObjects.StopProcessSignal, OPCUAWorkerPaths.StopProcessSignal_path, client);

        }
        ///<summaray>
        ///Метод  ReadIntegerValues осуществляет чтение всех Node целочисленного типа в проекте
        ///</summaray>
        ///<param name="client">OpcClient</param>
        public static void ReadIntegerValues(OpcClient client)
        {

            //variable.HeatAssist_Stage = client.ReadNode(OPCUAWorkerPaths.HeatAssist_Stage_path);
            //variable.Tech_cam_STAGE = client.ReadNode(OPCUAWorkerPaths.Tech_cam_STAGE_path);
            //variable.PreHeat_Stage = client.ReadNode(OPCUAWorkerPaths.PreHeat_Stage_path);
            ReadIntegerValue(ref OPCObjects.HeatAssist_Stage, OPCUAWorkerPaths.HeatAssist_Stage_path, client);
            ReadIntegerValue(ref OPCObjects.Tech_cam_STAGE, OPCUAWorkerPaths.Tech_cam_STAGE_path, client);
            ReadIntegerValue(ref OPCObjects.PreHeat_Stage, OPCUAWorkerPaths.PreHeat_Stage_path, client);
            //ReadIntegerValue(ref OPCObjects.FullCycleStage, OPCUAWorkerPaths.FullCycleStage_path, client);

        }
        ///<summaray>
        ///Метод  StartOPCUAClient первичное подключени при инициализации системы.
        ///Выполняет чтение всех переменных.
        ///Запускает таймер циклического обновления данных
        ///</summaray>

        public void StartOPCUAClient()
        {
            AnalogInput variable = new AnalogInput();
            OPCLocker = new object();
            client = new OpcClient("opc.tcp://192.168.0.10:4840/");
            opcobjects = OPCObjects.createObjects();
            OPCObjects.client = client;
            OPCObjects.OPCLocker = OPCLocker;
            
            lock (OPCObjects.OPCLocker) 
            {
                client.Connect();
                #region BAV_3
                ValveStatus BAV_3_Status = client.ReadNode(OPCUAWorkerPaths.BAV_3_Status_path).As<ValveStatus>();
                ValveInput BAV_3_Input = client.ReadNode(OPCUAWorkerPaths.BAV_3_Input_path).As<ValveInput>();
                #endregion
                #region FVV_S
                ValveStatus FVV_S_Status = client.ReadNode(OPCUAWorkerPaths.FVV_S_Status_path).As<ValveStatus>();
                ValveInput FVV_S_Input = client.ReadNode(OPCUAWorkerPaths.FVV_S_Input_path).As<ValveInput>();
                #endregion
                #region FVV_B
                ValveStatus FVV_B_Status = client.ReadNode(OPCUAWorkerPaths.FVV_B_Status_path).As<ValveStatus>();
                ValveInput FVV_B_Input = client.ReadNode(OPCUAWorkerPaths.FVV_B_Input_path).As<ValveInput>();
                #endregion
                #region CPV
                ValveStatus CPV_Status = client.ReadNode(OPCUAWorkerPaths.CPV_Status_path).As<ValveStatus>();
                ValveInput CPV_Input = client.ReadNode(OPCUAWorkerPaths.CPV_Input_path).As<ValveInput>();
                #endregion
                #region SHV
                ValveStatus SHV_Status = client.ReadNode(OPCUAWorkerPaths.SHV_Status_path).As<ValveStatus>();
                ValveInput SHV_Input = client.ReadNode(OPCUAWorkerPaths.SHV_Input_path).As<ValveInput>();
                #endregion
                





                #region Crio_pump
                CrioInput crioInput = client.ReadNode(OPCUAWorkerPaths.Crio_pump_Input_path).As<CrioInput>();
                CrioStatus crioStatus = client.ReadNode(OPCUAWorkerPaths.Crio_pump_Status_path).As<CrioStatus>();
                #endregion
                StopFVP StopFVP = client.ReadNode(OPCUAWorkerPaths.StopFVP_path).As<StopFVP>();
                StopCrio StopCrio = client.ReadNode(OPCUAWorkerPaths.StopCrio_path).As<StopCrio>();


                OpenCam OpenCam = client.ReadNode(OPCUAWorkerPaths.OpenCam_path).As<OpenCam>();
                CrioPumpStart CrioPumpStart = client.ReadNode(OPCUAWorkerPaths.CrioPumpStart_path).As<CrioPumpStart>();
                CamPrepare camPrepare = client.ReadNode(OPCUAWorkerPaths.CamPrepare_path).As<CamPrepare>();
                IonStatus IonStatus = client.ReadNode(OPCUAWorkerPaths.IonStatus_path).As<IonStatus>();
                IonOutputFeedBack IonOutputFeedBack = client.ReadNode(OPCUAWorkerPaths.IonOutputFeedBack_path).As<IonOutputFeedBack>();



                OPCObjects.IonInputSetPoint = client.ReadNode(OPCUAWorkerPaths.IonInputSetPoint_path).As<IonInputSetPoint>();


                //OpcNodeInfo adsd = client.BrowseNode(OPCUAWorkerPaths.IonInputSetPoint_path);
                //if (adsd is OpcVariableNodeInfo variablenode)
                //{
                //    OpcNodeId datatypeid = variablenode.DataTypeId;
                //    OpcDataTypeInfo datatype = client.GetDataTypeSystem().GetType(datatypeid);

                //    Console.WriteLine(datatype.TypeId);
                //    Console.WriteLine(datatype.Encoding);

                //    Console.WriteLine(datatype.Name);

                //    foreach (OpcDataFieldInfo field in datatype.GetFields())
                //        Console.WriteLine(".{0} : {1}", field.Name, field.FieldType);

                //    Console.WriteLine();
                //    Console.WriteLine("data type attributes:");
                //    Console.WriteLine(
                //            "\t[opcdatatype(\"{0}\")]",
                //            datatype.TypeId.ToString(OpcNodeIdFormat.Foundation));
                //    Console.WriteLine(
                //            "\t[opcdatatypeencoding(\"{0}\", namespaceuri = \"{1}\")]",
                //            datatype.Encoding.Id.ToString(OpcNodeIdFormat.Foundation),
                //            datatype.Encoding.Namespace.Value);
                //}


                IonInputCommand IonInputCommand = client.ReadNode(OPCUAWorkerPaths.IonInputCommand_path).As<IonInputCommand>();

               



                OPCObjects.FVPStatus = client.ReadNode(OPCUAWorkerPaths.FVPStatus_path).As<FVPStatus>();
                

                //variable.Alarm_Crio_power_failure = client.ReadNode(OPCUAWorkerPaths.Alarm_Crio_power_failure_path);
               
                //variable.Alarm_ELI_power_failure = client.ReadNode(OPCUAWorkerPaths.Alarm_ELI_power_failure_path);
               
                //variable.Alarm_FloatHeater_power_failure = client.ReadNode(OPCUAWorkerPaths.Alarm_FloatHeater_power_failure_path);
                //variable.Alarm_FVP_power_failure = client.ReadNode(OPCUAWorkerPaths.Alarm_FVP_power_failure_path);
                //variable.Alarm_Hight_Crio_Temp = client.ReadNode(OPCUAWorkerPaths.Alarm_Hight_Crio_Temp_path);
                //variable.Alarm_Hight_Pne_Presse = client.ReadNode(OPCUAWorkerPaths.Alarm_Hight_Pne_Presse_path);
                /// variable.Alarm_Indexer_power_failure = client.ReadNode(OPCUAWorkerPaths.Alarm_Indexer_power_failure_path);
                //variable.Alarm_Ion_power_failure = client.ReadNode(OPCUAWorkerPaths.Alarm_Ion_power_failure_path);
                //variable.Alarm_Low_One_Presse = client.ReadNode(OPCUAWorkerPaths.Alarm_Low_One_Presse_path);
                //variable.Alarm_manual_Stop = client.ReadNode(OPCUAWorkerPaths.Alarm_manual_Stop_path);
                //variable.Alarm_Open_door = client.ReadNode(OPCUAWorkerPaths.Alarm_Open_door_path);
                //variable.Alarm_Qartz_power_filure = client.ReadNode(OPCUAWorkerPaths.Alarm_Qartz_power_filure_path);
                //variable.Alarm_SSP_power_failure = client.ReadNode(OPCUAWorkerPaths.Alarm_SSP_power_failure_path);
                //variable.Alarm_TV1_power_failure = client.ReadNode(OPCUAWorkerPaths.Alarm_TV1_power_failure_path);
                //variable.Alarm_Water_CRIO = client.ReadNode(OPCUAWorkerPaths.Alarm_Water_CRIO_path);
                //variable.Alarm_Water_SECOND = client.ReadNode(OPCUAWorkerPaths.Alarm_Water_SECOND_path);
                //variable.BLM_Remote_Control_Done = client.ReadNode(OPCUAWorkerPaths.BLM_Remote_Control_Done_path);
                //variable.BLM_Run = client.ReadNode(OPCUAWorkerPaths.BLM_Run_path);
                //variable.BLM_Start = client.ReadNode(OPCUAWorkerPaths.BLM_Start_path);
                //variable.BLM_Stop = client.ReadNode(OPCUAWorkerPaths.BLM_Stop_path);
                //variable.Crio_start_signal = client.ReadNode(OPCUAWorkerPaths.Crio_start_signal_path);
                //variable.HeatAssist_Done = client.ReadNode(OPCUAWorkerPaths.HeatAssist_Done_path);
                //variable.HeatAssist_Flag = client.ReadNode(OPCUAWorkerPaths.HeatAssist_Flag_path);
                //variable.HeatAssist_TempDone = client.ReadNode(OPCUAWorkerPaths.HeatAssist_TempDone_path);
                //variable.Heat_Assist_ON = client.ReadNode(OPCUAWorkerPaths.Heat_Assist_ON_path);
                //variable.Heat_Done = client.ReadNode(OPCUAWorkerPaths.Heat_Done_path);
                //variable.Heat_Assist_ON = client.ReadNode(OPCUAWorkerPaths.Heat_Assist_ON_path);
                //variable.PreHeat_Done = client.ReadNode(OPCUAWorkerPaths.PreHeat_Done_path);
                //variable.PreHeat_Start = client.ReadNode(OPCUAWorkerPaths.PreHeat_Start_path);
              


                ReadAnalogValues(client);
               
                ReadDiscretValues(client);
                
                ReadIntegerValues(client);
               




                //variable.BLM_Speed = client.ReadNode(OPCUAWorkerPaths.BLM_Speed_path);


                // variable.BLM_Speed_SP = client.ReadNode(OPCUAWorkerPaths.BLM_Speed_SP_path);


                //variable.CameraPressure = client.ReadNode(OPCUAWorkerPaths.CameraPressure_path);

                //variable.CrioPressure = client.ReadNode(OPCUAWorkerPaths.CrioPressure_path);

                //variable.CrioTemperature = client.ReadNode(OPCUAWorkerPaths.CrioTemperature_path);


                //variable.FT_TT_1 = client.ReadNode(OPCUAWorkerPaths.FT_TT_1_path);
                //variable.FT_TT_2 = client.ReadNode(OPCUAWorkerPaths.FT_TT_2_path);
                //variable.FT_TT_3 = client.ReadNode(OPCUAWorkerPaths.FT_TT_3_path);




                //variable.HeatAssist_Temp_SP = client.ReadNode(OPCUAWorkerPaths.HeatAssist_Temp_SP_path);

                variable.HeatAssist_Timer = client.ReadNode(OPCUAWorkerPaths.HeatAssist_Timer_path);
                
                //variable.Heat_Assist_Timer_SP = client.ReadNode(OPCUAWorkerPaths.Heat_Assist_Timer_SP_path);
                
                
                //variable.MainPressure = client.ReadNode(OPCUAWorkerPaths.MainPressure_path);
                
                //variable.ManualSetTemp = client.ReadNode(OPCUAWorkerPaths.ManualSetTemp_path);
                
                //variable.PneumaticPressure = client.ReadNode(OPCUAWorkerPaths.PneumaticPressure_path);
                
                
                
                
                //variable.PreHeat_Temp_SP = client.ReadNode(OPCUAWorkerPaths.PreHeat_Temp_SP_path);
                
                variable.PreHeat_Timer = client.ReadNode(OPCUAWorkerPaths.PreHeat_Timer_path);
                
                //variable.PreHeat_Timer_SP = client.ReadNode(OPCUAWorkerPaths.PreHeat_Timer_SP_path);

                //variable.RRG_9A1_feedback = client.ReadNode(OPCUAWorkerPaths.RRG_9A1_feedback_path);
                //variable.RRG_9A2_feedback = client.ReadNode(OPCUAWorkerPaths.RRG_9A2_feedback_path);
                //variable.RRG_9A3_feedback = client.ReadNode(OPCUAWorkerPaths.RRG_9A3_feedback_path);
                //variable.RRG_9A4_feedback = client.ReadNode(OPCUAWorkerPaths.RRG_9A4_feedback_path);
                //variable.SFT01_FT = client.ReadNode(OPCUAWorkerPaths.SFT01_FT_path);
                //variable.SFT02_FT = client.ReadNode(OPCUAWorkerPaths.SFT02_FT_path);
                //variable.SFT03_FT = client.ReadNode(OPCUAWorkerPaths.SFT03_FT_path);
                //variable.SFT04_FT = client.ReadNode(OPCUAWorkerPaths.SFT04_FT_path);
                //variable.SFT05_FT = client.ReadNode(OPCUAWorkerPaths.SFT05_FT_path);
                //variable.SFT06_FT = client.ReadNode(OPCUAWorkerPaths.SFT06_FT_path);
                //variable.SFT07_FT = client.ReadNode(OPCUAWorkerPaths.SFT07_FT_path);
                //variable.SFT08_FT = client.ReadNode(OPCUAWorkerPaths.SFT08_FT_path);
                //variable.SFT09_FT = client.ReadNode(OPCUAWorkerPaths.SFT09_FT_path);
                //variable.SFT10_FT = client.ReadNode(OPCUAWorkerPaths.SFT10_FT_path);
                //variable.TE_1 = client.ReadNode(OPCUAWorkerPaths.TE_1_path);

               
               
               
                //client.Disconnect();
                
                Console.WriteLine("SDASDASDASDASDSA {0}", opcobjects.GetIonInputSetPoint().Heat_U_SP);


                OPCObjects.AnalogValues.Add(OPCObjects.BLM_Speed_SP);
                OPCObjects.AnalogValues.Add(OPCObjects.Camera_Pressure);
                OPCObjects.AnalogValues.Add(OPCObjects.Crio_Pressure);
                OPCObjects.AnalogValues.Add(OPCObjects.Crio_Temperature);
                OPCObjects.AnalogValues.Add(OPCObjects.FT_TT_1);
                OPCObjects.AnalogValues.Add(OPCObjects.FT_TT_2);
                OPCObjects.AnalogValues.Add(OPCObjects.FT_TT_3);
                OPCObjects.AnalogValues.Add(OPCObjects.HeatAssist_Temp_SP);
                OPCObjects.AnalogValues.Add(OPCObjects.HeatAssist_Timer_SP);
                OPCObjects.AnalogValues.Add(OPCObjects.Main_Pressure);
                OPCObjects.AnalogValues.Add(OPCObjects.ManualSetTemp);
                OPCObjects.AnalogValues.Add(OPCObjects.Pneumatic_Pressure);
                OPCObjects.AnalogValues.Add(OPCObjects.PreHeat_Temp_SP);
                OPCObjects.AnalogValues.Add(OPCObjects.PreHeat_Timer_SP);
                OPCObjects.AnalogValues.Add(OPCObjects.BLM_Speed);
                OPCObjects.AnalogValues.Add(OPCObjects.RRG_9A1_feedback);
                OPCObjects.AnalogValues.Add(OPCObjects.RRG_9A2_feedback);
                OPCObjects.AnalogValues.Add(OPCObjects.RRG_9A3_feedback);
                OPCObjects.AnalogValues.Add(OPCObjects.RRG_9A4_feedback);
                OPCObjects.AnalogValues.Add(OPCObjects.SFT01_FT);
                OPCObjects.AnalogValues.Add(OPCObjects.SFT02_FT);
                OPCObjects.AnalogValues.Add(OPCObjects.SFT03_FT);
                OPCObjects.AnalogValues.Add(OPCObjects.SFT04_FT);
                OPCObjects.AnalogValues.Add(OPCObjects.SFT05_FT);
                OPCObjects.AnalogValues.Add(OPCObjects.SFT06_FT);
                OPCObjects.AnalogValues.Add(OPCObjects.SFT07_FT);
                OPCObjects.AnalogValues.Add(OPCObjects.SFT08_FT);
                OPCObjects.AnalogValues.Add(OPCObjects.SFT09_FT);
                OPCObjects.AnalogValues.Add(OPCObjects.SFT10_FT);
                OPCObjects.AnalogValues.Add(OPCObjects.TE_1);
                OPCObjects.AnalogValues.Add(OPCObjects.K_RRG1);
                OPCObjects.AnalogValues.Add(OPCObjects.K_RRG2);
                OPCObjects.AnalogValues.Add(OPCObjects.K_RRG3);
                OPCObjects.AnalogValues.Add(OPCObjects.K_RRG4);

                OPCObjects.DiscreteValues.Add(OPCObjects.Alarm_Crio_power_failure);
                OPCObjects.DiscreteValues.Add(OPCObjects.Alarm_ELI_Power_failure);
                OPCObjects.DiscreteValues.Add(OPCObjects.Alarm_FloatHeater_power_failure);
                OPCObjects.DiscreteValues.Add(OPCObjects.Alarm_FVP_power_failure);
                OPCObjects.DiscreteValues.Add(OPCObjects.Alarm_Hight_Crio_Temp);
                OPCObjects.DiscreteValues.Add(OPCObjects.Alarm_Hight_Pne_Press);
                OPCObjects.DiscreteValues.Add(OPCObjects.Alarm_Indexer_power_failure);
                OPCObjects.DiscreteValues.Add(OPCObjects.Alarm_Ion_power_failure);
                OPCObjects.DiscreteValues.Add(OPCObjects.Alarm_Low_One_Presse);
                OPCObjects.DiscreteValues.Add(OPCObjects.Alarm_manual_stop);
                OPCObjects.DiscreteValues.Add(OPCObjects.Alarm_Open_door);
                OPCObjects.DiscreteValues.Add(OPCObjects.Alarm_Qartz_power_failure);
                OPCObjects.DiscreteValues.Add(OPCObjects.Alarm_SSP_power_failure);
                OPCObjects.DiscreteValues.Add(OPCObjects.Alarm_TV1_power_failure);
                OPCObjects.DiscreteValues.Add(OPCObjects.Alarm_Water_CRIO);
                OPCObjects.DiscreteValues.Add(OPCObjects.Alarm_Water_SECOND);
                OPCObjects.DiscreteValues.Add(OPCObjects.BLM_Remote_Control_Done);
                OPCObjects.DiscreteValues.Add(OPCObjects.BLM_Run);
                OPCObjects.DiscreteValues.Add(OPCObjects.BLM_Start);
                OPCObjects.DiscreteValues.Add(OPCObjects.BLM_Stop);
                OPCObjects.DiscreteValues.Add(OPCObjects.Crio_start_signal);
                OPCObjects.DiscreteValues.Add(OPCObjects.HeatAssist_Done);
                OPCObjects.DiscreteValues.Add(OPCObjects.HeatAssist_Flag);
                OPCObjects.DiscreteValues.Add(OPCObjects.HeatAssist_TempDone);
                OPCObjects.DiscreteValues.Add(OPCObjects.Heat_Assit_On);
                OPCObjects.DiscreteValues.Add(OPCObjects.Heat_Done);
                OPCObjects.DiscreteValues.Add(OPCObjects.PreHeat_Done);
                OPCObjects.DiscreteValues.Add(OPCObjects.PreHeat_Start);
                OPCObjects.DiscreteValues.Add(OPCObjects.StopProcessSignal);
                OPCObjects.DiscreteValues.Add(OPCObjects.StartProcessSignal);

                OPCObjects.IntValues.Add(OPCObjects.HeatAssist_Stage);
                OPCObjects.IntValues.Add(OPCObjects.Tech_cam_STAGE);
                OPCObjects.IntValues.Add(OPCObjects.PreHeat_Stage);

               







                opcobjects.setBAV_3_Status(BAV_3_Status);
                opcobjects.setBAV_3_Input(BAV_3_Input);
                opcobjects.set_CVP_Input(CPV_Input);
                opcobjects.set_CVP_Status(CPV_Status);
                opcobjects.set_FVV_B_Input(FVV_B_Input);
                opcobjects.set_FVV_B_Status(FVV_B_Status);
                opcobjects.set_FVV_S_Input(FVV_S_Input);
                opcobjects.set_FVV_S_Status(FVV_S_Status);
                opcobjects.set_SHV_Input(SHV_Input);
                opcobjects.set_SHV_Status(SHV_Status);
                opcobjects.SetCrioInput(crioInput);
                opcobjects.SetCrioStatus(crioStatus);
                opcobjects.SetStopFvp(StopFVP);
                opcobjects.SetStopCrio(StopCrio);
                opcobjects.set_OpcClient(client);
                opcobjects.SetOpenCam(OpenCam);
                opcobjects.set_CrioPumpStart(CrioPumpStart);
                opcobjects.set_camPrepare(camPrepare);
                opcobjects.SetIonStatus(IonStatus);
                opcobjects.SetIonOutputFeedBack(IonOutputFeedBack);
                //opcobjects.SetIonInputSetPoint(IonInputSetPoint);
                opcobjects.SetIonInputCommand(IonInputCommand);
                //opcobjects.SetFVPStatus(FVPStatus);
                opcobjects.SetAnalogInput(variable);
                opcobjects.setOPCLocker(OPCLocker);


                OPCObjects.ValvesInput.Add(1, OPCObjects.BAV_3_input);
                OPCObjects.ValvesStatus.Add(1, OPCObjects.BAV_3_status);
                OPCObjects.ValvesInput.Add(2, OPCObjects.SHV_Input);
                OPCObjects.ValvesStatus.Add(2, OPCObjects.SHV_Status);
                OPCObjects.ValvesInput.Add(3, OPCObjects.FVV_S_Input);
                OPCObjects.ValvesStatus.Add(3, OPCObjects.FVV_S_Status);
                OPCObjects.ValvesStatus.Add(4, OPCObjects.FVV_B_Status);
                OPCObjects.ValvesInput.Add(4, OPCObjects.FVV_B_Input);
                OPCObjects.ValvesInput.Add(5, OPCObjects.CPV_Input);
                OPCObjects.ValvesStatus.Add(5, OPCObjects.CPV_Status);

            }
            //this.RegisterSubscribe();

            OpcInnerTimer = new TimerCallback(TimerRead);
            timer = new Timer(OpcInnerTimer, client, 0, 2000);

            _opcHandler("OPC DONE");




        }


        public void RegisterSubscribe()
        {
            OpcSubscribeDataChange[] commands = new OpcSubscribeDataChange[]
            {
                new OpcSubscribeDataChange(OPCUAWorkerPaths.MainPressure_path,HandleAnalogDataChange),
                new OpcSubscribeDataChange(OPCUAWorkerPaths.CrioPressure_path,HandleAnalogDataChange)
            };
            var client = opcobjects.get_OpcClietn();
            OpcSubscription subscription = opcobjects.get_OpcClietn().SubscribeNodes(commands); 
        }

        private static void HandleAnalogDataChange(object sender, OpcDataChangeReceivedEventArgs e)
        {
            OpcMonitoredItem item = (OpcMonitoredItem)sender;

            Console.WriteLine(
                    "Data Change from NodeId '{0}': {1}",
                    item.RelativePath,
                    e.Item.Value);
            var objects = Objects.OPCObjects.createObjects();
            using(var context = new MyDBContext())
            {
                lock(objects.getSQLLocker())
                {
                    var analogs = context.AnalogValue.Where(x => x.Path == item.NodeId);
                    foreach (var analog in analogs)
                        {
                        var input = e.Item.Value.ToString();
                        analog.Value =float.Parse(input);
                        context.Update(analog);
                        context.SaveChanges();
                    }
                   
                    
                }

            }
            

    

        }
        ///<summaray>
        ///Метод  Write осуществляет запись Node если у ее модели есть представление
        ///</summaray>
        ///<param name="path">Путь к Node</param>
        ///<param name="obj">Изменененная Нода</param>
        public static void Write<T> (string path, T obj)
        {
            var opc = OPCObjects.createObjects();
            var client = opc.get_OpcClietn();
            client.WriteNode(path, obj);
       

        }
        public static void WriteDi(string path, bool obj)
        {

            var client = OPCObjects.client;
            lock(OPCObjects.OPCLocker)
            {
                client.Connect();
                client.WriteNode(path, obj);
            }
           
        }
        private static void ReadOPCData(object objclient)
        {
           var objects = OPCObjects.createObjects();
            lock (Objects.OPCObjects.createObjects().getOPCLocker())
            {
                OpcClient client = (OpcClient)objclient;
                var BAV_3_Status =objects.getBAV_3_Status();
                var BAV_3_Input = objects.getBAV_3_Input();
                var FVV_S_Status = objects.get_FVV_S_Status();
                var FVV_S_Input = objects.get_FVV_S_Input();
                var FVV_B_Status = objects.get_FVV_B_Status();
                var FVV_B_Input = objects.get_FVV_B_Input();
                var CPV_Status = objects.get_CVP_Status();
                var CPV_Input = objects.get_CVP_Input();
                var SHV_Status = objects.get_SHV_Status();
                var SHV_Input = objects.get_SHV_Input();
                var crioInput = objects.GetCrioInput();
                var crioStatus = objects.GetCrioStatus();
                var StopFVP = objects.GetStopFVP();
                var StopCrio =objects.GetStopCrio();
                var OpenCam = objects.GetOpenCam();
                var CrioPumpStart =objects.GetCrioPumpStart();
                var CamPrepare = objects.get_camPrepare();
                var IonStatus = objects.GetIonStatus();
                var IonOutputFeedBack = objects.GetIonOutputFeedBack();
                //var IonInputSetPoint = objects.GetIonInputSetPoint();
                var IonInputCommand = objects.GetIonInputCommand();
                var FVPStatus = objects.GetFVPStatus();
                var variable = objects.GetAnalogInput();

            
           
                client.Connect();
                BAV_3_Status = client.ReadNode(OPCUAWorkerPaths.BAV_3_Status_path).As<ValveStatus>();
                BAV_3_Input = client.ReadNode(OPCUAWorkerPaths.BAV_3_Input_path).As<ValveInput>();
                FVV_S_Status = client.ReadNode(OPCUAWorkerPaths.FVV_S_Status_path).As<ValveStatus>();
                FVV_S_Input = client.ReadNode(OPCUAWorkerPaths.FVV_S_Input_path).As<ValveInput>();
                FVV_B_Status = client.ReadNode(OPCUAWorkerPaths.FVV_B_Status_path).As<ValveStatus>();
                FVV_B_Input = client.ReadNode(OPCUAWorkerPaths.FVV_B_Input_path).As<ValveInput>();
                CPV_Status = client.ReadNode(OPCUAWorkerPaths.CPV_Status_path).As<ValveStatus>();
                CPV_Input = client.ReadNode(OPCUAWorkerPaths.CPV_Input_path).As<ValveInput>();
                SHV_Status = client.ReadNode(OPCUAWorkerPaths.SHV_Status_path).As<ValveStatus>();
                SHV_Input = client.ReadNode(OPCUAWorkerPaths.SHV_Input_path).As<ValveInput>();
                crioInput = client.ReadNode(OPCUAWorkerPaths.Crio_pump_Input_path).As<CrioInput>();
                crioStatus = client.ReadNode(OPCUAWorkerPaths.Crio_pump_Status_path).As<CrioStatus>();
                StopFVP = client.ReadNode(OPCUAWorkerPaths.StopFVP_path).As<StopFVP>();
                StopCrio = client.ReadNode(OPCUAWorkerPaths.StopCrio_path).As<StopCrio>();
                OpenCam = client.ReadNode(OPCUAWorkerPaths.OpenCam_path).As<OpenCam>();
                CrioPumpStart = client.ReadNode(OPCUAWorkerPaths.CrioPumpStart_path).As<CrioPumpStart>();
                CamPrepare = client.ReadNode(OPCUAWorkerPaths.CamPrepare_path).As<CamPrepare>();
                IonStatus = client.ReadNode(OPCUAWorkerPaths.IonStatus_path).As<IonStatus>();
                IonOutputFeedBack = client.ReadNode(OPCUAWorkerPaths.IonOutputFeedBack_path).As<IonOutputFeedBack>();
                OPCObjects.IonInputSetPoint = client.ReadNode(OPCUAWorkerPaths.IonInputSetPoint_path).As<IonInputSetPoint>();
                Console.WriteLine("SDASDASDASDASDSA {0}", OPCObjects.IonInputSetPoint.Heat_U_SP);
                IonInputCommand = client.ReadNode(OPCUAWorkerPaths.IonInputCommand_path).As<IonInputCommand>();
                OPCObjects.FVPStatus = client.ReadNode(OPCUAWorkerPaths.FVPStatus_path).As<FVPStatus>();
                Console.WriteLine("SDASDASDASDASDSA {0}", OPCObjects.FVPStatus.Remote);
                //variable.Alarm_Crio_power_failure = client.ReadNode(OPCUAWorkerPaths.Alarm_Crio_power_failure_path);
                
                //variable.Alarm_ELI_power_failure = client.ReadNode(OPCUAWorkerPaths.Alarm_ELI_power_failure_path);
                //variable.Alarm_FloatHeater_power_failure = client.ReadNode(OPCUAWorkerPaths.Alarm_FloatHeater_power_failure_path);
                //variable.Alarm_FVP_power_failure = client.ReadNode(OPCUAWorkerPaths.Alarm_FVP_power_failure_path);
                //variable.Alarm_Hight_Crio_Temp = client.ReadNode(OPCUAWorkerPaths.Alarm_Hight_Crio_Temp_path);
                //variable.Alarm_Hight_Pne_Presse = client.ReadNode(OPCUAWorkerPaths.Alarm_Hight_Pne_Presse_path);
                //variable.Alarm_Indexer_power_failure = client.ReadNode(OPCUAWorkerPaths.Alarm_Indexer_power_failure_path);
                //variable.Alarm_Ion_power_failure = client.ReadNode(OPCUAWorkerPaths.Alarm_Ion_power_failure_path);
                //variable.Alarm_Low_One_Presse = client.ReadNode(OPCUAWorkerPaths.Alarm_Low_One_Presse_path);
                //variable.Alarm_manual_Stop = client.ReadNode(OPCUAWorkerPaths.Alarm_manual_Stop_path);
                //variable.Alarm_Open_door = client.ReadNode(OPCUAWorkerPaths.Alarm_Open_door_path);
                //variable.Alarm_Qartz_power_filure = client.ReadNode(OPCUAWorkerPaths.Alarm_Qartz_power_filure_path);
                //variable.Alarm_SSP_power_failure = client.ReadNode(OPCUAWorkerPaths.Alarm_SSP_power_failure_path);
                //variable.Alarm_TV1_power_failure = client.ReadNode(OPCUAWorkerPaths.Alarm_TV1_power_failure_path);
                //variable.Alarm_Water_CRIO = client.ReadNode(OPCUAWorkerPaths.Alarm_Water_CRIO_path);
                //variable.Alarm_Water_SECOND = client.ReadNode(OPCUAWorkerPaths.Alarm_Water_SECOND_path);
                //variable.BLM_Remote_Control_Done = client.ReadNode(OPCUAWorkerPaths.BLM_Remote_Control_Done_path);
                //variable.BLM_Run = client.ReadNode(OPCUAWorkerPaths.BLM_Run_path);
                //variable.BLM_Speed = client.ReadNode(OPCUAWorkerPaths.BLM_Speed_path);
                //variable.BLM_Speed_SP = client.ReadNode(OPCUAWorkerPaths.BLM_Speed_SP_path);
                //variable.BLM_Start = client.ReadNode(OPCUAWorkerPaths.BLM_Start_path);
                //variable.BLM_Stop = client.ReadNode(OPCUAWorkerPaths.BLM_Stop_path);
                //variable.CameraPressure = client.ReadNode(OPCUAWorkerPaths.CameraPressure_path);
                //variable.CrioPressure = client.ReadNode(OPCUAWorkerPaths.CrioPressure_path);
                //variable.CrioTemperature = client.ReadNode(OPCUAWorkerPaths.CrioTemperature_path);
                //variable.Crio_start_signal = client.ReadNode(OPCUAWorkerPaths.Crio_start_signal_path);
                //variable.FT_TT_1 = client.ReadNode(OPCUAWorkerPaths.FT_TT_1_path);
                //variable.FT_TT_2 = client.ReadNode(OPCUAWorkerPaths.FT_TT_2_path);
                //variable.FT_TT_3 = client.ReadNode(OPCUAWorkerPaths.FT_TT_3_path);
                //variable.HeatAssist_Done = client.ReadNode(OPCUAWorkerPaths.HeatAssist_Done_path);
                //variable.HeatAssist_Flag = client.ReadNode(OPCUAWorkerPaths.HeatAssist_Flag_path);
                //variable.HeatAssist_Stage = client.ReadNode(OPCUAWorkerPaths.HeatAssist_Stage_path);
                //variable.HeatAssist_TempDone = client.ReadNode(OPCUAWorkerPaths.HeatAssist_TempDone_path);
                //variable.HeatAssist_Temp_SP = client.ReadNode(OPCUAWorkerPaths.HeatAssist_Temp_SP_path);
                variable.HeatAssist_Timer = client.ReadNode(OPCUAWorkerPaths.HeatAssist_Timer_path);
                //variable.Heat_Assist_ON = client.ReadNode(OPCUAWorkerPaths.Heat_Assist_ON_path);
                //variable.Heat_Assist_Timer_SP = client.ReadNode(OPCUAWorkerPaths.Heat_Assist_Timer_SP_path);
                //variable.Heat_Done = client.ReadNode(OPCUAWorkerPaths.Heat_Done_path);
                //variable.MainPressure = client.ReadNode(OPCUAWorkerPaths.MainPressure_path);
                //variable.ManualSetTemp = client.ReadNode(OPCUAWorkerPaths.ManualSetTemp_path);
                //variable.PneumaticPressure = client.ReadNode(OPCUAWorkerPaths.PneumaticPressure_path);
                //variable.PreHeat_Done = client.ReadNode(OPCUAWorkerPaths.PreHeat_Done_path);
                //variable.PreHeat_Stage = client.ReadNode(OPCUAWorkerPaths.PreHeat_Stage_path);
                //variable.PreHeat_Start = client.ReadNode(OPCUAWorkerPaths.PreHeat_Start_path);
                //variable.PreHeat_Temp_SP = client.ReadNode(OPCUAWorkerPaths.PreHeat_Temp_SP_path);
                variable.PreHeat_Timer = client.ReadNode(OPCUAWorkerPaths.PreHeat_Timer_path);
                //variable.PreHeat_Timer_SP = client.ReadNode(OPCUAWorkerPaths.PreHeat_Timer_SP_path);
                //variable.RRG_9A1_feedback = client.ReadNode(OPCUAWorkerPaths.RRG_9A1_feedback_path);
                //variable.RRG_9A2_feedback = client.ReadNode(OPCUAWorkerPaths.RRG_9A2_feedback_path);
                //variable.RRG_9A3_feedback = client.ReadNode(OPCUAWorkerPaths.RRG_9A3_feedback_path);
                //variable.RRG_9A4_feedback = client.ReadNode(OPCUAWorkerPaths.RRG_9A4_feedback_path);
                //variable.SFT01_FT = client.ReadNode(OPCUAWorkerPaths.SFT01_FT_path);
                //variable.SFT02_FT = client.ReadNode(OPCUAWorkerPaths.SFT02_FT_path);
                //variable.SFT03_FT = client.ReadNode(OPCUAWorkerPaths.SFT03_FT_path);
                //variable.SFT04_FT = client.ReadNode(OPCUAWorkerPaths.SFT04_FT_path);
                //variable.SFT05_FT = client.ReadNode(OPCUAWorkerPaths.SFT05_FT_path);
                //variable.SFT06_FT = client.ReadNode(OPCUAWorkerPaths.SFT06_FT_path);
                //variable.SFT07_FT = client.ReadNode(OPCUAWorkerPaths.SFT07_FT_path);
                //variable.SFT08_FT = client.ReadNode(OPCUAWorkerPaths.SFT08_FT_path);
                //variable.SFT09_FT = client.ReadNode(OPCUAWorkerPaths.SFT09_FT_path);
                //variable.SFT10_FT = client.ReadNode(OPCUAWorkerPaths.SFT10_FT_path);
                //variable.Tech_cam_STAGE = client.ReadNode(OPCUAWorkerPaths.Tech_cam_STAGE_path);
                //variable.TE_1 = client.ReadNode(OPCUAWorkerPaths.TE_1_path);

                ReadAnalogValues(client);
                ReadDiscretValues(client);
                ReadIntegerValues(client);





                client.Disconnect();



                
                objects.setBAV_3_Status(BAV_3_Status);
                objects.setBAV_3_Input(BAV_3_Input);
                objects.set_CVP_Input(CPV_Input);
                objects.set_CVP_Status(CPV_Status);
                objects.set_FVV_B_Input(FVV_B_Input);
                objects.set_FVV_B_Status(FVV_B_Status);
                objects.set_FVV_S_Input(FVV_S_Input);
                objects.set_FVV_S_Status(FVV_S_Status);
                objects.set_SHV_Input(SHV_Input);
                objects.set_SHV_Status(SHV_Status);
                objects.SetCrioInput(crioInput);
                objects.SetCrioStatus(crioStatus);
                objects.SetStopFvp(StopFVP);
                objects.SetStopCrio(StopCrio);
                objects.set_OpcClient(client);
                objects.SetOpenCam(OpenCam);
                objects.set_CrioPumpStart(CrioPumpStart);
                objects.set_camPrepare(CamPrepare);
                objects.SetIonStatus(IonStatus);
                objects.SetIonOutputFeedBack(IonOutputFeedBack);
                //objects.SetIonInputSetPoint(IonInputSetPoint);
                objects.SetIonInputCommand(IonInputCommand);
                //objects.SetFVPStatus(FVPStatus);
                objects.SetAnalogInput(variable);
            }
           

        }
        public  void TimerRead(object obj)
        {
            Console.WriteLine("OPCUpdate");
            ReadOPCData(obj);
            _opcHandler("OPC Server data update");
        }
        public void Dispose()
        {

        }
    }
}
