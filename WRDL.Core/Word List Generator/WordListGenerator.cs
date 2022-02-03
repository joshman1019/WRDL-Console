using WRDL.Core.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace WRDL.Core.Engines
{
    public static class WordListGenerator
    {
        public static void GenerateWordList(Game game)
        {
            int currentLine = 12;
            int position = 0;
            List<(char, int)> characterStateList = new List<(char, int)>();
            foreach (char[] guess in game.Guesses)
            {
                Console.SetCursorPosition(74, currentLine);
                foreach (char letter in guess)
                {
                    int stateExact = game.TestExactPosition(letter, position);
                    int stateRelative = game.TestRelativePosition(letter);
                    int finalState;
                    if (stateExact == stateRelative)
                    {
                        finalState = stateExact;
                    }
                    else if (stateExact > stateRelative)
                    {
                        finalState = stateExact;
                    }
                    else
                    {
                        finalState = stateRelative;
                    }
                    switch (finalState)
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            if(characterStateList.Contains((letter, 2)) || characterStateList.Contains((letter, 3)))
                            {
                                break;
                            }
                            characterStateList.Add((letter, 1));
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            if(characterStateList.Contains((letter, 3)))
                            {
                                break; 
                            }
                            characterStateList.Add((letter, 2));
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Green;
                            characterStateList.Add((letter, 3));
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }

                    Console.Write(letter);
                    Console.ResetColor();
                    position++;
                }
                currentLine += 1;
                position = 0;
            }
            BuildUsedCharacterMap(characterStateList);
        }

        private static void BuildUsedCharacterMap(List<(char, int)> characterStateList)
        {
            int startingLine = 12;
            int currentColumn = 15;
            char[] availableChars = new char[] {'A', 'B', 'C', 'D', 'E',
                                                'F', 'G', 'H', 'I', 'J',
                                                'K', 'L', 'M', 'N', 'O',
                                                'P', 'Q', 'R', 'S', 'T',
                                                'U', 'V', 'W', 'X', 'Y',
                                                'Z'};
            foreach (char availableChar in availableChars)
            {
                (char?, int?) result = characterStateList.FirstOrDefault(c => c.Item1 == availableChar);
                if (result.Item1 is not null)
                {
                    switch (result.Item2)
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if(currentColumn >= 35)
                {
                    currentColumn = 15;
                    startingLine += 1; 
                }
                Console.SetCursorPosition(currentColumn, startingLine);
                Console.Write(availableChar);
                currentColumn += 5;
                Console.ResetColor(); 
            }
        }
    }
}