using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_One
{
    public class MyPanel : Panel
    {
        public MyPanel()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }
    }
}
