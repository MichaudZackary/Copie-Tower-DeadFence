using Jeu.Core.Domain;

namespace Jeu.Core.TestsIntegres;

[TestClass]
public class TestApparitionEnemie
{
    [TestMethod]
    public void TestApparitionEnemieMultiple()
    {
        // Scénario
        Enemie EnemieChevalier;
        Enemie EnemieGobelin;
        Enemie EnemieSkelette;
        Enemie EnemieGoab;

        // Test
        EnemieChevalier = new Chevalier();
        EnemieGobelin = new Gobelin();
        EnemieSkelette = new Skelette();
        EnemieGoab = new Goab();

        // Post-Assertions
        Assert.IsInstanceOfType(EnemieChevalier, typeof(Chevalier));
        Assert.IsInstanceOfType(EnemieGobelin, typeof(Gobelin));
        Assert.IsInstanceOfType(EnemieSkelette, typeof(Skelette));
        Assert.IsInstanceOfType(EnemieGoab, typeof(Goab));

    }
}
