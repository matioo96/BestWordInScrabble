using RelayCommandLibrary;
using RelayCommandLibrary.Commands;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BestWordInScrabble.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        WordsList _wordsList;
        private List<string> _selectedLetters;
        private List<BestWord> _bestWords;
        public ICommand AddLetterCommand { get; set; }
        public ICommand BestWordCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        public MainWindowViewModel()
        {
            AddLetterCommand = new RelayCommand(AddLetter, CanAdd);
            BestWordCommand = new RelayCommand(ChoseBestWord);
            ExitCommand = new RelayCommand(Exit);

            var strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = System.IO.Path.GetDirectoryName(strExeFilePath) + "\\words.txt";

            _wordsList = new WordsList(path);
            _selectedLetters = new List<string>();
            LettersMenagment.ClearAndSetEmptyBestWords(ref _bestWords);
        }

        public string SelectedLetter1
        {
            get { return _selectedLetters.Count > 0 ? _selectedLetters[0] : string.Empty; }
        }
        public string SelectedLetter2
        {
            get { return _selectedLetters.Count > 1 ? _selectedLetters[1] : string.Empty; }
        }
        public string SelectedLetter3
        {
            get { return _selectedLetters.Count > 2 ? _selectedLetters[2] : string.Empty; }
        }
        public string SelectedLetter4
        {
            get { return _selectedLetters.Count > 3 ? _selectedLetters[3] : string.Empty; }
        }
        public string SelectedLetter5
        {
            get { return _selectedLetters.Count > 4 ? _selectedLetters[4] : string.Empty; }
        }
        public string SelectedLetter6
        {
            get { return _selectedLetters.Count > 5 ? _selectedLetters[5] : string.Empty; }
        }
        public string SelectedLetter7
        {
            get { return _selectedLetters.Count > 6 ? _selectedLetters[6] : string.Empty; }
        }
        public string SelectedLetter8
        {
            get { return _selectedLetters.Count > 7 ? _selectedLetters[7] : string.Empty; }
        }
        public string SelectedLetter9
        {
            get { return _selectedLetters.Count > 8 ? _selectedLetters[8] : string.Empty; }
        }

        public string BestWord1
        {
            get { return !string.IsNullOrEmpty(_bestWords[0].Word) ? 
                    $"{_bestWords[0].Word} - {_bestWords[0].Value}ptk" : "-- BRAK --"; }
        }
        public string BestWord2
        {
            get { return !string.IsNullOrEmpty(_bestWords[1].Word) ? 
                    $"{_bestWords[1].Word} - {_bestWords[1].Value}ptk" : "-- BRAK --"; }
        }
        public string BestWord3
        {
            get { return !string.IsNullOrEmpty(_bestWords[2].Word) ?
                    $"{_bestWords[2].Word} - {_bestWords[2].Value}ptk" : "-- BRAK --"; }
        }

        private void ChoseBestWord(object obj)
        {
            var button = obj as Button;
            var content = button.Content.ToString().Split(' ');
            var word = content[0];
            LettersMenagment.DeleteUsedLetters(word, _selectedLetters, ref _bestWords);
            LettersMenagment.CheckWordsForNewsLetters(_wordsList.GetWordsList, _selectedLetters, _bestWords);
            Refresh();
        }

        private bool CanAdd(object obj)
        {
            return _selectedLetters.Count >= 9 ? false : true;
        }

        private void AddLetter(object obj)
        {
            var button = obj as Button;
            _selectedLetters.Add(button.Content.ToString());
            LettersMenagment.CheckWordsForNewsLetters(_wordsList.GetWordsList, _selectedLetters, _bestWords);
            Refresh();
        }

        private void Refresh()
        {
            for (int i = 0; i <= 9; i++)
            {
                OnPropertyChanged($"SelectedLetter{i}");
            }
            OnPropertyChanged(nameof(BestWord1));
            OnPropertyChanged(nameof(BestWord2));
            OnPropertyChanged(nameof(BestWord3));
        }

        private void Exit(object obj)
        {
            Application.Current.Shutdown();
        }
    }
}
