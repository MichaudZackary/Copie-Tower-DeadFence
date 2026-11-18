using Google.Protobuf.WellKnownTypes;
using System.Drawing;

namespace Jeu.Core.Domain
{
    public abstract class Objets : Entite
    {
        #region Attributs

        private Rectangle _boite;

        #endregion

        #region Propriétés

        public Rectangle Boite
        { get { return _boite; } }

        /// <summary>
        ///   Image de l'acteur qui est affichée à l'écran.
        /// </summary>
        public Image Image { get; set; }

        /// <summary>
        /// Positions X
        /// </summary>
        public int X { get { return _boite.X; } set { _boite.X = value; } }

        /// <summary>
        /// Positions Y
        /// </summary>
        public int Y { get { return _boite.Y; } set { _boite.Y = value; } }

        /// <summary>
        /// Largeur Image/Hitbox
        /// </summary>
        public int Largeur { get { return _boite.Width; } set { _boite.Width = value; } }

        /// <summary>
        /// Hauteur Image/Hitbox
        /// </summary>
        public int Hauteur
        { get { return _boite.Height; } set { _boite.Height = value; } }


        #endregion

        #region Constructeurs
        /// <summary>
        ///   Constructeur
        /// </summary>
        protected Objets(string _image)
        {
            Image = Image.FromFile(_image);

            _boite = new Rectangle(0, 0, Image.Width, Image.Height);
        }

        #endregion

        #region Méthodes

        /// <summary>
        ///   Dessine l'objet à l'écran
        /// </summary>
        /// <param name="g">Graphiques/Écran de l'application en cours d'éxécution</param>
        public void Dessiner(Graphics g)
        {
            if (Image != null)
                g.DrawImage(Image, _boite.X, _boite.Y, _boite.Width, _boite.Height);
        }


        /// <summary>
        ///   Vérifie s'il y a collision entre deux objet
        ///   Par polymorphisme, tout objet du jeu (Tours, Projectile, ennemie) peut être passé en paramètre à la méthode suivante
        /// </summary>
        /// <param name="vehicule"></param>
        /// <returns></returns>
        public bool VerifierCollision(Objets objets)
        {
            return _boite.IntersectsWith(objets._boite);
        }

        /// <summary>
        ///   Libère RAM
        /// </summary>
        public void Disposer()
        {
            Image.Dispose();
        }


        #endregion
    }
}
