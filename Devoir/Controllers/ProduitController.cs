using Devoir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Devoir.Controllers
{
    public class ProduitController : Controller
    {
        // GET: Produit
        public ActionResult AjouterProduit()
        {
            Produit produit = new Produit();

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AjouterProduit(Produit p)
        {
            if (ModelState.IsValid)
            {
                p.nom = Request.Form["nom"];
                p.type = Request.Form["type"];
                p.prix = Convert.ToDecimal(Request.Form["prix"]);
                p.qstock = Convert.ToInt32(Request.Form["qstock"]);
                p.dateAjout = Convert.ToDateTime(Request.Form["dateAjout"]);
                Produits.produits.Add(p);
                return RedirectToAction("ListeProduit", "Produit");
                ViewData["message"] = "Ajouté avec succès !";
            }
            return View();
        }

        public ActionResult ListeProduit()
        {

            return View(Produits.produits);
        }

        public ActionResult Supprimer(int id)
        {   foreach(Produit p in Produits.produits)
            {
                if (p.id == id)
                {
                    Produits.produits.Remove(p);
                    break;
                }
            }

            return RedirectToAction("ListeProduit" , "Produit");
        }

        public ActionResult Modifier(int id)
        {
            foreach(Produit p in Produits.produits)
            {
                if(p.id == id)
                {
                    TempData["pos"] = Produits.produits.IndexOf(p);
                    return View(p);
                }
            }
          return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Modifier(Produit p)
        {   if (ModelState.IsValid)
            {
                p.nom = Request.Form["nom"];
                p.prix = Convert.ToDecimal(Request.Form["prix"]);
                p.type = Request.Form["type"];
                p.qstock = Convert.ToInt32(Request.Form["qstock"]);
                p.dateAjout = Convert.ToDateTime(Request.Form["dateAjout"]);
                Produits.produits[Convert.ToInt32(TempData["pos"])] = p;
                return RedirectToAction("ListeProduit", "Produit");
            }
            return View();
        }

        public ActionResult Detail(int id)
        {
            foreach (Produit p in Produits.produits)
            {
                if (p.id == id)
                {
                    return View(p);
                }
               
            }
 return HttpNotFound();
        }

        [HttpPost]

        public ActionResult Detail(Produit p )
        {
            return View();
        }
          
    
          public ActionResult Chercher()
             {
            return View();}
        [HttpPost]
        public ActionResult Chercher (String id)
        {
            id = Request.Form["q"];
            if (!String.IsNullOrEmpty(id))
                return RedirectToAction("Detail", "Produit", new { id = Convert.ToInt32(id) });
            else return View();
        }

        }

    

}

