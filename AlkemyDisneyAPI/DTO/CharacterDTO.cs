using System.ComponentModel.DataAnnotations;

namespace AlkemyDisneyAPI.DTO
{
    public class PostCharacterDTO
    {
        [Required]
        public string Image { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public float Weight { get; set; }
        [Required]
        public string History { get; set; }
        public virtual List<int> FilmsIDs { get; set; }
    }

    public class PutCharacterDTO
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }
        public string History { get; set; }
        public virtual List<int> FilmsIDs { get; set; }
    }

    public class GetCharacterDTO
    {
        public string? name { get; set; }
        public int? age { get; set; }
        public int? movies { get; set; }
    }
}
