using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Crud.Order.Types;

namespace Jeu.Core.Domain
{
    public class Projectile : ObjetsMobiles
    {
        /// <summary>
        /// Composante X de la vitesse
        /// </summary>
        public int VitesseX { get; protected set; }

        /// <summary>
        /// Composante Y de la vitesse
        /// </summary>
        public int VitesseY { get; protected set; }

        /// <summary>
        /// Temps de vie du projectile
        /// </summary>
        public int TempsDeVie { get; set; }

        /// <summary>
        /// Type de projectile
        /// </summary>
        public string TypeProjectile { get; set; }

        /// <summary>
        /// Constructeur de la classe Projectile
        /// </summary>
        /// <param name="tours"></param>
        /// <param name="image"></param>
        public Projectile(Tours tours, string image) : base(image)
        {
            /// Initialisation des propriétés du projectile
            Largeur = 12;
            Hauteur = 25;
            X = tours.X + tours.Image.Width / 2;
            Y = tours.Y;
            Vitesse = 20;
            VitesseX = 0;
            VitesseY = 0;
            TempsDeVie = 0;

        }
        /// <summary>
        /// Choisie la direction future de l'enemie en fonction de sa position actuelle et de sa direction
        /// </summary>
        /// <param name="enemie"></param>
        public void ChoisirdirectionFutur(Enemie enemie)
        {
            /// direction de l'enemie par défaut
            double directionX = 0.0;
            double directionY = 0.0;

            /// vecteur entre le projectile et l'enemie
            int VecteurX = enemie.X - X;
            int VecteurY = enemie.Y - Y;

            /// Normalisation du vecteur c-a-d qu'on le met sur une echelle entre 0 et 1
            double Vecteur = Math.Sqrt(VecteurX * VecteurX + VecteurY * VecteurY);

            /// direction dans lequel l'enemie se dirige
            switch (enemie.Direction)
            {
                case Direction.Droite:
                    directionX = 1.0;
                    break;
                case Direction.Gauche:
                    directionX = -1.0;
                    break;
                case Direction.Bas:
                    directionY = 1.0;
                    break;
                case Direction.Haut:
                    directionY = -1.0;
                    break;
                default:
                    directionX = 0.0;
                    directionY = 0.0;
                    break;
            }


            /// Estimation du temps pour atteindre la position actuelle de l'ennemi
            double TempsEstimeTouche = Vecteur / Vitesse;

            /// Position future estimée de l'ennemi
            double futureX = enemie.X + directionX * enemie.Vitesse * TempsEstimeTouche;
            double futureY = enemie.Y + directionY * enemie.Vitesse * TempsEstimeTouche;

            /// Vecteur cible vers la position future
            double VecteurFuturX = futureX - X;
            double VecteurFuturY = futureY - Y;
            double VecteurFuture = Math.Sqrt(VecteurFuturX * VecteurFuturX + VecteurFuturY * VecteurFuturY);



            /// Normalisation et application de la vitesse du projectile
            double VecteurNormaliseX = VecteurFuturX / VecteurFuture;
            double VecteurNormaliseY = VecteurFuturY / VecteurFuture;

            /// Composantes de la vitesse
            VitesseX = (int)Math.Round(VecteurNormaliseX * Vitesse);
            VitesseY = (int)Math.Round(VecteurNormaliseY * Vitesse);
        }
        /// <summary>
        /// Deplace le projectile selon ses composantes de vitesse
        /// </summary>
        public override void Deplacer()
        {
            X += (VitesseX);
            Y += (VitesseY);
        }
    }
}
