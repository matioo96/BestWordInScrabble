using System.Collections.Generic;

namespace BestWordInScrabble
{
    public static class ValueOfLetter
    {
        private static List<List<string>> LettersLists = new List<List<string>>()
        {
            new List<string>() { "A", "E", "I", "O" },
            new List<string>() { "B", "D", "L", "M", "N", "P", "R", "S", "T", "W", "Y", "Z" },
            new List<string>() { "C", "F", "H", "K", "U" },
            new List<string>() { "G", "J", "Ł" },
            new List<string>() { },
            new List<string>() { "Ą", "Ó", "Ś" },
            new List<string>() { "Ć" },
            new List<string>() { "Ę", "Ń", "Ż", "Ź" }
        };

        public static int GetValue(string selectedLetter)
        {
            for (int i = 0; i < 8; i++)
            {
                foreach (var letter in LettersLists[i])
                {
                    if (selectedLetter == letter)
                        return i + 1;
                }
            }
            return 0;
        }
    }
}
