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
        }

        [Test]
        public void GetWords()
        {
            List<WordDTO> wordCollection = wordController.GetWordCollection();
            Assert.IsNotNull(wordCollection);
            Assert.True(wordCollection.Count > 0);
            Assert.True(wordCollection[0].Word.Length > 0);
        }

        [Test]
        public void GetTestWord()
        {
            String result = wordController.GetRandomWord(true);
            Assert.IsNotNull(result);
            Assert.True(result.Equals("tesst"));
        }

        [Test]
        public void GetRandomWord()
        {
            int loopCnt = 3;
            List<String> selectedWords = new();

            for (int i = 0; i < loopCnt; i++)
            {
                String result = wordController.GetRandomWord(false);
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Length > 0);
                selectedWords.Add(result);
            }

            bool wordsAllSame = selectedWords.TrueForAll(x => x.Equals(selectedWords[0]));

            Assert.IsFalse(wordsAllSame, "Expected at least one of the " + loopCnt + " words to be different. Answer were all: '" + selectedWords[0] + "'");
        }

    }
}