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

        public int MinNum = 0;
        public int MaxNum = 11;

        //  Game Constructor
        public Game()
        {
            Console.WriteLine("Your game is about to begin!");
            endCommands();
        }

        //  game.Run() function that will handle the lifecycle of a game
        public void Run()
        {
            numOfRounds = setNumRounds();
            setPlayerNames();
            playGame(numOfRounds);

        }

        //  Ask player what number of rounds to play  
        public int setNumRounds()
        {
            //  Min should be 1 and max should be 10
            Console.WriteLine("How many rounds should we play today?");
            int x = Convert.ToInt32(Console.ReadLine());

            if(x > MinNum && x < MaxNum)
            {
                Console.WriteLine(" ");
                Console.WriteLine($"Ok, you are about to play {x} rounds!");
                endCommands();
                return x;
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine("Please pick a number between 1 and 10");
                endCommands();
                return setNumRounds();
            }
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
            Console.WriteLine($"The battle is set between {userN} and {compN} to play {this.numOfRounds} rounds!");
            Thread.Sleep(1000);
        }




        //  function for looping through rounds
        private void playGame(int numRounds)
        {
            for(int i = 1; i < numRounds + 1; i++)
            {
                playRound(i);
            }
        }

        //  function for each individual round
        private void playRound(int i)
        {
            Console.WriteLine($"Starting round {i}!");
        }


        //  Function for adding smooth transitions between pieces of the game. 
        //  This is to enhance UX
        private void endCommands()
        {
            Thread.Sleep(250);
            Console.WriteLine(".");
            Thread.Sleep(250);
            Console.WriteLine(".");
            Thread.Sleep(250);
            Console.WriteLine(".");
            Thread.Sleep(250);
            Console.WriteLine(".");
            Thread.Sleep(250);
            Console.WriteLine(".");
            Console.WriteLine(" ");
        }


    }
}
