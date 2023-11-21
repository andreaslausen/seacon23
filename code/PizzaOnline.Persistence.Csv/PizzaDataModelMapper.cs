using PizzaOnline.Core.Domain.Models;
using PizzaOnline.Persistence.Csv.DataModel;

namespace PizzaOnline.Persistence.Csv
{
    public class PizzaDataModelMapper
    {
        public Pizza ToPizza(PizzaModel pizzaModel, PizzaSorteModel sorte)
        {
            return new Pizza((PizzaSize)pizzaModel.Groesse, pizzaModel.Preis, ToSorte(sorte));
        }

        private PizzaSort ToSorte(PizzaSorteModel sorte)
        {
            return new PizzaSort(new byte[0], sorte.Nummer, sorte.Bezeichnung);
        }

        public PizzaSorteModel ToPizzaSorteModel(PizzaSort pizzaSort)
        {
            return new PizzaSorteModel
            {
                Bezeichnung = pizzaSort.Bezeichnung,
                //Bild = pizzaSorte.Bild,
                Nummer = pizzaSort.Nummer
            };
        }

        public PizzaModel ToPizzaModel(Pizza pizza)
        {
            return new PizzaModel
            {
                Groesse = (int)pizza.Size,
                Preis = pizza.Price,
                SorteNummer = pizza.Sort.Nummer
            };
        }
    }
}