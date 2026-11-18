using Google.Protobuf.WellKnownTypes;
using Jeu.Core.Domain;
using Jeu.Core.Services;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Jeu.Core.Repositories
{
    public class SauvegardeRepository : ISauvegardeRepository
    {
        // Nouvelle valeur injectable : si fournie via DI, elle sera utilisée.
        private readonly string? _connectionStringFromDi;

        // Constructeur par défaut (existant) — on le laisse pour compatibilité.
        public SauvegardeRepository()
        {
        }

        // Nouveau constructeur ajouté : permet d'injecter la chaîne de connexion depuis l'application Blazor.
        public SauvegardeRepository(string? connectionString)
        {
            _connectionStringFromDi = connectionString;
        }

        // Propriété modifiée pour prioriser la chaîne injectée puis retomber sur ConfigurationManager si nécessaire.
        protected string ChaineConnexion =>
            !string.IsNullOrEmpty(_connectionStringFromDi)
                ? _connectionStringFromDi!
                : ConfigurationManager.ConnectionStrings["towerdeadfence"]?.ConnectionString
                    ?? throw new InvalidOperationException("La chaîne de connexion 'towerdeadfence' n'est pas configurée.");
        

        public void AjouterSauvegarde(Sauvegarde save)
        {
            // Implémentation de l'ajout de sauvegarde
            using (MySqlConnection conn = new MySqlConnection(ChaineConnexion))
            {
                // Instanciation de la commande SQL
                MySqlCommand cmd = new MySqlCommand("INSERT INTO Sauvegarde (IdUser, NomSauvegarde, Vague, Argent, Score) VALUES (@IdUser, @NomSauvegarde, @Vague, @Argent, @Score)", conn);
                // Ajout des paramètres
                cmd.Parameters.AddWithValue("@IdUser", save.IdUser);
                cmd.Parameters.AddWithValue("@NomSauvegarde", save.NomSave);
                cmd.Parameters.AddWithValue("@Vague", save.Vague);
                cmd.Parameters.AddWithValue("@Argent", save.Argent);
                cmd.Parameters.AddWithValue("@Score", save.Score);

                // Ouverture de la connexion
                conn.Open();
                // Exécution de la commande
                cmd.ExecuteNonQuery();
                save.Id = (int)cmd.LastInsertedId;
            }
        }

        public void SupprimerSauvegarde(int id)
        {
            // Implémentation de la suppression de sauvegarde
            using (MySqlConnection conn = new MySqlConnection(ChaineConnexion))
            {
                // Instanciation de la commande SQL
                MySqlCommand cmd = new MySqlCommand("DELETE FROM Sauvegarde WHERE IdSauvegarde = @IdSauvegarde", conn);
                // Ajout du paramètre contenant l'identifiant de la sauvegarde à supprimer
                cmd.Parameters.AddWithValue("@IdSauvegarde", id);
                // Ouverture de la connexion
                conn.Open();
                // Exécution de la commande
                cmd.ExecuteNonQuery();
            }
        }

        public bool ExisteSauvegarde(int id)
        {
            // Implémentation de la vérification de l'existence d'une sauvegarde
            using (MySqlConnection conn = new MySqlConnection(ChaineConnexion))
            {
                // Instanciation de la commande SQL
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM Sauvegarde WHERE IdSauvegarde = @IdSauvegarde", conn);
                // Ajout du paramètre contenant l'identifiant de la sauvegarde à vérifier
                cmd.Parameters.AddWithValue("@IdSauvegarde", id);
                // Ouverture de la connexion
                conn.Open();
                // Exécution de la commande et récupération du résultat
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        public Sauvegarde? ObtenirSauvegardeParId(int id)
        {
            // Implémentation de l'obtention d'une sauvegarde par son identifiant
            using (MySqlConnection conn = new MySqlConnection(ChaineConnexion))
            {
                // Instanciation de la commande SQL
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Sauvegarde WHERE IdSauvegarde = @IdSauvegarde", conn);
                // Ajout du paramètre contenant l'identifiant de la sauvegarde à obtenir
                cmd.Parameters.AddWithValue("@IdSauvegarde", id);
                // Ouverture de la connexion
                conn.Open();
                // Exécution de la commande et récupération du résultat
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Sauvegarde
                        {
                            Id = reader.GetInt32("IdSauvegarde"),
                            IdUser = reader.GetInt32("IdUser"),
                            NomSave = reader.GetString("NomSave"),
                            Vague = reader.GetInt32("Vague"),
                            Argent = reader.GetInt32("Argent"),
                            Score = reader.GetInt32("Score")
                        };
                    }
                    else
                    {
                        return null; // Sauvegarde non trouvée
                    }
                }
            }
        }
        // Obtient toutes les sauvegardes dans la base de données
        public List<Sauvegarde> ObtenirToutesLesSauvegardes()
        {
            // Implémentation de l'obtention de toutes les sauvegardes
            List<Sauvegarde> sauvegardes = new List<Sauvegarde>();
            using (MySqlConnection conn = new MySqlConnection(ChaineConnexion))
            {
                // Instanciation de la commande SQL
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Sauvegarde", conn);
                // Ouverture de la connexion
                conn.Open();
                // Exécution de la commande et récupération du résultat
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Sauvegarde save = new Sauvegarde
                        {
                            Id = reader.GetInt32("IdSauvegarde"),
                            IdUser = reader.GetInt32("IdUser"),
                            NomSave = reader.GetString("NomSauvegarde"),
                            Vague = reader.GetInt32("Vague"),
                            Argent = reader.GetInt32("Argent"),
                            Score = reader.GetInt32("Score")
                        };
                        sauvegardes.Add(save);


                    }
                }
            }
            return sauvegardes;
        }
    }
}
