using NUnit.Framework;
using System.Collections.Generic;
using Wordle_API.Controllers;
using Wordle_API.DTO;

namespace Wordle_API_Tests
{
    [TestFixture]
    public class WordControllerTests
    {
        public WordController wordController = new();

        [SetUp]
        public void Setup()
        {
            //wordController = new();
        }

        [Test]
        public void GetWords()
        {
            List<WordDTO> wordCollection = wordController.GetWordCollection();
            Assert.IsNotNull(wordCollection);
            Assert.True(wordCollection.Count > 0);
        }
    }
}