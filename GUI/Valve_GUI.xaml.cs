using KVANT_Scada_2.Objects;
using KVANT_Scada_2.UDT.Valve;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KVANT_Scada_2.GUI
{
    /// <summary>
    /// Логика взаимодействия для Valve_GUI.xaml
    /// </summary>
    public partial class Valve_GUI : Window
    {
        TimerCallback UpdateTimerCallBack;
        Timer UpdateTimer;

        public  ValveInput Input;
        public  ValveStatus Status;
       

        private string inputPath;
        private string statusPath;
        private SolidColorBrush on, error, neutral;

        private void AutoModeOn_Click(object sender, RoutedEventArgs e)
        {
            lock (OPCObjects.OPCLocker)
            {
               
                
               
              
                Console.WriteLine("###################################################3");
               
                   
                  
                //var client = OPCObjects.client;
                //client.Connect();
                Input.Auto_mode = true;
                OPCUAWorker.OPCUAWorker.Write<ValveInput>(inputPath, Input);
                //client.WriteNode(inputPath, Input);
            
                
                
            }
        }

        private void ManualModeOn_Click(object sender, RoutedEventArgs e)
        {
            //Input.Auto_mode = false;
            //OPCUAWorker.OPCUAWorker.Write<ValveInput>(this.inputPath, Input);
            lock (OPCObjects.OPCLocker)
            {
                
                Input.Auto_mode = false;
                OPCUAWorker.OPCUAWorker.Write<ValveInput>(inputPath, Input);


            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            Input.Man_command = true;
            OPCUAWorker.OPCUAWorker.Write<ValveInput>(this.inputPath, Input);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Input.Man_command = false;
            OPCUAWorker.OPCUAWorker.Write<ValveInput>(this.inputPath, Input);
        }

        public Valve_GUI( string name, ref ValveInput valveInput,  ref ValveStatus valveStatus, string inputPath, string statusPath)
        {
            InitializeComponent();
            this.Title = name;
            Input = valveInput;
            Status = valveStatus;
            on = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            error = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            neutral = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            this.inputPath = inputPath;
            this.statusPath = statusPath;
            UpdateTimerCallBack = new TimerCallback(UpdateGUI);
            UpdateTimer = new Timer(UpdateTimerCallBack, null, 0, 1000);
        }
        public void UpdateGUI(object obj)
        {

            Dispatcher.Invoke(() =>
            {
                lock (OPCObjects.OPCLocker)
                {
                    var client = OPCObjects.client;
                    client.Connect();
                    Status = client.ReadNode(statusPath).As<ValveStatus>();
                    
                    Console.WriteLine("-----------------------------------Обновление{0}", Status.Auto_mode.ToString());
                    if (Status.Auto_mode)
                    {
                        ValveAutoMode.Fill = on;
                        ValveManuakMode.Fill = neutral;
                    }
                    else
                    {
                        ValveAutoMode.Fill = neutral;
                        ValveManuakMode.Fill = on;
                    }

                    if (Status.Blocked)
                    {
                        ValveBlocked.Fill = error;
                    }
                    else
                    {
                        ValveBlocked.Fill = neutral;
                    }

                    if (Status.Closed)
                    {
                        ValveClosed.Fill = on;
                    }
                    else
                    {
                        ValveClosed.Fill = neutral;
                    }

                    if (Status.Opened)
                    {
                        ValveOpened.Fill = on;
                    }
                    else
                    {
                        ValveOpened.Fill = neutral;
                    }
                }
            });
            
        }
     }
  
}
