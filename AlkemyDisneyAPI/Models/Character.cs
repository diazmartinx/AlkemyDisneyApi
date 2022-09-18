namespace AlkemyDisneyAPI.Models
{
    public class Character
    {
        public Character()
        {
            this.Films = new HashSet<Film>();
        }

        public int ID { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }
        public string History { get; set; }
        public virtual ICollection<Film> Films { get; set; }
    }
}
