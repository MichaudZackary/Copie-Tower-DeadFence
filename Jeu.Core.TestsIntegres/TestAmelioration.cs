using Jeu.Core.Domain;

namespace Jeu.Core.TestsIntegres
{
    [TestClass]
    public sealed class TestAmelioration
    {
        [TestMethod]
        public void TestAmeliorationTours()
        {
            // Scénario
            Tours tourFeu = new TourFeu(100, 100, "images\\TourFeu1.png");
            Tours tourMagie = new TourMagie(200, 200, "images\\TourMagie1.png");
            Tours tourBombe = new TourBombe(300, 300, "images\\TourBombe1.png");

            // Test
            tourFeu.Amelioration();
            tourMagie.Amelioration();
            tourMagie.Amelioration(); // Amélioration supplémentaire pour vérifier que l'amélioration au niveau deux est bien fait
            tourBombe.Amelioration();
            tourBombe.Amelioration(); 
            tourBombe.Amelioration(); // Amélioration supplémentaire pour vérifier que l'amélioration ne fonctionne pas, car il est deja niveau max

            // Post-Assertions
            Assert.AreEqual(2, tourFeu.Niveau);
            Assert.AreEqual(3, tourMagie.Niveau);
            Assert.AreEqual(3, tourBombe.Niveau);



        }
    }
}
