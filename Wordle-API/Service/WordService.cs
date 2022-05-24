﻿using Wordle_API.DTO;
using Newtonsoft.Json;

namespace Wordle_API.Service
{
    public class WordService
    {
        public List<WordDTO> GetWords()
        {
            List<WordDTO> words = new();
            String path = "..\\Wordle-API\\WordList.json";

            String location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            if (location.Contains("Debug"))
            {
                path = "..\\..\\..\\..\\Wordle-API\\WordList.json";
            }

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                if (json != null)
                {
#pragma warning disable CS8600 // Possible null reference assignment.
                    words = JsonConvert.DeserializeObject<List<WordDTO>>(json);
#pragma warning restore CS8600 // Possible null reference assignment.
                    if (words == null)
                    {
                        words = new List<WordDTO>();
                        words.Add(new WordDTO(0, "No words found!"));
                    }
                }
                else
                {
                    words.Add(new WordDTO(0,"ERROR"));
                }
            }
            return words;
        }

    }
}
