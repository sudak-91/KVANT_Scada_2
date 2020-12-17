using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Opc.Ua.Configuration;

using System.Threading;
using KVANT_Scada_2.DB;
using KVANT_Scada_2.Objects;
using System.ComponentModel;
using KVANT_Scada_2.GUI;
using KVANT_Scada_2.DB.Logic;

namespace KVANT_Scada_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public OPCUAWorker.OPCUAWorker opcUaWorker;
        public static TextBox tb;
        bool Firstcheck;
        TimerCallback UpdateTimerCallBack;
        Timer UpdateTimer;
        private SolidColorBrush on, error, neutral;
        


        //private BackgroundWorker backgroundWorker;


        public MainWindow()
        {
            
            //opcUaWorker.OPCNotify += OpcUaWorker_OPCNotify;
            InitializeComponent();
            Firstcheck = false;
            on = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            error = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            neutral = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            Main_pressure.IsReadOnly = true;
            Crio_pressure.IsReadOnly = true;
            ForVac_pressure.IsReadOnly = true;
            PnePressure.IsReadOnly = true;
            CamTemperature.IsReadOnly = true;
            Crio_temperature.IsReadOnly = true;
            this.WindowState = WindowState.Maximized;
          
            
            UpdateTimerCallBack = new TimerCallback(delegate  {
                UpdateGUI(null); 
            });
            UpdateTimer = new Timer(UpdateTimerCallBack, null, 0, 1000);


    





            


        }

        public void OpcUaWorker_OPCNotify(string text)
        {
            Console.WriteLine(text);
            
          
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
           
                
                
            
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        private void image_MouseEnter()
        {

        }

        private void Image_MouseEnter_1(object sender, MouseEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void UserCheck()
        {
            if(OPCObjects.user.Role == 0)
            {
                CrioStart.IsEnabled = false;
                StopCrio.IsEnabled = false;
            }
        }

        private void FVP_Open_Click(object sender, RoutedEventArgs e)
        {

            Thread FVPGuiThread = new Thread(delegate ()
            {
                FVP_GUI w = new FVP_GUI();
                w.Show();
                System.Windows.Threading.Dispatcher.Run();
            });
            FVPGuiThread.SetApartmentState(ApartmentState.STA);
            FVPGuiThread.Start();



        }

        private void CrioPumpStart_Click(object sender, RoutedEventArgs e)
        {

            Thread CrionGuiThread = new Thread(delegate ()
            {
                Crio_GUI w = new Crio_GUI();
                w.Show();
                System.Windows.Threading.Dispatcher.Run();
            });
            CrionGuiThread.SetApartmentState(ApartmentState.STA);
            CrionGuiThread.Start();

        }
        public void UpdateGUI(object obj)
        {
            Dispatcher.Invoke(()=> 
            {
                lock (OPCObjects.OPCLocker)
                {
                    Main_pressure.Text = OPCObjects.Main_Pressure.Value.ToString("E2") + "mbar";
                    Crio_pressure.Text = OPCObjects.Crio_Pressure.Value.ToString("E2") + "mbar";
                    ForVac_pressure.Text = OPCObjects.Camera_Pressure.Value.ToString() + "mbar";
                    PnePressure.Text = OPCObjects.Pneumatic_Pressure.Value.ToString() + "МПа";
                    Crio_temperature.Text = OPCObjects.Crio_Temperature.Value.ToString() + "K";
                    CamTemperature.Text = OPCObjects.TE_1.Value.ToString();
                    User_login_name.Content = OPCObjects.user.Login;
                    if (OPCObjects.user.Role == 0)
                    {
                        FVP_Open.IsEnabled = false;
                        CrioPumpStart.IsEnabled = false;
                        CPV_GUI.IsEnabled = false;
                        FVV_S_GUI.IsEnabled = false;
                        FVV_B_GUI.IsEnabled = false;
                        BAV3_GUI.IsEnabled = false;
                        IonGUI_ON.IsEnabled = false;
                        Driver_GUI.IsEnabled = false;
                        HeaterGUI_ON.IsEnabled = false;
                        CrioStart.IsEnabled = false;
                        StopCrio.IsEnabled = false;
                        OpenCam.IsEnabled = false;
                        CamPrepare.IsEnabled = false;
                        StopFVPBTN.IsEnabled = false;
                        StartELI.IsEnabled = false;
                        StopELI.IsEnabled = false;
                        PreHeatProc.IsEnabled = false;
                        Register_GUI.IsEnabled = false;
                        Signin.IsEnabled = true;
                        Signin.Visibility = Visibility.Visible;
                        Logout.Visibility = Visibility.Hidden;
                    }
                    if (OPCObjects.user.Role == 9)
                    {
                        Signin.IsEnabled = false;
                        Signin.Visibility = Visibility.Hidden;
                        Logout.Visibility = Visibility.Visible;
                        FVP_Open.IsEnabled = true;
                        CrioPumpStart.IsEnabled = true;
                        CPV_GUI.IsEnabled = true;
                        FVV_S_GUI.IsEnabled = true;
                        FVV_B_GUI.IsEnabled = true;
                        BAV3_GUI.IsEnabled = true;
                        IonGUI_ON.IsEnabled = true;
                        Driver_GUI.IsEnabled = true;
                        HeaterGUI_ON.IsEnabled = true;
                        CrioStart.IsEnabled = true;
                        StopCrio.IsEnabled = true;
                        OpenCam.IsEnabled = true;
                        CamPrepare.IsEnabled = true;
                        StopFVPBTN.IsEnabled = true;
                        StartELI.IsEnabled = true;
                        StopELI.IsEnabled = true;
                        PreHeatProc.IsEnabled = true;
                        Register_GUI.IsEnabled = true;

                    }
                    if (OPCObjects.user.Role != 0 && OPCObjects.user.Role != 9)
                    {
                        Signin.IsEnabled = false;
                        Signin.Visibility = Visibility.Hidden;
                        Logout.Visibility = Visibility.Visible;
                        FVP_Open.IsEnabled = true;
                        CrioPumpStart.IsEnabled = true;
                        CPV_GUI.IsEnabled = true;
                        FVV_S_GUI.IsEnabled = true;
                        FVV_B_GUI.IsEnabled = true;
                        BAV3_GUI.IsEnabled = true;
                        IonGUI_ON.IsEnabled = true;
                        Driver_GUI.IsEnabled = true;
                        HeaterGUI_ON.IsEnabled = true;
                        CrioStart.IsEnabled = true;
                        StopCrio.IsEnabled = true;
                        OpenCam.IsEnabled = true;
                        CamPrepare.IsEnabled = true;
                        StopFVPBTN.IsEnabled = true;
                        StartELI.IsEnabled = true;
                        StopELI.IsEnabled = true;
                        PreHeatProc.IsEnabled = true;
                        Register_GUI.IsEnabled = false;

                    }
                    if(OPCObjects.SHV_Status.Opened)
                    {
                        SHVOpened.Fill = on;
                    }
                    else
                    {
                        SHVOpened.Fill = neutral;
                    }
                    if(OPCObjects.EliShutter.Opened)
                    {
                        ELIShutter.Fill = on;
                    }
                    else
                    {
                        ELIShutter.Fill = neutral;
                    }

                    if (OPCObjects.Alarm_Open_door.Value)
                    {
                        AlarmOpenDoor.Fill = error;
                        DoorOpen.Fill = error;
                    }
                    else
                    {
                        AlarmOpenDoor.Fill = neutral;
                        DoorOpen.Fill = on;
                    }
                    if(OPCObjects.camPrepare.Stage_0_Cam_prepare_Complite)
                    {
                        CamPrepDone.Fill = on;
                    }
                    else
                    {
                        CamPrepDone.Fill = neutral;
                    }
                    if(OPCObjects.CrioPumpStart.Stage_0_CompliteP)
                    {
                        CrioStartDone.Fill = on;
                    }
                    else
                    {
                        CrioStartDone.Fill = neutral;
                    }
                    if(OPCObjects.openCam.Stage_1_done)
                    {
                        AtmosDone.Fill = on;
                    }
                    else
                    {
                        AtmosDone.Fill = neutral;
                    }
                    if(OPCObjects.FullCycleStage.Value == 1)
                    {
                        FullStage0.Fill = on;
                    }
                    if(OPCObjects.FullCycleStage.Value == 2)
                    {
                        FullStage1.Fill = on;
                    }
                    if (OPCObjects.FullCycleStage.Value == 20)
                    {
                        FullStage2.Fill = on;
                    }
                    if (OPCObjects.FullCycleStage.Value == 200)
                    {
                        FullStage3.Fill = on;
                    }
                    if (OPCObjects.FullCycleStage.Value == 3)
                    {
                        FullStage4.Fill = on;
                    }
                    if (OPCObjects.FullCycleStage.Value == 0)
                    {
                        FullStage0.Fill = neutral;
                        FullStage1.Fill = neutral;
                        FullStage2.Fill = neutral;
                        FullStage3.Fill = neutral;
                        FullStage4.Fill = neutral;
                    }

                    if (OPCObjects.Alarm_Crio_power_failure.Value)
                    {
                        AlarmCrioPower.Fill = error;
                    }
                    else
                    {
                        AlarmCrioPower.Fill = neutral;
                    }

                    if (OPCObjects.Alarm_ELI_Power_failure.Value)
                    {
                        AlarmELIPower.Fill = error;
                    }
                    else
                    {
                        AlarmELIPower.Fill = neutral;
                    }

                    if (OPCObjects.Alarm_FloatHeater_power_failure.Value)
                    {
                        AlarmFloatHeaterPower.Fill = error;
                    }
                    else
                    {
                        AlarmFloatHeaterPower.Fill = neutral;
                    }

                    if (OPCObjects.Alarm_FVP_power_failure.Value)
                    {
                        AlarmFVPPower.Fill = error;
                    } else
                    {
                        AlarmFVPPower.Fill = neutral;
                    }

                    if (OPCObjects.Alarm_Hight_Crio_Temp.Value)
                    {
                        AlarmHightCrioTemp.Fill = error;
                    }
                    else
                    {
                        AlarmHightCrioTemp.Fill = neutral;
                    }

                    if (OPCObjects.Alarm_Hight_Pne_Press.Value)
                    {
                        AlarmHightPnePress.Fill = error;
                    }
                    else
                    {
                        AlarmHightPnePress.Fill = neutral;
                    }

                    if (OPCObjects.Alarm_Indexer_power_failure.Value)
                    {
                        AlarmInderxerPower.Fill = error;
                    }
                    else
                    {
                        AlarmInderxerPower.Fill = neutral;
                    }


                    if (OPCObjects.Alarm_Ion_power_failure.Value)
                    {
                        AlarmIonPower.Fill = error;
                    }
                    else
                    {
                        AlarmIonPower.Fill = neutral;
                    }

                    if (OPCObjects.Alarm_Low_One_Presse.Value)
                    {
                        AlarmLowPnePress.Fill = error;
                    }
                    else
                    {
                        AlarmLowPnePress.Fill = neutral;
                    }

                    if (OPCObjects.Alarm_Qartz_power_failure.Value)
                    {
                        AlarmQartzPower.Fill = error;
                    }
                    else
                    {
                        AlarmQartzPower.Fill = neutral;
                    }

                    if (OPCObjects.Alarm_SSP_power_failure.Value)
                    {
                        AlarmSSPPower.Fill = error;
                    }
                    else {
                        AlarmSSPPower.Fill = neutral;
                    }

                    if (OPCObjects.Alarm_TV1_power_failure.Value)
                    {
                        AlarmTV1Power.Fill = error;
                    }
                    else
                    {
                        AlarmTV1Power.Fill = neutral;
                    }

                    if (OPCObjects.Alarm_Water_CRIO.Value)
                    {
                        AlarmWaterCrio.Fill = error;
                    }
                    else
                    {
                        AlarmWaterCrio.Fill = neutral;
                    }

                    if (OPCObjects.Alarm_Water_SECOND.Value)
                    {
                        AlarmWaterSecond.Fill = error;
                    }
                    else
                    {
                        AlarmWaterSecond.Fill = neutral;
                    }
                    if (OPCObjects.CrioStatus.Turn_On)
                    {
                        CrioPump.Fill = on;
                    }
                    else
                    {
                        CrioPump.Fill = neutral;
                    }
                    if (OPCObjects.FVPStatus.Power_On)
                    {
                        FVP.Fill = on;
                    }
                    else
                    {
                        FVP.Fill = neutral;
                    }
                    if (OPCObjects.FVV_B_Status.Opened)
                    {
                        FVV_B.Fill = on;
                    }
                    else
                    {
                        FVV_B.Fill = neutral;
                    }
                    if (OPCObjects.FVV_S_Status.Opened)
                    {
                        FVV_S.Fill = on;
                    }
                    else
                    {
                        FVV_S.Fill = neutral;
                    }
                    if (OPCObjects.CPV_Status.Opened)
                    {
                        CPV.Fill = on;
                    }
                    else
                    {
                        CPV.Fill = neutral;
                    }

                    if (OPCObjects.BAV_3_status.Opened)
                    {
                        BAV_3.Fill = on;
                    }
                    else
                    {
                        BAV_3.Fill = neutral;
                    }
                    if (!Firstcheck) {

                        HeatAssistcheckBox.IsChecked = OPCObjects.HeatAssist_Flag.Value;
                        HeatCam.IsChecked = OPCObjects.openCam.Heat_cam;
                        Firstcheck = true;
                    }
                    if (OPCObjects.Tech_cam_STAGE.Value == 3)
                    {
                        CamPrepare.Background = on;
                    }
                    else
                    {
                        CamPrepare.Background = neutral;
                    }
                    if (OPCObjects.Tech_cam_STAGE.Value == 2)
                    {
                        CamPrepare.Background = on;
                    }
                    else
                    {
                        CamPrepare.Background = neutral;
                    }
                    if (OPCObjects.Tech_cam_STAGE.Value == 4)
                    {
                        StopCrio.Background = on;
                    }
                    else
                    {
                        StopCrio.Background = neutral;
                    }
                    if (OPCObjects.Tech_cam_STAGE.Value == 5)
                    {
                        StopFVPBTN.Background = on;
                    }
                    else
                    {
                        StopFVPBTN.Background = neutral;
                    }
                    if (OPCObjects.CrioPumpStart.Stage_0_Stage != 0)
                    {
                        CrioStart.Background = on;
                    }
                    else
                    {
                        CrioStart.Background = neutral;
                    }
                    if (OPCObjects.StartProcessSignal.Value)
                    {
                        StartELI.Background = on;
                    }
                    else
                    {
                        StartELI.Background = neutral;
                    }
                    if (OPCObjects.BAV_3_status.Opened)
                    {
                        BAV_3.Fill = on;
                    }
                    else
                    {
                        BAV_3.Fill = neutral;
                    }
                    if (OPCObjects.CPV_Status.Opened)
                    {
                        CPV.Fill = on;
                    }
                    else
                    {
                        CPV.Fill = neutral;
                    }
                    if (OPCObjects.FVV_B_Status.Opened)
                    {
                        FVV_B.Fill = on;
                    }
                    else
                    {
                        FVV_B.Fill = neutral;
                    }
                    if (OPCObjects.FVV_S_Status.Opened)
                    {
                        FVV_S.Fill = on;
                    }
                    else
                    {
                        FVV_S.Fill = neutral;
                    }
                    if (OPCObjects.FVPStatus.Turn_On)
                    {
                        FVP.Fill = on;
                    }
                    else
                    {
                        FVP.Fill = neutral;
                    }
                    if (OPCObjects.CrioStatus.Turn_On)
                    {
                        CrioPump.Fill = on;
                    }
                    else
                    {
                        CrioPump.Fill = neutral;
                    }
                    if (OPCObjects.ELI_access.Value)
                    {
                        Eli_access.Fill = on;
                    }
                    else
                    {
                        Eli_access.Fill = error;
                    }
                    if (OPCObjects.ELI_complete.Value)
                    {
                        Eli_complete.Fill = on;
                    }
                    else
                    {
                        Eli_complete.Fill = neutral;
                    }
                    if (OPCObjects.BAV_3_status.Auto_mode)
                    {
                        BAV3AutoMode.Fill = on;
                    }
                    else
                    {
                        BAV3AutoMode.Fill = neutral;
                    }
                    if (OPCObjects.SHV_Status.Auto_mode)
                    {
                        SHVAutoMode.Fill = on;
                    }
                    else
                    {
                        SHVAutoMode.Fill = neutral;
                    }
                    if (OPCObjects.CPV_Status.Auto_mode)
                    {
                        CPVAutoMode.Fill = on;
                    }
                    else
                    {
                        CPVAutoMode.Fill = neutral;
                    }
                    if (OPCObjects.FVV_B_Status.Auto_mode)
                    {
                        FVVBAutoMode.Fill = on;
                    }
                    else
                    {
                        FVVBAutoMode.Fill = neutral;
                    }
                    if (OPCObjects.FVV_S_Status.Auto_mode)
                    {
                        FVVSAutoMode.Fill = on;
                    }
                    else
                    {
                        FVVSAutoMode.Fill = neutral;
                    }
                    if (OPCObjects.CrioStatus.Auto_mode)
                    {
                        CPAutoMode.Fill = on;
                    }
                    else
                    {
                        CPAutoMode.Fill = neutral;
                    }
                    if (OPCObjects.FVPStatus.Auto_mode)
                    {
                        FVPAutoMode.Fill = on;
                    }
                    else
                    {
                        FVPAutoMode.Fill = neutral;
                    }
                    if (OPCObjects.CrioPumpStart.Stage_0_Stage != 0)
                    {
                        CP_WORK.Fill = on;
                    }
                    else
                    {
                        CP_WORK.Fill = neutral;
                    }
                    if (OPCObjects.CrioPumpStart.Stage_0_Stage == 3)
                    {
                        CP_Vacuuming.Fill = on;
                    }
                    else
                    {
                        CP_Vacuuming.Fill = neutral;
                    }
                    if (OPCObjects.CrioPumpStart.Stage_0_Stage == 4)
                    {
                        CP_VacuumCheck.Fill = on;
                    }
                    else
                    {
                        CP_VacuumCheck.Fill = neutral;
                    }
                    if (OPCObjects.CrioPumpStart.Stage_0_Stage == 6)
                    {
                        CP_Cooling.Fill = on;
                    }
                    else
                    {
                        CP_Cooling.Fill = neutral;
                    }
                    if (OPCObjects.Tech_cam_STAGE.Value == 2)
                    {
                        CamPrepare.Background = on;
                    } else
                    {
                        CamPrepare.Background = neutral;
                    }
                    if(OPCObjects.Tech_cam_STAGE.Value == 3)
                    {
                        OpenCam.Background = on;
                    }
                    else
                    {
                        OpenCam.Background = neutral;
                    }
                    if(OPCObjects.SSP_turn_on.Value)
                    {
                        SSPStartStop.Background = on;
                    }
                    else
                    {
                        SSPStartStop.Background = neutral;
                    }


                    Console.WriteLine("MAIN GUI UPDATE" + DateTime.Now.ToString());
                        
                }
            });
          
        }

        private void BAV3_GUI_Click(object sender, RoutedEventArgs e)
        {
            Thread BAV_3_GuiThread = new Thread(delegate ()
            {
                Valve_GUI w = new Valve_GUI("Клапан напуска", ref OPCObjects.BAV_3_input, ref  OPCObjects.BAV_3_status, OPCUAWorker.OPCUAWorkerPaths.BAV_3_Input_path, OPCUAWorker.OPCUAWorkerPaths.BAV_3_Status_path);
                w.Show();
                System.Windows.Threading.Dispatcher.Run();
            });
            BAV_3_GuiThread.SetApartmentState(ApartmentState.STA);
            BAV_3_GuiThread.Start();
        }

        private void SHV_GUI_Click(object sender, RoutedEventArgs e)
        {
            Thread SHV_GuiThread = new Thread(delegate ()
            {
                Valve_GUI w = new Valve_GUI("Шиберный затвор", ref OPCObjects.SHV_Input, ref  OPCObjects.SHV_Status, OPCUAWorker.OPCUAWorkerPaths.SHV_Input_path, OPCUAWorker.OPCUAWorkerPaths.SHV_Status_path);
                w.Show();
                System.Windows.Threading.Dispatcher.Run();
            });
            SHV_GuiThread.SetApartmentState(ApartmentState.STA);
            SHV_GuiThread.Start();

        }

        private void CPV_GUI_Click(object sender, RoutedEventArgs e)
        {
            Thread CPV_GuiThread = new Thread(delegate ()
            {
                Valve_GUI w = new Valve_GUI("Клапан крионасоса", ref OPCObjects.CPV_Input,  ref OPCObjects.CPV_Status, OPCUAWorker.OPCUAWorkerPaths.CPV_Input_path, OPCUAWorker.OPCUAWorkerPaths.CPV_Status_path);
                w.Show();
                System.Windows.Threading.Dispatcher.Run();
            });
            CPV_GuiThread.SetApartmentState(ApartmentState.STA);
            CPV_GuiThread.Start();

        }

        private void FVV_S_GUI_Click(object sender, RoutedEventArgs e)
        {
            Thread FVV_S_GuiThread = new Thread(delegate ()
            {
                Valve_GUI w = new Valve_GUI("Клапан маленького сечения", ref OPCObjects.FVV_S_Input, ref  OPCObjects.FVV_S_Status, OPCUAWorker.OPCUAWorkerPaths.FVV_S_Input_path, OPCUAWorker.OPCUAWorkerPaths.FVV_S_Status_path);
                w.Show();
                System.Windows.Threading.Dispatcher.Run();
            });
            FVV_S_GuiThread.SetApartmentState(ApartmentState.STA);
            FVV_S_GuiThread.Start();

        }

        private void FVV_B_GUI_Click(object sender, RoutedEventArgs e)
        {
            Thread FVV_B_GuiThread = new Thread(delegate ()
            {
                Valve_GUI w = new Valve_GUI("Клапан большого сечения", ref OPCObjects.FVV_B_Input, ref OPCObjects.FVV_B_Status, OPCUAWorker.OPCUAWorkerPaths.FVV_B_Input_path, OPCUAWorker.OPCUAWorkerPaths.FVV_B_Status_path);
                w.Show();
                System.Windows.Threading.Dispatcher.Run();
            });
            FVV_B_GuiThread.SetApartmentState(ApartmentState.STA);
            FVV_B_GuiThread.Start();

        }

        private void Driver_GUI_Click(object sender, RoutedEventArgs e)
        {
            Thread Driver_GuiThread = new Thread(delegate ()
            {
                Driver_GUI w = new Driver_GUI();
                w.Show();
                System.Windows.Threading.Dispatcher.Run();
            });
            Driver_GuiThread.SetApartmentState(ApartmentState.STA);
            Driver_GuiThread.Start();

        }

        private void HeatAssistcheckBox_Checked(object sender, RoutedEventArgs e)
        {
            OPCObjects.HeatAssist_Flag.Value = (bool)HeatAssistcheckBox.IsChecked;
            OPCObjects.HeatAssist_Flag.WriteValue(ref OPCObjects.session);
           
            CreateData.AddOperatoAction(OPCObjects.user.Login, "Включение ассистирования при напылении");
        }

        private void HeatAssistcheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            OPCObjects.HeatAssist_Flag.Value = (bool)HeatAssistcheckBox.IsChecked;
            OPCObjects.HeatAssist_Flag.WriteValue(ref OPCObjects.session);
          
            CreateData.AddOperatoAction(OPCObjects.user.Login, "Отключение ассистирования при напылении");
        }

        private void CrioStart_Click(object sender, RoutedEventArgs e)
        {
            if (OPCObjects.user.Role == 0)
            {
                MessageBox.Show("Не хвататет прав доступа");

            }
            else
            {
                lock (OPCObjects.OPCLocker)
                {
                    if (OPCObjects.CrioPumpStart.Stage_0_Stage == 0)
                    {
                        OPCObjects.Crio_start_signal.Value = true;
                        OPCObjects.Crio_start_signal.WriteValue(ref OPCObjects.session);
                        CreateData.AddOperatoAction(OPCObjects.user.Login, "Запуск автоматического включения крионасоса");
                    }
          
                }
                

            }
        }

        private void StopCrio_Click(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
                OPCObjects.Tech_cam_STAGE.Value = 4;
                OPCObjects.Tech_cam_STAGE.WriteValue(ref OPCObjects.session);
            }
            CreateData.AddOperatoAction(OPCObjects.user.Login, "Запуск автоматической остановки крионасоса");
        }

        private void CamPrepare_Click(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
                OPCObjects.Tech_cam_STAGE.Value = 2;
                OPCObjects.Tech_cam_STAGE.WriteValue(ref OPCObjects.session);
            }
            CreateData.AddOperatoAction(OPCObjects.user.Login, "Запуск автоматической откачки камеры");
        }

        private void OpenCam_Click(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
                OPCObjects.Tech_cam_STAGE.Value = 3;
                OPCObjects.Tech_cam_STAGE.WriteValue(ref OPCObjects.session);
                
            }
            CreateData.AddOperatoAction(OPCObjects.user.Login, "Запуск автоматического напуска камеры");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
                OPCObjects.Tech_cam_STAGE.Value = 5;
                OPCObjects.Tech_cam_STAGE.WriteValue(ref OPCObjects.session);
            }
            CreateData.AddOperatoAction(OPCObjects.user.Login, "Запуск автоматической остановки ФВН");
        }

        private void StartELI_Click(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
                OPCObjects.StartProcessSignal.Value = true;
                OPCObjects.StartProcessSignal.WriteValue(ref OPCObjects.session);
            }
            CreateData.AddOperatoAction(OPCObjects.user.Login, "Запуск напыления");
        }

        private void StopELI_Click(object sender, RoutedEventArgs e)
        {
            lock (OPCObjects.OPCLocker)
            {
                OPCObjects.ELI_block.Value = false;
                OPCObjects.StopProcessSignal.Value = true;
                OPCObjects.StopProcessSignal.WriteValue(ref OPCObjects.session);
                OPCObjects.ELI_block.WriteValue(ref OPCObjects.session);
            }
            CreateData.AddOperatoAction(OPCObjects.user.Login, "Ручная остановка напыления");
        }

        private void PreHeatProc_Click(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
                OPCObjects.PreHeat_Start.Value = true;
                OPCObjects.PreHeat_Start.WriteValue(ref OPCObjects.session);
                
            }
            CreateData.AddOperatoAction(OPCObjects.user.Login, "Включение режима препрогрева");
        }
    

        private void Signin_Click(object sender, RoutedEventArgs e)
        {
            Thread USER_GuiThread = new Thread(delegate ()
            {
                Login w = new Login();
                w.Show();
                System.Windows.Threading.Dispatcher.Run();
            });
            USER_GuiThread.SetApartmentState(ApartmentState.STA);
            USER_GuiThread.Start();

        }

        private void Register_GUI_Click(object sender, RoutedEventArgs e)
        {
            Thread Register_GuiThread = new Thread(delegate ()
            {
                Register_GUI w = new Register_GUI();
                w.Show();
                System.Windows.Threading.Dispatcher.Run();
            });
            Register_GuiThread.SetApartmentState(ApartmentState.STA);
            Register_GuiThread.Start();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            OPCObjects.user.Role = 0;
            OPCObjects.user.Login = "";

        }

        private void RRG_GUI_Click(object sender, RoutedEventArgs e)
        {
            Thread RRG_GUIthread = new Thread(delegate ()
            {
                RRG_GUI w = new RRG_GUI();
                w.Show();
                System.Windows.Threading.Dispatcher.Run();
            });
            RRG_GUIthread.SetApartmentState(ApartmentState.STA);
            RRG_GUIthread.Start();

        }

        private void StopCriostart_Click(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
                OPCObjects.CrioPumpStart.Stage_0_Stage = 0;
                OPCObjects.CrioPumpStart.WriteInput(ref OPCObjects.session);
            }

        }

        private void StopPreHeat_Click(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
                OPCObjects.PreHeat_Done.Value = true;
                OPCObjects.PreHeat_Done.WriteValue(ref OPCObjects.session);
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            UpdateTimer.Dispose();
        }

        private void SSPStartStop_Click(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
                if(OPCObjects.SSP_turn_on.Value)
                {
                    OPCObjects.SSP_on.Value = false;
                }
                else
                {
                    OPCObjects.SSP_on.Value = true;
                }
                OPCObjects.SSP_on.WriteValue(ref OPCObjects.session);
            }
        }

        private void HeatCam_Checked(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
                OPCObjects.openCam.Heat_cam = HeatCam.IsChecked.Value;
                OPCObjects.openCam.WriteInput(ref OPCObjects.session);
            }
        }

        private void HeatCam_Unchecked(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
                OPCObjects.openCam.Heat_cam = HeatCam.IsChecked.Value;
                OPCObjects.openCam.WriteInput(ref OPCObjects.session);
            }
        }

        private void Shutter_Click(object sender, RoutedEventArgs e)
        {
            Thread ELIShutter_GUI = new Thread(delegate ()
            {
                ELIShutter w = new GUI.ELIShutter();
                w.Show();
                System.Windows.Threading.Dispatcher.Run();
            });
            ELIShutter_GUI.SetApartmentState(ApartmentState.STA);
            ELIShutter_GUI.Start();

        }

        private void IonGUI_ON_Click(object sender, RoutedEventArgs e)
        {
            Thread Ion_GuiThread = new Thread(delegate ()
            {
                Ion_GUI w = new Ion_GUI();
                w.Show();
                System.Windows.Threading.Dispatcher.Run();
            });
           Ion_GuiThread.SetApartmentState(ApartmentState.STA);
            Ion_GuiThread.Start();
        }

        private void HeaterGUI_ON_Click(object sender, RoutedEventArgs e)
        {
            Thread Heater_GuiThread = new Thread(delegate ()
            {
                Heat_GUI w = new Heat_GUI();
                w.Show();
                System.Windows.Threading.Dispatcher.Run();
            });
            Heater_GuiThread.SetApartmentState(ApartmentState.STA);
            Heater_GuiThread.Start();
        }
    }
}
