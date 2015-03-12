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


        //Objects appear in game
        private Thread gameThread;
        public static List<Enemy> EnemyTankList;
        //private ArrayList<Blast> blastList;
        public static BlackOps_tank tank;
        public static List<Stone> stoneList;
        public static List<Brick> brickList;
        public static List<Water> waterList;
        public static List<Coin_Pile> coinPileList;
        public static List<Life_Pack> lifePackList;
        
        public Main_window()
        {
            InitializeComponent();
            this.BackgroundImage = TankGame_BlackOps.Properties.Resources.bg; //setting the background image
            
            //initializing grid objects
            EnemyTankList = new List<Enemy>();
            stoneList = new List<Stone>();
            brickList = new List<Brick>();
            waterList = new List<Water>();
            coinPileList = new List<Coin_Pile>();
            lifePackList = new List<Life_Pack>();
            //blastList=new ArrayList<>();
            
           
        }

       


        private void Main_window_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

                g.DrawImage(this.BackgroundImage, 0, 0);     //draw background

              //  tank.draw(g);   //drawing our tank

                for (int i = 0; i < EnemyTankList.Count; i++)  //drawing enemies
                    EnemyTankList.ElementAt(i).draw(g);

                for (int i = 0; i <brickList.Count; i++)  //drawing bricks
                    brickList.ElementAt(i).draw(g);

                for (int i = 0; i < stoneList.Count; i++)   //drawing stones
                    stoneList.ElementAt(i).draw(g);

                for (int i = 0; i < waterList.Count; i++)   //drawing water cells
                    waterList.ElementAt(i).draw(g);

                for (int i = 0; i < coinPileList.Count; i++)   //drawing coin piles
                    coinPileList.ElementAt(i).draw(g);

                for (int i = 0; i < lifePackList.Count; i++)  //drawing life packs
                    lifePackList.ElementAt(i).draw(g);
         
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
            this.Invalidate();
            
         
        }

       


    }
}
