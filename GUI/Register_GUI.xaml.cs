using KVANT_Scada_2.DB;
using KVANT_Scada_2.DB.Entity;
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
    /// Логика взаимодействия для Register_GUI.xaml
    /// </summary>
    public partial class Register_GUI : Window
    {
        public Register_GUI()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            lock (OPCObjects.SQLLocker)
            {
                using (var context = new MyDBContext())
                {
                    var user = context.User.Where(x => x.Login == Username.Text);
                    if (user.Count() == 0)
                    {
                        var newuser = new User
                        {
                            Login = Username.Text,
                            Password = Password.Text,
                            Role = Role.SelectedIndex
                        };
                        context.User.Add(newuser);
                        context.SaveChanges();
                        context.Dispose();
                        MessageBox.Show("Пользователь создан");

                    }
                    else
                    {
                        MessageBox.Show("Пользователь с данным именем уже существует");
                    }
                }
            }
        }
    }
}
