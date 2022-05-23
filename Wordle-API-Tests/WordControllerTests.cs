using NUnit.Framework;
using Wordle_API.Controller;


namespace Wordle_API_Tests
{
    [TestFixture]
    public class Tests
    {
        public WordController wordController = new();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void VerifyWordsLoad()
        {

            Assert.Pass();
        }
    }
}