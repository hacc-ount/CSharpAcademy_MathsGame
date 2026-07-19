namespace MathsGame;

internal class Helpers
{
    internal static bool isStringANumber(string input)
    {
        try
        {
            int.Parse(input);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("No input detected. Please choose an option from the menu.");
            return false;
        }
        catch (FormatException)
        {
            Console.WriteLine($"{input} is not a valid number. Please choose an option from the menu.");
            return false;
        }

        return true;
    }
}
