namespace AlkemyDisneyAPI.Models
{
    public class Film
    {
        public Film()
        {
            this.Characters = new HashSet<Character>();
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public float Rating { get; set; }
        // AGREGAR IMAGEN (ME OLVIDE)

        //Navigation Propertires
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
        public virtual ICollection<Character> Characters { get; set; }
    }
}
