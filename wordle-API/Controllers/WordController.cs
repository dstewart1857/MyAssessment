using Microsoft.AspNetCore.Mvc;
using Wordle_API.DTO;
using Wordle_API.Service;
using Swashbuckle.AspNetCore.Annotations;

namespace Wordle_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordController : Controller
    {
        private WordService wordService = new();
        private static List<WordDTO> wordCollection = new();

        [Route("loadWords")]
        [HttpPost]
        [SwaggerOperation(Summary = "-- Adds word objects to a word collection.",
                        Description = "Builds a collection of word objects that can be retrieved using the 'getWords' endpoint.")]
        public void LoadWords()
        {
            List<WordDTO> words = wordService.GetWords();
            wordCollection.AddRange(words);
        }

        [Route("getWords")]
        [HttpGet]
        [SwaggerOperation(Summary = "-- Gets a list of word objects from a previously built word collection.",
                        Description = "Returns the list of word objects stored in the word collection.")]
        public List<WordDTO> GetWordCollection()
        {
            return wordCollection;
        }

        //[Route("getRandomWord")]
        [HttpGet(Name = "getRandomWord")]
        [SwaggerOperation(Summary = "-- Gets a random word from a previously built word collection.",
                        Description = "Returns a random word from objects stored in the word collection.")]
        public string GetRandomWord(bool test)
        {
            if(test == true)
            {
                return "tesst";
            }
            else if(wordCollection.Count == 0)
            {
                return "EMPTY";
            }

            Random r = new Random();
            int selection = r.Next(0, wordCollection.Count());
            return wordCollection[selection].Word;
        }

        [Route("deleteAllWords")]
        [HttpDelete]
        [SwaggerOperation(Summary = "-- Deletes all word objects in the current word collection.",
                        Description = "This will delete ALL words that exist in the current word collection.")]
        public void DeleteWordCollection()
        {
            wordCollection.Clear();
        }


    }
}
