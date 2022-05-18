using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame.Players
{
    //  Parent player class for this game
    public class Player
    {
        //  This will hold the shared attributes players have
        public string name { get; set; }
        public int score { get; set; } = 0;


    }
}
