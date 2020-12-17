using KVANT_Scada_2.Objects;
using KVANT_Scada_2.UDT.Crio;
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
    /// Логика взаимодействия для Crio_GUI.xaml
    /// </summary>
    public partial class Crio_GUI : Window
    {
        private SolidColorBrush on, error, neutral;
        private TimerCallback timeCallback;
        private Timer timer;
        public Crio_GUI()
        {
            on = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            error = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            neutral = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            timeCallback = new TimerCallback(Update_GUI);
            timer = new Timer(timeCallback, null, 0, 1000);
            InitializeComponent();
            this.Topmost = true;
        }

        private void AutoMode_Click(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
                OPCObjects.CrioInput.Auto_mode = true;
                OPCObjects.CrioInput.WriteCrioInput(ref OPCObjects.session);
                

            }

        }

        private void ManualMode_Click(object sender, RoutedEventArgs e)
        {
            lock (OPCObjects.OPCLocker)
            {
                OPCObjects.CrioInput.Auto_mode = false;
                OPCObjects.CrioInput.WriteCrioInput(ref OPCObjects.session);

            }

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            lock (OPCObjects.OPCLocker)
            {
                OPCObjects.CrioInput.Command_manual = true;
                OPCObjects.CrioInput.WriteCrioInput(ref OPCObjects.session);

            }

        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            lock (OPCObjects.OPCLocker)
            {
                OPCObjects.CrioInput.Command_manual = false;
                OPCObjects.CrioInput.WriteCrioInput(ref OPCObjects.session);

            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer.Dispose();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void Update_GUI(object obj)
        {
            Dispatcher.Invoke(()=>
            {
                lock(OPCObjects.OPCLocker)
                {
                    if(OPCObjects.CrioStatus.Auto_mode)
                    {
                        CrioAutoMode.Fill = on;
                        CrioManualMode.Fill = neutral;
                    }
                    else
                    {
                        CrioAutoMode.Fill = neutral;
                        CrioManualMode.Fill = on;
                    }

                    if(OPCObjects.CrioStatus.Blocked)
                    {
                        CrioBlock.Fill = error;
                    }
                    else
                    {
                        CrioBlock.Fill = neutral;
                    }

                    if(OPCObjects.CrioStatus.Error)
                    {
                        CrioError.Fill = error;
                    }
                    else
                    {
                        CrioError.Fill = neutral;
                    }

                    if(OPCObjects.CrioStatus.Power_On)
                    {
                        CrioPowerOn.Fill = on;
                    }
                    else
                    {
                        CrioPowerOn.Fill = neutral;
                    }

                    if(OPCObjects.CrioStatus.Turn_On)
                    {
                        CrioTurnOn.Fill = on;
                    }
                    else
                    {
                        CrioTurnOn.Fill = neutral;
                    }
                }
            });

        }
    }

}
