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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Opc.UaFx.Client;
using Opc.Ua.Configuration;
using Opc.UaFx;
using System.Threading;
using KVANT_Scada_2.DB;
using KVANT_Scada_2.Objects;

namespace KVANT_Scada_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        
        public MainWindow()
        {
            InitializeComponent();
            
            //opcUaWorker= new OPCUAWorker.OPCUAWorker();
            //createData = new DB.Logic.CreateData();
            //Thread OPCthread = new Thread(new ThreadStart(opcUaWorker.StartOPCUAClient));
            //Thread CreateDataThread = new Thread(new ThreadStart(createData.CreateTables));
            // CreateDataThread.Start();
            // OPCthread.Start();
            //Thread thread = new Thread(new ThreadStart(StartTimer));
            //thread.Start();
            
            //this.RunUpdates();



            //while (OPCthread.IsAlive)
            //{
            //    Main_Load_bar.Value += 1;
            //}




            //Objects.OPCObjects opcObject = Objects.OPCObjects.createObjects();
            //UDT.Valve.ValveStatus BAV_3_Status = opcObject.getBAV_3_Status();
            //Console.WriteLine(BAV_3_Status.Auto_mode);
            //valve = new UDT.Valve.ValveUDT();
            // UDT.Valve.ValveUDT valve = client.ReadNode("ns=3;s=\"Valve_DB\".\"BAV_3\"").As<UDT.Valve.ValveUDT>();
            //OpcClient client = opcObject.get_OpcClietn();





            //var client = new OpcClient("opc.tcp://192.168.0.10:4840/");
            //client.Connect();

            //var node = client.BrowseNode("ns=3;s=\"Tech_Cam_Logic\".\"Stop_Crio\"");

            //if (node is OpcVariableNodeInfo variablenode)
            //{
            //    OpcNodeId datatypeid = variablenode.DataTypeId;
            //    OpcDataTypeInfo datatype = client.GetDataTypeSystem().GetType(datatypeid);

            //    Console.WriteLine(datatype.TypeId);
            //    Console.WriteLine(datatype.Encoding);

            //    Console.WriteLine(datatype.Name);

            //    foreach (OpcDataFieldInfo field in datatype.GetFields())
            //        Console.WriteLine(".{0} : {1}", field.Name, field.FieldType);

            //    Console.WriteLine();
            //    Console.WriteLine("data type attributes:");
            //    Console.WriteLine(
            //            "\t[opcdatatype(\"{0}\")]",
            //            datatype.TypeId.ToString(OpcNodeIdFormat.Foundation));
            //    Console.WriteLine(
            //            "\t[opcdatatypeencoding(\"{0}\", namespaceuri = \"{1}\")]",
            //            datatype.Encoding.Id.ToString(OpcNodeIdFormat.Foundation),
            //            datatype.Encoding.Namespace.Value);
            //}
            //Console.WriteLine("А я из основного потока. Просто надо так сделать");




        }


      
        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
        
        
    }
}
