using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Jeu.Core.Domain
{
    public class TourMagie : Tours
    {
        /// <summary>
        /// Constructeur de la classe TourMagie
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="image"></param>
        public TourMagie(int x, int y, String image) : base(image)
        {
            /// Initialisation des propri�t�s sp�cifiques � la TourMagie
            Y = y - Image.Height + 20;
            X = x - Image.Width / 2;
            Niveau = 1;
            PrixAmelioration = 60;
            PrixAchat = 40;
            OrDepense = PrixAchat;
            Porte = 200;
            VitesseAttaque = 15;
            type = "TourMagie";
        }
        /// <summary>
        ///  Am�liore la tour en fonction de son niveau
        /// </summary>
        public override void Amelioration()
        {
            if (Niveau == 1)
            {
                Image = Image.FromFile("images\\TourMagie2.png");
                OrDepense = OrDepense + PrixAmelioration;
                PrixAmelioration = PrixAmelioration + 60;
                Porte = 300;
                Niveau++;
            }
            else if (Niveau == 2)
            {
                Image = Image.FromFile("images\\TourMagie3.png");
                OrDepense = OrDepense + PrixAmelioration;
                VitesseAttaque = 10;
                Niveau++;
            }
            
        }

    }
}
