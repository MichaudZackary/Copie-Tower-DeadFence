using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu.Core.Domain
{
    public class Goab : Enemie
    {
        /// <summary>
        /// Constructeur de la classe Goab
        /// </summary>
        public Goab() : base("images\\Goab.png")
        {
            Direction = Direction.Droite;
            Vitesse = 1;
            NombreVies = 50;
            score = 100;
        }
    }
}
