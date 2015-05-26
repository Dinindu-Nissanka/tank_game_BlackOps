using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TankGame_BlackOps.Cell;

namespace TankGame_BlackOps.Game_Engine
{
   public class Game_Launcher
    {

       public void InitOurTank(String message)
       {
           String[] array = Regex.Split(message, ":");  //split the original 'S' message by ':' // S:P0;0,0;0:P1;0,19;0:P2;19,0;0#
           String info = array[array.Length - 1];    //returns our information  // P1;0,19;0
           String[] myArray = Regex.Split(info, ";"); //split information by ';' // P1 // x,y //direction

           int tankNum = int.Parse(myArray[0].Substring(1, 1));
           int tankX = int.Parse(myArray[1].Substring(0, 1));
           int tankY = int.Parse(myArray[1].Substring(2, 1));
           int tankDirection = int.Parse(myArray[2]);

           Main_window.tank = new BlackOps_tank(tankNum, tankX, tankY, tankDirection); //initialize our tank
       }

       public void InitGameObjects(String message)
       {
           /* split the original I message by ' '
            * I:P<num>:< x>,<y>;< x>,<y>:< x>,<y>;< x>,<y>:< x>,<y>;< x>,<y>;< x>,<y>#
            */
           String[] array = Regex.Split(message, ":");  //  I // P2 // Bricks // Stones //Waters
           BlackOps_tank.TANK_NUM = int.Parse(array[1].Substring(1, 1));

           String[] brickCordinates=Regex.Split(array[2], ";");  // get brick cordinates
           String[] stoneCordinates=Regex.Split(array[3], ";");  // get stone cordinates
           String[] waterCordinates=Regex.Split(array[4], ";");  // get water cordinates

           String[] cordinate;
           
           for (int i = 0; i < brickCordinates.Length; i++){   //intializing bricks
               cordinate=Regex.Split(brickCordinates[i], ",");
<<<<<<< HEAD
               Main_window.brickList.Add(new Brick(int.Parse(cordinate[0]), int.Parse(cordinate[1]))); 
=======
               Main_window.brickList.Add(new Brick(int.Parse(cordinate[0]), int.Parse(cordinate[1])));
               cordinate = null;
>>>>>>> 5429e3e615b89cb2ef7f453f70d90419f08bb10c
           }


           for (int i = 0; i < stoneCordinates.Length; i++)   //initializing stones
           {
               cordinate = Regex.Split(stoneCordinates[i], ",");
               Main_window.stoneList.Add(new Stone(int.Parse(cordinate[0]), int.Parse(cordinate[1])));
               cordinate = null;
           }

           for (int i = 0; i < waterCordinates.Length; i++)   //initializing water
           {
               cordinate = Regex.Split(waterCordinates[i], ",");
               Main_window.waterList.Add(new Water(int.Parse(cordinate[0]), int.Parse(cordinate[1])));
               cordinate = null;
           }
           for (int i = 0; i < Main_window.brickList.Count; i++) {
               Console.WriteLine(Main_window.brickList.ElementAt(i).getXY());
           }
           
       }



    }
}
