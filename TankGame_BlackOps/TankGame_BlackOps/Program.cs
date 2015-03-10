using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using TankGame_BlackOps.Rewards;
using TankGame_BlackOps.Game_Engine;
using TankGame_BlackOps.Cell;
namespace TankGame_BlackOps
{
    static class Program
    {
        static void Main()
        {
            Main_window m = new Main_window();
            Main_window.brickList.Add(new Brick(50,200));
            Application.Run(m);
            m.run();

            
           
        }
    }
}
