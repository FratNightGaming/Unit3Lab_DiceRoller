using System.Drawing;
using System.Runtime.Intrinsics.X86;
using System;

namespace DiceRoller
{
    internal class Program
    {

        public static int diceSides = 0;

        public static int roll1 = 0;
        public static int roll2 = 0;

        public static int rollSum = 0;

        static void Main(string[] args)
        {
            Introduction();
        }

        public static void Introduction()
        {
            Console.WriteLine("Welcome to DICE ROLLER!");

            ChooseDice();
        }

        public static void ChooseDice()
        {

            while (true)
            {
                diceSides = 0;
                Console.WriteLine("How many sides would you like for your dice? Enter \"6 - 20\":");
            
                try
                {
                    diceSides = int.Parse(Console.ReadLine());

                    if (diceSides >= 6 && diceSides <= 20)
                    {
                        RollDice(diceSides);
                        break;
                    }

                    else
                    {
                        throw new Exception($"{diceSides} is not within specified boundaries. Try again.");
                    }
                }

                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }

        public static void RollDice(int sides)
        {
            string response1 = null;
            string response2 = null;

            Console.WriteLine("\nAre you ready to roll your dice?(Y/N)\n");
            response1 = Console.ReadLine().Trim().ToUpper();
            
            while (true)
            {

                if (response1 == "Y" || response1 == "YES")
                {
                    Random r = new Random();
                    roll1 = r.Next(1, sides + 1);
                    roll2 = r.Next(1, sides + 1);
                    rollSum = roll1 + roll2;

                    Console.WriteLine($"\nYou rolled {roll1} and {roll2}. Your total is {rollSum}.\n");

                    if (sides == 6)
                    {
                        string combinationResponse = SixSideDiceCombinations(roll1, roll2);
                        if (combinationResponse != string.Empty)
                        {
                            Console.WriteLine(combinationResponse);
                        }

                        string rollSumResponse = SixSideDiceTotals(rollSum);
                        if (rollSumResponse != string.Empty)
                        {
                            Console.WriteLine(rollSumResponse);
                        }

                        if (goAgain())
                        {
                            continue;
                        }

                        else
                        {
                            break;
                        }
                    }

                    else
                    {
                        string combinationResponse = CustomDiceCombinations(roll1, roll2);
                        if (combinationResponse != string.Empty)
                        {
                            Console.WriteLine(combinationResponse);
                        }

                        string rollSumResponse = CustomDiceTotals(rollSum);
                        if (rollSumResponse != string.Empty)
                        {
                            Console.WriteLine(rollSumResponse);
                        }

                        if (goAgain())
                        {
                            continue;
                        }

                        else
                        {
                            break;
                        }
                    }
                }

                else if (response1 == "N" || response1 == "NO")
                {
                    Console.WriteLine("\nTake your time. There's no pressure, except for the thousands of dollars on the line.\n");
                    continue;//unnecessary
                }

                else
                {
                    Console.WriteLine("\nInvalid response. Try again.\n");
                    continue;//unnecessary
                }
            }
        }

        public static string SixSideDiceTotals(int rollSum)
        {
            string output = string.Empty;

            switch (rollSum)
            {
                case 7:
                    output = "Win.";
                    break;
                case 11:
                    output = "Win.";
                    break;
                case 2:
                    output = "Craps!";
                    break;
                case 3:
                    output = "Craps!";
                    break;
                case 12:
                    output = "Craps!";
                    break;
                default:
                    break;
            }

            return output;
        }

        public static string SixSideDiceCombinations(int roll1, int roll2)
        {
            string output = string.Empty;

            if (roll1 == 1 && roll2 == 1)
            {
                output = "Snake Eyes!";
            }

            else if (roll1 == 1 && roll2 == 2 || roll1 == 2 && roll2 == 1)
            {
                output = "Ace Deuce!";
            }

            else if (roll1 == 6 && roll2 == 6)
            {
                output = "Box Cars!";
            }

            else
            {
                output = string.Empty;//unnecessary
            }

            return output;
        }

        public static string CustomDiceTotals(int rollSum)
        {
            string output = string.Empty;

            switch (rollSum)
            {
                case 40:
                    output = "You are a GOD!";
                    break;
                case 20:
                    output = "Half a legend";
                    break;
                case 25:
                    output = "Quarter Pounder";
                    break;
                case 2:
                    output = "You are the DEVIL!";
                    break;
                case 10:
                    output = "Winning";
                    break;
                case 13:
                    output = "My lucky number";
                    break;
                case 35:
                    output = "5 Touchdowns";
                    break;
                case 30:
                    output = "Awesome!";
                    break;
                case 24:
                    output = "Good job!";
                    break;
                case 19:
                    output = "I lost my virginity at this age";
                    break;
                default:
                    break;
            }

            return output;
        }

        public static string CustomDiceCombinations(int roll1, int roll2)
        {
            string output = string.Empty;

            if (roll1 == 20 && roll2 == 20)
            {
                output = "Jackpot. You win $1,000,000!";
            }

            else if (roll1 == 8 && roll2 == 8 || roll1 == 8 && roll2 == 8 || roll1 == 10 && roll2 == 10)
            {
                output = "Mid-Doubles";
            }

            else
            {
                output = string.Empty;//unnecessary
            }

            return output;
        }

        public static bool goAgain()
        {
            Console.WriteLine("Would you like to roll again Y/N");

            string input = Console.ReadLine().Trim().ToUpper();

            if (input == "Y" || input == "YES")
            {
                return true;
            }
            else if (input == "N" || input == "NO")
            {
                Console.WriteLine("\nThanks for playing and have a great day!");
                return false;
            }
            else
            {
                Console.WriteLine($"\n\"{input}\" is an invalid command. Try again.");
                return goAgain();
            }
        }
    }
}
/*What will the application do?
The application asks the user to enter the number of sides for a pair of dice. 
If you have learned about exception handling, make sure the user can only enter numbers
The application prompts the user to roll the dice.
The application “rolls” two n-sided dice, displaying the results of each along with a total
For 6-sided dice, the application recognizes the following dice combinations and displays a message for each. It should not output this for any other size of dice.
Snake Eyes: Two 1s
Ace Deuce: A 1 and 2
Box Cars: Two 6s
Win: A total of 7 or 11
Craps: A total of 2, 3, or 12 (will also generate another message!)
The application asks the user if he/she wants to roll the dice again.

Build Specifications:
Create a static method to generate the random numbers.
Proper method header: 2 points
Program generates random numbers validly within the user-specified range: 1 point
Method returns meaningful value of proper type: 1 point
Create a static method for six - sided dice that takes two dice values as parameters, and returns a string for one of the valid combinations(e.g.Snake Eyes, etc.) or an empty string if the dice don’t match one of the combinations.
Create a static method to implement output for different dice combinations
Proper method header: 2 points
Method recognizes all specified cases correctly: 1 point
Method displays properly to Console: 1 point
Application takes all user input correctly: 1 point
Application loops properly: 1 point

Hints:
Use the Random class to generate a random number.

Extra Challenges:
Come up with a set of winning combinations for other dice sizes besides 6.*/
