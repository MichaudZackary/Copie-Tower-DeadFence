using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Jeu.Core.Domain
{
    public class TourFeu : Tours
    {
        /// <summary>
        /// Constructeur de la classe TourFeu
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="image"></param>
        public TourFeu(int x, int y, String image) : base(image)
        {
            Y = y - Image.Height + 20;
            X = x - Image.Width / 2;
            Niveau = 1;
            PrixAmelioration = 50;
            PrixAchat = 20;
            OrDepense = PrixAchat;
            Porte = 200;
            VitesseAttaque = 10;
            type = "TourFeu";
        }
        /// <summary>
        ///  Améliore la tour en fonction de son niveau
        /// </summary>
        public override void Amelioration()
        {
            if (Niveau == 1)
            {
                OrDepense = OrDepense + PrixAmelioration;
                PrixAmelioration = PrixAmelioration + 150;
                Image = Image.FromFile("images\\TourFeu2.png");
                VitesseAttaque = 5;
                Niveau++;
            }
            else if (Niveau == 2)
            {
                Image = Image.FromFile("images\\TourFeu3.png");
                OrDepense = OrDepense + PrixAmelioration;
                Porte = 250;
                VitesseAttaque = 2;
                Niveau++;
            }
            
        }

    }
}
