using KVANT_Scada_2.Objects;
using KVANT_Scada_2.UDT.ION;
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
    /// Логика взаимодействия для Ion_GUI.xaml
    /// </summary>
    public partial class Ion_GUI : Window
    {
        private SolidColorBrush on, error, neutral;
        TimerCallback UpdateTimerCallBack;
        Timer UpdateTimer;
        public Ion_GUI()
        {
            InitializeComponent();
            on = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            error = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            neutral = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            UpdateTimerCallBack = new TimerCallback(UpdateGUI);
            UpdateTimer = new Timer(UpdateTimerCallBack, null, 0, 1000);
        }

        private void SaveSP_Click(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
                OPCObjects.IonInputSetPoint.Anod_I_SP = float.Parse(AnodSPI.Text);
                OPCObjects.IonInputSetPoint.Anod_P_SP = float.Parse(AnodSPP.Text);
                OPCObjects.IonInputSetPoint.Anod_U_SP = float.Parse(AnodSPU.Text);
                OPCObjects.IonInputSetPoint.Heat_I_SP = float.Parse(HeatSPI.Text);
                OPCObjects.IonInputSetPoint.Heat_P_SP = float.Parse(HeatSPP.Text);
                OPCObjects.IonInputSetPoint.Heat_U_SP = float.Parse(HeatSPU.Text);
                OPCUAWorker.OPCUAWorker.Write<IonInputSetPoint>(OPCUAWorker.OPCUAWorkerPaths.IonInputSetPoint_path, OPCObjects.IonInputSetPoint);
            }
        }

        private void IonStart_Click(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
                OPCObjects.IonInputCommnd.Manual_Start = true;
                OPCUAWorker.OPCUAWorker.Write<IonInputCommand>(OPCUAWorker.OPCUAWorkerPaths.IonInputCommand_path, OPCObjects.IonInputCommnd);
            }
        }

        private void IonStop_Click(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
                OPCObjects.IonInputCommnd.Manual_Stop = true;
                OPCUAWorker.OPCUAWorker.Write<IonInputCommand>(OPCUAWorker.OPCUAWorkerPaths.IonInputCommand_path, OPCObjects.IonInputCommnd);
            }
        }

        private void IonError_Click(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
                OPCObjects.IonInputCommnd.Reset_error = true;
                OPCUAWorker.OPCUAWorker.Write<IonInputCommand>(OPCUAWorker.OPCUAWorkerPaths.IonInputCommand_path, OPCObjects.IonInputCommnd);
            }
        }

        private void IonAutoMode_Click(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
                if(OPCObjects.IonInputCommnd.Auto_mod)
                {
                    OPCObjects.IonInputCommnd.Auto_mod = false;
                }
                else
                {
                    OPCObjects.IonInputCommnd.Auto_mod = true;
                }
                OPCUAWorker.OPCUAWorker.Write<IonInputCommand>(OPCUAWorker.OPCUAWorkerPaths.IonInputCommand_path, OPCObjects.IonInputCommnd);

            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UpdateTimer.Dispose();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lock (OPCObjects.OPCLocker)
            {
                AnodSPI.Text = OPCObjects.IonInputSetPoint.Anod_I_SP.ToString();
                AnodSPP.Text = OPCObjects.IonInputSetPoint.Anod_P_SP.ToString();
                AnodSPU.Text = OPCObjects.IonInputSetPoint.Anod_U_SP.ToString();
                HeatSPI.Text = OPCObjects.IonInputSetPoint.Heat_I_SP.ToString();
                HeatSPU.Text = OPCObjects.IonInputSetPoint.Heat_U_SP.ToString();
                HeatSPP.Text = OPCObjects.IonInputSetPoint.Heat_P_SP.ToString();
            }
        }
        private void UpdateGUI(object obj)
        {
            Dispatcher.Invoke(() => {
                lock (OPCObjects.OPCLocker)
                {
                    AnodI1.Text = OPCObjects.IonOutputFeedBack.Anod_I.ToString();
                    AnodP1.Text = OPCObjects.IonOutputFeedBack.Anod_P.ToString();
                    AnodU1.Text = OPCObjects.IonOutputFeedBack.Anod_U.ToString();
                    HeatI.Text = OPCObjects.IonOutputFeedBack.Heat_I.ToString();
                    HeatP.Text = OPCObjects.IonOutputFeedBack.Heat_P.ToString();
                    HeatU.Text = OPCObjects.IonOutputFeedBack.Heat_U.ToString();
                    if (OPCObjects.IonStatus.Power_on)
                    {
                        PowerOn.Fill = on;
                    }
                    else
                    {
                        PowerOn.Fill = neutral;
                    }
                    if (OPCObjects.IonStatus.Auto_mode)
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
    }

}
