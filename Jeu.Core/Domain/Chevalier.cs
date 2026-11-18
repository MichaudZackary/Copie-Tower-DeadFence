using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu.Core.Domain
{
    public class Chevalier : Enemie
    {
        /// <summary>
        /// Constructeur de la classe Chevalier
        /// </summary>
        public Chevalier() : base("images\\Chevalier2.png")
        {
            Direction = Direction.Droite;
            Vitesse = 3;
            NombreVies = 5;
            score = 25;
        }
    }
}
