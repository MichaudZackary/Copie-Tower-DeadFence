using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu.Core.Domain
{
    public class Skelette : Enemie
    {
        /// <summary>
        /// Constructeur de la classe Skelette
        /// </summary>
        public Skelette() : base("images\\Skelette.png")
        {
            /// Initialisation des propriétés spécifiques au Skelette
            Direction = Direction.Droite;
            Vitesse = 4;
            NombreVies = 2;
            score = 5;
        }
    
    }
}
