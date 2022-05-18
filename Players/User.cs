using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame.Players
{
    public class User : Player
    {
        //  This will have the functionality for a user to guess numbers
        public User(string _name)
        {
            name = _name;
        }
    }
}
