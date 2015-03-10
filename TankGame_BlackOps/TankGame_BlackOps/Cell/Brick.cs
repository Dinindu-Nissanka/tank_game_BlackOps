using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankGame_BlackOps.Cell
{
    public class Brick : Cell
    {
        private int health;
        /*
         * 0 - 0%
         * 1 - 25%
         * 2 - 50%
         * 3 - 75%
         * 4 - 100%
         */ 
        public Brick(int x, int y) {
            this.x = x;
            this.y = y;
            this.health = 4;
            this.img = TankGame_BlackOps.Properties.Resources.stone;
        }
        public void setHealth(int health) {
            this.health = health;
        }
        public int getHealth() {
            return health;
        }

        public void setX(int x){
            this.x=x;
        }
    }
}
