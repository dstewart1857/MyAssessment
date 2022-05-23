using System;
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
//        public void SubmitTests([FromBody] List<WordDTO> newTests)
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

        [Route("getRandomWord")]
        [HttpGet]
        [SwaggerOperation(Summary = "-- Gets a random word from a previously built word collection.",
                        Description = "Returns a random word from objects stored in the word collection.")]
        public string GetRandomWord()
        {
            int size = wordCollection.Count();

            return wordCollection[0].Word;
        }

        [Route("deleteAllWords")]
        [HttpDelete]
        [SwaggerOperation(Summary = "-- Deletes all word objects in the current word collection.",
                        Description = "This will delete ALL words that exist in the current word collection.")]
        public void DeleteWordCollection()
        {
            wordCollection.Clear();
        }
/*
        [Route("sortedGrades")]
        [HttpGet]
        [SwaggerOperation(Summary = "-- Returns a list of sorted tests by student name or grade. The tests are first graded and then sorted.",
                        Description = "The sort parameter will determine which sort method is used. A value of 0 will sort by student name in ascending order (A..Z). A value of 1 will sort by grade in ascending order (A,B,C,D,F).")]
        public ActionResult<List<ReportCardDTO>> SortedGrades(int sortMethod)
        {
            List<ReportCardDTO> reportCardCollection = new();

            foreach (TestDTO testDTO in testCollection)
            {
                ReportCardDTO reportCardDTO = reportCardService.GradeTest(testDTO);
                reportCardCollection.Add(reportCardDTO);
            }

            // Sort reportCardCollection: 0 = sort by student name, 1 = sort by grade
            List<ReportCardDTO> sortedReportCards = new();
            if (sortMethod == 0)
            {
                // Sort by student name in ascending order(A..Z)
                sortedReportCards = reportCardCollection.OrderBy(o => o.StudentName).ToList();
            }
            else if (sortMethod == 1)
            {
                // Sort by grade in ascending order (A,B,C,D,F)
                sortedReportCards = reportCardCollection.OrderBy(o => o.Grade).ToList();
            }
            else
            {
                return BadRequest("The provided sort method '" + sortMethod + "' is not supported!  Please select one of the available sort methods:\n0 = sort by name (ascending)\n1 = sort by grade (ascending)");
            }

            return Ok(sortedReportCards);
        }
*/
    }
}
