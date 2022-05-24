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

        public WordController()
        {
            wordCollection.AddRange(wordService.GetWords());
        }

        [Route("getWords")]
        [HttpGet]
        [SwaggerOperation(Summary = "-- Gets a list of word objects from a previously built word collection.",
                        Description = "Returns the list of word objects stored in the word collection.")]
        public List<WordDTO> GetWordCollection()
        {
            return wordCollection;
        }

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

    }
}
