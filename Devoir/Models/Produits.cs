using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Devoir.Models
{
    public class Produits : IEnumerable<Produit>
    {
        public static List<Produit> produits = new List<Produit>()
       {
            new Produit("brosse","cheuveux" , 100 , 50) ,
            new Produit("trico","vetement" , 200 , 400)
    };
    public IEnumerator<Produit> GetEnumerator()
        {
            return (IEnumerator<Produit>)produits;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}