namespace DescartesDB.Models
{
    public record MaisonVM
    {
        public List<string> TypesMaisons { get; set; }
        public IEnumerable<ListMaisonFromFunction> listMaison { get; set; }       
    }
}
