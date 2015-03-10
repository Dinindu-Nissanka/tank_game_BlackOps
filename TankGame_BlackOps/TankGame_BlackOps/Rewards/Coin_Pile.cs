using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankGame_BlackOps.Rewards
{
    public class Coin_Pile {

        private int X;
        private int Y;
        private int value;
        private int remainingTime;  //time in miliseconds
        private long lastUpdateTime;  //time in millis when the coin pile was updated last time
        private Image img;

         public Coin_Pile(int x,int y,int value,int remainingTime) {
           this.X=x;
           this.Y=y;
           this.value=value;
           this.remainingTime=remainingTime;
           this.img = TankGame_BlackOps.Properties.Resources.coin_us_dollar_by_customicondesign_d66zf9g;
           //this.lastUpdateTime=System.currentTimeMillis();
        }

         public bool update()  {   //return true if this coin pile is available
             return true;
         }

         public void draw(Graphics g)  {   //draw coin pile on screen
             g.DrawImage(img, this.X, this.Y);
         }
    }
}
