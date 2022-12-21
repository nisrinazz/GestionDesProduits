using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Devoir.Models
{
    public class Produit
    {
        private static int counter = 0;
        public int id { get; set; }
        public string nom { get; set; }
        public string type { get; set; }    
        public decimal prix { get; set; }
        public int qstock { get; set; }
        public DateTime dateAjout { get; set; }

        public Produit() {
            id = ++counter;
        }
        public Produit(string nom , string type , decimal prix , int qstock )
        {
            id = ++counter;
            this.nom = nom; 
            this.type = type;   
            this.prix = prix;
            this.qstock = qstock;
            dateAjout= DateTime.Now;
        }







    }
}