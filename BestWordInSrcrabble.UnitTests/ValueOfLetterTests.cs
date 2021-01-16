using BestWordInScrabble;
using NUnit.Framework;

namespace BestWordInSrcrabble.UnitTests
{
    public class ValueOfLetterTests
    {
        [Test]
        public void GetValue_CalculatePoints_3Points()
        {
            //Arange

            //Act
            var result = ValueOfLetter.GetValue("H");

            //Assert
            Assert.That(result, Is.EqualTo(3));
        }
    }
}
