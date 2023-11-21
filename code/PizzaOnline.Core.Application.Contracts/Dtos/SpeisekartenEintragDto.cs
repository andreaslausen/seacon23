namespace PizzaOnline.Core.Application.Contracts.Dtos
{
    public struct SpeisekartenEintragDto
    {
        public int Nummer { get; set; }
        public string Bezeichnung { get; set; }
        public PizzaPriceDto[] Preise { get; set; }
    }
}