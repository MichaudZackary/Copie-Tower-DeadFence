using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu.Core.Domain
{
    public class Courriel
    {
        /// <summary>
        /// va valider le courriel pour regarder si il passe les normes d'exigence et retourner une liste de messages d'erreur s'il y en a
        /// </summary>
        /// <param name="courriel"></param>
        /// <returns></returns>
        public static List<string> ValiderCourriel(string courriel)
        {
            List<string> listeMessage = new List<string>();

            if (string.IsNullOrWhiteSpace(courriel)) 
            {
                listeMessage.Add("L'adresse courriel ne peut pas être vide.");
                return listeMessage;
            }

            if (courriel.Length < 10)
                listeMessage.Add("L'adresse courriel doit avoir au moins 10 caractères.");

            int indexArobas = courriel.IndexOf('@');

            if (courriel.Count(c => c == '@') != 1)
            {
                listeMessage.Add("L'adresse courriel doit contenir un arobas.");
                return listeMessage;
            }

            if (courriel.Substring(indexArobas).Count(c => c == '.') < 1)
                listeMessage.Add("L'adresse courriel doit avoir au moins un point après l'arobas.");

            if (courriel.Substring(0, indexArobas).Length < 3)
                listeMessage.Add("L'adresse courriel doit avoir au moins 3 caractères avant l'arobas.");

            if (courriel.Substring(indexArobas).Length < 6)
                listeMessage.Add("L'adresse courriel doit avoir au moins 6 caractères après l'arobas.");

            string[] composantes = courriel.Substring(indexArobas).Split('.');
            if (composantes.Last().Length < 2)
                listeMessage.Add("L'adresse courriel doit avoir au moins 2 caractères après le dernier point.");

            string caracteresAcceptes = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789.@";

            bool tousCaracteresSontValidés = courriel.All(c => caracteresAcceptes.Contains(c));

            if (!tousCaracteresSontValidés)
                listeMessage.Add("L'adresse courriel doit avoir des caractères compris parmi les suivants : lettres, chiffres, points, @, ");

            return listeMessage;
        }
    }
}
