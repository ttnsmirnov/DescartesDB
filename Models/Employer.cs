using System;
using System.Collections.Generic;

namespace DescartesDB.Models
{
    public partial class Employer
    {
        public Employer()
        {
            Clients = new HashSet<Client>();
        }

        public decimal RefEmployer { get; set; }
        public string? Numero { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public DateTime? DateEmbouche { get; set; }
        public decimal? Salaire { get; set; }
        public string? Adresse { get; set; }
        public string? Password { get; set; }
        public string? TypeEmployer { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
