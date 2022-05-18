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
        public int currentRound { get; set; } = 1;

        //  Function to start game
        //  Perhaps class constructor can init the sequence of events needed ?


        //  Ask player what number of rounds to play  
        public void setNumRounds()
        {
            Console.WriteLine("How many rounds should we play?");
            numOfRounds = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Ok, you are about to play {numOfRounds}!");
        }


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
        //  private because only this class needs to use it
        private void createPlayers(string userN, string compN) 
        {
            _user = new User(userN);
            _comp = new Computer(compN);
            Console.WriteLine($"The battle is set between {userN} and {compN}!");
            Thread.Sleep(500);
        }



   



        //  Have top of round and bottom of round
        //  Each player picks and guesses



    }
}
