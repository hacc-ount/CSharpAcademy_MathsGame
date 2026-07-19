namespace MathsGame;

internal class Games
{
    //Addition game function 
    internal static void AdditionGame(List<int> difficulty, int MAX_ROUNDS)
    {
        Random random = new Random();
        int firstNumber;
        int secondNumber;

        int score = 0;

        Console.WriteLine("Addition game started...\n");

        // Run rounds
        for (int round = 0; round < MAX_ROUNDS; round++)
        {
            // Update the number variables based on difficulty
            firstNumber = random.Next(difficulty[0], difficulty[1]);
            secondNumber = random.Next(difficulty[0], difficulty[1]);

            Console.WriteLine($"What is {firstNumber} + {secondNumber}?\n");
            string result = Console.ReadLine();

            if (int.Parse(result) == firstNumber + secondNumber && round == MAX_ROUNDS - 1)
            {
                Console.WriteLine("Correct answer.");
                Console.WriteLine("Game over. Press any key to return to the main menu.\n");
                score++;
            }
            else if (int.Parse(result) == firstNumber + secondNumber && round <= MAX_ROUNDS - 1)
            {
                Console.WriteLine("Correct answer. Press any key to continue.\n");
                score++;
            }
            else if (round <= MAX_ROUNDS - 1)
            {
                Console.WriteLine("Incorrect. Press any key to continue.\n");
            }
            else
            {
                Console.WriteLine("Incorrect.");
                Console.WriteLine("Game Over. Press any key to return to the main menu.\n");
            }
        }
    }

    //Subtraction game function

    //Multiplication game function

    //Division game function
}
