namespace PizzaOnline.Persistence.Csv.DataModel
{
    // TODO sollten diese Klassen Dto, Record, Model oder einfach Pizza heißen
    public class PizzaModel
    {
        public int Groesse { get; set; }
        public decimal Preis { get; set; }
        public int SorteNummer { get; set; }
    }
}