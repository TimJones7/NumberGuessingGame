using NumberGuessingGame.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame
{
    public class Game
    {
        public string userName { get; set; }
        public string compName { get; set; }
        public User _user { get; set; }
        public Computer _comp { get; set; }
        public int numOfRounds { get; set; } = 5;


        //  Function to start game
        
        //  Get player names 
        public void setPlayerNames()
        {
            Console.WriteLine("What is your name?");
            userName = Console.ReadLine();
            Console.WriteLine($"That's awesome {userName}");
            Thread.Sleep(1000);
            Console.WriteLine("What should we call your opponent?");
            compName = Console.ReadLine();
            Console.WriteLine("Thank You!");
            Thread.Sleep(1000);

            if (userName != null && compName != null)
            {
                createPlayers(userName, compName);
            }
        }


        //  function to create players
        public void createPlayers(string userN, string compN) 
        {
            _user = new User(userN);
            _comp = new Computer(compN);
            Console.WriteLine($"The battle is set between {userN} and {compN}!");
            Thread.Sleep(500);
        }



        //  Ask player what number of rounds to play  




        //  Have top of round and bottom of round
        //  Each player picks and guesses



    }
}
