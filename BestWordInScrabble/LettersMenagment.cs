using System.Collections.Generic;
using System.Linq;

namespace BestWordInScrabble
{
    public static class LettersMenagment
    {
        public static void CheckWordsForNewsLetters(
            List<List<string>> wordsList, List<string> selectedLetters, List<BestWord> bestWords)
        {
            foreach (var list in wordsList)
            {
                foreach (var word in list)
                {
                    var valueOfWord = CheckIfWorldIsGood(word, selectedLetters);
                    if (valueOfWord > 0)
                        SetWordInBestWords(word, valueOfWord, bestWords);
                }
            }
        }

        public static int CheckIfWorldIsGood(string word, List<string> selectedLetters)
        {
            List<string> letters = new List<string>();
            var anyLetterIteration = 0;
            var goodLetter = false;
            var valueOfWord = 0;
            foreach (var letter in selectedLetters)
            {
                if (letter != " ")
                    letters.Add(letter);
                else
                    anyLetterIteration++;
            }
            foreach (var letter in word)
            {
                if (letters.Count == 0)
                    return 0;
                foreach (var selectedLetter in letters)
                {
                    goodLetter = false;
                    if (selectedLetter == letter.ToString())
                    {
                        letters.Remove(selectedLetter);
                        valueOfWord += ValueOfLetter.GetValue(letter.ToString());
                        goodLetter = true;
                        break;
                    }
                }
                if (!goodLetter)
                {
                    if (anyLetterIteration > 0)
                    {
                        anyLetterIteration--;
                        valueOfWord += ValueOfLetter.GetValue(letter.ToString());
                        goodLetter = true;
                    }
                    else
                        return 0;
                }
            }
            return valueOfWord;
        }

        private static void SetWordInBestWords(string word, int valueOfWord, List<BestWord> bestWords)
        {
            if (valueOfWord >= bestWords[0].Value && word != bestWords[0].Word)
            {
                if (!string.IsNullOrEmpty(bestWords[1].Word))
                    bestWords[2] = new BestWord
                    {
                        Word = bestWords[1].Word,
                        Value = bestWords[1].Value
                    };
                if (!string.IsNullOrEmpty(bestWords[0].Word))
                    bestWords[1] = new BestWord
                    {
                        Word = bestWords[0].Word,
                        Value = bestWords[0].Value
                    };
                bestWords[0] = new BestWord
                {
                    Word = word,
                    Value = valueOfWord
                };
            }
            else if (valueOfWord >= bestWords[1].Value && word != bestWords[1].Word && 
                word != bestWords[1].Word)
            {
                if (!string.IsNullOrEmpty(bestWords[1].Word))
                    bestWords[2] = new BestWord
                    {
                        Word = bestWords[1].Word,
                        Value = bestWords[1].Value
                    };
                bestWords[1] = new BestWord
                {
                    Word = word,
                    Value = valueOfWord
                };
            }
            else if (valueOfWord >= bestWords[2].Value && word != bestWords[2].Word && word != bestWords[1].Word && word != bestWords[0].Word)
            {
                bestWords[2] = new BestWord
                {
                    Word = word,
                    Value = valueOfWord
                };
            }
        }

        public static void DeleteUsedLetters(string word, List<string> selectedLetters, 
            ref List<BestWord> bestWords)
        {
            ClearAndSetEmptyBestWords(ref bestWords);
            foreach (var letter in word)
            {
                var anyLetter = true;
                for (int i = selectedLetters.Count - 1; i >= 0; i--)
                {
                    if (selectedLetters[i] == letter.ToString())
                    {
                        selectedLetters.RemoveAt(i);
                        anyLetter = false;
                        break;
                    }
                }
                if (anyLetter)
                    for (int i = selectedLetters.Count - 1; i >= 0; i--)
                    {
                        if (selectedLetters[i] == " ")
                        {
                            selectedLetters.RemoveAt(i);
                            break;
                        }
                    }
            }
        }

        public static void ClearAndSetEmptyBestWords(ref List<BestWord> bestWords)
        {
            bestWords = new List<BestWord>();
            for (int i = 0; i < 3; i++)
            {
                bestWords.Add(new BestWord());
            }
        }
    }
}
