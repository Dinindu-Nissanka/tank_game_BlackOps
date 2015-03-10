using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TankGame_BlackOps.Communication
{
    class Decoder
    {
        private string[] initMessage;
        public void Decode_message(string message){
            initMessage = Regex.Split(message, ":");
            switch(initMessage[0]){
                case "I":
                    break;
                case "C"

            }
        }
    }
}
