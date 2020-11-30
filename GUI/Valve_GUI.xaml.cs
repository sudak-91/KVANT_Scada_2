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
    /// Логика взаимодействия для Valve_GUI.xaml
    /// </summary>
    public partial class Valve_GUI : Window
    {
        public Valve_GUI( string name)
        {
            InitializeComponent();
            this.Title = name;
        }
    }
}
