using System;

class GameOfSticks
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Game of Sticks!");

        int totalNumberSticks = 10;
        int numberOfTurns = 1;

        while (totalNumberSticks > 0)
        {
            Console.Clear();
            Console.WriteLine($"\nThere are {totalNumberSticks} sticks on the board.\n");

            if (DetermineTurn(numberOfTurns))
            {
                Console.WriteLine("\nPlayer 1's turn:\n");
                totalNumberSticks -= UserPicksSticks();
            }
            else
            {
                Console.WriteLine("\nComputer's turn:\n");
                int aiSticks = AiPicksSticks(totalNumberSticks);
                totalNumberSticks -= aiSticks;
                Console.WriteLine($"AI picked {aiSticks} stick(s).");
            }

            numberOfTurns++;
        }

        Console.WriteLine(DetermineTurn(numberOfTurns) ? "\nPlayer 1 wins!\n" : "\nComputer wins!\n");
        PlayAgain();
    }

    static bool DetermineTurn(int numberOfTurns)
    {
        return numberOfTurns % 2 == 1; // If turn number is odd, it's player's turn; otherwise, it's AI's turn.
    }

    static int UserPicksSticks()
    {
        while (true)
        {
            Console.Write("How many sticks do you pick up (1-3)? ");
            if (int.TryParse(Console.ReadLine(), out int numSticks) && numSticks >= 1 && numSticks <= 3)
            {
                return numSticks;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
            }
        }
    }

    static int AiPicksSticks(int totalNumberSticks)
    {
        if (totalNumberSticks > 3)
        {
            Random random = new Random();
            return random.Next(1, 4); // Choose a random number between 1 and 3.
        }
        else if (totalNumberSticks == 3)
        {
            return 2;
        }
        else if (totalNumberSticks == 2)
        {
            return 1;
        }
        else // totalNumberSticks == 1
        {
            return 1;
        }
    }

    static void PlayAgain()
    {
        Console.Write("Do you want to play  again? [y/n] \n");
        if (Console.ReadLine().Trim().ToLower() == "y")
        {
            Console.Clear();
            Main(); // Restart the game.
        }
        else
        {
            Console.WriteLine("Thank you for playing!");
        }
    }
}




