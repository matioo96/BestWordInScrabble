using BestWordInScrabble;
using NUnit.Framework;
using System.Collections.Generic;

namespace BestWordInSrcrabble.UnitTests
{
    public class LettersMenagmentTests
    {
        [Test]
        public void CheckIfWorldIsGood_CheckingIfAllLettersFitsToWord_Yes()
        {
            //Arange
            string word = "STOLIK";
            List<string> selectedLetters = new List<string>() { "O", "L", "S", "I", "T", "K" };

            //Act
            var result = LettersMenagment.CheckIfWorldIsGood(word, selectedLetters);

            //Assert
            Assert.That(result, Is.EqualTo(11));
        }
    }
}
