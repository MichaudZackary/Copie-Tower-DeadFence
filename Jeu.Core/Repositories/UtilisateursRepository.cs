using Jeu.Core.Domain;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu.Core.Repositories
{
    public class UtilisateursRepository : IUtilisateursRepository
    {
        // Champ ajouté pour recevoir la chaîne via DI sans supprimer le comportement existant.
        private readonly string? _ChaineConnection;

        // Constructeur par défaut (inchangé) — conservé pour compatibilité.
        public UtilisateursRepository()
        {
        }

        // Constructeur additionnel: permet d'injecter la chaîne de connexion depuis Program.cs.
        public UtilisateursRepository(string? Conn)
        {
            _ChaineConnection = Conn;
        }

        // Propriété modifiée: priorise la chaîne injectée, sinon retombe sur ConfigurationManager de façon sûre.
        protected string ChaineConnexion =>
            !string.IsNullOrWhiteSpace(_ChaineConnection)
                ? _ChaineConnection!
                : ConfigurationManager.ConnectionStrings["towerdeadfence"]?.ConnectionString
                    ?? throw new InvalidOperationException("La chaîne de connexion 'towerdeadfence' n'est pas configurée. Ajoute-la dans appsettings.json ou enregistre le dépôt en DI avec la chaîne.");

        public void Ajouter(Utilisateur user)
        {
            using (MySqlConnection conn = new MySqlConnection(ChaineConnexion))
            {
                // Instanciation de la commande SQL
                MySqlCommand cmd = new MySqlCommand("INSERT INTO User (Username, Courriel) VALUES (@Username, @Courriel)", conn);

                // Ajout des paramètres
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Courriel", user.Courriel);
                // Ouverture de la connexion
                conn.Open();
                // Exécution de la commande
                cmd.ExecuteNonQuery();
                user.Id = (int)cmd.LastInsertedId;
            }
        }
        public bool Existe(int id)
        {
            try
            {
                var utilisateur = Obtenir(id);
            }
            catch
            {
                return false;
            }

            return true;
        }
        public Utilisateur Obtenir(int id)
        {
            // Instanciation de la connexion SQL
            using (MySqlConnection conn = new MySqlConnection(ChaineConnexion))
            {
                // Instanciation de la commande SQL
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM  USER WHERE IdUser = @Id", conn);

                // Paramètres contenant les valeurs
                cmd.Parameters.AddWithValue("@Id", id);

                // Établir la connexion avec le serveur MySQL
                conn.Open();

                // Instanciation du lecteur
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    // Exécuter la requête SQL et lire les enregistrements
                    if (reader.Read())
                    {
                        var User = new Utilisateur
                        {
                            Id = (int)reader["IdUser"],
                            Username = (string)reader["Username"],
                            Courriel = (string)reader["Courriel"]
                        };
                        return User;
                    }
                }
            } // Fermeture de la conenxion SQL

            throw new ArgumentOutOfRangeException();
        }


        public List<Utilisateur> ObtenirTous()
        {
            var liste = new List<Utilisateur>();

            // Instanciation de la connexion SQL
            using (MySqlConnection conn = new MySqlConnection(ChaineConnexion))
            {
                // Instanciation de la commande SQL
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Contact", conn);

                // Établir la connexion avec le serveur MySQL
                conn.Open();

                // Instanciation du lecteur
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    // Exécuter la requête SQL et lire les enregistrements
                    while (reader.Read())
                    {
                        var User = new Utilisateur
                        {
                            Id = (int)reader["IdContact"],
                            Username = (string)reader["Nom"],
                            Courriel = (string)reader["Courriel"]
                        };
                        liste.Add(User);
                    }
                }
            } // Fermeture de la conenxion SQL

            return liste;
        }

        public void Supprimer(int id)
        {
            // Instanciation de la connexion SQL
            using (MySqlConnection conn = new MySqlConnection(ChaineConnexion))
            {
                // Instanciation de la commande SQL
                MySqlCommand cmd = new MySqlCommand("DELETE FROM Contact WHERE IdContact = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);

                // Établir la connexion avec le serveur MySQL
                conn.Open();

                // Exécuter la requête SQL
                cmd.ExecuteNonQuery();
            } // Fermeture de la conenxion SQL
        }
    }
}
