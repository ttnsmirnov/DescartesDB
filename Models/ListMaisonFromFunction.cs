namespace DescartesDB.Models;

public record ListMaisonFromFunction
{
 
        public decimal RefClients { get; set; }
        public string? Nom_Client { get; set; }
        public string? Nom { get; set; }
        public string? email { get; set; }
        public decimal? Prix { get; set; }
        public string? TypeMaison { get; set; }
       
}