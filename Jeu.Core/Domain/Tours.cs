using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Jeu.Core.Domain
{


    public class Tours : Objets
    {
        /// <summary>
        /// Vitesse d'attaque de la tour
        /// </summary>
        public int VitesseAttaque { get; set; }
        /// <summary>
        /// Compteur pour la vitesse d'attaque
        /// </summary>
        public int VitesseAttaqueCompteur { get; set; } = 0;
        /// <summary>
        /// Prix d'achat de la tour
        /// </summary>
        public int PrixAchat { get; protected set; }
        /// <summary>
        /// prix d'amélioration de la tour
        /// </summary>
        public int PrixAmelioration { get; protected set; }
        /// <summary>
        /// niveau de la tour
        /// </summary>
        public int Niveau { get; protected set; }
        /// <summary>
        /// or dépensé total dans la tour
        /// </summary>
        public int OrDepense { get; protected set; }
        /// <summary>
        /// porté effective de la tour
        /// </summary>
        public int Porte { get; protected set; }
        public string type { get; set; }

        public Tours(string image) : base(image)
        {
            Image = Image.FromFile(image);
        }

        /// <summary>
        /// Méthode d'amélioration de la tour de base
        /// </summary>
        public virtual void Amelioration() { }
        /// <summary>
        /// Regarde si la tour peut attaquer l'ennemie passé en paramètre
        /// </summary>
        /// <param name="enemie"></param>
        /// <returns></returns>
        public bool PeuxAttaquer(Enemie enemie)
        { /// Récupérer la largeur de l'image (avec fallback sécurisés)
            int largeur = Image.Width/2;
            /// Position de référence : milieu en haut
            int referenceX = X + (largeur / 2);
            int referenceY = Y;
            /// Initialisation des différences
            int differenceX = 0;
            int differenceY = 0;

            /// Calcul des différences en X et Y entre la tour et l'ennemie
            if (enemie.X < referenceX)
            {

                if (enemie.Y < referenceY)
                {
                    differenceX = referenceX - enemie.X;
                    differenceY = referenceY - enemie.Y;
                }
                else
                {
                    differenceX = referenceX - enemie.X;
                    differenceY = enemie.Y - referenceY;
                }
            }
            else
            {
                if (enemie.Y < referenceY)
                {
                    differenceX = enemie.X - referenceX;
                    differenceY = referenceY - enemie.Y;
                }
                else
                {
                    differenceX = enemie.X - referenceX;
                    differenceY = enemie.Y - referenceY;
                }
            }
            /// Vérification si l'ennemie est dans la portée de la tour
            if (differenceX < Porte && differenceY < Porte)
            { return true; }
            else
            { return false; }
        }
    }
}
