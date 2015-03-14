using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using TankGame_BlackOps.Game_Engine;
using TankGame_BlackOps.Rewards;

namespace TankGame_BlackOps.Communication
{
    class Decoder
    {
        private Thread thread_decoder;
        private bool global = false;
        private Game_Launcher g;
        public Decoder(Game_Launcher g) {
            this.g = g;
            thread_decoder = new Thread(new ThreadStart(decode_message));
            thread_decoder.Start();
        }

        public void decode_message()
        {
            while (true) {
                if (Receiver.read_buffer.Count != 0)
                {
                    string[] array_split = Regex.Split(Receiver.read_buffer.ElementAt(0), ":");
                    string s = Receiver.read_buffer.ElementAt(0).Substring(0, Receiver.read_buffer.ElementAt(0).Length - 1);
                    switch (array_split[0])
                    {
                        case ("I"):
                            Console.WriteLine("IIIII----" + s);
                            g.InitGameObjects(s);
                            Receiver.read_buffer.RemoveAt(0);
                            break;
                        case ("S"):
                            Console.WriteLine("SSSSS----" + s);
                            g.InitOurTank(s);
                            Receiver.read_buffer.RemoveAt(0);
                            break;
                        case ("G"):
                            global_method(Receiver.read_buffer.ElementAt(0));
                            Receiver.read_buffer.RemoveAt(0);
                            break;
                        case ("C"):
                            coin_method(Receiver.read_buffer.ElementAt(0));
                            Receiver.read_buffer.RemoveAt(0);
                            break;
                        case ("L"):
                            lifepack_method(Receiver.read_buffer.ElementAt(0));
                            Receiver.read_buffer.RemoveAt(0);
                            break;
                        default:
                            break;
                    }
                }
                /*else
                {
                    Console.WriteLine("Read Buffer is empty");
                }*/
            }
        }

        private void lifepack_method(string p)
        {
            p = p.Substring(0, p.Length - 1);
            string[] coin_details = Regex.Split(p, ":");
            string[] cordinators = Regex.Split(coin_details[1], ",");
            int x = Convert.ToInt32(cordinators[0]);
            int y = Convert.ToInt32(cordinators[1]);
            int time = Convert.ToInt32(coin_details[2]);
            Life_Pack lifePack = new Life_Pack(x, y, time);
            Main_window.lifePackList.Add(lifePack);
        }

        private void coin_method(string p)
        {
            p = p.Substring(0, p.Length - 1);
            string[] coin_details = Regex.Split(p,":");
            string[] cordinators = Regex.Split(coin_details[1], ",");
            int x = Convert.ToInt32(cordinators[0]);
            int y = Convert.ToInt32(cordinators[1]);
            int time = Convert.ToInt32(coin_details[2]);
            int val = Convert.ToInt32(coin_details[3]);
            Coin_Pile coinPile = new Coin_Pile(x,y,val,time);
            Main_window.coinPileList.Add(coinPile);
        }

        private void global_method(string s)
        {
            s = s.Substring(0, s.Length - 1);
            string[] array_global = Regex.Split(s, ":");
            string[] player_details = null;
            if (!global)
            {
                this.global = true;
                for (int i = 1; i <= 2; i++)
                {
                    player_details = Regex.Split(array_global[i], ";");
                    string[] coordinations = Regex.Split(player_details[1], ",");
                    int x = Convert.ToInt32(coordinations[0]);
                    int y = Convert.ToInt32(coordinations[1]);
                    /*Console.WriteLine("Buffer---" + Receiver.read_buffer.ElementAt(0));
                    Console.WriteLine("Message -- " + array_global[i]);
                    Console.WriteLine("x -- " + x);
                    Console.WriteLine("y -- " + y);
                    Console.WriteLine(player_details[1]);
                    Console.WriteLine(player_details[2]);*/
                    int direction = Convert.ToInt32(player_details[2]);
                    string temp_char = player_details[0];
                    if (Convert.ToInt32(temp_char[1])!=BlackOps_tank.TANK_NUM)
                    {
                        Enemy enemy = new Enemy(x, y, direction);
                        Main_window.EnemyTankList.Add(enemy);
                    }
                }
            }
            else {
                int array_index=0;
                int i = 0;
                for (i = 1; i <= 2; i++) {
                    player_details = Regex.Split(array_global[i], ";");
                    string[] coordinations = Regex.Split(player_details[1], ",");
                    int x = Convert.ToInt32(coordinations[0]);
                    int y = Convert.ToInt32(coordinations[1]);
                    int direction = Convert.ToInt32(player_details[2]);
                    int int_isShot = Convert.ToInt32(player_details[3]);
                    bool isShot;
                    if (int_isShot == 0)
                        isShot = false;
                    else
                        isShot = true;
                    int health = Convert.ToInt32(player_details[4]);
                    int coins = Convert.ToInt32(player_details[5]);
                    int points = Convert.ToInt32(player_details[6]);
                    string temp_char = player_details[0];
                    if (Convert.ToInt32(temp_char[1]) == BlackOps_tank.TANK_NUM)
                    {
                        Main_window.tank.update(x,y,direction,health,coins,points,isShot);
                    }
                    else
                    {
                        Main_window.EnemyTankList.ElementAt(array_index).update(x,y,direction,health,coins,points,isShot);
                        array_index++;
                    }
                }
                for (int j=i; j < array_global.Length-1; j++) { 
                    /*
                     * brick update
                     */ 
                }
            }
            player_details = null;
        }
    }
}
