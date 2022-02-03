using System;

namespace WRDL.Core.Engines
{
    public static class LetterEngine
    {
        // These are the portions of the character blocks that are always in place
        public static string SEGMENT_1 => " .----------------. ";
        public static string SEGMENT_2 => "| .--------------. |";
        public static string SEGMENT_9 => "| |              | |";
        public static string SEGMENT_10 => "| '--------------' |";
        public static string SEGMENT_11 => " '----------------' ";

        // These are the dynamic portions of the letters, beginning with segment 3
        // and ending with segment 8
        public static string SEGMENT_3(char character)
        {
            switch (character)
            {
                case 'A':
                    return "| |      __      | |";
                case 'B':
                    return "| |   ______     | |";
                case 'C':
                    return "| |     ______   | |";
                case 'D':
                    return "| |  ________    | |";
                case 'E':
                    return "| |  _________   | |";
                case 'F':
                    return "| |  _________   | |";
                case 'G':
                    return "| |    ______    | |";
                case 'H':
                    return "| |  ____  ____  | |";
                case 'I':
                    return "| |     _____    | |";
                case 'J':
                    return "| |     _____    | |";
                case 'K':
                    return "| |  ___  ____   | |";
                case 'L':
                    return "| |   _____      | |";
                case 'M':
                    return "| | ____    ____ | |";
                case 'N':
                    return "| | ____  _____  | |";
                case 'O':
                    return "| |     ____     | |";
                case 'P':
                    return "| |   ______     | |";
                case 'Q':
                    return "| |    ___       | |";
                case 'R':
                    return "| |  _______     | |";
                case 'S':
                    return "| |    _______   | |";
                case 'T':
                    return "| |  _________   | |";
                case 'U':
                    return "| | _____  _____ | |";
                case 'V':
                    return "| | ____   ____  | |";
                case 'W':
                    return "| | _____  _____ | |";
                case 'X':
                    return "| |  ____  ____  | |";
                case 'Y':
                    return "| |  ____  ____  | |";
                case 'Z':
                    return "| |   ________   | |";
                default:
                    return string.Empty;
            }
        }

        public static string SEGMENT_4(char character)
        {
            switch (character)
            {
                case 'A':
                    return @"| |     /  \     | |";
                    
                case 'B':
                    return @"| |  |_   _ \    | |";
                    
                case 'C':
                    return "| |   .' ___  |  | |";
                    
                case 'D':
                    return "| | |_   ___ `.  | |";
                    
                case 'E':
                    return "| | |_   ___  |  | |";
                    
                case 'F':
                    return "| | |_   ___  |  | |";
                    
                case 'G':
                    return "| |  .' ___  |   | |";
                    
                case 'H':
                    return "| | |_   ||   _| | |";
                    
                case 'I':
                    return "| |    |_   _|   | |";
                    
                case 'J':
                    return "| |    |_   _|   | |";
                    
                case 'K':
                    return "| | |_  ||_  _|  | |";
                    
                case 'L':
                    return "| |  |_   _|     | |";
                    
                case 'M':
                    return @"| ||_   \  /   _|| |";
                    
                case 'N':
                    return @"| ||_   \|_   _| | |";
                    
                case 'O':
                    return "| |   .'    `.   | |";
                    
                case 'P':
                    return @"| |  |_   __ \   | |";
                    
                case 'Q':
                    return "| |  .'   '.     | |";
                    
                case 'R':
                    return @"| | |_   __ \    | |";
                    
                case 'S':
                    return "| |   /  ___  |  | |";
                    
                case 'T':
                    return "| | |  _   _  |  | |";
                    
                case 'U':
                    return "| ||_   _||_   _|| |";
                    
                case 'V':
                    return "| ||_  _| |_  _| | |";
                    
                case 'W':
                    return "| ||_   _||_   _|| |";
                    
                case 'X':
                    return "| | |_  _||_  _| | |";
                    
                case 'Y':
                    return "| | |_  _||_  _| | |";
                    
                case 'Z':
                    return "| |  |  __   _|  | |";
                    
                default:
                    return string.Empty;
            }
        }

        public static string SEGMENT_5(char character)
        {
            switch (character)
            {
                case 'A':
                    return @"| |    / /\ \    | |";
                    
                case 'B':
                    return "| |    | |_) |   | |";
                    
                case 'C':
                    return @"| |  / .'   \_|  | |";
                    
                case 'D':
                    return @"| |   | |   `. \ | |";
                    
                case 'E':
                    return @"| |   | |_  \_|  | |";
                    
                case 'F':
                    return @"| |   | |_  \_|  | |";
                    
                case 'G':
                    return @"| | / .'   \_|   | |";
                    
                case 'H':
                    return "| |   | |__| |   | |";
                    
                case 'I':
                    return "| |      | |     | |";
                    
                case 'J':
                    return "| |      | |     | |";
                    
                case 'K':
                    return "| |   | |_/ /    | |";
                    
                case 'L':
                    return "| |    | |       | |";
                    
                case 'M':
                    return @"| |  |   \/   |  | |";
                    
                case 'N':
                    return @"| |  |   \ | |   | |";
                    
                case 'O':
                    return @"| |  /  .--.  \  | |";
                    
                case 'P':
                    return "| |    | |__) |  | |";
                    
                case 'Q':
                    return @"| | /  .-.  \    | |";
                    
                case 'R':
                    return "| |   | |__) |   | |";
                    
                case 'S':
                    return @"| |  |  (__ \_|  | |";
                    
                case 'T':
                    return @"| | |_/ | | \_|  | |";
                    
                case 'U':
                    return "| |  | |    | |  | |";
                    
                case 'V':
                    return @"| |  \ \   / /   | |";
                    
                case 'W':
                    return @"| |  | | /\ | |  | |";
                    
                case 'X':
                    return @"| |   \ \  / /   | |";
                    
                case 'Y':
                    return @"| |   \ \  / /   | |";
                    
                case 'Z':
                    return "| |  |_/  / /    | |";
                    
                default:
                    return string.Empty;
            }
        }

        public static string SEGMENT_6(char character)
        {
            switch (character)
            {
                case 'A':
                    return @"| |   / ____ \   | |";
                    
                case 'B':
                    return "| |    |  __'.   | |";
                    
                case 'C':
                    return "| |  | |         | |";
                    
                case 'D':
                    return "| |   | |    | | | |";
                    
                case 'E':
                    return "| |   |  _|  _   | |";
                    
                case 'F':
                    return "| |   |  _|      | |";
                    
                case 'G':
                    return "| | | |    ____  | |";
                    
                case 'H':
                    return "| |   |  __  |   | |";
                    
                case 'I':
                    return "| |      | |     | |";
                    
                case 'J':
                    return "| |   _  | |     | |";
                    
                case 'K':
                    return "| |   |  __'.    | |";
                    
                case 'L':
                    return "| |    | |   _   | |";
                    
                case 'M':
                    return @"| |  | |\  /| |  | |";
                    
                case 'N':
                    return @"| |  | |\ \| |   | |";
                    
                case 'O':
                    return "| |  | |    | |  | |";
                    
                case 'P':
                    return "| |    |  ___/   | |";
                    
                case 'Q':
                    return "| | | |   | |    | |";
                    
                case 'R':
                    return "| |   |  __ /    | |";
                    
                case 'S':
                    return "| |   '.___`-.   | |";
                    
                case 'T':
                    return "| |     | |      | |";
                    
                case 'U':
                    return "| |  | '    ' |  | |";
                    
                case 'V':
                    return @"| |   \ \ / /    | |";
                    
                case 'W':
                    return @"| |  | |/  \| |  | |";
                    
                case 'X':
                    return "| |    > `' <    | |";
                    
                case 'Y':
                    return @"| |    \ \/ /    | |";
                    
                case 'Z':
                    return "| |     .'.' _   | |";
                    
                default:
                    return string.Empty;
            }
        }

        public static string SEGMENT_7(char character)
        {
            switch (character)
            {
                case 'A':
                    return @"| | _/ /    \ \_ | |";
                    
                case 'B':
                    return "| |   _| |__) |  | |";
                    
                case 'C':
                    return @"| |  \ `.___.'\  | |";
                    
                case 'D':
                    return "| |  _| |___.' / | |";
                    
                case 'E':
                    return "| |  _| |___/ |  | |";
                    
                case 'F':
                    return "| |  _| |_       | |";
                    
                case 'G':
                    return @"| | \ `.___]  _| | |";
                    
                case 'H':
                    return "| |  _| |  | |_  | |";
                    
                case 'I':
                    return "| |     _| |_    | |";
                    
                case 'J':
                    return "| |  | |_' |     | |";
                    
                case 'K':
                    return @"| |  _| |  \ \_  | |";
                    
                case 'L':
                    return "| |   _| |__/ |  | |";
                    
                case 'M':
                    return @"| | _| |_\/_| |_ | |";
                    
                case 'N':
                    return @"| | _| |_\   |_  | |";
                    
                case 'O':
                    return @"| |  \  `--'  /  | |";
                    
                case 'P':
                    return "| |   _| |_      | |";
                    
                case 'Q':
                    return @"| | \  `-'  \_   | |";
                    
                case 'R':
                    return @"| |  _| |  \ \_  | |";
                    
                case 'S':
                    return @"| |  |`\____) |  | |";
                    
                case 'T':
                    return "| |    _| |_     | |";
                    
                case 'U':
                    return @"| |   \ `--' /   | |";
                    
                case 'V':
                    return @"| |    \ ' /     | |";
                    
                case 'W':
                    return @"| |  |   /\   |  | |";
                    
                case 'X':
                    return @"| |  _/ /'`\ \_  | |";
                    
                case 'Y':
                    return "| |    _|  |_    | |";
                    
                case 'Z':
                    return "| |   _/ /__/ |  | |";
                    
                default:
                    return string.Empty;
            }
        }

        public static string SEGMENT_8(char character)
        {
            switch (character)
            {
                case 'A':
                    return "| ||____|  |____|| |";
                    
                case 'B':
                    return "| |  |_______/   | |";
                    
                case 'C':
                    return "| |   `._____.'  | |";
                    
                case 'D':
                    return "| | |________.'  | |";
                    
                case 'E':
                    return "| | |_________|  | |";
                    
                case 'F':
                    return "| | |_____|      | |";
                    
                case 'G':
                    return "| |  `._____.'   | |";
                    
                case 'H':
                    return "| | |____||____| | |";
                    
                case 'I':
                    return "| |    |_____|   | |";
                    
                case 'J':
                    return "| |  `.___.'     | |";
                    
                case 'K':
                    return "| | |____||____| | |";
                    
                case 'L':
                    return "| |  |________|  | |";
                    
                case 'M':
                    return "| ||_____||_____|| |";
                    
                case 'N':
                    return @"| ||_____|\____| | |";
                    
                case 'O':
                    return "| |   `.____.'   | |";
                    
                case 'P':
                    return "| |  |_____|     | |";
                    
                case 'Q':
                    return @"| |  `.___.\__|  | |";
                    
                case 'R':
                    return @"| | |____| |___| | |";
                    
                case 'S':
                    return "| |  |_______.'  | |";
                    
                case 'T':
                    return "| |   |_____|    | |";
                    
                case 'U':
                    return "| |    `.__.'    | |";
                    
                case 'V':
                    return @"| |     \_/      | |";
                    
                case 'W':
                    return @"| |  |__/  \__|  | |";
                    
                case 'X':
                    return "| | |____||____| | |";
                    
                case 'Y':
                    return "| |   |______|   | |";
                    
                case 'Z':
                    return "| |  |________|  | |";
                    
                default:
                    return string.Empty;
            }
        }
    }
}