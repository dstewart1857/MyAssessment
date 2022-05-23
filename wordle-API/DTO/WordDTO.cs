namespace Wordle_API.DTO
{
    public class WordDTO
    {
        public WordDTO(int id, string word)
        {
            Id = id;
            Word = word;
        }

        public String Word { get; set; }
        public int Id { get; set; }
    }
}