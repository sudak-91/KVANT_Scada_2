using KVANT_Scada_2.Objects;
using KVANT_Scada_2.UDT.FVP;
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
    /// Логика взаимодействия для FVP_GUI.xaml
    /// </summary>
    public partial class FVP_GUI : Window
    {
        private SolidColorBrush on, error, neutral;
        private TimerCallback timerCallback;
        private Timer UpdateTimer;

        public FVP_GUI()
        {
            on = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            error = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            neutral = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            InitializeComponent();
            timerCallback = new TimerCallback(Update_GUI);
            UpdateTimer = new Timer(timerCallback, null, 0, 1000);
        }

        private void btnFVPAutoMode_Click(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
                OPCObjects.FVPStatus.Auto_mode = true;
                OPCObjects.FVPStatus.Remote = false;
                UDT.FVP.FVPStatus.WriteInput(ref OPCObjects.session, ref OPCObjects.FVPStatus);
                
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnFVPManualMode_Click(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
                OPCObjects.FVPStatus.Auto_mode = false;
                OPCObjects.FVPStatus.Remote = true;
                UDT.FVP.FVPStatus.WriteInput(ref OPCObjects.session, ref OPCObjects.FVPStatus);
            }
        }

        private void btnFVPOpen_Click(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
                OPCObjects.FVPStatus.Manual_start = true;
                UDT.FVP.FVPStatus.WriteInput(ref OPCObjects.session, ref OPCObjects.FVPStatus);
            }
        }

        private void btnFVPClose_Click(object sender, RoutedEventArgs e)
        {
            lock (OPCObjects.OPCLocker)
            {
                OPCObjects.FVPStatus.Manual_start = false;
                UDT.FVP.FVPStatus.WriteInput(ref OPCObjects.session, ref OPCObjects.FVPStatus);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           
            UpdateTimer.Dispose();
        }

        private void btnFVPService_Click(object sender, RoutedEventArgs e)
        {


        }
        private void Update_GUI(object obj)
        {
            Dispatcher.Invoke(() => {
            lock(OPCObjects.OPCLocker)
                {
                    if (OPCObjects.FVPStatus.Auto_mode)
                    {
                        FVPAutoMode.Fill = on;
                        FVPManualMode.Fill = neutral;
                    }
                    else
                    {
                        FVPManualMode.Fill = on;
                        FVPAutoMode.Fill = neutral;
                    }

                    if (OPCObjects.FVPStatus.Power_On)
                    {
                        FVPPowerOn.Fill = on;
                    }
                    else
                    {
                        FVPPowerOn.Fill = neutral;
                    }
                    if (OPCObjects.FVPStatus.Turn_On)
                    {
                        FVPTurnOn.Fill = on;
                    }
                    else
                    {
                        FVPTurnOn.Fill = neutral;
                    }
                }
            });
            
        }
    }

}
