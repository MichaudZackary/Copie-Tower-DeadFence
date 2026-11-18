using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu.Core.Domain
{
    /// <summary>
    /// classe représentant un utilisateur
    /// </summary>
    public class Utilisateur
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(150)]
        public string Username { get; set; } = "";


        [MinLength(3)]
        [MaxLength(150)]

        public string Courriel { get; set; } = "";


    }

}
