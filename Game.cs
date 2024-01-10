using System;

class Player
{
    public string Name { get; } // attribute

    public Player(string name)
    {
        Name = name;
    }

    public virtual int TakeSticks(int sticksOnTable) // Method for taking sticks
    {
        int sticksTaken;

        Console.Write($"{Name}: How many sticks do you take (1-3)? ");

        while (!int.TryParse(Console.ReadLine(), out sticksTaken) || sticksTaken < 1 || sticksTaken > 3)
        {
            Console.WriteLine("Please enter a valid number between 1 and 3.");
            Console.Write($"{Name}: How many sticks do you take (1-3)? ");
        }

        return sticksTaken;
    }
}

class AI : Player
{
    private Random random;

    public AI(string name) : base(name)
    {
        random = new Random();
    }

    public override int TakeSticks(int sticksOnTable)
    {
        // AI logic to select the number of sticks to take
        int sticksTaken = random.Next(1, 4);

        Console.WriteLine($"{Name} selects {sticksTaken}.");

        return sticksTaken;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the game of sticks!");

        do
        {
            Console.Write("How many sticks are there on the table initially (10-100)? ");
            int sticksOnTable;
            while (!int.TryParse(Console.ReadLine(), out sticksOnTable) || sticksOnTable < 10 || sticksOnTable > 100)
            {
                Console.WriteLine("Please enter a valid number between 10 and 100.");
                Console.Write("How many sticks are there on the table initially (10-100)? ");
            }

            Console.WriteLine("Options:");
            Console.WriteLine("  1. Play against a friend");
            Console.WriteLine("  2. Play against the computer");

            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || (option != 1 && option != 2))
            {
                Console.WriteLine("Please enter a valid option (1 or 2).");
                Console.Write("Which option do you take (1-2)? ");
            }

            Player player1 = new Player("Player 1");
            Player player2 = (option == 1) ? new Player("Player 2") : new AI("AI");

            do
            {
                Console.WriteLine($"There are {sticksOnTable} sticks on the board.");

                // Player 1's turn
                int sticksTakenByPlayer1 = player1.TakeSticks(sticksOnTable);
                sticksOnTable -= sticksTakenByPlayer1;

                if (sticksOnTable <= 0)
                {
                    Console.WriteLine($"{player1.Name} wins!");
                    break;
                }

                // Player 2's turn (either Player 2 or AI)
                int sticksTakenByPlayer2 = player2.TakeSticks(sticksOnTable);
                sticksOnTable -= sticksTakenByPlayer2;

                if (sticksOnTable <= 0)
                {
                    Console.WriteLine($"{player2.Name} wins!");
                    break;
                }

            } while (true);

            Console.Write("Play again (1 = yes, 0 = no)? ");
        } while (Console.ReadLine() == "1");
    }
}



