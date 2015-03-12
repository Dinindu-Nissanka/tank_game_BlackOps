using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using TankGame_BlackOps.Game_Engine;

namespace TankGame_BlackOps.Communication
{
    class Decoder
    {
        private Thread thread_decoder;
        private bool global = false;
        public Decoder() {
            thread_decoder = new Thread(new ThreadStart(decode_message));
        }

        public void decode_message()
        {
            if (Receiver.read_buffer.Count != 0)
            {
                string[] array_split = Regex.Split(Receiver.read_buffer.ElementAt(0), ":");
                switch (array_split[0]) { 
                    case ("I"):
                        //hduhudh
                        break;
                    case ("S"):
                        //dgwydgwg
                        break;
                    case ("G"):
                        global_method(Receiver.read_buffer.ElementAt(0));
                        Receiver.read_buffer.RemoveAt(0);
                        break;
                    case ("C"):
                        coin_method(Receiver.read_buffer.ElementAt(0));
                        Receiver.read_buffer.RemoveAt(0);
                        break;
                    default:
                        break;
                }
            }
        }

        private void coin_method(string p)
        {
            p = p.Substring(0, p.Length - 1);

        }

        private void global_method(string s)
        {
            s = s.Substring(0, s.Length - 1);
            string[] array_global = Regex.Split(s, ":");
            string[] player_details = null;
            if (!global)
            {
                this.global = true;
                for (int i = 1; i <= 5; i++)
                {
                    player_details = Regex.Split(array_global[i], ";");
                    string[] coordinations = Regex.Split(player_details[1], ",");
                    int x = Convert.ToInt32(coordinations[0]);
                    int y = Convert.ToInt32(coordinations[1]);
                    int direction = Convert.ToInt32(player_details[2]);
                    if (3 > 5)
                    {
                    }
                    else
                    {
                        Enemy enemy = new Enemy(x, y, direction);
                        Main_window.EnemyTankList.Add(enemy);
                    }
                }
            }
            else {
                int array_index=0;
                int i = 0;
                for (i = 1; i < 5; i++) {
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
                    if (3 > 5)
                    {
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
        }
    }
}
