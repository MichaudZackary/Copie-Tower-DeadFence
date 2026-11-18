using Jeu.Core.Domain;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Jeu.Core.Repositories
{
    public class ToursRepository : IToursRepository
    {   //Chaîne de connexion à la base de données


        protected string ChaineConnexion => ConfigurationManager.ConnectionStrings["towerdeadfence"].ConnectionString;

        //Obtient une tour par son id dans la base de données
        public Tours Obtenir(int id)
        {
            using (MySqlConnection connexion = new MySqlConnection(ChaineConnexion))
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM TOUR WHERE idEmplacementTour = @id", connexion);
                cmd.Parameters.AddWithValue("@id", id);
                connexion.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {

                    if (reader.Read())
                    {       //regarde le type de la tour et son nivau pour l'instancier dans la bonne classe
                        switch ((string)reader["TypeTours"])
                        {
                            case "TourFeu":
                                {
                                    if ((int)reader["NIVTour"] == 1)
                                        return new TourFeu((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourFeu1.png");
                                    if ((int)reader["NIVTour"] == 2)
                                        return new TourFeu((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourFeu2.png");
                                    if ((int)reader["NIVTour"] == 2)
                                        return new TourFeu((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourFeu3.png");
                                }
                                break;

                            case "TourGlace":
                                {
                                    if ((int)reader["NIVTour"] == 1)
                                        return new TourGlace((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourGlace1.png");
                                    if ((int)reader["NIVTour"] == 2)
                                        return new TourGlace((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourGlace2.png");
                                    if ((int)reader["NIVTour"] == 3)
                                        return new TourGlace((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourGlace3.png");
                                }
                                break;

                            case "TourMagie":
                                {
                                    if ((int)reader["NIVTour"] == 1)
                                        return new TourMagie((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourMagie1.png");
                                    if ((int)reader["NIVTour"] == 2)
                                        return new TourMagie((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourMagie2.png");
                                    if ((int)reader["NIVTour"] == 3)
                                        return new TourMagie((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourMagie3.png");
                                }
                                break;

                            case "TourBombe":
                                {
                                    if ((int)reader["NIVTour"] == 1)
                                        return new TourGlace((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourBombe1.png");
                                    if ((int)reader["NIVTour"] == 2)
                                        return new TourGlace((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourBombe2.png");
                                    if ((int)reader["NIVTour"] == 2)
                                        return new TourGlace((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourBombe3.png");

                                }
                                break;

                            case "TourElec":
                                {
                                    if ((int)reader["NIVTour"] == 1)
                                        return new TourElec((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourElec1.png");
                                    if ((int)reader["NIVTour"] == 2)
                                        return new TourElec((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourElec2.png");
                                    if ((int)reader["NIVTour"] == 3)
                                        return new TourElec((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourElec3.png");
                                }
                                break;
                        }
                    }
                }

            }
            return null;
        }

        //Obtient toutes les tours dans la base de données
        public List<Tours> ObtenirTous(int id)
        {
            var liste = new List<Tours>();
            using (MySqlConnection connexion = new MySqlConnection(ChaineConnexion))
            {
                // Instanciation de la commande SQL
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM TOUR WHERE IdSauvegarde = @IdSauvegarde ", connexion);
                // ajout des paramètres
                cmd.Parameters.AddWithValue("@IdSauvegarde", id);
                // Établir la connexion avec le serveur MySQL
                connexion.Open();
                // Exécuter la requête SQL
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {           //regarde le type de la tour et son niveau pour l'instancier dans la bonne classe
                        switch ((string)reader["TypeTours"])
                        {
                            case "TourGlace":
                                {
                                    if ((int)reader["NIVTour"] == 1)
                                        liste.Add(new TourGlace((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourGlace1.png"));
                                    if ((int)reader["NIVTour"] == 2)
                                        liste.Add(new TourGlace((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourGlace2.png"));
                                    if ((int)reader["NIVTour"] == 3)
                                        liste.Add(new TourGlace((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourGlace3.png"));
                                }
                                break;

                            case "TourFeu":
                                {
                                    if ((int)reader["NIVTour"] == 1)
                                        liste.Add(new TourFeu((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourFeu1.png"));
                                    if ((int)reader["NIVTour"] == 2)
                                        liste.Add(new TourFeu((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourFeu2.png"));
                                    if ((int)reader["NIVTour"] == 3)
                                        liste.Add(new TourFeu((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourFeu3.png"));
                                }
                                break;

                            case "TourMagie":
                                {
                                    if ((int)reader["NIVTour"] == 1)
                                        liste.Add(new TourMagie((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourMagie1.png"));
                                    if ((int)reader["NIVTour"] == 2)
                                        liste.Add(new TourMagie((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourMagie2.png"));
                                    if ((int)reader["NIVTour"] == 3)
                                        liste.Add(new TourMagie((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourMagie3.png"));
                                }
                                break;
                            case "TourBombe":
                                {
                                    if ((int)reader["NIVTour"] == 1)
                                        liste.Add(new TourGlace((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourBombe1.png"));
                                    if ((int)reader["NIVTour"] == 2)
                                        liste.Add(new TourGlace((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourBombe2.png"));
                                    if ((int)reader["NIVTour"] == 3)
                                        liste.Add(new TourGlace((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourBombe3.png"));

                                }
                                break;

                            case "TourElec":
                                {
                                    if ((int)reader["NIVTour"] == 1)
                                        liste.Add(new TourElec((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourElec1.png"));
                                    if ((int)reader["NIVTour"] == 2)
                                        liste.Add(new TourElec((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourElec2.png"));
                                    if ((int)reader["NIVTour"] == 3)
                                        liste.Add(new TourElec((int)reader["EmplacementTourX"], (int)reader["EmplacementTourY"], "images\\TourElec3.png"));
                                }
                                break;
                        }
                    }
                }

            }
            return liste;
        }
        //Ajoute une tour dans la base de données
        public void Ajouter(Tours tours, int save)
        {
            using (MySqlConnection conn = new MySqlConnection(ChaineConnexion))
            {
                conn.Open();
                string requete = "INSERT INTO Tour (IdSauvegarde,EmplacementTourX, EmplacementTourY, TypeTours, NivTour) " +
                                 "VALUES (@IdSauvegarde, @EmplacementTourX, @EmplacementTourY, @TypeTours, @NIVTour)";
                // Instanciation de la commande SQL
                using (MySqlCommand cmd = new MySqlCommand(requete, conn))
                {
                    // Paramètres contenant les valeurs de la requêtes SQL
                    cmd.Parameters.AddWithValue("@IdSauvegarde", save);
                    cmd.Parameters.AddWithValue("@EmplacementTourX", tours.X + tours.Largeur + 20); 
                    cmd.Parameters.AddWithValue("@EmplacementTourY", tours.Y + tours.Hauteur / 2);
                    cmd.Parameters.AddWithValue("@TypeTours", tours.type);
                    cmd.Parameters.AddWithValue("@NIVTour", tours.Niveau);
                    cmd.ExecuteNonQuery();

                    // Obtention du Id auto-incrémenté par la base de données
                    tours.Id = (int)cmd.LastInsertedId;
                }
            }
        }

        //Vérifie si une tour existe dans la base de données
        public bool Existe(int id)
        {
            try
            {
                var contact = Obtenir(id);
            }
            catch
            {
                return false;
            }

            return true;
        }

        //Supprime une tour de la base de données
        public void Supprimer(int id)
        {
            // Instanciation de la connexion SQL
            using (MySqlConnection connexion = new MySqlConnection(ChaineConnexion))
            {
                // Instanciation de la commande SQL
                MySqlCommand commande = new MySqlCommand("DELETE FROM Tour WHERE IdSauvegarde = @IdSauvegarde", connexion);
                commande.Parameters.AddWithValue("@IdSauvegarde", id);

                // Établir la connexion avec le serveur MySQL
                connexion.Open();

                // Exécuter la requête SQL
                commande.ExecuteNonQuery();
            } // Fermeture de la conenxion SQL

        }
    }

}
