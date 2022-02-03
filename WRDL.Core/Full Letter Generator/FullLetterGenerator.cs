namespace WRDL.Core.Engines
{
    public static class FullLetterGenerator
    {
        public static void GenerateBlankBlock(int placement)
        {
            // Placement guard
            if (placement < 1 || placement > 5)
            {
                throw new Exception("The placemnt is invalid");
            }

            // Write letter
            int correctedPlacement = placement - 1;
            Console.ForegroundColor = StateColor(1);

            Console.SetCursorPosition(correctedPlacement * 20 + 1, 0);
            Console.Write(LetterEngine.SEGMENT_1);

            Console.SetCursorPosition(correctedPlacement * 20 + 1, 1);
            Console.Write(LetterEngine.SEGMENT_2);

            Console.SetCursorPosition(correctedPlacement * 20 + 1, 2);
            Console.Write(LetterEngine.SEGMENT_9);

            Console.SetCursorPosition(correctedPlacement * 20 + 1, 3);
            Console.Write(LetterEngine.SEGMENT_9);

            Console.SetCursorPosition(correctedPlacement * 20 + 1, 4);
            Console.Write(LetterEngine.SEGMENT_9);

            Console.SetCursorPosition(correctedPlacement * 20 + 1, 5);
            Console.Write(LetterEngine.SEGMENT_9);

            Console.SetCursorPosition(correctedPlacement * 20 + 1, 6);
            Console.Write(LetterEngine.SEGMENT_9);

            Console.SetCursorPosition(correctedPlacement * 20 + 1, 7);
            Console.Write(LetterEngine.SEGMENT_9);

            Console.SetCursorPosition(correctedPlacement * 20 + 1, 8);
            Console.Write(LetterEngine.SEGMENT_9);

            Console.SetCursorPosition(correctedPlacement * 20 + 1, 9);
            Console.Write(LetterEngine.SEGMENT_10);

            Console.SetCursorPosition(correctedPlacement * 20 + 1, 10);
            Console.Write(LetterEngine.SEGMENT_11);
        }

        public static void GenerateLetter(char character, int placement, int state)
        {
            placement++;

            // Placement guard
            if (placement < 1 || placement > 5)
            {
                throw new Exception("The placemnt is invalid");
            }

            // State guard
            if (state < 1 || state > 4)
            {
                throw new Exception("The state is invalid");
            }

            // Write letter
            int correctedPlacement = placement - 1;
            Console.ForegroundColor = StateColor(state);

            Console.SetCursorPosition(correctedPlacement * 20 + 1, 0);
            Console.Write(LetterEngine.SEGMENT_1);

            Console.SetCursorPosition(correctedPlacement * 20 + 1, 1);
            Console.Write(LetterEngine.SEGMENT_2);

            Console.SetCursorPosition(correctedPlacement * 20 + 1, 2);
            Console.Write(LetterEngine.SEGMENT_3(character));

            Console.SetCursorPosition(correctedPlacement * 20 + 1, 3);
            Console.Write(LetterEngine.SEGMENT_4(character));

            Console.SetCursorPosition(correctedPlacement * 20 + 1, 4);
            Console.Write(LetterEngine.SEGMENT_5(character));

            Console.SetCursorPosition(correctedPlacement * 20 + 1, 5);
            Console.Write(LetterEngine.SEGMENT_6(character));

            Console.SetCursorPosition(correctedPlacement * 20 + 1, 6);
            Console.Write(LetterEngine.SEGMENT_7(character));

            Console.SetCursorPosition(correctedPlacement * 20 + 1, 7);
            Console.Write(LetterEngine.SEGMENT_8(character));

            Console.SetCursorPosition(correctedPlacement * 20 + 1, 8);
            Console.Write(LetterEngine.SEGMENT_9);

            Console.SetCursorPosition(correctedPlacement * 20 + 1, 9);
            Console.Write(LetterEngine.SEGMENT_10);

            Console.SetCursorPosition(correctedPlacement * 20 + 1, 10);
            Console.Write(LetterEngine.SEGMENT_11);

            Console.ResetColor();
        }

        private static ConsoleColor StateColor(int state)
        {
            switch (state)
            {
                case 1:
                    return ConsoleColor.White;
                case 2:
                    return ConsoleColor.DarkYellow;
                case 3:
                    return ConsoleColor.Green;
                case 4:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.White;
            }
        }
    }
}