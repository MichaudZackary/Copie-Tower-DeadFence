using Jeu.Core.Domain;

namespace Jeu.Core.TestsIntegres;

[TestClass]
public class TestDeplacementEnemie
{
    [TestMethod]
    public void TestEnemieDeplacer()
    {
        // Scénario
        Enemie enemie = new Gobelin();
        int positionXInitiale = enemie.X;
        int positionYInitiale = enemie.Y;
        int positionXFinale;
        int positionYFinale;

        // Test
        enemie.Deplacer();
        positionXFinale = enemie.X;
        positionYFinale = enemie.Y;

        // Post-Assertions
        Assert.AreNotEqual(positionXInitiale, positionXFinale);
        Assert.AreEqual(positionYInitiale, positionYFinale);
    }
}
