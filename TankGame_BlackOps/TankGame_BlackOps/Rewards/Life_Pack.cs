using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Runtime;
using System.Drawing;
using System.Windows.Forms;


namespace TankGame_BlackOps.Rewards
{
    public class Life_Pack
    {

        private int X;
        private int Y;
        private int value;
        private int remainingTime;  //time in miliseconds
        private long lastUpdateTime;  //time in millis when the lifepack was updated last time
        private Image img;

        System.Diagnostics.Stopwatch S = new System.Diagnostics.Stopwatch();
        Image img2;

        public Life_Pack(int x,int y,int remainingTime) {
           this.X=x;
           this.Y=y;
           this.value=20;
           this.remainingTime=remainingTime;
           img = TankGame_BlackOps.Properties.Resources.download;
           //this.lastUpdateTime=System.currentTimeMillis();
       }

        public bool update() {   //return true if this life pack is available
           return true;
        }

        public void draw(Graphics g) {   //draw life pack on screen
            g.DrawImage(img, this.X*50, this.Y*50);
        }

        

    }
}
