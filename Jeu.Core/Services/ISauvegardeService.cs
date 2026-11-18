using System.Collections.Generic;
using System.Threading.Tasks;
using Jeu.Core.Domain;

namespace Jeu.Core.Services
{
    public interface ISauvegardeService
    {
        void Ajouter(Sauvegarde save);
        bool Existe(int id);
        Sauvegarde Obtenir(int id);
        List<Sauvegarde> ObtenirTous();
        void Supprimer(int id);

        // Méthode asynchrone ajoutée sans supprimer les anciennes signatures
        Task<IEnumerable<object>> GetAllAsync();
    }
}