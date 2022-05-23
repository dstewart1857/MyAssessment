using Wordle_API.DTO;
using Newtonsoft.Json;

//[assembly: InternalsVisibleTo("TestCoreAPITests")]
namespace Wordle_API.Service
{
    public class WordService
    {
//        public List<WordDTO> words = new List<WordDTO>();

        public List<WordDTO> GetWords()
        {
            List<WordDTO> words = new();

            using (StreamReader r = new StreamReader("..\\Wordle-API\\words.json"))
            {
                string json = r.ReadToEnd();
                if (json != null)
                {
#pragma warning disable CS8600 // Possible null reference assignment.
                    words = JsonConvert.DeserializeObject<List<WordDTO>>(json);
                    if(words == null)
                    {
                        words = new List<WordDTO>();
                        words.Add(new WordDTO(0, "No words found!"));
                    }
#pragma warning restore CS8600 // Possible null reference assignment.
                }
                else
                {
                    words.Add(new WordDTO(0,"No words found!"));
                }
            }
            return words;
        }



/*
        public ReportCardDTO GradeTest(TestDTO testDTO)
        {
            ReportCardDTO reportCardDTO = new();

            reportCardDTO.StudentName = testDTO.studentName;
            reportCardDTO.ClassName = testDTO.className;
            reportCardDTO.Grade = GetGrade(testDTO.score);

            return reportCardDTO;
        }

        internal string GetGrade(int score)
        {
            String grade;

            switch (score)
            {
                case >= 90 and <= 100:
                    {
                        grade = "A";
                        break;
                    }
                case >= 80 and < 90:
                    {
                        grade = "B";
                        break;
                    }
                case >= 70 and < 80:
                    {
                        grade = "C";
                        break;
                    }
                case >= 60 and < 70:
                    {
                        grade = "D";
                        break;
                    }
                case >= 0 and < 60:
                    {
                        grade = "F";
                        break;
                    }
                default:
                    {
                        grade = "U";
                        break;
                    }
            }
            return grade;

        }
*/

    }
}
