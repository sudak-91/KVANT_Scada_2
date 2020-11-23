using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.UDT.IntValue
{
    ///<summaray>
    ///Класс IntValue является представлением 
    ///Целочисленной переменной OPC сервера.
    ///</summaray>
    ///<value name = "Path">Путь к переменной в OPC Сервере </value>
    ///<value name = "Value">Значение переменной </value>
    public class IntValue
    {
        public string Path { get; set; }
        public int Value { get; set; }
    }
}
