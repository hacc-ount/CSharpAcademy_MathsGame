namespace MathsGame;

public class GameFunctions
{
    const int EASY = 1;
    const int MEDIUM = 2;
    const int HARD = 3;
    internal static void getDifficulty(int[] setDifficulty)
    {
        string? result;
        bool validInput = false;
        int userChoice = 0;

    do
    {
        Console.WriteLine(@$"
Choose your difficulty:
   
1. Easy
2. Medium
3. Hard
   
Enter a valid number from the list.
");

        result = Console.ReadLine();
        if (result == null)
        {
            Console.WriteLine("Input is null. Exiting the program");
            Environment.Exit(1);
        }

        try
        {
            int.Parse(result);
            
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("No input detected. Please choose an option from the menu.\n");
            continue;
        }
        catch (FormatException)
        {
            Console.WriteLine($"{result} is not a valid number. Please choose an option from the menu.\n");
            continue;
        }

        userChoice = int.Parse(result);
        if (Helpers.isInRange(userChoice, 1, 3))
        {
            validInput = true;
        }
        else
        {
            Console.WriteLine($"{userChoice} is not a menu option. Please choose again.\n");
        }
        
    } while (validInput == false);

    switch (userChoice)
    {
        case EASY:
            setDifficulty[0] = 0;
            setDifficulty[1] = 9;
            break;
        case MEDIUM:
            setDifficulty[0] = 0;
            setDifficulty[1] = 100;
            break;
        case HARD:
            setDifficulty[0] = -100;
            setDifficulty[1] = 100;
            break;
        default:
            Console.WriteLine("Error setting difficulty");
            Environment.Exit(1);
            break;
    }
    }
}
