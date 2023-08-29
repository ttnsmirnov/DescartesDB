using System;
using System.Collections.Generic;

namespace DescartesDB.Models
{
    public partial class Maison
    {
        public decimal RefMaison { get; set; }
        public string? NumeroPieces { get; set; }
        public string? TypeMaison { get; set; }
        public string? DateConstruction { get; set; }
        public decimal? Prix { get; set; }
        public string? Statut { get; set; }
        public string? Adresse { get; set; }
        public string? Description { get; set; }
        public decimal? RefCleint { get; set; }

        public virtual Client? RefCleintNavigation { get; set; }

		internal static object FromSqlRaw(string v)
		{
			throw new NotImplementedException();
		}
	}
}
