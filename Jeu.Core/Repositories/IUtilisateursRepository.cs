using Jeu.Core.Domain;

namespace Jeu.Core.Repositories
{
    public interface IUtilisateursRepository
    {
        void Ajouter(Utilisateur user);
        bool Existe(int id);
        Utilisateur Obtenir(int id);
        List<Utilisateur> ObtenirTous();
        void Supprimer(int id);
    }
}