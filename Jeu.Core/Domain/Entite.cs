using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu.Core.Domain
{

    /// <summary>
    ///  Classe de base pour toutes les entités à gérer par le logiciel : Tour, Sauveguard et User.
    /// </summary>
    public abstract class Entite
    {
        public int Id { get; set; }
        public bool EstNouveau { get { return Id == 0; } }
    }
}
