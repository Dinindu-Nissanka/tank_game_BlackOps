using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankGame_BlackOps.Game_Engine
{
    public class BlackOps_tank
    {
        private int X;
        private int Y;
        private int health;
        private int coinCount;
        private int pointCount;
        private int direction;
        private bool isShot;

        public static int TANK_NUM;

        //images
        Image tankRight;
        Image tankDown;
        Image tankLeft;
        Image tankUp;

        /* direction convention
          0 - north
          1 - east
          2 - south
          3 - west
      */

    public BlackOps_tank(int tank_num,int x,int y,int direction) {

        TANK_NUM = tank_num;
        this.X=x;
        this.Y=y;
        this.direction=direction;
        this.health=100;
        this.coinCount=0;
        this.pointCount=0;
        this.isShot=false;

        tankRight = TankGame_BlackOps.Properties.Resources.right;
        tankDown = TankGame_BlackOps.Properties.Resources.down;
        tankLeft = TankGame_BlackOps.Properties.Resources.left;
        tankUp = TankGame_BlackOps.Properties.Resources.up;

    }
    
    //now we need to use AI and decide our next move
    //do all the AI proccessing and return the next move as a  string
    //that string we need to send to the server
    public String nextMove(){
        return null;
    }
    
    
    //update all the intrnal variables of our tank according to the global update received
    public void update(int x,int y,int direction,int health,int coinCount,int pointCount,bool isShot){
        this.X=x;
        this.Y=y;
        this.direction=direction;
        this.health=health;
        this.coinCount=coinCount;
        this.pointCount=pointCount;
        this.isShot=isShot;
    }

    public void draw(Graphics g)  //draw our tank on screen
    {
        if (direction == 0)
            g.DrawImage(tankUp, this.X * 50, this.Y * 50);
        else if (direction == 1)
            g.DrawImage(tankRight, this.X * 50, this.Y * 50);
        else if (direction == 2)
            g.DrawImage(tankDown, this.X * 50, this.Y * 50);
        else
            g.DrawImage(tankLeft, this.X * 50, this.Y * 50);
    }

    }
}
