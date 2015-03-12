using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace TankGame_BlackOps.Game_Engine
{
    public class Enemy
    {

        private int X;
        private int Y;
        private int health;
        private int coinCount;
        private int pointCount;
        private int direction;
        private bool isShotting;
        private bool isDead;

        //images
        Image enmyRight;
        Image enmyDown;
        Image enmyLeft;
        Image enmyUp;

        /* direction convention
          0 - north
          1 - east
          2 - south
          3 - west
       */

        public Enemy(int x, int y, int direction)
        {
            this.X = x;
            this.Y = y;
            this.direction = direction;
            this.health = 100;
            this.coinCount = 0;
            this.pointCount = 0;
            this.isShotting = false;
            this.isDead = false;

            enmyRight = TankGame_BlackOps.Properties.Resources.enemyRIGHT;
            enmyDown = TankGame_BlackOps.Properties.Resources.enemyDOWN;
            enmyLeft = TankGame_BlackOps.Properties.Resources.enemyLEFT;
            enmyUp = TankGame_BlackOps.Properties.Resources.enemyUP;
        }

        //update all the intrnal variables of enemy when the global update is received
        public void update(int x, int y, int direction, int health, int coinCount, int pointCount, bool isShot)
        {
            this.X = x;
            this.Y = y;
            this.direction = direction;
            this.health = health;
            this.coinCount = coinCount;
            this.pointCount = pointCount;
            this.isShotting = isShot;

            if (health <= 0)
                this.isDead = true;

        }

        public void draw(Graphics g)  //draw enemy on screen
        {
            if (direction == 0)
                g.DrawImage(enmyUp, this.X, this.Y);
            else if (direction == 1)
                g.DrawImage(enmyRight, this.X, this.Y);
            else if (direction == 2)
                g.DrawImage(enmyDown, this.X, this.Y);
            else
                g.DrawImage(enmyLeft, this.X, this.Y);
        }
    }
}
