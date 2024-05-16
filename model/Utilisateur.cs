using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InpollAdmin.model
{

    public class Utilisateur
    {
        public string? _Id { get; set; }
        public string? Prenom { get; set; }
        public string? Nom { get; set; }
        public string? Email { get; set; }
        public string? Profil { get; set; }
        public string? Liste { get; set; }
        public string? RestoreCode { get; set; }
        public string? Connected { get; set; }


        public Utilisateur(string _id, string nom, string prenom, string email, string connected)
        {
            this._Id = _id;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Email = email;
            this.Connected = connected;
        }

        



    }


}
