using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Jeu.Core.Domain
{
    public class TourElec : Tours
    {
        /// <summary>
        /// Constructeur de la classe TourElec
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="image"></param>
        public TourElec(int x, int y, String image) : base(image)
        {
            /// Initialisation des propriétés spécifiques à la TourElec
            Y = y - Image.Height + 20;
            X = x - Image.Width / 2;
            Niveau = 1;
            PrixAmelioration = 75;
            PrixAchat = 50;
            OrDepense = PrixAchat;
            Porte = 300;
            VitesseAttaque = 10;
            type = "TourElec";
        }
        /// <summary>
        ///  Améliore la tour en fonction de son niveau
        /// </summary>
        public override void Amelioration()
        {
            if (Niveau == 1)
            {
                Image = Image.FromFile("images\\TourElec2.png");
                OrDepense = OrDepense + PrixAmelioration;
                PrixAmelioration = PrixAmelioration + 75;
                Porte = 400;
                Niveau++;
            }
            else if (Niveau == 2)
            {
                Image = Image.FromFile("images\\TourElec3.png");
                OrDepense = OrDepense + PrixAmelioration;
                VitesseAttaque = 5;
                Niveau++;
            }
        }

    }
}
