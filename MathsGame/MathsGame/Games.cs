using System.Collections.Concurrent;
using System.Text;

namespace MathsGame;

internal class Games
{
   
    /* Function to run the game rounds. Picks a game based on the game choice
     * which is found in the main Program.cs.*/
    internal static void Game(string gameChoice, int[] difficulty, int MAX_ROUNDS, List<string> gameLog)
    {
        // Initial variables
        Random random = new Random();
        int firstNumber;
        int secondNumber;
        int score = 0;
        int userAnswer;

        Console.Clear();
        Console.WriteLine($"{gameChoice} game started...\n");

        // Run rounds
        for (int round = 0; round < MAX_ROUNDS; round++)
        {
            // Temporarily set the answer back to zero within the loop
            userAnswer = 0;

            // Update the number variables based on difficulty
            firstNumber = random.Next(difficulty[0], difficulty[1]);
            secondNumber = random.Next(difficulty[0], difficulty[1]);

            // List of Operation objects with different game operations
            List<Operations> operations = new List<Operations>()
            {
                    new Operations(firstNumber, secondNumber)
                    {
                        Result = firstNumber + secondNumber,
                        Question = $"What is {firstNumber} + {secondNumber}?\n"
                    },
                    new Operations(firstNumber, secondNumber)
                    {
                        Result = firstNumber - secondNumber,
                        Question = $"What is {firstNumber} - {secondNumber}?\n"
                    }
            };

            
            // Set a random game (or operation) from operations
            Operations randomChoice = operations[random.Next(2)];

            // Ask the question based on the game choice and get the answer
            int correctAnswer = GetAnswer(gameChoice, firstNumber, secondNumber, randomChoice);
            
            // Get user input
            string? result = Console.ReadLine();
            if (result == null)
            {
                Console.WriteLine("Result was null.");
                Environment.Exit(1);
            }

            // Check the user input
            try
            {
                userAnswer = int.Parse(result);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number.");
            }

            // Check the users answer and display messages
            score += CheckAnswers(round, MAX_ROUNDS, userAnswer, correctAnswer);
            Helpers.ConsoleClear();
        }

        string log = $"{gameChoice}: Total Score: {score} -- {DateTime.Now}";
        gameLog.Add(log);
    }

    // Function for asking the appropriate game question and getting the result.
    private static int GetAnswer(string gameChoice, int firstNumber, int secondNumber, Operations randomChoice)
    {
        switch (gameChoice)
        {
            case "Addition":
                Console.WriteLine($"What is {firstNumber} + {secondNumber}?\n");
                return firstNumber + secondNumber;
            case "Random":
                Console.WriteLine(randomChoice.Question);
                return randomChoice.Result;
            default:
                Console.WriteLine("Error, no gamemode selected.");
                return -10000; // This number will never be reached, so it equals an error.
        }
    }

    // Function for checking the user answer against the correct answer.
    private static int CheckAnswers(int round, int MAX_ROUNDS, int userAnswer, int correctAnswer)
    {
        int score = 0;
        if (userAnswer == correctAnswer && round == MAX_ROUNDS - 1)
        {
            Console.WriteLine("Correct answer.");
            Console.WriteLine("Game over. Press any key to return to the main menu.\n");
            Console.ReadLine();
            score++;
            return score;
        }
        else if (userAnswer == correctAnswer && round <= MAX_ROUNDS - 1)
        {
            Console.WriteLine("Correct answer.\n");
            score++;
            return score;
        }
        else if (userAnswer != correctAnswer && round == MAX_ROUNDS - 1)
        {
            Console.WriteLine($"Incorrect. The answer was {correctAnswer}.");
            Console.WriteLine("Game Over. Press any key to return to the main menu.\n");
            Console.ReadLine();
            return score;
        }
        else
        {
            Console.WriteLine($"Incorrect. The answer was {correctAnswer}.\n");
            return score;
        }
    }
}
