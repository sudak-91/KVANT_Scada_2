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
using Opc.UaFx.Client;
using Opc.Ua.Configuration;
using Opc.UaFx;
using System.Threading;
using KVANT_Scada_2.DB;
using KVANT_Scada_2.Objects;
using System.ComponentModel;
using KVANT_Scada_2.GUI;

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
        public static string ConsoleMessage
        {
            get
            {
                return _consoleMessage;
            }
            set
            {
                _consoleMessage = value;
                if(_consoleMessage == value)
                {
                    MainWindow mw = new MainWindow();
                    mw.UpdateMainConsole();
                }
            }
        }

        public static string _consoleMessage { get; private set; }

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

            
            UpdateTimerCallBack = new TimerCallback(delegate  {
                UpdateGUI(null); 
            });
            UpdateTimer = new Timer(UpdateTimerCallBack, null, 0, 1000);

            
            //backgroundWorker = ((BackgroundWorker)this.FindResource("backgroundWorker"));
            //opcUaWorker= new OPCUAWorker.OPCUAWorker();
            //createData = new DB.Logic.CreateData();
            //Thread OPCthread = new Thread(new ThreadStart(opcUaWorker.StartOPCUAClient));
            //Thread CreateDataThread = new Thread(new ThreadStart(createData.CreateTables));
            // CreateDataThread.Start();
            // OPCthread.Start();
            //Thread thread = new Thread(new ThreadStart(StartTimer));
            //thread.Start();

            //this.RunUpdates();



            //while (OPCthread.IsAlive)
            //{
            //    Main_Load_bar.Value += 1;
            //}




            //Objects.OPCObjects opcObject = Objects.OPCObjects.createObjects();
            //UDT.Valve.ValveStatus BAV_3_Status = opcObject.getBAV_3_Status();
            //Console.WriteLine(BAV_3_Status.Auto_mode);
            //valve = new UDT.Valve.ValveUDT();
            // UDT.Valve.ValveUDT valve = client.ReadNode("ns=3;s=\"Valve_DB\".\"BAV_3\"").As<UDT.Valve.ValveUDT>();
            //OpcClient client = opcObject.get_OpcClietn();





            //var client = new OpcClient("opc.tcp://192.168.0.10:4840/");
            //client.Connect();

            //var node = client.BrowseNode("ns=3;s=\"Tech_Cam_Logic\".\"Stop_Crio\"");

            //if (node is OpcVariableNodeInfo variablenode)
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
            //Console.WriteLine("А я из основного потока. Просто надо так сделать");




        }

        public void OpcUaWorker_OPCNotify(string text)
        {
            Console.WriteLine(text);
            
            //UpdateMainConsole();
            //backgroundWorker.RunWorkerAsync();
        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        public  void UpdateMainConsole()
        {

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
                    Main_pressure.Text = OPCObjects.Main_Pressure.Value.ToString("E5") + "mbar";
                    Main_pressure.Text = OPCObjects.Main_Pressure.Value.ToString("E5") + "mbar";
                    Crio_pressure.Text = OPCObjects.Crio_Pressure.Value.ToString("E4") + "mbar";
                    ForVac_pressure.Text = OPCObjects.Camera_Pressure.Value.ToString() + "mbar";
                    PnePressure.Text = OPCObjects.Pneumatic_Pressure.Value.ToString() + "bar";
                    Crio_temperature.Text = OPCObjects.Crio_Temperature.Value.ToString() + "K";
                    CamTemperature.Text = OPCObjects.TE_1.Value.ToString();


                    if(OPCObjects.Alarm_Open_door.Value)
                    {
                        AlarmOpenDoor.Fill = error;
                        DoorOpen.Fill = error;
                    }
                    else
                    {
                        AlarmOpenDoor.Fill = neutral;
                        DoorOpen.Fill = on;
                    }


                    if(OPCObjects.Alarm_Crio_power_failure.Value)
                    {
                        AlarmCrioPower.Fill = error;
                    }
                    else
                    {
                        AlarmCrioPower.Fill = neutral;
                    }

                    if(OPCObjects.Alarm_ELI_Power_failure.Value)
                    {
                        AlarmELIPower.Fill = error;
                    }
                    else
                    {
                        AlarmELIPower.Fill = neutral;
                    }

                    if(OPCObjects.Alarm_FloatHeater_power_failure.Value)
                    {
                        AlarmFloatHeaterPower.Fill = error;
                    }
                    else
                    {
                        AlarmFloatHeaterPower.Fill = neutral;
                    }

                    if(OPCObjects.Alarm_FVP_power_failure.Value)
                    {
                        AlarmFVPPower.Fill = error;
                    }else
                    {
                        AlarmFVPPower.Fill = neutral;
                    }

                    if(OPCObjects.Alarm_Hight_Crio_Temp.Value)
                    {
                        AlarmHightCrioTemp.Fill = error;
                    }
                    else
                    {
                        AlarmHightCrioTemp.Fill = neutral;
                    }

                    if(OPCObjects.Alarm_Hight_Pne_Press.Value)
                    {
                        AlarmHightPnePress.Fill = error;
                    }
                    else
                    {
                        AlarmHightPnePress.Fill = neutral;
                    }

                    if(OPCObjects.Alarm_Indexer_power_failure.Value)
                    {
                        AlarmInderxerPower.Fill = error;
                    }
                    else
                    {
                        AlarmInderxerPower.Fill = neutral;
                    }


                    if(OPCObjects.Alarm_Ion_power_failure.Value)
                    {
                        AlarmIonPower.Fill = error;
                    }
                    else
                    {
                        AlarmIonPower.Fill = neutral;
                    }

                    if(OPCObjects.Alarm_Low_One_Presse.Value)
                    {
                        AlarmLowPnePress.Fill = error;
                    } 
                    else
                    {
                        AlarmLowPnePress.Fill = neutral;
                    }

                    if(OPCObjects.Alarm_Qartz_power_failure.Value)
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

                    if(OPCObjects.Alarm_TV1_power_failure.Value)
                    {
                        AlarmTV1Power.Fill = error;
                    }
                    else
                    {
                        AlarmTV1Power.Fill = neutral;
                    }

                    if(OPCObjects.Alarm_Water_CRIO.Value)
                    {
                        AlarmWaterCrio.Fill = error;
                    }
                    else
                    {
                        AlarmWaterCrio.Fill = neutral;
                    }

                    if(OPCObjects.Alarm_Water_SECOND.Value)
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
                    if(OPCObjects.FVV_B_Status.Opened)
                    {
                        FVV_B.Fill = on;
                    }
                    else
                    {
                        FVV_B.Fill = neutral;
                    }
                    if(OPCObjects.FVV_S_Status.Opened)
                    {
                        FVV_S.Fill = on;
                    }
                    else
                    {
                        FVV_S.Fill = neutral;
                    }
                    if(OPCObjects.CPV_Status.Opened)
                    {
                        CPV.Fill = on;
                    }
                    else
                    {
                        CPV.Fill = neutral;
                    }

                    if(OPCObjects.BAV_3_status.Opened)
                    {
                        BAV_3.Fill = on;
                    }
                    else
                    {
                        BAV_3.Fill = neutral;
                    }
                    if (!Firstcheck) {

                        HeatAssistcheckBox.IsChecked = OPCObjects.HeatAssist_Flag.Value;
                        Firstcheck = true;
                    }
                    

                }
            });
          
        }

        private void BAV3_GUI_Click(object sender, RoutedEventArgs e)
        {
            Thread BAV_3_GuiThread = new Thread(delegate ()
            {
                Valve_GUI w = new Valve_GUI("Клапан напуска");
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
                Valve_GUI w = new Valve_GUI("Шиберный затвор");
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
                Valve_GUI w = new Valve_GUI("Клапан крионасоса");
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
                Valve_GUI w = new Valve_GUI("Клапан маленького сечения");
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
                Valve_GUI w = new Valve_GUI("Клапан большого сечения");
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

            OPCUAWorker.OPCUAWorker.WriteDi(OPCUAWorker.OPCUAWorkerPaths.HeatAssist_Flag_path, (bool)HeatAssistcheckBox.IsChecked);
        }

        private void HeatAssistcheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            OPCUAWorker.OPCUAWorker.WriteDi(OPCUAWorker.OPCUAWorkerPaths.HeatAssist_Flag_path, (bool)HeatAssistcheckBox.IsChecked);
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
