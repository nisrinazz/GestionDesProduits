using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Devoir.Models
{
    public class Utilisateur
    {
        [Required(ErrorMessage = "Le champ est obligatoire")]
        public string nom { get; set; }
        [Required(ErrorMessage = "Le champ est obligatoire")]
        public string prenom { get; set; }
        [Required(ErrorMessage = "Le champ est obligatoire")]
        [EmailAddress]
        public string email { get; set; }
        [Required(ErrorMessage = "Le champ est obligatoire")]
        public string login { get; set; }
        [Required(ErrorMessage = "Le champ est obligatoire")]
        [Display(Name = "Mot de passe")]
        public string mdp { get; set; }

        [Display(Name = "Confirmer le mot de passe")]
        [Compare("mdp", ErrorMessage = "Veuillez entrer le meme mot de passe pour la confirmation")]
        public string mdp1 { get; set; }


        public string role { get; set; }

        public Utilisateur()
        {

        }
        public Utilisateur(string nom, string prenom,string email , string login , string mdp , string role)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.email = email;
            this.login = login;
            this.mdp = mdp;
            this.role = role;

        }
    }
}