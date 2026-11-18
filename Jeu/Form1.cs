using Jeu.Core.Domain;
using Jeu.Core.Repositories;
using Jeu.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.ApplicationServices;
using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Utilities.IO;
using System.Diagnostics.Eventing.Reader;

namespace Jeu
{
    public partial class Form1 : Form
    {
        public bool premiereTour { get; private set; }
        public bool ameliorer { get; private set; }
        public bool detruire { get; private set; }
        public bool colTours { get; private set; }
        public bool userBool { get; private set; }
        public string? imageTour { get; private set; }
        public int CompteurAnimOr { get; private set; }
        public int nombreOr { get; private set; }
        public int PointDeVie { get; private set; }
        public int OrBonus { get; private set; }
        public Random Random { get; private set; }
        public List<Tours> listeTours { get; private set; }
        public List<Enemie> listeEnemies { get; private set; }
        public List<Projectile> listeProjectile { get; private set; }
        public Tours? tour { get; private set; }
        public int score { get; set; }
        public int scoreProchaineVague { get; set; }
        public int vague { get; set; }
        public int nombreEnemieMax { get; private set; }


        // partie de sauvegarde BD

        /// Services
        protected List<Sauvegarde> sauvegardes { get; private set; }
        protected Sauvegarde sauvegardeActuelle { get; private set; }
        protected string cheminSauvegarde { get; private set; } = "sauvegardes.json";
        protected ISauvegardeService sauvegardeService { get; }
        protected IToursService toursService { get; }
        protected IUtilisateursService utilisateursService { get; }

        private int IdUtilisateurConnecte;

        /// <summary>
        /// instanciation des services via injection de d�pendances
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            CompteurAnimOr = 0;
            nombreOr = 50;
            LblArgent.Text = nombreOr.ToString();
            OrBonus = 25;
            nombreEnemieMax = 5;
            score = 0;
            scoreProchaineVague = 500;
            vague = 1;
            PointDeVie = 3;
            listeTours = new List<Tours>();
            listeEnemies = new List<Enemie>();
            listeProjectile = new List<Projectile>();
            premiereTour = true;
            colTours = true;
            ameliorer = false;
            userBool = false;
            detruire = false;
            imageTour = null;
            Random = new Random();
            this.TopMost = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            sauvegardes = new List<Sauvegarde>();
            sauvegardeService = new SauvegardeService(new SauvegardeRepository());
            toursService = new ToursService(new ToursRepository());
            utilisateursService = new UtilisateursService(new UtilisateursRepository());
            sauvegardeActuelle = new Sauvegarde();

        }



        // fermeture du jeu
        private void BtnFerme_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Bouton de nouvelle partie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNP_Click(object sender, EventArgs e)
        {
            if (userBool)
            {
                if (utilisateursService.Existe(IdUtilisateurConnecte))
                {
                    return;
                }
                else
                {
                    Utilisateur user = new Utilisateur();
                    user.Username = textBoxUtilisateur.Text;
                    user.Courriel = textBoxCouriel.Text;
                    utilisateursService.Ajouter(user);
                    IdUtilisateurConnecte = user.Id;
                }
                BtnNP.Visible = false;
                BtnCharger.Visible = false;
                LblTitre.Visible = false;
                btnCommencer.Visible = true;
                btnAmeliore.Visible = true;
                btnBombe.Visible = true;
                btnDetruire.Visible = true;
                btnElec.Visible = true;
                btnFeu.Visible = true;
                btnGlace.Visible = true;
                btnMagie.Visible = true;
                lblOr.Visible = true;
                LblAmelioration.Visible = true;
                LblArgent.Visible = true;
                lblScore.Visible = true;
                lblVague.Visible = true;
                lblPV.Visible = true;
                btnOuvrir.Visible = false;
                btnSuprimer.Visible = false;
                listViewSauvegarde.Visible = false;
                btnSauvegarder.Visible = true;
                timerPrincipal.Start();
                timerAnimation.Start();
                timerAttaqueTour.Start();
            }
            else
            {
                MessageBox.Show("Veuillez confirmer votre nom d'utilisateur et courriel avant de continuer.");
            }

        }

        /// <summary>
        /// Bouton de charger une partie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCharger_Click(object sender, EventArgs e)
        {
            if (userBool)
            {
                listViewSauvegarde.Visible = true;
                btnOuvrir.Visible = true;
                btnSuprimer.Visible = true;
                RafraichirListeView();
            }
            else
            {
                MessageBox.Show("Veuillez confirmer votre nom d'utilisateur et courriel avant de continuer.");
            }
        }

        /// <summary>
        /// Initialisation de la liste view
        /// </summary>
        private void InitialiserListeView()
        {
            listViewSauvegarde.Clear();
            listViewSauvegarde.View = View.Details;
            listViewSauvegarde.FullRowSelect = true;
            listViewSauvegarde.MultiSelect = false;
            listViewSauvegarde.Columns.Add("ID", 25);
            listViewSauvegarde.Columns.Add("NomSave", 150);
            listViewSauvegarde.Columns.Add("Vague", 75);
            listViewSauvegarde.Columns.Add("Argent", 300);
            listViewSauvegarde.Columns.Add("Score", 75);
        }



        /// <summary>
        /// Chargement du formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            RafraichirListeView();
        }

        // Rafraichir la liste view
        private void RafraichirListeView()
        {
            sauvegardes = sauvegardeService.ObtenirTous();

            InitialiserListeView();

            foreach (Sauvegarde sauvegarde in sauvegardes)
            {
                ListViewItem item = new ListViewItem(sauvegarde.Id.ToString());
                item.SubItems.Add(sauvegarde.NomSave);
                item.SubItems.Add(sauvegarde.Vague.ToString());
                item.SubItems.Add(sauvegarde.Argent.ToString());
                item.SubItems.Add(sauvegarde.Score.ToString());
                listViewSauvegarde.Items.Add(item);
            }
        }

        private void timerPrincipal_Tick(object sender, EventArgs e)
        {
            lblScore.Text = "Score : " + score.ToString();
            if (tour is not null)
            {
                tour.X = MousePosition.X - tour.Image.Width / 2;
                tour.Y = MousePosition.Y - tour.Image.Height + 20;
            }


            foreach (Enemie enemie in listeEnemies)
            {
                enemie.Deplacer();
            }


            // D�placement des projectiles
            if (listeProjectile.Count > 0)
            {
                foreach (Projectile projectile in listeProjectile)
                {
                    projectile.Deplacer();
                    projectile.TempsDeVie++;
                }
            }

            // V�rification des collisions entre les projectiles et les ennemis
            for (int i = listeProjectile.Count - 1; i >= 0; i--)
            {
                Projectile projectile = listeProjectile[i];
                bool collision = false;

                for (int n = listeEnemies.Count - 1; n >= 0; n--)
                {
                    Enemie enemie = listeEnemies[n];

                    if (enemie.VerifierCollision(projectile))
                    {
                        switch (projectile.TypeProjectile)
                        {
                            case "Feu":
                                enemie.NombreVies -= 1;
                                break;
                            case "Glace":
                                enemie.NombreVies -= 1;
                                enemie.ralentir();
                                break;
                            case "Magie":
                                enemie.NombreVies -= 2;
                                break;
                            case "Bombe":
                                enemie.NombreVies -= 5;
                                break;
                            case "Elec":
                                enemie.NombreVies -= 1;
                                break;
                        }



                        nombreOr++;
                        LblArgent.Text = nombreOr.ToString();

                        collision = true;

                        if (enemie.NombreVies <= 0)
                        {
                            listeEnemies[n].Disposer();
                            listeEnemies.RemoveAt(n);
                            score += enemie.score;
                        }

                        break;
                    }
                }

                if (collision)
                {
                    projectile.Disposer();
                    listeProjectile.RemoveAt(i);
                }
            }



            if (listeProjectile.Count > 0)
                foreach (Projectile projectile in listeProjectile)
                {
                    if (projectile.TempsDeVie >= 30)
                    {
                        listeProjectile.Remove(projectile);
                        projectile.Disposer();
                        break;
                    }
                }

            lblPV.Text = $"Point de Vie : {PointDeVie.ToString()} ";

            if (score >= scoreProchaineVague)
            {
                nombreEnemieMax = nombreEnemieMax + 5;
                scoreProchaineVague = scoreProchaineVague + (vague * 1000);
                timerApparition.Stop();
                timerFinVague.Start();
            }

            foreach (Enemie enemie in listeEnemies)
            {
                if (enemie.Y >= 1080)
                {
                    enemie.Disposer();
                    listeEnemies.Remove(enemie);
                    PointDeVie--;
                    break;
                }
            }
            if (PointDeVie <= 0)
            {
                timerPrincipal.Stop();
                timerApparition.Stop();
                timerAttaqueTour.Stop();
                timerAnimation.Stop();
                timerFinVague.Stop();
                MessageBox.Show($"Game Over! Votre score final est de {score} points et vous avez ateint la vague {vague} ! ");
                Application.Exit();
            }
            Invalidate();
        }

        /// <summary>
        /// Gestion des �v�nements de la souris
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (imageTour is not null)
                switch (imageTour)
                {
                    case "images\\TourFeu1.png":
                        tour = new TourFeu(MousePosition.X, MousePosition.Y, "images\\TourFeu1.png");
                        break;
                    case "images\\TourGlace1.png":
                        tour = new TourGlace(MousePosition.X, MousePosition.Y, "images\\TourGlace1.png");
                        break;
                    case "images\\TourMagie1.png":
                        tour = new TourMagie(MousePosition.X, MousePosition.Y, "images\\TourMagie1.png");
                        break;
                    case "images\\TourBombe1.png":
                        tour = new TourBombe(MousePosition.X, MousePosition.Y, "images\\TourBombe1.png");
                        break;
                    case "images\\TourElec1.png":
                        tour = new TourElec(MousePosition.X, MousePosition.Y, "images\\TourElec1.png");
                        break;
                }
            if (detruire)
                foreach (Tours tour in listeTours)
                {
                    if (tour.Boite.Contains(e.Location))
                    {
                        listeTours.Remove(tour);
                        tour.Disposer();
                        nombreOr = nombreOr + tour.OrDepense / 2;
                        LblArgent.Text = nombreOr.ToString();
                        break;
                    }
                }
            if (ameliorer)
                foreach (Tours tour in listeTours)
                {
                    if (tour.Boite.Contains(e.Location) && (nombreOr - tour.PrixAmelioration >= 0))
                    {
                        nombreOr = nombreOr - tour.PrixAmelioration;
                        tour.Amelioration();
                        LblArgent.Text = nombreOr.ToString();
                    }
                }
        }

        /// <summary>
        /// Mouse up pour placer la tour
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (imageTour is not null && tour is not null && nombreOr - tour.PrixAchat >= 0)
            {
                if (!premiereTour)
                {
                    foreach (Tours tours in listeTours)
                    {
                        colTours = tour.VerifierCollision(tours);
                        if (colTours)
                            break;
                    }
                    if (!colTours)
                    {
                        switch (imageTour)
                        {
                            case "images\\TourFeu1.png":
                                listeTours.Add(new TourFeu(MousePosition.X, MousePosition.Y, "images\\TourFeu1.png"));

                                break;
                            case "images\\TourGlace1.png":
                                listeTours.Add(new TourGlace(MousePosition.X, MousePosition.Y, "images\\TourGlace1.png"));
                                break;
                            case "images\\TourMagie1.png":
                                listeTours.Add(new TourMagie(MousePosition.X, MousePosition.Y, "images\\TourMagie1.png"));
                                break;
                            case "images\\TourBombe1.png":
                                listeTours.Add(new TourBombe(MousePosition.X, MousePosition.Y, "images\\TourBombe1.png"));
                                break;
                            case "images\\TourElec1.png":
                                listeTours.Add(new TourElec(MousePosition.X, MousePosition.Y, "images\\TourElec1.png"));
                                break;
                        }
                        nombreOr = nombreOr - tour.PrixAchat;
                        LblArgent.Text = nombreOr.ToString();
                    }
                }
                else
                {
                    switch (imageTour)
                    {
                        case "images\\TourFeu1.png":
                            listeTours.Add(new TourFeu(MousePosition.X, MousePosition.Y, "images\\TourFeu1.png"));
                            break;
                        case "images\\TourGlace1.png":
                            listeTours.Add(new TourGlace(MousePosition.X, MousePosition.Y, "images\\TourGlace1.png"));
                            break;
                        case "images\\TourMagie1.png":
                            listeTours.Add(new TourMagie(MousePosition.X, MousePosition.Y, "images\\TourMagie1.png"));
                            break;
                        case "images\\TourBombe1.png":
                            listeTours.Add(new TourBombe(MousePosition.X, MousePosition.Y, "images\\TourBombe1.png"));
                            break;
                        case "images\\TourElec1.png":
                            listeTours.Add(new TourElec(MousePosition.X, MousePosition.Y, "images\\TourElec1.png"));
                            break;
                    }
                    nombreOr = nombreOr - tour.PrixAchat;
                    LblArgent.Text = nombreOr.ToString();
                    premiereTour = false;

                }
            }
            if (tour is not null)
            {
                tour.Disposer();
                tour = null;
            }

        }


        /// <summary>
        /// dessine des �l�ments
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (tour is not null)
                tour.Dessiner(e.Graphics);

            foreach (Tours tour in listeTours)
                tour.Dessiner(e.Graphics);

            foreach (Enemie enemie in listeEnemies)
                enemie.Dessiner(e.Graphics);

            if (listeProjectile.Count > 0)
                foreach (Projectile projectile in listeProjectile)
                    projectile.Dessiner(e.Graphics);
        }

        /// <summary>
        /// bouton de la tour de feu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFeu_Click(object sender, EventArgs e)
        {
            imageTour = "images\\TourFeu1.png";
            btnFeu.BackColor = Color.DarkGray;
            btnGlace.BackColor = Color.White;
            btnMagie.BackColor = Color.White;
            btnBombe.BackColor = Color.White;
            btnElec.BackColor = Color.White;
            btnDetruire.BackColor = Color.White;
            btnAmeliore.BackColor = Color.White;
            ameliorer = false;
            detruire = false;
            LblAmelioration.Text = "Prix d'achat 20 Or";
        }
        /// <summary>
        /// bouton de la tour de glace
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGlace_Click(object sender, EventArgs e)
        {
            imageTour = "images\\TourGlace1.png";
            btnFeu.BackColor = Color.White;
            btnGlace.BackColor = Color.DarkGray;
            btnMagie.BackColor = Color.White;
            btnBombe.BackColor = Color.White;
            btnElec.BackColor = Color.White;
            btnDetruire.BackColor = Color.White;
            btnAmeliore.BackColor = Color.White;
            ameliorer = false;
            detruire = false;
            LblAmelioration.Text = "Prix d'achat 30 Or";
        }
        /// <summary>
        /// boutton de la tour de magie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMagie_Click(object sender, EventArgs e)
        {
            imageTour = "images\\TourMagie1.png";
            btnFeu.BackColor = Color.White;
            btnGlace.BackColor = Color.White;
            btnMagie.BackColor = Color.DarkGray;
            btnBombe.BackColor = Color.White;
            btnElec.BackColor = Color.White;
            btnDetruire.BackColor = Color.White;
            btnAmeliore.BackColor = Color.White;
            ameliorer = false;
            detruire = false;
            LblAmelioration.Text = "Prix d'achat 40 Or";
        }

        /// <summary>
        /// boutton de la tour de bombe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBombe_Click(object sender, EventArgs e)
        {
            imageTour = "images\\TourBombe1.png";
            btnFeu.BackColor = Color.White;
            btnGlace.BackColor = Color.White;
            btnMagie.BackColor = Color.White;
            btnBombe.BackColor = Color.DarkGray;
            btnElec.BackColor = Color.White;
            btnDetruire.BackColor = Color.White;
            btnAmeliore.BackColor = Color.White;
            ameliorer = false;
            detruire = false;
            LblAmelioration.Text = "Prix d'achat 70 Or";
        }

        /// <summary>
        /// boutton de la tour d'�lectricit�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnElec_Click(object sender, EventArgs e)
        {
            imageTour = "images\\TourElec1.png";
            btnFeu.BackColor = Color.White;
            btnGlace.BackColor = Color.White;
            btnMagie.BackColor = Color.White;
            btnBombe.BackColor = Color.White;
            btnElec.BackColor = Color.DarkGray;
            btnDetruire.BackColor = Color.White;
            btnAmeliore.BackColor = Color.White;
            ameliorer = false;
            detruire = false;
            LblAmelioration.Text = "Prix d'achat 50 Or";
        }

        /// <summary>
        /// bouton de destruction de tour
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetruire_Click(object sender, EventArgs e)
        {
            imageTour = null;
            btnFeu.BackColor = Color.White;
            btnGlace.BackColor = Color.White;
            btnMagie.BackColor = Color.White;
            btnBombe.BackColor = Color.White;
            btnElec.BackColor = Color.White;
            btnDetruire.BackColor = Color.DarkGray;
            btnAmeliore.BackColor = Color.White;
            ameliorer = false;
            detruire = true;
        }

        /// <summary>
        ///  bouton d'am�lioration de tour
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAmeliore_Click(object sender, EventArgs e)
        {
            imageTour = null;
            btnFeu.BackColor = Color.White;
            btnGlace.BackColor = Color.White;
            btnMagie.BackColor = Color.White;
            btnBombe.BackColor = Color.White;
            btnElec.BackColor = Color.White;
            btnDetruire.BackColor = Color.White;
            btnAmeliore.BackColor = Color.DarkGray;
            ameliorer = true;
            detruire = false;
        }

        /// <summary>
        /// Gestion du mouvement de la souris
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (ameliorer)
            {
                bool vide = false;
                foreach (Tours tour in listeTours)
                    if (tour.Boite.Contains(e.Location))
                    {
                        if (tour.Niveau < 3)
                            LblAmelioration.Text = $"Prix Am�lioration : {tour.PrixAmelioration.ToString()} Or";
                        else
                            LblAmelioration.Text = "Am�lioration Maximum";
                        vide = true;
                        break;
                    }
                if (!vide)
                    LblAmelioration.Text = "Aucune tour selectionn�";
                vide = false;
            }
            if (detruire)
            {
                bool vide = false;
                foreach (Tours tour in listeTours)
                    if (tour.Boite.Contains(e.Location))
                    {
                        LblAmelioration.Text = $"Remboursement : {(tour.OrDepense / 2).ToString()} Or";
                        vide = true;
                        break;
                    }
                if (listeTours.Count == 0)
                    premiereTour = true;
                if (!vide)
                    LblAmelioration.Text = "Aucune tour selectionn�";
                vide = false;
            }
        }

        /// <summary>
        /// compteur pour l'animation de l'or
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            switch (CompteurAnimOr)
            {
                case 0:
                    lblOr.Image = Image.FromFile("images\\Or1.png");
                    CompteurAnimOr++;
                    break;
                case 1:
                    lblOr.Image = Image.FromFile("images\\Or2.png");
                    CompteurAnimOr++;
                    break;
                case 2:
                    lblOr.Image = Image.FromFile("images\\Or3.png");
                    CompteurAnimOr++;
                    break;
                case 3:
                    lblOr.Image = Image.FromFile("images\\Or4.png");
                    CompteurAnimOr++;
                    break;
                case 4:
                    lblOr.Image = Image.FromFile("images\\Or5.png");
                    CompteurAnimOr++;
                    break;
                case 5:
                    lblOr.Image = Image.FromFile("images\\Or6.png");
                    CompteurAnimOr++;
                    break;
                case 6:
                    lblOr.Image = Image.FromFile("images\\Or7.png");
                    CompteurAnimOr++;
                    break;
                case 7:
                    lblOr.Image = Image.FromFile("images\\Or8.png");
                    CompteurAnimOr = 0;
                    break;
            }
        }

        /// <summary>
        /// timmer pour l'attaque des tours
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerAttaqueTour_Tick(object sender, EventArgs e)
        {
            if (listeTours.Count > 0)
                foreach (Tours tours in listeTours)
                {
                    if (tours.VitesseAttaqueCompteur >= tours.VitesseAttaque)
                    {
                        foreach (Enemie enemie in listeEnemies)
                        {
                            if (tours.PeuxAttaquer(enemie))
                            {
                                Projectile projectile = null;

                                if (tours is TourFeu)
                                {
                                    projectile = new Projectile(tours, "images\\BouleFeu.png");
                                    projectile.TypeProjectile = "Feu";
                                }

                                if (tours is TourMagie)
                                {
                                    projectile = new Projectile(tours, "images\\BouleMagie.png");
                                    projectile.TypeProjectile = "Magie";
                                }

                                if (tours is TourBombe)
                                {
                                    projectile = new Projectile(tours, "images\\BouleBombe.png");
                                    projectile.TypeProjectile = "Bombe";
                                }

                                if (tours is TourGlace)
                                {
                                    if (!enemie.ralentie)
                                    {
                                        projectile = new Projectile(tours, "images\\BouleGlace.png");
                                        projectile.TypeProjectile = "Glace";
                                    }
                                }

                                if (tours is TourElec)
                                {
                                    projectile = new Projectile(tours, "images\\BouleElec.png");
                                    projectile.TypeProjectile = "Elec";
                                }

                                if (projectile is not null)
                                {
                                    projectile.ChoisirdirectionFutur(enemie);
                                    listeProjectile.Add(projectile);
                                    tours.VitesseAttaqueCompteur = 0;
                                    break;
                                }
                            }
                        }

                    }
                    tours.VitesseAttaqueCompteur++;
                }
        }
        /// <summary>
        /// timer pour l'apparition des ennemies
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerApparition_Tick(object sender, EventArgs e)
        {
            if (!(vague % 10 == 0))
            {
                if (listeEnemies.Count < nombreEnemieMax)
                {
                    switch (Random.Next(0, 3))
                    {
                        case 0:
                            listeEnemies.Add(new Gobelin());
                            break;
                        case 1:
                            listeEnemies.Add(new Chevalier());
                            break;
                        case 2:
                            listeEnemies.Add(new Skelette());
                            break;
                        case 3:
                            break;
                    }
                }
            }
            else
            {
                if (listeEnemies.Count < 1)
                {
                    listeEnemies.Add(new Goab());
                }
            }
        }

        /// <summary>
        /// commencement de la partie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCommencer_Click(object sender, EventArgs e)
        {
            timerApparition.Start();
            btnCommencer.Visible = false;
            btnSauvegarder.Visible = false;
        }

        /// <summary>
        /// timer de fin de vague
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerFinVague_Tick(object sender, EventArgs e)
        {
            if (listeEnemies.Count == 0)
            {
                timerFinVague.Stop();
                MessageBox.Show($"Vague {vague} termin�e! Pr�parez-vous pour la prochaine vague. Voici {vague * OrBonus} Or pour toi !");
                nombreOr = nombreOr + (vague * OrBonus);
                vague++;
                LblArgent.Text = nombreOr.ToString();
                lblVague.Text = $"Vague : {vague.ToString()}";
                btnCommencer.Visible = true;
                btnCommencer.Text = $"Commencer Vague {vague} ";
                btnSauvegarder.Visible = true;
            }
        }
        /// <summary>
        /// bouton pour ouvrir une sauvegarde
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOuvrir_Click(object sender, EventArgs e)
        {
            if (listViewSauvegarde.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewSauvegarde.SelectedItems[0];
                int sauvegardeId = int.Parse(item.SubItems[0].Text);
                Sauvegarde save = sauvegardes.First(s => s.Id == sauvegardeId);
                Utilisateur user = utilisateursService.Obtenir(save.IdUser);
                IdUtilisateurConnecte = user.Id;
                nombreOr = save.Argent;
                vague = save.Vague;
                score = save.Score;
                listeTours.Clear();
                listeTours = toursService.ObtenirTous(save.Id);
                LblArgent.Text = nombreOr.ToString();
                lblVague.Text = $"Vague : {vague.ToString()}";
                lblScore.Text = "Score : " + score.ToString();

                if (utilisateursService.Existe(IdUtilisateurConnecte))
                {
                    BtnNP.Visible = false;
                    BtnCharger.Visible = false;
                    LblTitre.Visible = false;
                    btnCommencer.Visible = true;
                    btnAmeliore.Visible = true;
                    btnBombe.Visible = true;
                    btnDetruire.Visible = true;
                    btnElec.Visible = true;
                    btnFeu.Visible = true;
                    btnGlace.Visible = true;
                    btnMagie.Visible = true;
                    lblOr.Visible = true;
                    LblAmelioration.Visible = true;
                    LblArgent.Visible = true;
                    lblScore.Visible = true;
                    lblVague.Visible = true;
                    lblPV.Visible = true;
                    btnOuvrir.Visible = false;
                    btnSuprimer.Visible = false;
                    listViewSauvegarde.Visible = false;
                    btnSauvegarder.Visible = true;
                    timerPrincipal.Start();
                    timerAnimation.Start();
                    timerAttaqueTour.Start();
                    premiereTour = false;
                }
                else
                {
                    MessageBox.Show("Erreur lors de la cr�ation de l'utilisateur. Veuillez r�essayer.");
                }
            }

        }

        /// <summary>
        /// suppression d'une sauvegarde
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSuprimer_Click(object sender, EventArgs e)
        {
            if (listViewSauvegarde.SelectedItems.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("�tes-vous s�re de supprimer ce personnage ?", "GestionPersonnage", MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }

                ListViewItem item = listViewSauvegarde.SelectedItems[0];
                int sauvegardeId = int.Parse(item.SubItems[0].Text);
                Sauvegarde save = sauvegardes.First(s => s.Id == sauvegardeId);
                toursService.Supprimer(save.Id);
                sauvegardeService.Supprimer(save.Id);
                RafraichirListeView();
            }

        }

        /// <summary>
        /// confirmation du courriel et du nom d'utilisateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComfirmee_Click(object sender, EventArgs e)
        {
            List<string> ListeErreur = Courriel.ValiderCourriel(textBoxCouriel.Text);
            if (textBoxUtilisateur.Text != "Nom utilisateur" && ListeErreur.Count == 0)
            {
                textBoxUtilisateur.Visible = false;
                textBoxCouriel.Visible = false;
                btnComfirmee.Visible = false;
                userBool = true;
            }
            else
            {
                string messageErreur = "";

                foreach (string erreur in ListeErreur)
                    messageErreur += $"{erreur} \n";
                MessageBox.Show($"Veuillez entrer un nom d'utilisateur valide et un courriel qui ne comporte pas ces erreur : \n {messageErreur}");
            }
        }



        /// <summary>
        /// bouton de sauvegarde
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSauvegarder_Click(object sender, EventArgs e)
        {
            Sauvegarde save = new Sauvegarde();
            save.NomSave = $"Save de {textBoxUtilisateur.Text}";
            save.Argent = nombreOr;
            save.Vague = vague;
            save.Score = score;
            save.IdUser = IdUtilisateurConnecte;
            sauvegardeService.Ajouter(save);
            foreach (Tours tour in listeTours)
            {
                toursService.Ajouter(tour, save.Id);

            }
            MessageBox.Show("Sauvegarde r�ussie !");
        }
    }
}
