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
    /// Логика взаимодействия для ELIShutter.xaml
    /// </summary>
    public partial class ELIShutter : Window
    {


        private SolidColorBrush on, error, neutral;
        private TimerCallback timeCallback;
        private Timer timer;
        public ELIShutter()
        {
            on = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            error = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            neutral = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            timeCallback = new TimerCallback(Update_GUI);
            timer = new Timer(timeCallback, null, 0, 1000);
            InitializeComponent();
            this.Topmost = true;
        }

        private void btnAutoMode_Click(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
                if(OPCObjects.EliShutter.AutoMode)
                {
                    OPCObjects.EliShutter.AutoMode = false;
                }
                else
                {
                    OPCObjects.EliShutter.AutoMode = true;
                }
                OPCObjects.EliShutter.WriteValue(ref OPCObjects.session);
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
                OPCObjects.EliShutter.ManualOpen = true;
                OPCObjects.EliShutter.WriteValue(ref OPCObjects.session);
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
                OPCObjects.EliShutter.ManualClose = true;
                OPCObjects.EliShutter.WriteValue(ref OPCObjects.session);
            }
        }

        private void Update_GUI(object obj)
        {
            Dispatcher.Invoke(() => 
            {
                lock(OPCObjects.OPCLocker)
                {
                    if(OPCObjects.EliShutter.Opened)
                    {
                        Opened.Fill = on;
                    }
                    else
                    {
                        Opened.Fill = neutral;
                    }

                    if(OPCObjects.EliShutter.Closed)
                    {
                        Closed.Fill = on;
                    }
                    else
                    {
                        Closed.Fill = neutral;
                    }

                    if(OPCObjects.EliShutter.AutoMode)
                    {
                        AutoMode.Fill = on;

                    }
                    else
                    {
                        AutoMode.Fill = neutral;
                    } 
                }
                
            });
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer.Dispose();
        }
    }
}
