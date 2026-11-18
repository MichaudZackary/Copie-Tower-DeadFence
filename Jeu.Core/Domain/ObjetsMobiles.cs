using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu.Core.Domain
{
    public abstract class ObjetsMobiles : Objets
    {

        public int Vitesse { get; protected set; }

        public Direction Direction { get; set; }

        public ObjetsMobiles(string image) : base(image)
        {

        }

        /// </summary>
        ///   Déplace l'objet
        /// </summary>
        /// <summary>
        ///   Déplace l'objet selon sa direction.
        ///   Une méthode « virtual » peut être redéfinie dans la classe héritière.
        /// </summary>
        public virtual void Deplacer()
        {
            switch (Direction)
            {
                case Direction.Gauche:
                    X -= Vitesse;
                    break;
                case Direction.Droite:
                    X += Vitesse;
                    break;
                case Direction.Haut:
                    Y -= Vitesse;
                    break;
                case Direction.Bas:
                    Y += Vitesse;
                    break;
            }
        }


        /// <summary>
        ///   Valide s'il y a collision entre l'objet mobile et un autre objet mobile.
        /// </summary>
        public bool ValiderCollision(ObjetsMobiles objetMobile2)
        {
            return this.Boite.IntersectsWith(objetMobile2.Boite);
        }


    }
}
