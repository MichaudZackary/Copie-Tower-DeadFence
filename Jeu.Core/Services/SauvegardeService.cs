using Jeu.Core.Domain;
using Jeu.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu.Core.Services
{
    public class SauvegardeService : ISauvegardeService
    {
        // Dépôt de sauvegarde
        protected ISauvegardeRepository SauvegardeService1 { get; }

        public SauvegardeService(ISauvegardeRepository sauvegardeRepository)
        {
            // Initialisation du service avec le dépôt de sauvegarde
            SauvegardeService1 = sauvegardeRepository;
        }

        public Sauvegarde Obtenir(int id)
        {
            // Implémentation pour obtenir une sauvegarde par ID
            return SauvegardeService1.ObtenirSauvegardeParId(id);
        }

        public List<Sauvegarde> ObtenirTous()
        {
            // Implémentation pour obtenir toutes les sauvegardes
            return SauvegardeService1.ObtenirToutesLesSauvegardes();
        }

        public void Ajouter(Sauvegarde save)
        {
            // Implémentation d'ajout
            SauvegardeService1.AjouterSauvegarde(save);
        }

        public void Supprimer(int id)
        {
            // Implémentation de suppression
            SauvegardeService1.SupprimerSauvegarde(id);
        }
        public bool Existe(int id)
        {
            // Vérifie si une sauvegarde existe par ID
            return SauvegardeService1.ExisteSauvegarde(id);
        }

        // Méthode asynchrone ajoutée (wrapper autour de la méthode synchrone existante).
        // Retourne IEnumerable<object> pour rester compatible avec l'usage actuel du composant Blazor
        public Task<IEnumerable<object>> GetAllAsync()
        {
            var list = ObtenirTous() ?? new List<Sauvegarde>();
            var objects = list.Cast<object>().ToList();
            return Task.FromResult<IEnumerable<object>>(objects);
        }
    }
}
