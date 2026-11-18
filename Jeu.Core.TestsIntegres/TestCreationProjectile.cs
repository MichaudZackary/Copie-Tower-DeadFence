using Jeu.Core.Domain;
namespace Jeu.Core.TestsIntegres;

[TestClass]
public class TestCreationProjectile
{
    [TestMethod]
    public void TestMethod1()
    {
        // Scénario
        TourFeu tourFeu = new TourFeu(100, 100, "images\\TourFeu1.png");
        Enemie enemie = new Gobelin();
        enemie.X = 150;
        enemie.Y = 150;
        Projectile projectile;

        // Test
        if (tourFeu.PeuxAttaquer(enemie))
            projectile = new Projectile(tourFeu, "images\\BouleFeu.png");
        else
            projectile = null;

        // Post-Assertions
        Assert.IsNotNull(projectile);
        Assert.IsInstanceOfType(projectile, typeof(Projectile));
    }
}
