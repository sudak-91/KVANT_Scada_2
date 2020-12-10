using KVANT_Scada_2.Objects;
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
using System.Windows.Shapes;

namespace KVANT_Scada_2.GUI
{
    /// <summary>
    /// Логика взаимодействия для Heat_GUI.xaml
    /// </summary>
    public partial class Heat_GUI : Window
    {
        public Heat_GUI()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HeatAssistTemp.Text = OPCObjects.HeatAssist_Temp_SP.Value.ToString();
            HeatAssistTime.Text = OPCObjects.HeatAssist_Timer_SP.Value.ToString();
            PreHeatTemp2.Text = OPCObjects.PreHeat_Temp_SP.Value.ToString();
            PreHeatTime2.Text = OPCObjects.PreHeat_Timer_SP.Value.ToString();
            HeatPowerSP.Text = OPCObjects.ManualSetTemp.Value.ToString();
        }

        private void PreHeatSave_Click(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
                OPCObjects.PreHeat_Temp_SP.Value = float.Parse(PreHeatTemp2.Text);
                OPCObjects.PreHeat_Temp_SP.WriteValue(ref OPCObjects.session);
                
                OPCObjects.PreHeat_Timer_SP.Value = float.Parse(PreHeatTime2.Text);
                OPCObjects.PreHeat_Timer_SP.WriteValue(ref OPCObjects.session);


            }
        }

        private void HeatAssistSave_Click(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
                OPCObjects.HeatAssist_Temp_SP.Value = float.Parse(HeatAssistTemp.Text);
                OPCObjects.HeatAssist_Temp_SP.WriteValue(ref OPCObjects.session);
                OPCObjects.HeatAssist_Timer_SP.Value = float.Parse(HeatAssistTime.Text);
                OPCObjects.HeatAssist_Timer_SP.WriteValue(ref OPCObjects.session);
            }
        }

        private void HeatManual_Click(object sender, RoutedEventArgs e)
        {
            lock(OPCObjects.OPCLocker)
            {
               OPCObjects.PidHeatMode.Value = (float)4.0;
                OPCObjects.PidHeatMode.WriteValue(ref OPCObjects.session);

            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
