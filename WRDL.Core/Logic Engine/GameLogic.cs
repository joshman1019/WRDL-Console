using WRDL.Core.Engines;
using WRDL.Core.DataModels;
using System.Data;

namespace WRDL.Core.GameLogic
{
    public class GameLogic
    {
        private readonly string PATH = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "FullWordList.xml");
        public static void InitGame()
        {
            CreateBlankTiles();
            WriteGameBoard();
        }

        private static void CreateBlankTiles()
        {
            FullLetterGenerator.GenerateBlankBlock(1);
            FullLetterGenerator.GenerateBlankBlock(2);
            FullLetterGenerator.GenerateBlankBlock(3);
            FullLetterGenerator.GenerateBlankBlock(4);
            FullLetterGenerator.GenerateBlankBlock(5);
        }

        public void ClearInvalidWordText()
        {
            Console.SetCursorPosition(5, 24);
            Console.Write("".PadRight(12));
            Console.SetCursorPosition(0, 0);
        }

        public bool DetermineWin(Game game)
        {
            // Null game check
            if (game is null)
            {
                throw new Exception("Game was null. Error");
            }

            // If word is not in dictionary, return false without advancing or 
            // showing letter results
            var resultString = new string(game.CurrentGuess);
            var dictioanry = GetGameTable();
            bool invalid = true; 
            foreach (DataRow wordRow in dictioanry.Item1.Tables[0].Rows)
            {
                if (wordRow[0].ToString() == resultString)
                {
                    invalid = false;
                    break; 
                }
            }

            if(invalid)
            {
                game.CurrentGuess = new char[5];
                game.CurrentPosition = 0;
                return false; 
            }

            // Determine if word was a winner
            foreach (int state in game.CurrentGuessStates)
            {
                if (state != 3)
                {
                    game.GuessNumber += 1;
                    game.Guesses.Add(game.CurrentGuess.ToArray());

                    // Clear the current guess
                    game.CurrentGuess = new char[5];
                    return false;
                }
            }
            return true;
        }

        private static void WriteGameBoard()
        {
            GameBoardGenerator.WriteGameBoardBounds();
            GameBoardGenerator.WriteHeaderSections();
        }

        public void IdentifyAndAdvance(Game game)
        {
            // Returns with no change if word is invalid
            string wordResult = new string(game.CurrentGuess);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(74, 24);
            Console.Write($"LAST ATTEMPT: {wordResult}");
            Console.ResetColor();
            if (!IsWordInDictionary(wordResult))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(5, 24);
                Console.Write($"INVALID WORD");
                Console.ResetColor();
                return;
            }

            // Reset game current position 
            game.CurrentPosition = 0;

            for (int i = 0; i < game.CurrentGuess.Length; i++)
            {
                int exactMatchState = game.TestExactPosition(game.CurrentGuess[i], game.CurrentPosition);
                int relativeMatchState = game.TestRelativePosition(game.CurrentGuess[i]);
                if (exactMatchState == relativeMatchState)
                {
                    game.CurrentGuessStates[game.CurrentPosition] = exactMatchState;
                }
                else if (exactMatchState > relativeMatchState)
                {
                    game.CurrentGuessStates[game.CurrentPosition] = exactMatchState;
                }
                else game.CurrentGuessStates[game.CurrentPosition] = relativeMatchState;
                game.CurrentPosition += 1;
            }

            // Reset game current position for writing results
            game.CurrentPosition = 0;

            for (int i = 0; i < game.CurrentGuess.Length; i++)
            {
                FullLetterGenerator.GenerateLetter(game.CurrentGuess[i], game.CurrentPosition, game.CurrentGuessStates[i]);
                game.CurrentPosition += 1;
            }

            // Reset game current position for next guess, if any remain
            game.CurrentPosition = 0;
        }

        public bool BeginGuessLoop(Game game)
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Black;
            if (game.CurrentPosition <= game.MAX_POSITION)
            {
                var currentChar = TakeKeyGuess();
                if (currentChar == 3)
                {
                    if (game.CurrentPosition <= game.MAX_POSITION)
                        return true;

                    return false;
                }
                if (currentChar == 8)
                {
                    if (game.CurrentPosition == 0)
                        return true;
                    game.CurrentPosition -= 1;
                    FullLetterGenerator.GenerateBlankBlock(game.CurrentPosition + 1);
                    return true;
                }

                // Write invalid letter if character value is outside of range
                if (GetKeyCharInvariant(currentChar) < 65 || GetKeyCharInvariant(currentChar) > 90)
                {
                    FullLetterGenerator.GenerateLetter('X', game.CurrentPosition, 4);
                    game.CurrentPosition += 1;
                    return true;
                }

                // Write character to current guess
                game.CurrentGuess[game.CurrentPosition] = GetKeyCharInvariant(currentChar);

                // Write guess into position once it is valid
                // Then advance current position
                FullLetterGenerator.GenerateLetter(GetKeyCharInvariant(currentChar), game.CurrentPosition, 1);
                game.CurrentPosition += 1;
                return true;
            }
            else
            {
                var currentChar = TakeKeyGuess();
                if (currentChar == 3)
                {
                    if (game.CurrentPosition < game.MAX_POSITION)
                        return true;
                    return false;
                }
                else if (currentChar == 8)
                {
                    if (game.CurrentPosition == 0)
                        return true;
                    game.CurrentPosition -= 1;
                    FullLetterGenerator.GenerateBlankBlock(game.CurrentPosition + 1);
                    return true;
                }
                else return true;
            }
        }

        private char TakeKeyGuess()
        {
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey();
                // Special key returns
                if (key.Key == ConsoleKey.Enter)
                    return (char)3;
                if (key.Key == ConsoleKey.Backspace)
                    return (char)8;
            } while ((key.KeyChar < 97 && key.KeyChar > 122) && (key.KeyChar < 65 && key.KeyChar > 90));
            // Regular alpha return
            return key.KeyChar;
        }

        private char GetKeyCharInvariant(char character)
        {
            char outputChar;
            if (character >= 97 && character <= 122)
            {
                outputChar = (char)(character - 32);
                return outputChar;
            }
            if (character >= 65 && character <= 90)
                return character;

            return (char)0;
        }

        /// <summary>
        /// Retrieves a new game with a word populated
        /// </summary>
        /// <returns></returns>
        public Game GetNewGame()
        {
            Game gm = new Game();
            gm.CurrentPosition = 0;
            gm.Word = GetWordFromList();
            return gm;
        }

        private char[] GetWordFromList()
        {
            var gameTable = GetGameTable();
            Random rdm = new Random();
            int position = rdm.Next(gameTable.Item2);
            string value = gameTable.Item1.Tables[0].Rows[position][0].ToString();
            if (value is not null)
            {
                return value.ToCharArray();
            }
            else throw new Exception("Word was null. Error");
        }

        private bool IsWordInDictionary(string word)
        {
            var gameTable = GetGameTable();
            foreach (DataRow row in gameTable.Item1.Tables[0].Rows)
            {
                if (row[0].ToString() == word)
                {
                    return true;

                }
            }
            return false;
        }

        // Retrieves a datatable containing the word list
        private (DataSet, int) GetGameTable()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(PATH);
            return (ds, ds.Tables[0].Rows.Count);
        }

        public void EndScreenResultsGenerator(Game game)
        {
            int consoleRow = 15;
            // Set cursor position to below the result text
            foreach (char[] guess in game.Guesses)
            {
                int charPosition = 0;
                Console.SetCursorPosition(47, consoleRow);
                foreach (char character in guess)
                {
                    int exactStatus = game.TestExactPosition(character, charPosition);
                    int relativeStatus = game.TestRelativePosition(character);
                    int finalStatus;
                    if (exactStatus == relativeStatus)
                    {
                        finalStatus = exactStatus;
                    }
                    else if (exactStatus > relativeStatus)
                    {
                        finalStatus = exactStatus;
                    }
                    else
                    {
                        finalStatus = relativeStatus;
                    }

                    switch (finalStatus)
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write('#');
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write('#');
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write('#');
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write('#');
                            break;
                    }
                    charPosition += 1;
                }
                consoleRow += 1;
            }
        }
    }
}