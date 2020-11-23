using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace KVANT_Scada_2
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        Timer key;
        OPCUAWorker.OPCUAWorker opcUaWorker;
        DB.Logic.CreateData createData;

        [STAThread]
        private void Application_Startup(object sender, StartupEventArgs e)
        {

            opcUaWorker = new OPCUAWorker.OPCUAWorker();
            createData = new DB.Logic.CreateData();
            Thread OPCthread = new Thread(new ThreadStart(opcUaWorker.StartOPCUAClient));
            Thread CreateDataThread = new Thread(new ThreadStart(createData.CreateTables));
            CreateDataThread.Start();
            OPCthread.Start(); 
        }
        

    }
  
}
