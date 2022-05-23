using NUnit.Framework;
using System.Collections.Generic;
using Wordle_API.Controllers;
using Wordle_API.DTO;

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
        public void GetWords()
        {
            List<WordDTO> wordCollection = wordController.GetWordCollection();
            Assert.Pass();
        }
    }
}