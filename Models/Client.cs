using System;
using System.Collections.Generic;

namespace DescartesDB.Models
{
    public partial class Client
    {
        public Client()
        {
            Maisons = new HashSet<Maison>();
        }

        public decimal RefClients { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Password { get; set; }
        public string? Adresse { get; set; }
        public decimal? RefEmployer { get; set; }
        public string? TypeCleint { get; set; }
        public string? Email { get; set; }

        public virtual Employer? RefEmployerNavigation { get; set; }
        public virtual ICollection<Maison> Maisons { get; set; }
    }
}
