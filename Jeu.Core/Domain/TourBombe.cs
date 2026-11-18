using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Jeu.Core.Domain
{
    public class TourBombe : Tours
    {
        /// <summary>
        /// Constructeur de la classe TourBombe
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="image"></param>
        public TourBombe(int x, int y, String image) : base(image)
        {
            /// Initialisation des propriétés spécifiques à la TourBombe
            Y = y - Image.Height + 20;
            X = x - Image.Width / 2;
            Niveau = 1;
            PrixAmelioration = 100;
            PrixAchat = 70;
            OrDepense = PrixAchat;
            Porte = 200;
            VitesseAttaque = 30;
            type = "TourBombe";
        }
        /// <summary>
        ///  Améliore la tour en fonction de son niveau
        /// </summary>
        public override void Amelioration()
        {
            if (Niveau == 1)
            {
                Image = Image.FromFile("images\\TourBombe2.png");
                OrDepense = OrDepense + PrixAmelioration;
                PrixAmelioration = PrixAmelioration + 100;
                Porte = 250;
                Niveau++;
            }
            else if (Niveau == 2)
            {
                Image = Image.FromFile("images\\TourBombe3.png");
                OrDepense = OrDepense + PrixAmelioration;
                VitesseAttaque = 15;
                Niveau++;
            }
        }

    }
}
