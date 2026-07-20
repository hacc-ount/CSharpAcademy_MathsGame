using MathsGame;

int[] setDifficulty = new int[2];
int[] difficultyMenuOptions = [1, 2, 3];

bool runGame = true;

GameFunctions.getDifficulty(setDifficulty);
Console.WriteLine($"Difficulty: {setDifficulty[0]}{setDifficulty[1]}.");
do
{
    RunMenu();
} while (runGame == true);

void RunMenu()
{

}
