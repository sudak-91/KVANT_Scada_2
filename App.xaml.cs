using Opc.Ua;
using Opc.Ua.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Opc.Ua.Client;

namespace KVANT_Scada_2
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        object locker;
        Timer key;
        public OPCUAWorker.OPCUAWorker opcUaWorker;
        DB.Logic.CreateData createData;
        MainWindow MainWindow;
        static string text;
        Resource1 res;
        

        public delegate void RefreshConsole();
        public event RefreshConsole Notify;

        [STAThread]
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            locker = new object();

            res = new Resource1();


            ApplicationInstance application = new ApplicationInstance();
            application.ApplicationName = "Quickstart Console Reference Client";
            application.ApplicationType = ApplicationType.Client;
            application.LoadApplicationConfiguration("D:\\Project\\opcua_TEST\\OpcUATest\\ConsoleReferenceClient.Config.xml", false).Wait();
            // check the application certificate.
            application.CheckApplicationInstanceCertificate(false, 0).Wait();

            application.ApplicationConfiguration.CertificateValidator.CertificateValidation += CertificateValidation;

            createData = new DB.Logic.CreateData();
            opcUaWorker = new OPCUAWorker.OPCUAWorker(application.ApplicationConfiguration);
            opcUaWorker.RegisterHandler(new OPCUAWorker.OPCUAWorker.OPCHandler(OpcUaWorker_OPCNotify));
            MainWindow = new MainWindow();
            MainWindow.Show();
           
            //opcUaWorker.OPCNotify += OpcUaWorker_OPCNotify;

            ConsoleWrite();
            //opcUaWorker.OPCNotify += MainWindow.OpcUaWorker_OPCNotify;
            Thread OPCthread = new Thread(new ThreadStart(opcUaWorker.StartOPCUAClient));
            Thread CreateDataThread = new Thread(new ThreadStart(createData.CreateTables));
            CreateDataThread.Start();
            OPCthread.Start(); 
        }


        
        private void OpcUaWorker_OPCNotify(string text)
        {
          
            //MainWindow.UpdateMainConsole();
            //throw new NotImplementedException();
        }
        private void ConsoleWrite()
        {
           
        }
        private static void CertificateValidation(CertificateValidator sender, CertificateValidationEventArgs e)
        {
            bool certificateAccepted = true;

            // ****
            // Implement a custom logic to decide if the certificate should be accepted or not and set certificateAccepted flag accordingly.
            // The certificate can be retrieved from the e.Certificate field
            // ***

            if (certificateAccepted)
            {
                Console.WriteLine("Untrusted Certificate accepted. SubjectName = {0}", e.Certificate.SubjectName);
            }

            e.Accept = certificateAccepted;
        }

    }
  
}
