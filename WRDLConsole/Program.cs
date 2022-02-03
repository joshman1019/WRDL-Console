using WRDL.Core.GameLogic;
using WRDL.Core.Engines; 

namespace WRDL
{
    public static class Program
    {
        public static async Task Main()
        {
            Console.SetWindowSize(101, 26);

            bool win = false;
            GameLogic logic = new GameLogic();
            var game = logic.GetNewGame();
            while (!win)
            {
                GameLogic.InitGame();
                while (logic.BeginGuessLoop(game))
                {
                    // Roll through guess loop
                }
                logic.IdentifyAndAdvance(game);
                win = logic.DetermineWin(game);

                // Handle a win
                if (win)
                {
                    string winEndString = "CONGRATULATIONS : YOU ARE A WINNER";
                    game.Guesses.Add(game.CurrentGuess);
                    WordListGenerator.GenerateWordList(game);
                    Console.Clear();
                    Console.SetCursorPosition((Console.WindowWidth - winEndString.Length) / 2, 13);
                    Console.ForegroundColor = ConsoleColor.Green; 
                    Console.Write(winEndString);
                    logic.EndScreenResultsGenerator(game); 
                    Console.ReadLine();
                    return; 
                }

                // Handle a max guesses event
                if (game.GuessNumber == game.MAX_GUESSES)
                {
                    string endString = "GAME OVER : PLEASE TRY AGAIN";
                    game.Guesses.Add(game.CurrentGuess);
                    WordListGenerator.GenerateWordList(game); 
                    Console.Clear();
                    Console.SetCursorPosition((Console.WindowWidth - endString.Length) / 2, 13);
                    Console.ForegroundColor = ConsoleColor.Red; 
                    Console.Write(endString);
                    logic.EndScreenResultsGenerator(game);
                    Console.ReadLine();
                    return; 
                }

                // Display the Guess Number
                Console.SetCursorPosition(55, 24);
                Console.ForegroundColor = ConsoleColor.Cyan; 
                Console.WriteLine($"Guesses: {game.GuessNumber}");
                Console.ResetColor();

                // Delay console events
                await Task.Delay(2500);

                // Generate word list
                WordListGenerator.GenerateWordList(game); 

                // Clear invalid word text if it exists
                logic.ClearInvalidWordText();
            }
        }
    }
}

