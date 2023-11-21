using CsvHelper.Configuration;
using PizzaOnline.Persistence.Csv.DataModel;

namespace PizzaOnline.Persistence.Csv
{
    public sealed class PizzaSorteMap : ClassMap<PizzaSorteModel>
    {
        public PizzaSorteMap()
        {
            Map(x => x.Nummer);
            Map(x => x.Bezeichnung);
            //Map(x => x.Bild).TypeConverter<ByteArrayConverter>();
        }
    }
}