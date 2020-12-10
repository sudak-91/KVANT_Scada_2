using KVANT_Scada_2.Objects;
using KVANT_Scada_2.UDT;
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
    /// Логика взаимодействия для RRG_GUI.xaml
    /// </summary>
    
    public partial class RRG_GUI : Window
    {
        private SolidColorBrush on, error, neutral;
        TimerCallback UpdateTimerCallBack;
        Timer UpdateTimer;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RRG_1_Feebback.IsReadOnly = true;
            RRG_2_Feebback.IsReadOnly = true;
            RRG_3_Feebback.IsReadOnly = true;
            RRG_4_Feebback.IsReadOnly = true;
            lock (OPCObjects.OPCLocker)
            {
                RRG_1_K.Text = OPCObjects.K_RRG1.Value.ToString();
                RRG_2_K.Text = OPCObjects.K_RRG2.Value.ToString();
                RRG_3_K.Text = OPCObjects.K_RRG3.Value.ToString();
                RRG_4_K.Text = OPCObjects.K_RRG4.Value.ToString();
                RRG_PID_SP.Text = OPCObjects.RRG_Pressure_SP.Value.ToString();
            }
            UpdateTimerCallBack = new TimerCallback(UpdateGUI);
            UpdateTimer = new Timer(UpdateTimerCallBack, null, 0, 1000);
        }

        private void SaveRRGPIDSP_Click(object sender, RoutedEventArgs e)
        {
            lock (OPCObjects.OPCLocker)
            {
                OPCObjects.RRG_Pressure_SP.Value = float.Parse(RRG_PID_SP.Text.Replace(".", ","));
                OPCObjects.RRG_Pressure_SP.WriteValue(ref OPCObjects.session);
               
            }
        }

        private void SaveRRG_K_Click(object sender, RoutedEventArgs e)
        {
            lock (OPCObjects.OPCLocker)
            {
                OPCObjects.K_RRG1.Value = float.Parse(RRG_1_K.Text.Replace(".", ","));
                OPCObjects.K_RRG2.Value = float.Parse(RRG_2_K.Text.Replace(".", ","));
                OPCObjects.K_RRG3.Value = float.Parse(RRG_3_K.Text.Replace(".", ","));
                OPCObjects.K_RRG4.Value = float.Parse(RRG_4_K.Text.Replace(".", ","));
                OPCObjects.K_RRG1.WriteValue(ref OPCObjects.session);
                OPCObjects.K_RRG2.WriteValue(ref OPCObjects.session);
                OPCObjects.K_RRG3.WriteValue(ref OPCObjects.session);
                OPCObjects.K_RRG4.WriteValue(ref OPCObjects.session);

            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UpdateTimer.Dispose();
        }

        public RRG_GUI()
        {
            InitializeComponent();
            on = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            error = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            neutral = new SolidColorBrush(Color.FromRgb(221, 221, 221));
        }
        private void UpdateGUI(object obj)
        {
            Dispatcher.Invoke(() => {
                RRG_1_Feebback.Text = OPCObjects.RRG_9A1_feedback.Value.ToString();
                RRG_2_Feebback.Text = OPCObjects.RRG_9A2_feedback.Value.ToString();
                RRG_3_Feebback.Text = OPCObjects.RRG_9A3_feedback.Value.ToString();
                RRG_4_Feebback.Text = OPCObjects.RRG_9A4_feedback.Value.ToString();
                
            });
            
        }


    }
}
