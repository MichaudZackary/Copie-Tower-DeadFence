using Jeu.Core.Domain;
using Jeu.Core.Repositories;
using System.Security.Cryptography.X509Certificates;

namespace Jeu.Core.TestsIntegres;

[TestClass]
public class Test_TourRepository
{
    [TestMethod]
    public void TestMethod1()
    {
        // Scénario
        Tours tourFeu = new TourFeu(100, 100, "images\\TourFeu1.png");
        Tours tourMagie = new TourMagie(200, 200, "images\\TourMagie1.png");
        Tours tourBombe = new TourBombe(300, 300, "images\\TourBombe1.png");
        IToursRepository toursRepository = new ToursRepository();
        // Ajouter les tours
        toursRepository.Ajouter(tourFeu, 1);
        toursRepository.Ajouter(tourMagie, 1);
        toursRepository.Ajouter(tourBombe, 1);
        // Vérifier l'existence des tours
        Assert.IsTrue(toursRepository.Existe(tourFeu.Id));
        Assert.IsTrue(toursRepository.Existe(tourMagie.Id));
        Assert.IsTrue(toursRepository.Existe(tourBombe.Id));
        // Obtenir et vérifier les tours
        Tours obtenuTourFeu = toursRepository.Obtenir(tourFeu.Id);
        Tours obtenuTourMagie = toursRepository.Obtenir(tourMagie.Id);
        Tours obtenuTourBombe = toursRepository.Obtenir(tourBombe.Id);
        Assert.AreEqual(tourFeu.Id, obtenuTourFeu.Id);
        Assert.AreEqual(tourMagie.Id, obtenuTourMagie.Id);
        Assert.AreEqual(tourBombe.Id, obtenuTourBombe.Id);
        // Supprimer les tours
        toursRepository.Supprimer(tourFeu.Id);
        toursRepository.Supprimer(tourMagie.Id);
        toursRepository.Supprimer(tourBombe.Id);
        // Vérifier la suppression des tours
        Assert.IsFalse(toursRepository.Existe(tourFeu.Id));
        Assert.IsFalse(toursRepository.Existe(tourMagie.Id));
        Assert.IsFalse(toursRepository.Existe(tourBombe.Id));
    }
}
