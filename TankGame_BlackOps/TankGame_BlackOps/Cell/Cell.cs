using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankGame_BlackOps.Cell
{
    public class Cell
    {
        protected int x;
        protected int y;
        protected Image img;

        public void draw(Graphics g) {

            g.DrawImage(img, this.x, this.y);
        
        }
    }
}
