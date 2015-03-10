using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TankGame_BlackOps.Rewards;
using TankGame_BlackOps.Game_Engine;
using System.Threading;
using TankGame_BlackOps.Cell;

namespace TankGame_BlackOps
{
    public partial class Main_window : Form
    {

        //map width and height
        public static int WIDTH = 1000;
        public static int HEIGHT = 1000;

        private bool running;   //game in the running state
        private int FPS = 5;   //frames per second

        //Objects appear in game
        private Thread gameThread;
        private BlackOps_tank tank;
        public static List<Enemy> EnemyTankList;
        //private ArrayList<Blast> blastList;
        public static List<Stone> stoneList;
        public static List<Brick> brickList;
        public static List<Water> waterList;
        public static List<Coin_Pile> coinPileList;
        public static List<Life_Pack> lifePackList;
        
        public Main_window()
        {
            InitializeComponent();

            //initializing grid objects
            EnemyTankList = new List<Enemy>();
            stoneList = new List<Stone>();
            brickList = new List<Brick>();
            waterList = new List<Water>();
            coinPileList = new List<Coin_Pile>();
            lifePackList = new List<Life_Pack>();
            //blastList=new ArrayList<>();
            
           
        }

        public void run()
        {

            while (true)
            {
                draw();
            }


        }


        private void Main_window_Paint(object sender, PaintEventArgs e)
        {
         /*   Graphics g = e.Graphics;
            while (true) { 
                for (int i = 0; i <brickList.Count; i++)
                    brickList.ElementAt(i).draw(g);

                for (int i = 0; i < coinPileList.Count; i++)
                    coinPileList.ElementAt(i).draw(g);
           } */
         
        }

        public void draw()
        {
            Graphics g;
            g= this.CreateGraphics();
            for (int i = 0; i < brickList.Count; i++)
                brickList.ElementAt(i).draw(g);
        }


    }
}
