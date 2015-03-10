using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankGame_BlackOps.Cell
{
    public class Water : Cell
    {
        public Water(int x,int y) {
            this.x = x;
            this.y = y;
            this.img = TankGame_BlackOps.Properties.Resources.water;
        }
    }
}
