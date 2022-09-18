using System.ComponentModel.DataAnnotations;

namespace AlkemyDisneyAPI.DTO
{
    public class PostFilmDTO
    {
        [Required]
        [StringLength(64)]
        public string Title { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [Range(1,5)]
        public float Rating { get; set; }
        [Required]
        public int GenreId { get; set; }
    }

    public class PutFilmDTO
    {
        [StringLength(64)]
        public string Title { get; set; }
        public DateTime Date { get; set; }
        [Range(1, 5)]
        public float Rating { get; set; }
        public int GenreId { get; set; }
    }

    public class GetFilmDTO
    {
        public string? name { get; set; }
        public int? idGenero { get; set; }
        public string? order { get; set; }
    }

    public class GetFilmResponse
    {
        public string Title { get; set;}
        public DateTime Date { get; set; }
    }
}
