using Jeu.Core.Domain;
namespace Jeu.Core.TestsIntegres;

[TestClass]
public class TestDeplacementProjectile
{
    [TestMethod]
    public void TestDeplacerProjectile()
    {
        // Scénario
        TourFeu tourFeu = new TourFeu(100, 100, "images\\TourFeu1.png");
        Enemie enemie = new Enemie("images\\Chevalier2.png");
        enemie.X = 200;
        enemie.Y = 200;
        Projectile projectile = new Projectile(tourFeu, "images\\BouleFeu.png");
        projectile.ChoisirdirectionFutur(enemie);
        int positionXInitiale = projectile.X;
        int positionYInitiale = projectile.Y;
        int positionXFinale;
        int positionYFinale;

        // Test
        projectile.Deplacer();
        positionXFinale = projectile.X;
        positionYFinale = projectile.Y;
        
        // Post-Assertions
        Assert.AreNotEqual(positionXInitiale, positionXFinale);
        Assert.AreNotEqual(positionYInitiale, positionYFinale);
    }
}
