using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Jeu.Core.Domain
{
    public class Sauvegarde
    {
        /// <summary>
        /// Identifiant unique de la sauvegarde
        /// </summary>
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(150)]

        /// Identifiant de l'utilisateur lié à la sauvegarde
        public int IdUser { get; set; }

        /// <summary>
        /// Nom de la sauvegarde
        /// </summary>
        public string NomSave { get; set; } = string.Empty;

        /// <summary>
        /// Vague atteinte lors de la sauvegarde
        /// </summary>
        public int Vague { get; set; }

        /// <summary>
        /// Argent du joueur au moment de la sauvegarde
        /// Rendre mutable pour pouvoir l'associer facilement à `nombreOr` depuis Form1
        /// </summary>
        public int Argent { get; set; }

        /// <summary>
        /// Score du joueur au moment de la sauvegarde
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Méthode pour mettre à jour l'argent à partir de `nombreOr`
        /// </summary>
        /// <param name="nombreOr"></param>
        public void UpdateFromNombreOr(int nombreOr)
        {
            Argent = nombreOr;
        }
    }
}

