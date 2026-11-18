using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Jeu.Core.Domain
{
    /// <summary>
    /// enemie qui suit un chemin prédéfini
    /// /// </summary>
    public class Enemie : ObjetsMobiles
    {
        /// <summary>
        /// PV de l'enemie
        /// </summary>
        public int NombreVies { get; set; }
        /// <summary>
        /// compteur pour le ralentissement
        /// </summary>
        private int Compteur { get; set; }
        /// <summary>
        /// Bool indiquant si l'enemie est ralenti
        /// </summary>
        public bool ralentie { get; protected set; }
        /// <summary>
        /// compteur pour la durée du ralentissement
        /// </summary>
        public int compteurRalentie { get; protected set; }
        /// <summary>
        /// etape du chemin actuel de l'enemie
        /// </summary>
        protected int etape { get; private set; }
        /// <summary>
        /// score donné à la mort de l'enemie
        /// </summary>
        public int score { get; protected set; }

        /// <summary>
        /// constructeur de la classe Enemie
        /// </summary>
        /// <param name="image"></param>
        public Enemie(string image) : base(image)
        {
            X = 0;
            Y = 490;
            ralentie = false;
            compteurRalentie = 0;
            Largeur = 35;
            Hauteur = 35;
            Vitesse = 2;
            NombreVies = 2;
            etape = 0;
        }

        /// <summary>
        /// Déplace l'objet le long d'un trajet prédéfini en plusieurs segments
        /// </summary>
        public override void Deplacer()
        {
            if (Direction == Direction.Droite && X >= 960 && Y == 490 && etape == 0)
            {
                Direction = Direction.Haut;
                etape++;
                X = 960;
                
            }
            if (Direction == Direction.Haut && X == 960 && Y <= 200 && etape == 1)
            {
                Direction = Direction.Gauche;
                etape++;
                Y = 200;
            }
            if (Direction == Direction.Gauche && X <= 630 && Y == 200 && etape == 2)
            {
                Direction = Direction.Bas;
                etape++;
                X = 630;
            }
            if (Direction == Direction.Bas && X == 630 && Y >= 950 && etape == 3)
            {
                Direction = Direction.Gauche;
                etape++;
                Y = 950;
            }
            if (Direction == Direction.Gauche && X <= 320 && Y == 950 && etape == 4)
            {
                Direction = Direction.Haut;
                etape++;
                X = 320;
            }
            if (Direction == Direction.Haut && X == 320 && Y <= 700 && etape == 5)
            {
                Direction = Direction.Droite;
                etape++;
                Y = 700;
            }
            if (Direction == Direction.Droite && X >= 1210 && Y == 700 && etape == 6)
            {
                Direction = Direction.Haut;
                etape++;
                X = 1210;
            }
            if (Direction == Direction.Haut && X == 1210 && Y <= 400 && etape == 7)
            {
                Direction = Direction.Droite;
                etape++;
                Y = 400;
            }
            if (Direction == Direction.Droite && X >= 1440 && Y == 400 && etape == 8)
            {
                Direction = Direction.Bas;
                etape++;
                X = 1440;
            }
            if (Direction == Direction.Bas && X == 1440 && Y >= 860 && etape == 9)
            {
                Direction = Direction.Gauche;
                etape++;
                Y = 860;
            }
            if (Direction == Direction.Gauche && X <= 880 && Y == 860 && etape == 10)
            {
                Direction = Direction.Bas;
                etape++;
                X = 880;
            }

            base.Deplacer();
            
            /// gestion du ralentissement
            if (ralentie)
            {
                compteurRalentie++;
                if (compteurRalentie >= 100)
                {
                    Vitesse = Vitesse * 2;
                    ralentie = false;
                    compteurRalentie = 0;
                }
            }


        }
        /// <summary>
        /// ralentit l'enemie en divisant sa vitesse par 2 une seule fois si la tour de glace le touche
        /// </summary>
        public void ralentir()
        {
            if (!ralentie)
            {
                Vitesse = Vitesse / 2;
                ralentie = true;
            }
            
        }
    }
}
