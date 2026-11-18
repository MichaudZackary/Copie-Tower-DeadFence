using Jeu.Core.Domain;

namespace Jeu.Core.Services
{
    public interface IToursService
    {
        void Ajouter(Tours tours, int save);
        bool Existe(int id);
        Tours Obtenir(int id);
        List<Tours> ObtenirTous(int id);
        void Supprimer(int id);
    }
}