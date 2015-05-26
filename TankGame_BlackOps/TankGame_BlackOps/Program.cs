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
using TankGame_BlackOps.Communication;
namespace TankGame_BlackOps
{
    static class Program
    {
        static void Main()
        {
            Game_Launcher g = new Game_Launcher();
            Main_window m = new Main_window();
<<<<<<< HEAD
          /*  Main_window.brickList.Add(new Brick(50,200));
            Main_window.stoneList.Add(new Stone(80, 100));
            Main_window.waterList.Add(new Water(300, 40));
            Main_window.EnemyTankList.Add(new Enemy(600, 40,2));
            Main_window.coinPileList.Add(new Coin_Pile(500, 80,12,10));
            Main_window.lifePackList.Add(new Life_Pack(400, 70,12,12));  */
=======
            Sender s = new Sender();
            Receiver r = new Receiver();
            TankGame_BlackOps.Communication.Decoder d = new TankGame_BlackOps.Communication.Decoder(g);
            //Main_window.brickList.Add(new Brick(50,200));
            //Main_window.stoneList.Add(new Stone(80, 100));
            //Main_window.waterList.Add(new Water(300, 40));
            //Main_window.EnemyTankList.Add(new Enemy(600, 40,2));
            //Main_window.coinPileList.Add(new Coin_Pile(500, 80,12,10));
            //Main_window.lifePackList.Add(new Life_Pack(400, 70,12,12));
>>>>>>> 5429e3e615b89cb2ef7f453f70d90419f08bb10c
            Application.Run(m);
            
            
            
           
        }
    }
}
