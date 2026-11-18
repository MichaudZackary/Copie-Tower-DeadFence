using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu.Core.Domain
{
    public class Gobelin : Enemie
    {
        /// <summary>
        /// Constructeur de la classe Gobelin
        /// </summary>
        public Gobelin() : base("images\\Gobelin.png")
        {
            Direction = Direction.Droite;
            Vitesse = 6;
            NombreVies = 1;
            score = 15;
        }
    }
}
