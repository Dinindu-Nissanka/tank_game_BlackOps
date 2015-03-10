using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankGame_BlackOps.Game_Engine
{
    class Bullet
    {

        private int X;
        private int Y;
        private int direction; 
        private int SPEED=300;
        private bool isValid;

        public Bullet(int X, int Y,int direction) {
            this.X = X;
            this.Y = Y;
            this.direction=direction;
            this.isValid=true;
        }
    
        //update positions of bullets
        public void updatePosition(){
       
        
        }

        public void draw()  //draw bullets on screen
        {

        }

    }
}
