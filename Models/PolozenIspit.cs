namespace DrugiPutKlk.Models
{
    public class PolozenIspit
    {
        public Student Student { get; set; } = null!;
        public Predmet Predmet { get; set; } = null!;

        public int Grade { get; set; }

    }
}
