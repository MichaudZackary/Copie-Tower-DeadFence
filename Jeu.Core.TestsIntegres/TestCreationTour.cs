using Jeu.Core.Domain;

namespace Jeu.Core.TestsIntegres;

[TestClass]
public class TestTour
{
    [TestMethod]
    public void TestAmelioration()
    {
        // Scénario
        Tours tourFeu; 
        
        // Test
        tourFeu = new TourFeu(100, 100, "images\\TourFeu2.png");

        // Post-Assertions
        Assert.IsInstanceOfType(tourFeu, typeof(Tours));
    }   
}
       