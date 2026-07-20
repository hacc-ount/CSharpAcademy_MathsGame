using MathsGame;

int[] difficulty = new int[2];

bool runGame = false;

difficulty = GameFunctions.SetDifficulty();
do
{
    RunMenu();
} while (runGame == false);
void RunMenu()
{
    Console.WriteLine("---------- Maths Game ----------");
    Console.WriteLine("Select an option below by typing in the command line:\n");
    Console.WriteLine("! - Change Difficulty");
    Console.WriteLine("A - Addition");
    Console.WriteLine("S - Subtraction");
    Console.WriteLine("M - Multiplication");
    Console.WriteLine("D - Division");
    string ?result = Console.ReadLine();
    if (result == null)
    {
        Console.WriteLine("Input was null, exiting game.");
        Environment.Exit(1);
    }

    try
    {
        char userInput = Convert.ToChar(result.Trim());
        if (Char.IsPunctuation(userInput))
        {
            switch (userInput)
            {
                case '!':
                    GameFunctions.SetDifficulty();
                    break;

            }
        }
        else if (Char.IsAsciiLetter(userInput))
        {
            switch (userInput)
            {
                case 'A':
                    Console.WriteLine("Addition");
                    break;
            }
        }
        else
        {
            
        }
    }
    catch (FormatException)
    {
        Console.WriteLine($"{result} has too many characters. Please only input one character.");
    }
}
