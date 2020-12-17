
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
using KVANT_Scada_2.UDT.DiscreteValue;
using KVANT_Scada_2.UDT.IntValue;
using System.Windows.Controls;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Configuration;
using System.Windows;

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

        public delegate void OPCHandler(string text);



        static string m_serverUrl = "opc.tcp://192.168.0.10:4840"; // Сервер
        
        static Session session;
        ConfiguredEndpoint endpoint;

        private ApplicationConfiguration _mapconfig;
        OPCHandler _opcHandler;
        public event OPCHandler OPCNotify;
        public OPCObjects opcobjects;

        public OPCUAWorker(ApplicationConfiguration ap)
        {
            opcobjects = OPCObjects.createObjects();
            _mapconfig = ap;
            EndpointDescription endpointDescription = CoreClientUtils.SelectEndpoint(m_serverUrl, false);
            EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create(_mapconfig);
            endpoint = new ConfiguredEndpoint(null, endpointDescription, endpointConfiguration);
            
        

        }
        public void ConnectOPC()
        {
            try
            {
                OPCObjects.session = Session.Create(
                       _mapconfig,
                       endpoint,
                       false,
                       false,
                       _mapconfig.ApplicationName,
                       10 * 60 * 60 * 1000,
                       new UserIdentity(),
                       null).Result;

            }catch(Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }
            
        }
        public void DisconectOPC()
        {
            OPCObjects.session.Close();
            OPCObjects.session.Dispose();
        }
        public void OPCUAConnect()
        {


        }
        public void RegisterHandler(OPCHandler opcHandler)
        {
            _opcHandler = opcHandler;
        }



        ///<summaray>
        ///Метод  StartOPCUAClient первичное подключени при инициализации системы.
        ///Выполняет чтение всех переменных.
        ///Запускает таймер циклического обновления данных
        ///</summaray>

        public void StartOPCUAClient()
        {
         
            


          
           
            
            


            lock (OPCObjects.OPCLocker)
            {

                #region BAV_3



                try
                {
                    OPCObjects.BAV_3_status.ReadValue(ref OPCObjects.session);
                    OPCObjects.FVV_S_Status.ReadValue(ref OPCObjects.session);
                    OPCObjects.FVV_B_Status.ReadValue(ref OPCObjects.session);

                    OPCObjects.CPV_Status.ReadValue(ref OPCObjects.session);
                    OPCObjects.SHV_Status.ReadValue(ref OPCObjects.session);




                    #region Crio_pump

                    OPCObjects.CrioStatus.ReadStatus(ref OPCObjects.session);
                    #endregion





                    OPCObjects.openCam.ReadValue(ref OPCObjects.session);

                    OPCObjects.CrioPumpStart.ReadValue(ref OPCObjects.session);


                    OPCObjects.camPrepare.ReadValue(ref OPCObjects.session);



                    OPCObjects.IonStatus.ReadValue(ref OPCObjects.session);


                    OPCObjects.IonOutputFeedBack.ReadValue(ref OPCObjects.session);

                    OPCObjects.IonInputSetPoint.ReadValue(ref OPCObjects.session);
                    OPCObjects.EliShutter.ReadValue(ref OPCObjects.session);



















                    OPCObjects.FVPStatus.ReadValue(ref OPCObjects.session);










                    //variable.BLM_Speed = client.ReadNode(OPCUAWorkerPaths.BLM_Speed_path);


                    // variable.BLM_Speed_SP = client.ReadNode(OPCUAWorkerPaths.BLM_Speed_SP_path);


                    //variable.CameraPressure = client.ReadNode(OPCUAWorkerPaths.CameraPressure_path);

                    //variable.CrioPressure = client.ReadNode(OPCUAWorkerPaths.CrioPressure_path);

                    //variable.CrioTemperature = client.ReadNode(OPCUAWorkerPaths.CrioTemperature_path);


                    //variable.FT_TT_1 = client.ReadNode(OPCUAWorkerPaths.FT_TT_1_path);
                    //variable.FT_TT_2 = client.ReadNode(OPCUAWorkerPaths.FT_TT_2_path);
                    //variable.FT_TT_3 = client.ReadNode(OPCUAWorkerPaths.FT_TT_3_path);




                    //variable.HeatAssist_Temp_SP = client.ReadNode(OPCUAWorkerPaths.HeatAssist_Temp_SP_path);

                    //variable.HeatAssist_Timer = client.ReadNode(OPCUAWorkerPaths.HeatAssist_Timer_path);

                    //variable.Heat_Assist_Timer_SP = client.ReadNode(OPCUAWorkerPaths.Heat_Assist_Timer_SP_path);


                    //variable.MainPressure = client.ReadNode(OPCUAWorkerPaths.MainPressure_path);

                    //variable.ManualSetTemp = client.ReadNode(OPCUAWorkerPaths.ManualSetTemp_path);

                    //variable.PneumaticPressure = client.ReadNode(OPCUAWorkerPaths.PneumaticPressure_path);




                    //variable.PreHeat_Temp_SP = client.ReadNode(OPCUAWorkerPaths.PreHeat_Temp_SP_path);

                    // variable.PreHeat_Timer = client.ReadNode(OPCUAWorkerPaths.PreHeat_Timer_path);

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
                    OPCObjects.AnalogValues.Add(OPCObjects.RRG_Pressure_SP);
                    OPCObjects.AnalogValues.Add(OPCObjects.PidHeatMode);
                    foreach (var a in OPCObjects.AnalogValues)
                    {
                        a.ReadValue(ref OPCObjects.session);
                    }

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
                    OPCObjects.DiscreteValues.Add(OPCObjects.ELI_access);
                    OPCObjects.DiscreteValues.Add(OPCObjects.ELI_complete);
                    OPCObjects.DiscreteValues.Add(OPCObjects.ELI_block);
                    OPCObjects.DiscreteValues.Add(OPCObjects.SSP_on);
                    OPCObjects.DiscreteValues.Add(OPCObjects.SSP_turn_on);
                    foreach (var a in OPCObjects.DiscreteValues)
                    {
                        a.ReadValue(ref OPCObjects.session);
                    }


                    OPCObjects.IntValues.Add(OPCObjects.HeatAssist_Stage);
                    OPCObjects.IntValues.Add(OPCObjects.Tech_cam_STAGE);
                    OPCObjects.IntValues.Add(OPCObjects.PreHeat_Stage);

                    foreach (var a in OPCObjects.IntValues)
                    {
                        a.ReadValue(ref OPCObjects.session);
                    }










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
                catch(Exception ex)
                {
                    MessageBox.Show(ex.InnerException.ToString());
                }

            }
            //this.RegisterSubscribe();

            OpcInnerTimer = new TimerCallback(TimerRead);
            timer = new Timer(OpcInnerTimer, session, 0, 5000);

            _opcHandler("OPC DONE");




        }






        

        private static void ReadOPCData()
        {
            
           
            lock (OPCObjects.OPCLocker)
            {
                try
                {
                    OPCObjects.BAV_3_status.ReadValue(ref OPCObjects.session);
                    OPCObjects.FVV_S_Status.ReadValue(ref OPCObjects.session);
                    OPCObjects.FVV_B_Status.ReadValue(ref OPCObjects.session);

                    OPCObjects.CPV_Status.ReadValue(ref OPCObjects.session);
                    OPCObjects.SHV_Status.ReadValue(ref OPCObjects.session);





                    #region Crio_pump

                    OPCObjects.CrioStatus.ReadStatus(ref OPCObjects.session);
                    #endregion




                    OPCObjects.openCam.ReadValue(ref OPCObjects.session);

                    OPCObjects.CrioPumpStart.ReadValue(ref OPCObjects.session);


                    OPCObjects.camPrepare.ReadValue(ref OPCObjects.session);

                    OPCObjects.IonStatus.ReadValue(ref OPCObjects.session);

                    OPCObjects.IonOutputFeedBack.ReadValue(ref OPCObjects.session);

                    OPCObjects.IonInputSetPoint.ReadValue(ref OPCObjects.session);
                    OPCObjects.EliShutter.ReadValue(ref OPCObjects.session);

















                    OPCObjects.FVPStatus.ReadValue(ref OPCObjects.session);


                    // variable.HeatAssist_Timer = client.ReadNode(OPCUAWorkerPaths.HeatAssist_Timer_path);

                    // variable.PreHeat_Timer = client.ReadNode(OPCUAWorkerPaths.PreHeat_Timer_path);


                    foreach (var a in OPCObjects.DiscreteValues)
                    {
                        a.ReadValue(ref OPCObjects.session);

                    }

                    foreach (var a in OPCObjects.AnalogValues)
                    {
                        a.ReadValue(ref OPCObjects.session);
                    }


                    foreach (var a in OPCObjects.IntValues)
                    {
                        a.ReadValue(ref OPCObjects.session);
                    }


                }catch(Exception ex)
                {
                    MessageBox.Show(ex.InnerException.ToString());
                }


                
            }


        }
        public void TimerRead(object obj)
        {
            
            Console.WriteLine("OPCUpdate");
            ReadOPCData();
           
        }
        
        public void Dispose()
        {

        }
    }
}
#endregion