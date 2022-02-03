namespace WRDL.Core.DataModels
{
    public class Game
    {
        public readonly int MAX_GUESSES = 6;
        public readonly int MAX_POSITION = 4;
        public char[] Word { get; set; } = new char[5];
        public char[] CurrentGuess { get; set; } = new char[5];
        public int[] CurrentGuessStates { get; set; } = new int[5];
        public List<char[]> Guesses { get; set; } = new List<char[]>(); 
        public int GuessNumber { get; set; }
        public int CurrentPosition { get; set; } = 0; 

        /// <summary>
        /// Returns a status after analyzing whether a character resides in an exact position
        /// within the string. 
        /// </summary>
        /// <param name="character"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public int TestExactPosition(char character, int position)
        {
            if (Word[position] == character)
            {
                return 3;
            }
            else return 1; 
        }

        /// <summary>
        /// Returns a status after analyzing whether a character resides in a relative position
        /// within the string
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public int TestRelativePosition(char character)
        {
            for (int i = 0; i < Word.Length; i++)
            {
                if (Word[i] == character)
                    return 2;
            }
            return 1; 
        }
    }
}