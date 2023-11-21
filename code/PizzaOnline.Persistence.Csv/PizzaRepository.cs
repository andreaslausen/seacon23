using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using PizzaOnline.Core.Domain.Interfaces;
using PizzaOnline.Core.Domain.Models;
using PizzaOnline.Persistence.Csv.DataModel;

namespace PizzaOnline.Persistence.Csv
{
    public class PizzaRepository : IPizzaRepository
    {
        private const string PizzaRepositoryPath = "C:\\temp\\pizzaOnline\\pizza.csv";
        private const string PizzaSorteRepositoryPath = "C:\\temp\\pizzaOnline\\pizzasorte.csv";
        private readonly PizzaDataModelMapper _pizzaDataModelMapper = new PizzaDataModelMapper();

        // ToDo: Wir halten fest: Repositories können mehrere Datenstrukturen zusammenfassend behandeln.
        // Die Zuordnung von einem Repo zu einer DB Tabelle ist nicht obligatorisch.
        // So weiter machen: Zwei CSV Dateien für Pizza und PizzaSorte erstellen

        public IEnumerable<Pizza> GetPizzen()
        {
            var pizzaSorten = Read<PizzaSorteMap, PizzaSorteModel>(PizzaSorteRepositoryPath);

            var pizzas = Read<PizzaMap, PizzaModel>(PizzaRepositoryPath);

            return ToPizzas(pizzas, pizzaSorten);
        }

        public Pizza GetPizza(Guid pizzaId)
        {
            throw new NotImplementedException();
        }

        private static TModel[] Read<TMap, TModel>(string path)
            where TMap : ClassMap
            where TModel : class
        {
            using (var fileStream = new FileStream(path, FileMode.Open))
            using (var streamReader = new StreamReader(fileStream))
            using (var csvReader = new CsvReader(streamReader))
            {
                csvReader.Configuration.RegisterClassMap<TMap>();
                csvReader.Configuration.HasHeaderRecord = false;

                return csvReader.GetRecords<TModel>().ToArray();
            }
        }

        private static void Add<TMap, TModel>(string path, TModel model)
            where TMap : ClassMap
            where TModel : class
        {
            using (var fileStream = new FileStream(path, FileMode.OpenOrCreate))
            using (var streamWriter = new StreamWriter(fileStream))
            using (var csvWriter = new CsvWriter(streamWriter))
            {
                csvWriter.Configuration.RegisterClassMap<PizzaMap>();

                //csvWriter.WriteHeader<TModel>();

                csvWriter.WriteRecord(model);
            }
        }

        private IEnumerable<Pizza> ToPizzas(IEnumerable<PizzaModel> pizzas, PizzaSorteModel[] pizzaSorten)
        {
            foreach (var pizzaModel in pizzas)
            {
                var sorte = pizzaSorten.Single(x => x.Nummer == pizzaModel.SorteNummer);

                yield return _pizzaDataModelMapper.ToPizza(pizzaModel, sorte);
            }
        }

        public void AddPizza(Pizza pizza)
        {
            var sorten = new PizzaSorteModel[0]; // Read<PizzaSorteMap, PizzaSorteModel>(PizzaSorteRepositoryPath);
            if (!sorten.Any(x => x.Nummer == pizza.Sort.Nummer))
            {
                Add<PizzaSorteMap, PizzaSorteModel>(PizzaSorteRepositoryPath, _pizzaDataModelMapper.ToPizzaSorteModel(pizza.Sort));
            }

            var model = _pizzaDataModelMapper.ToPizzaModel(pizza);

            Add<PizzaMap, PizzaModel>(PizzaRepositoryPath, model);
        }
    }
}