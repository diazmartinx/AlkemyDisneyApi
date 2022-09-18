using System.ComponentModel.DataAnnotations;

namespace AlkemyDisneyAPI.DTO
{
    public class PostGenreDTO
    {
        [Required]
        [StringLength(64)]
        public string Name { get; set; }
        [Required]
        [Url]
        public string Image { get; set; }
    }
}
