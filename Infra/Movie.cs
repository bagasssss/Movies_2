using System.ComponentModel.DataAnnotations;

namespace Movies.Infra
{
    public class Movie
    {
        [Key]
        public string title { get; set; }
        public int year { get; set; }
        public string category { get; set; }
        public string directorName { get; set; }
    }
}