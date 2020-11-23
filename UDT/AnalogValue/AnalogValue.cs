using Opc.UaFx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.UDT
{
    public class AnalogValue
    {
        public string Path { get; set; }
        public float Value { get; set; }
    }
}
