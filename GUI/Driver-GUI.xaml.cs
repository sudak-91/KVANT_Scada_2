using KVANT_Scada_2.Objects;
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
    /// Логика взаимодействия для Driver_GUI.xaml
    /// </summary>
    public partial class Driver_GUI : Window
    {
        private SolidColorBrush on, error, neutral;
        private TimerCallback timerCallback;
        private Timer timer;
        public Driver_GUI()
        {
            on = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            error = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            neutral = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            timerCallback = new TimerCallback(Update_GUI);
            timer = new Timer(timerCallback, null, 0, 1000);
            this.Topmost = true;
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
                OPCObjects.BLM_Stop.Value = false;
                OPCObjects.BLM_Stop.WriteValue(ref OPCObjects.session);
               
                OPCObjects.BLM_Start.Value = true;
                OPCObjects.BLM_Start.WriteValue(ref OPCObjects.session);
            }
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            lock (OPCObjects.OPCLocker)
            {
                OPCObjects.BLM_Stop.Value = true;
                OPCObjects.BLM_Stop.WriteValue(ref OPCObjects.session);

                OPCObjects.BLM_Start.Value = false;
                OPCObjects.BLM_Start.WriteValue(ref OPCObjects.session);
            }
        

        }

        private void Reconnect_Click(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
               
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
                SpeedSP.Text = OPCObjects.BLM_Speed_SP.Value.ToString();
            }
            
        }
        private void Update_GUI(object obj)
        {
            Dispatcher.Invoke(()=>
            {
                lock(OPCObjects.OPCLocker)
                {
                    if(OPCObjects.BLM_Remote_Control_Done.Value)
                    {
                        RemoreControl.Fill = on;
                    }
                    else
                    {
                        RemoreControl.Fill = neutral;
                    }
                }
            });

        }
    }
}
