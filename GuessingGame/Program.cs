using System;
using System.Text.RegularExpressions;

//Namespace
namespace NumberGuesser
{
    //Main Class
    class Program
    {
        //Entry Point Method
        static void Main(string[] args)
        {
            // Set app vars
            string app_name = "Number Guesser";
            string app_version = "1.0.0";
            string app_author = "Todd Buck";


            //Customize console appearance
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkGray;

            //Print app info
            Console.WriteLine("{0}: v{1} by {2}", app_name, app_version, app_author);

            //Reset console appearance
            Console.ResetColor();

            //Collect user's name
            Console.Write("Enter Your Name: ");
            var user_name = Console.ReadLine();

            //Print user information and begin game
            Console.WriteLine("Hello " + user_name + "! Let's play a game...");

            //Generate Random Number [1,100]
            int lower_bound = 1;
            int upper_bound = 100;
            int correct_number = new Random().Next(lower_bound, upper_bound);
            int number_of_guesses = (int)Math.Ceiling(Math.Log2(upper_bound - lower_bound));
            int guesses_used = 0;

            //Pause for effect
            System.Threading.Thread.Sleep(1000);

            //Print game rules, ask to play
            Console.WriteLine("I have chosen a number from {0} to {1} (inclusive) for you to guess. If you can guess the number in less than {2} guesses, you win", lower_bound, upper_bound, number_of_guesses);
            Console.WriteLine("Press any key to begin, or type E to exit.");

            //Exit condition
            if (Console.ReadLine() == "E") return;

            while (guesses_used < number_of_guesses)
            {
                Console.Write("Enter a number: ");

                guesses_used++;

                string? user_input = Console.ReadLine();

                if (Int32.TryParse(user_input, out int guess))
                {
                    if (guess == correct_number)
                    {
                        Console.WriteLine("Congratulations! You guessed the correct number in only {0} guesses.", guesses_used);
                        Console.WriteLine("Press any key to exit the game.");
                        Console.ReadLine();
                        return;
                    }
                    else if (guess < correct_number)
                    {
                        Console.WriteLine("You guessed too low. Try Again.");
                        Console.WriteLine("Number of guesses remaining: {0}", number_of_guesses - guesses_used);
                        Console.WriteLine("");
                    }
                    else if (guess > correct_number)
                    {
                        Console.WriteLine("You guessed too high. Try Again.");
                        Console.WriteLine("Number of guesses remaining: {0}", number_of_guesses - guesses_used);
                        Console.WriteLine("");
                    }
                }
                else
                {
                    Console.WriteLine("\"{0}\" is not a valid input. Try again by guessing a number from 1 to 100 (inclusive).", user_input);
                    Console.WriteLine("Number of guesses remaining: {0}", number_of_guesses - guesses_used);
                    Console.WriteLine("");
                }
            }

            Console.WriteLine("Game over! The correct answer was: " + correct_number);
            Console.WriteLine("");

            Console.WriteLine("Press any key to exit the game.");
            Console.ReadLine();
        }

    }
}