using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace MineSweeperSolver
{
    class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel(): base()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.Opaque |
                          ControlStyles.OptimizedDoubleBuffer, true);
        }
    }
}
