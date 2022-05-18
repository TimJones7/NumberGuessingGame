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
            finishGame();
            playAgain();
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
            endCommands();
            Console.WriteLine("What should we call your opponent?");
            compName = Console.ReadLine();
            Console.WriteLine("Thank You!");
            endCommands();

            if (userName.Length > 0 && compName.Length > 0)
            {
                createPlayers(userName, compName);
            }
            else
            {
                Console.WriteLine("NAMES CANT BE EMPTY, TRY AGAIN DOOFUS!");
                setPlayerNames();
            }
        }


        //  function to create players
        //  private because only this class needs to use it
        private void createPlayers(string userN, string compN) 
        {
            _user = new User(userN);
            _comp = new Computer(compN);
            Console.WriteLine($"The battle is set between {userN} and {compN} to play {this.numOfRounds} rounds!");
            endCommands();
        }




        //  function for looping through rounds
        private void playGame(int numRounds)
        {
            for(int i = 1; i < numRounds + 1; i++)
            {
                playRound(i);
                endCommands();
                postScore();
                endCommands();
            }
        }

        //  function for each individual round
        private void playRound(int i)
        {
            Console.WriteLine($"Starting round {i}!");
        }





        //  Function for finishing the game and recording the score
        private void finishGame()
        {
            Console.WriteLine($"We had an epic battle of wits today between {_user.name} and {_comp.name};");
            Console.WriteLine(" ");
            Console.WriteLine("Please give us a second to tally the final score!");
            endCommands();
            if (_user.score > _comp.score)
            {
                Console.WriteLine("CONGRATULATIONS!!!");
                Console.WriteLine(" ");
                Console.WriteLine($"Today {_user.name} prevailed over {_comp.name} with a final score of: ");
                postScore();
                endCommands();
            }
            else if(_comp.score > _user.score)
            {
                Console.WriteLine("WOMP WOMP WOMP... YOU LOST!!!");
                Console.WriteLine(" ");
                Console.WriteLine($"Today {_comp.name} prevailed over {_user.name} with a final score of: ");
                postScore();
                endCommands();
            }
            else if(_comp.score == _user.score)
            {
                Console.WriteLine("Ain't that a bitch, nobody won!");
                Console.WriteLine(" ");
                Console.WriteLine("The final score today was: ");
                postScore();
                Console.WriteLine(" ");
            }
        }

        //  Function to ask if player would like to play again
        private void playAgain()
        {
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Would you like to play again? [Y] [N]");
            char n = Console.ReadLine()[0];
            if(n == 'y' || n == 'Y')
            {
                this.Run();
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine("Fine, fuck off!");
            }
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


        private void postScore()
        {
            Console.WriteLine($"{_user.name} - {_user.score}");
            Console.WriteLine($"{_comp.name} - {_comp.score}");
        }

    }
}
