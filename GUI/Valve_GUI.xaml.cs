﻿using KVANT_Scada_2.Objects;
using KVANT_Scada_2.UDT.Valve;
using Opc.UaFx.Client;
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




                ref OpcClient client = ref OPCObjects.client;
                //client.Connect();
                Input = client.ReadNode(inputPath).As<ValveInput>();
                   
                  
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
                ref OpcClient client = ref OPCObjects.client;

                //client.Connect();
                Input = client.ReadNode(inputPath).As<ValveInput>();
                Input.Auto_mode = false;
                OPCUAWorker.OPCUAWorker.Write<ValveInput>(inputPath, Input);
                //client.Disconnect();


            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            lock (OPCObjects.OPCLocker)
            {
                ref OpcClient client = ref OPCObjects.client;
                //client.Connect();
                Input = client.ReadNode(inputPath).As<ValveInput>();
                Input.Man_command = true;
                OPCUAWorker.OPCUAWorker.Write<ValveInput>(this.inputPath, Input);
                //client.Disconnect();

            }
         
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            ref OpcClient client =  ref OPCObjects.client;
            //client.Connect();
            Input = client.ReadNode(inputPath).As<ValveInput>();
            Input.Man_command = false;
            OPCUAWorker.OPCUAWorker.Write<ValveInput>(this.inputPath, Input);
            //client.Disconnect();
        }

        private void ServiceMode_Click(object sender, RoutedEventArgs e)
        {
            ref OpcClient client = ref OPCObjects.client;
            //client.Connect();
            Input = client.ReadNode(inputPath).As<ValveInput>();
            if(Input.Service_mode)
            {
                Input.Service_mode = false;
            }
            else
            {
                Input.Service_mode = true;
            }
            OPCUAWorker.OPCUAWorker.Write<ValveInput>(this.inputPath, Input);

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           
            UpdateTimer.Dispose();
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
                    ref OpcClient client = ref OPCObjects.client;
                    //client.Disconnect();
                    //client.Connect();
                
                    Status = OPCObjects.client.ReadNode(statusPath).As<ValveStatus>();
                    //client.Disconnect();
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
                    if(Status.Serviced)
                    {
                        ValveService.Fill = on;
                    }
                    else
                    {
                        ValveService.Fill = neutral;
                    }
                }
            });
            
        }
     }
  
}
