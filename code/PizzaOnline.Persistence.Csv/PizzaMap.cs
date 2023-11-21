using CsvHelper.Configuration;
using PizzaOnline.Persistence.Csv.DataModel;

namespace PizzaOnline.Persistence.Csv
{
    public sealed class PizzaMap : ClassMap<PizzaModel>
    {
        public PizzaMap()
        {
            Map(x => x.Groesse);
            Map(x => x.Preis);
            Map(x => x.SorteNummer);
        }
    }
}