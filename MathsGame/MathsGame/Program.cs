using MathsGame;

int[] difficulty = new int[2];
const int EASY = 1;
const int MEDIUM = 2;
const int HARD = 3;

bool runGame = true;

SetInitialDifficulty();
do
{
    RunMenu();
} while (runGame == true);

void RunMenu()
{

}


void SetInitialDifficulty()
{
    Console.WriteLine(@$"
   Choose your difficulty:
   
   1. Easy
   2. Medium
   3. Hard
   
   Enter a valid number from the list.
   ");

    // Keep asking user for valid input.
    string? result;
    bool validNumber = false;
    int convertedNumber = 0;

    do
    {
        result = Console.ReadLine();
        validNumber = Helpers.isStringANumber(result);
        if (validNumber == true)
        {
            convertedNumber = int.Parse(result);
        }
        
    } while (validNumber == false || convertedNumber < 1 || convertedNumber > 3);

    switch (convertedNumber)
    {
        case EASY:
            difficulty[0] = 0;
            difficulty[1] = 9;
            break;
        case MEDIUM:
            difficulty[0] = 0;
            difficulty[1] = 100;
            break;
        case HARD:
            difficulty[0] = -100;
            difficulty[1] = 100;
            break;
        default:
            Console.WriteLine("Error with intial difficulty option function");
            Environment.Exit(1);
            break;
    }
}
