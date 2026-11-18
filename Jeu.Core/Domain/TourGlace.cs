using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Jeu.Core.Domain
{
    public class TourGlace : Tours
    {
        /// <summary>
        /// Constructeur de la classe TourGlace
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="image"></param>
        public TourGlace(int x, int y, String image) : base(image)
        {
            /// Initialisation des propriétés spécifiques à la TourGlace
            Y = y - Image.Height + 20;
            X = x - Image.Width / 2;
            Niveau = 1;
            PrixAmelioration = 50;
            PrixAchat = 30;
            OrDepense = PrixAchat;
            Porte = 200;
            VitesseAttaque = 15;
            type = "TourGlace";
        }
        /// <summary>
        ///  Améliore la tour en fonction de son niveau
        /// </summary>
        public override void Amelioration()
        {
            if (Niveau == 1)
            {
                Image = Image.FromFile("images\\TourGlace2.png");
                OrDepense = OrDepense + PrixAmelioration;
                PrixAmelioration = PrixAmelioration + 50;
                Porte = 300;
                Niveau++;
            }
            else if (Niveau == 2)
            { 
                Image = Image.FromFile("images\\TourGlace3.png");
                OrDepense = OrDepense + PrixAmelioration;
                Porte = 400;
                VitesseAttaque = 8;
                Niveau++;
            }
        }

    }
}
