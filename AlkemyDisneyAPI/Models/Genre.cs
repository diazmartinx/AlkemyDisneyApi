namespace AlkemyDisneyAPI.Models
{
    public class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        //Navigation Properties
        public List<Film> Films { get; set; }
    }
}
