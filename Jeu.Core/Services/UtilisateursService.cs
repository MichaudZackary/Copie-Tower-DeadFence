using Jeu.Core.Domain;
using Jeu.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu.Core.Services
{
    /// <summary>
    /// Service pour gérer les utilisateurs. 
    /// </summary>
    public class UtilisateursService : IUtilisateursService
    {
        protected IUtilisateursRepository UtilisateursRepository { get; }

        public UtilisateursService(IUtilisateursRepository utilisateursRepository)
        {
            UtilisateursRepository = utilisateursRepository;
        }
        public void Ajouter(Utilisateur user)
        {
            UtilisateursRepository.Ajouter(user);
        }

        public Utilisateur Obtenir(int id)
        {
            return UtilisateursRepository.Obtenir(id);
        }
        public bool Existe(int id)
        {
            return UtilisateursRepository.Existe(id);
        }

        public void Supprimer(int id)
        {
            UtilisateursRepository.Supprimer(id);
        }

        public List<Utilisateur> ObtenirTous()
        {
            return UtilisateursRepository.ObtenirTous();
        }
    }
}
