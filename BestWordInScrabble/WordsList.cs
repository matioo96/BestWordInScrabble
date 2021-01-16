using System.Collections.Generic;
using System.IO;

namespace BestWordInScrabble
{
    public class WordsList
    {
        private List<List<string>> _wordsList;
        public WordsList(string path)
        {
            _wordsList = new List<List<string>>();
            for (int i = 0; i < 9; i++)
            {
                _wordsList.Add(new List<string>());
            }
            ReadWordsToList(path);
        }

        public List<List<string>> GetWordsList
        {
            get { return _wordsList; }
        }

        private void ReadWordsToList(string path)
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                string word;
                while ((word = streamReader.ReadLine()) != null)
                {
                    _wordsList[word.Length - 1].Add(word);
                }
            }
        }
    }
}
