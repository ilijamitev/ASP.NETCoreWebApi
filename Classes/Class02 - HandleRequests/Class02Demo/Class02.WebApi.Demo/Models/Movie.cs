namespace Class02.WebApi.Demo.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Rating { get; set; }
        public Genre Genre { get; set; }
    }

    public enum Genre
    {
        Action = 1,
        Comedy,
        SciFi
    }
}
