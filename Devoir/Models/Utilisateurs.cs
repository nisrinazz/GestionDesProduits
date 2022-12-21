using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Devoir.Models
{
    public class Utilisateurs : IEnumerable<Utilisateur>
    {
        public static List<Utilisateur> utilisateurs = new List<Utilisateur>()
        {
            new Utilisateur("admin", "admin", "admin@gmail.com", "admin", "admin123", "ADMIN") ,
             new Utilisateur("utilisateur", "utilisateur", "utilisateur@gmail.com", "utilisateur", "user123", "CLIENT")
    };

        public IEnumerator<Utilisateur> GetEnumerator()
        {
            return (IEnumerator<Utilisateur>)utilisateurs;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();

        }

    }

}