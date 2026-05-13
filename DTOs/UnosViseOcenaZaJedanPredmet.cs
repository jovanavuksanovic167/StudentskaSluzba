namespace DrugiPutKlk.DTOs
{
    public class UnosViseOcenaZaJedanPredmet
    {

        public string Sifra { get; set; } = string.Empty;

        public List<UnosOceneDTO> studeniSaOcenama { get; set; } = new();

    }
}
