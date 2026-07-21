using System.Collections.Concurrent;

namespace MathsGame;

internal class Games
{
    //Addition game function 
    internal static void Game(string gameChoice, int[] difficulty, int MAX_ROUNDS)
    {
        Random random = new Random();
        int firstNumber;
        int secondNumber;

        int score = 0;

        int userAnswer = 0;

        Console.WriteLine($"{gameChoice} game started...\n");

        // Run rounds
        for (int round = 0; round < MAX_ROUNDS; round++)
        {
            // Update the number variables based on difficulty
            firstNumber = random.Next(difficulty[0], difficulty[1]);
            secondNumber = random.Next(difficulty[0], difficulty[1]);

            int correctAnswer = GetAnswer(gameChoice, firstNumber, secondNumber);
            

            string? result = Console.ReadLine();
            if (result == null)
            {
                Console.WriteLine("Result was null.");
                Environment.Exit(1);
            }

            // Temporarily set the answer back to zero within the loop
            userAnswer = 0;
            

            try
            {
                userAnswer = int.Parse(result);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number.");
            }

            
            CheckAnswers(round, MAX_ROUNDS, userAnswer, correctAnswer, score);
            Helpers.ConsoleClear();
        }
    }

    // Function for asking the appropriate game question and getting the result.
    private static int GetAnswer(string gameChoice, int firstNumber, int secondNumber)
    {
        switch (gameChoice)
        {
            case "Addition":
                Console.WriteLine($"What is {firstNumber} + {secondNumber}?\n");
                return firstNumber + secondNumber;
            default:
                Console.WriteLine("Error, no gamemode selected.");
                return -10000; // This number will never be reached, so it equals an error.
        }
    }

    // Function for checking the user answer against the correct answer.
    private static void CheckAnswers(int round, int MAX_ROUNDS, int userAnswer, int correctAnswer, int score)
    {
        if (userAnswer == correctAnswer && round == MAX_ROUNDS - 1)
        {
            Console.WriteLine("Correct answer.");
            Console.WriteLine("Game over. Press any key to return to the main menu.\n");
            score++;
        }
        else if (userAnswer == correctAnswer && round <= MAX_ROUNDS - 1)
        {
            Console.WriteLine("Correct answer. Press any key to continue.\n");
            score++;
        }
        else if (userAnswer != correctAnswer && round <= MAX_ROUNDS - 1)
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
