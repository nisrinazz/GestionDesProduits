using Devoir.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Devoir.Controllers
{ 
    public class UtilisateurController : Controller
    {
        public ActionResult SignUp() {
        Utilisateur user = new Utilisateur();
            return View(user);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SignUp(Utilisateur user)
        {
            if (ModelState.IsValid)
            {   
                user.nom = Request.Form["nom"];
                user.email = Request.Form["email"];
                user.login = Request.Form["login"];
                user.prenom = Request.Form["prenom"];
                user.mdp = Request.Form["mdp"];
                user.role = "CLIENT";
                Utilisateurs.utilisateurs.Add(user);
                return RedirectToAction("Login", "Utilisateur");    
            }
            return View();
        }
        public ActionResult Login()
        {
            Utilisateur user = new Utilisateur();

            return View(user);
        }

        [NonAction]
        public Utilisateur Exist(string login , string mdp)
        {  foreach(Utilisateur user in Utilisateurs.utilisateurs){
                if(user.login == login && user.mdp == mdp) { return user; }
            }
        return null;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Login(Utilisateur user) { 
        
            if(ModelState.IsValidField("login") && ModelState.IsValidField("mdp"))
            {   user.login = Request.Form["login"];
                user.mdp = Request.Form["mdp"];
               Utilisateur userConnecte = Exist(user.login, user.mdp);
                if (userConnecte != null && userConnecte.role=="CLIENT" )
                {
                    Session["user"] = userConnecte;
                    Session["role"] = userConnecte.role;
                    return RedirectToAction("ListeProduit", "Produit");

                }
                else if(userConnecte != null && userConnecte.role == "ADMIN") 
                {
                    Session["user"] = userConnecte;
                    Session["role"] = userConnecte.role;
                    return RedirectToAction("ListeProduit", "Produit");

                }
                else
                {
                    TempData["error"] = "mot de passe incorrecte";
                    return View();
                }
                

            }
            return View();

        }
        
        public ActionResult Logout()
        {
            Session["user"] = null;
            Session["role"] = null;
            return RedirectToAction("Login", "Utilisateur");
        }


    }
}