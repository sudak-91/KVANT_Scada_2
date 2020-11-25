using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.GUI
{
    class GUI_Logic
    {
        FVP_GUI FVP;
        public GUI_Logic()
        {
            FVP = new FVP_GUI();
        }
        
        public void RunFVPGui()
        {
            FVP = new FVP_GUI();
            FVP.Show();
        }

    }
}
