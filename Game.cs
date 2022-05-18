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
        public int numOfNumbers { get; set; } = 10;

        public int MinNum = 0;
        public int MaxNum = 11;
        public int MaxRange = 101;

        //  Game Constructor
        public Game()
        {
            Console.WriteLine("Welcome to GUESSING GAME 3000!!!");
            Console.WriteLine("Created by Tim Jones out of procrastination!");
            viewRules();
            endCommands();
            Console.WriteLine("Your game is about to begin!");
            endCommands();

        }

        //  game.Run() function that will handle the lifecycle of a game
        public void Run()
        {
            numOfRounds = setNumRounds();
            numOfNumbers = setNumRange();
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
            string intRounds = Console.ReadLine();

            if (intRounds.Length > 0)
            {
                int x = Convert.ToInt32(intRounds);

                if (x > MinNum && x < MaxNum)
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
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine("Please pick a number between 1 and 10");
                endCommands();
                return setNumRounds();
            }
        }


        //  Set amount of numbers to play with
        public int setNumRange()
        {
            //  Min should be 1 and max should be 100
            Console.WriteLine("How many numbers should we play with today?");

            string playNums = Console.ReadLine();

            if (playNums.Length > 0)
            {
                int x = Convert.ToInt32(playNums);

                if (x > MinNum && x < MaxRange)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine($"Ok, we will play with {x} numbers!");
                    endCommands();
                    return x;
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Please pick a number between 1 and 100");
                    endCommands();
                    return setNumRange();
                }
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine("Please pick a number between 1 and 100");
                endCommands();
                return setNumRange();
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
            Console.WriteLine($"The battle is set between {userN} and {compN} to play {this.numOfRounds} rounds using {numOfNumbers} numbers!");
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


            //  Here is where the round battle logic occurs
            //  There is a top and bottom to a round

            //  Top of the round, you pick number for machine to guess
            Random randA = new Random();
            int userNum = getUserNumber();
            int compGuess = randA.Next(MinNum, numOfNumbers);
            Console.WriteLine($"The computer has guessed {compGuess} and is {userNum - compGuess} away from the actual");
            endCommands();

            Console.WriteLine("The computer is thinking of a numbner for you to guess...");
            endCommands();
            Console.WriteLine("Ok, the computer is ready!");
            Random randB = new Random();
            int compNum = randB.Next(MinNum, numOfNumbers);
            int userGuess = getUserGuess();


            Console.WriteLine($"You have guessed {userGuess} and is {compNum - userGuess} away from the actual");
            endCommands();

            int userOffBy = Math.Abs(compNum - userGuess);
            int compOffBy = Math.Abs(userNum - compGuess);
            int diff = userOffBy - compOffBy;


            switch (diff)
            {
                case <0:
                    _user.score++;
                    break;
                case > 0:
                    _comp.score++;
                    break;
                case 0:
                    break;
            }


        }

        private int getUserNumber()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Pick a number for the computer to guess!");
            string num = Console.ReadLine();
            if (num.Length > 0)
            {
                int x = Convert.ToInt32(num);
                if(x > MinNum && x < MaxRange)
                {
                    return x;
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine($"Please pick a number between {MinNum + 1} and {MaxRange - 1}");
                    endCommands();
                    return getUserNumber();
                }
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine($"Please pick a number between {MinNum + 1} and {MaxRange - 1}");
                endCommands();
                return getUserNumber();
            }
        }

        private int getUserGuess()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Try to guess the computer's number!");
            string num = Console.ReadLine();
            if (num.Length > 0)
            {
                int x = Convert.ToInt32(num);
                if (x > MinNum && x < MaxRange)
                {
                    return x;
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine($"Please guess a number between {MinNum + 1} and {MaxRange - 1}");
                    endCommands();
                    return getUserGuess();
                }
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine($"Please guess a number between {MinNum + 1} and {MaxRange - 1}");
                endCommands();
                return getUserGuess();
            }

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
            string nn = Console.ReadLine();

            if (nn.Length > 0)
            {
                char n = nn[0];
                if (n == 'y' || n == 'Y')
                {
                    this.Run();
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Fine, fuck off!");
                }
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

        //  post the current score of the game
        private void postScore()
        {
            Console.WriteLine($"{_user.name} - {_user.score}");
            Console.WriteLine($"{_comp.name} - {_comp.score}");
        }

        //  functionality for player to view rules
        private void viewRules()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Would you like to view the rules? [Y] or enter to skip");
            
            string wordsIn = Console.ReadLine();

            if (wordsIn.Length > 0)
            {
                char n = wordsIn[0];
                if (n == 'y' || n == 'Y')
                {
                    Console.WriteLine("This is a number guessing game.");

                    Console.WriteLine("You will battle against the computer using a user defined amount of numbers over a user defined number of rounds.");
                    Console.WriteLine("You will take turns picking a number and guessing what the other player chose");
                    Console.WriteLine("Whoever guesses closer to the other player's number will win the point.");
                    Console.WriteLine("Any user who guesses exactly will be awarded 5 points");
                    Console.WriteLine("Any ties will replay the round");
                    Console.WriteLine("The game CAN end in a tie between players");
                    Console.WriteLine("Good luck and thanks for playing!");
                }
            }
        }




    }
}
