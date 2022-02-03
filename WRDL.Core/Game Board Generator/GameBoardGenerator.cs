using WRDL.Core.DataModels; 

namespace WRDL.Core.Engines
{
    public static class GameBoardGenerator
    {
        public static int TOP_OF_BOARD = 11;
        public static int BOTTOM_OF_BOARD = 26;
        public static int LEFT_OF_BOARD = 0; 
        public static int RIGHT_OF_BOARD = 101; 

        public static void WriteGameBoardBounds()
        {
            for (int i = TOP_OF_BOARD; i < BOTTOM_OF_BOARD; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan; 
                Console.SetCursorPosition(50, i);
                Console.Write('|');
            }
        }

        public static void WriteHeaderSections()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(16, 11);
            Console.Write("CHARACTER MAP");

            Console.SetCursorPosition(74, 11); 
            Console.Write("WORD ATTEMPTS"); 
        }
    }
}