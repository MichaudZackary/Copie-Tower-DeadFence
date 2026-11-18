using Jeu.Core.Domain;

namespace Jeu.Core.Repositories
{
    public interface ISauvegardeRepository
    {
        void AjouterSauvegarde(Sauvegarde save);
        bool ExisteSauvegarde(int id);
        Sauvegarde? ObtenirSauvegardeParId(int id);
        List<Sauvegarde> ObtenirToutesLesSauvegardes();
        void SupprimerSauvegarde(int id);
    }
}