namespace PizzaOnline.Core.Domain.Models
{
    public class PizzaSort
    {
        public byte[] Bild { get; }
        public int Nummer { get; }
        public string Bezeichnung { get; }

        public PizzaSort(byte[] bild, int nummer, string bezeichnung)
        {
            Bild = bild;
            Nummer = nummer;
            Bezeichnung = bezeichnung;
        }
    }
}