namespace Jeu
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            LblTitre = new Label();
            BtnNP = new Button();
            BtnFerme = new Button();
            BtnCharger = new Button();
            timerPrincipal = new System.Windows.Forms.Timer(components);
            btnFeu = new Button();
            btnGlace = new Button();
            btnMagie = new Button();
            btnBombe = new Button();
            btnElec = new Button();
            btnDetruire = new Button();
            btnAmeliore = new Button();
            LblAmelioration = new Label();
            lblOr = new Label();
            timerAnimation = new System.Windows.Forms.Timer(components);
            LblArgent = new Label();
            timerAttaqueTour = new System.Windows.Forms.Timer(components);
            timerApparition = new System.Windows.Forms.Timer(components);
            btnCommencer = new Button();
            lblScore = new Label();
            timerFinVague = new System.Windows.Forms.Timer(components);
            lblVague = new Label();
            lblPV = new Label();
            listViewSauvegarde = new ListView();
            btnOuvrir = new Button();
            btnSuprimer = new Button();
            btnSauvegarder = new Button();
            textBoxUtilisateur = new TextBox();
            btnComfirmee = new Button();
            textBoxCouriel = new TextBox();
            SuspendLayout();
            // 
            // LblTitre
            // 
            LblTitre.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LblTitre.BackColor = Color.Transparent;
            LblTitre.Font = new Font("Microsoft Sans Serif", 27F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblTitre.ForeColor = Color.Black;
            LblTitre.Image = Properties.Resources.LabelTitre1;
            LblTitre.Location = new Point(772, 47);
            LblTitre.Name = "LblTitre";
            LblTitre.Size = new Size(457, 161);
            LblTitre.TabIndex = 1;
            LblTitre.Text = "Tower Deadfence";
            LblTitre.TextAlign = ContentAlignment.MiddleCenter;
            LblTitre.Click += BtnNP_Click;
            // 
            // BtnNP
            // 
            BtnNP.BackColor = Color.Transparent;
            BtnNP.BackgroundImage = Properties.Resources.LabelStart1;
            BtnNP.BackgroundImageLayout = ImageLayout.Center;
            BtnNP.FlatAppearance.BorderSize = 0;
            BtnNP.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnNP.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BtnNP.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnNP.ForeColor = SystemColors.Desktop;
            BtnNP.Location = new Point(820, 530);
            BtnNP.Name = "BtnNP";
            BtnNP.Size = new Size(300, 129);
            BtnNP.TabIndex = 0;
            BtnNP.Text = "Nouvelle Partie";
            BtnNP.UseVisualStyleBackColor = false;
            BtnNP.Click += BtnNP_Click;
            // 
            // BtnFerme
            // 
            BtnFerme.BackColor = SystemColors.ActiveCaptionText;
            BtnFerme.ForeColor = Color.Black;
            BtnFerme.Image = Properties.Resources.BtnFermer;
            BtnFerme.Location = new Point(1860, 10);
            BtnFerme.Name = "BtnFerme";
            BtnFerme.Size = new Size(50, 50);
            BtnFerme.TabIndex = 2;
            BtnFerme.UseVisualStyleBackColor = false;
            BtnFerme.Click += BtnFerme_Click;
            // 
            // BtnCharger
            // 
            BtnCharger.BackColor = Color.Transparent;
            BtnCharger.BackgroundImage = Properties.Resources.LabelStart1;
            BtnCharger.BackgroundImageLayout = ImageLayout.Center;
            BtnCharger.FlatAppearance.BorderSize = 0;
            BtnCharger.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnCharger.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BtnCharger.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnCharger.ForeColor = SystemColors.Desktop;
            BtnCharger.Location = new Point(820, 737);
            BtnCharger.Name = "BtnCharger";
            BtnCharger.Size = new Size(300, 129);
            BtnCharger.TabIndex = 3;
            BtnCharger.Text = "Charger Partie";
            BtnCharger.UseVisualStyleBackColor = false;
            BtnCharger.Click += BtnCharger_Click;
            // 
            // timerPrincipal
            // 
            timerPrincipal.Interval = 20;
            timerPrincipal.Tick += timerPrincipal_Tick;
            // 
            // btnFeu
            // 
            btnFeu.BackgroundImage = Properties.Resources.btnFeu1;
            btnFeu.BackgroundImageLayout = ImageLayout.Center;
            btnFeu.Location = new Point(1835, 87);
            btnFeu.Name = "btnFeu";
            btnFeu.Size = new Size(75, 75);
            btnFeu.TabIndex = 4;
            btnFeu.UseVisualStyleBackColor = true;
            btnFeu.Visible = false;
            btnFeu.Click += btnFeu_Click;
            // 
            // btnGlace
            // 
            btnGlace.BackgroundImage = Properties.Resources.Glaceimg1;
            btnGlace.BackgroundImageLayout = ImageLayout.Center;
            btnGlace.Location = new Point(1835, 189);
            btnGlace.Name = "btnGlace";
            btnGlace.Size = new Size(75, 75);
            btnGlace.TabIndex = 5;
            btnGlace.UseVisualStyleBackColor = true;
            btnGlace.Visible = false;
            btnGlace.Click += btnGlace_Click;
            // 
            // btnMagie
            // 
            btnMagie.BackgroundImage = Properties.Resources.magieimg1;
            btnMagie.BackgroundImageLayout = ImageLayout.Center;
            btnMagie.Location = new Point(1835, 298);
            btnMagie.Name = "btnMagie";
            btnMagie.Size = new Size(75, 75);
            btnMagie.TabIndex = 6;
            btnMagie.UseVisualStyleBackColor = true;
            btnMagie.Visible = false;
            btnMagie.Click += btnMagie_Click;
            // 
            // btnBombe
            // 
            btnBombe.BackgroundImage = Properties.Resources.cannonimg1;
            btnBombe.BackgroundImageLayout = ImageLayout.Center;
            btnBombe.Location = new Point(1835, 397);
            btnBombe.Name = "btnBombe";
            btnBombe.Size = new Size(75, 75);
            btnBombe.TabIndex = 7;
            btnBombe.UseVisualStyleBackColor = true;
            btnBombe.Visible = false;
            btnBombe.Click += btnBombe_Click;
            // 
            // btnElec
            // 
            btnElec.BackgroundImage = Properties.Resources.electriciteimg1;
            btnElec.BackgroundImageLayout = ImageLayout.Center;
            btnElec.Location = new Point(1835, 500);
            btnElec.Name = "btnElec";
            btnElec.Size = new Size(75, 75);
            btnElec.TabIndex = 8;
            btnElec.UseVisualStyleBackColor = true;
            btnElec.Visible = false;
            btnElec.Click += btnElec_Click;
            // 
            // btnDetruire
            // 
            btnDetruire.BackgroundImage = Properties.Resources.detruireimg1;
            btnDetruire.BackgroundImageLayout = ImageLayout.Center;
            btnDetruire.Location = new Point(1835, 601);
            btnDetruire.Name = "btnDetruire";
            btnDetruire.Size = new Size(75, 75);
            btnDetruire.TabIndex = 9;
            btnDetruire.UseVisualStyleBackColor = true;
            btnDetruire.Visible = false;
            btnDetruire.Click += btnDetruire_Click;
            // 
            // btnAmeliore
            // 
            btnAmeliore.BackgroundImage = Properties.Resources.ameimg1;
            btnAmeliore.BackgroundImageLayout = ImageLayout.Center;
            btnAmeliore.Location = new Point(1835, 708);
            btnAmeliore.Name = "btnAmeliore";
            btnAmeliore.Size = new Size(75, 75);
            btnAmeliore.TabIndex = 10;
            btnAmeliore.UseVisualStyleBackColor = true;
            btnAmeliore.Visible = false;
            btnAmeliore.Click += btnAmeliore_Click;
            // 
            // LblAmelioration
            // 
            LblAmelioration.AutoSize = true;
            LblAmelioration.BackColor = Color.Transparent;
            LblAmelioration.FlatStyle = FlatStyle.Flat;
            LblAmelioration.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblAmelioration.ForeColor = SystemColors.Control;
            LblAmelioration.Location = new Point(26, 153);
            LblAmelioration.Name = "LblAmelioration";
            LblAmelioration.Size = new Size(222, 25);
            LblAmelioration.TabIndex = 13;
            LblAmelioration.Text = "Aucune tour selectionné";
            LblAmelioration.TextAlign = ContentAlignment.MiddleCenter;
            LblAmelioration.UseMnemonic = false;
            LblAmelioration.Visible = false;
            // 
            // lblOr
            // 
            lblOr.BackColor = Color.Transparent;
            lblOr.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOr.Image = Properties.Resources.Or1;
            lblOr.Location = new Point(26, 10);
            lblOr.Name = "lblOr";
            lblOr.RightToLeft = RightToLeft.Yes;
            lblOr.Size = new Size(50, 50);
            lblOr.TabIndex = 14;
            lblOr.TextAlign = ContentAlignment.MiddleCenter;
            lblOr.Visible = false;
            // 
            // timerAnimation
            // 
            timerAnimation.Tick += timerAnimation_Tick;
            // 
            // LblArgent
            // 
            LblArgent.AutoSize = true;
            LblArgent.BackColor = Color.Transparent;
            LblArgent.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblArgent.ForeColor = Color.White;
            LblArgent.Location = new Point(80, 20);
            LblArgent.Name = "LblArgent";
            LblArgent.Size = new Size(44, 31);
            LblArgent.TabIndex = 15;
            LblArgent.Text = "50";
            LblArgent.Visible = false;
            // 
            // timerAttaqueTour
            // 
            timerAttaqueTour.Tick += timerAttaqueTour_Tick;
            // 
            // timerApparition
            // 
            timerApparition.Interval = 500;
            timerApparition.Tick += timerApparition_Tick;
            // 
            // btnCommencer
            // 
            btnCommencer.AllowDrop = true;
            btnCommencer.BackColor = Color.Chartreuse;
            btnCommencer.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCommencer.Location = new Point(12, 1003);
            btnCommencer.Name = "btnCommencer";
            btnCommencer.Size = new Size(435, 85);
            btnCommencer.TabIndex = 16;
            btnCommencer.Text = "Commencer Vague 1";
            btnCommencer.UseVisualStyleBackColor = false;
            btnCommencer.Visible = false;
            btnCommencer.Click += btnCommencer_Click;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.BackColor = Color.Transparent;
            lblScore.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblScore.ForeColor = Color.White;
            lblScore.Location = new Point(26, 121);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(85, 24);
            lblScore.TabIndex = 17;
            lblScore.Text = "Score : 0";
            lblScore.Visible = false;
            // 
            // timerFinVague
            // 
            timerFinVague.Interval = 50;
            timerFinVague.Tick += timerFinVague_Tick;
            // 
            // lblVague
            // 
            lblVague.AutoSize = true;
            lblVague.BackColor = Color.Transparent;
            lblVague.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVague.ForeColor = Color.White;
            lblVague.Location = new Point(26, 87);
            lblVague.Name = "lblVague";
            lblVague.Size = new Size(91, 24);
            lblVague.TabIndex = 18;
            lblVague.Text = "Vague : 1";
            lblVague.Visible = false;
            // 
            // lblPV
            // 
            lblPV.AutoSize = true;
            lblPV.BackColor = Color.Transparent;
            lblPV.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPV.ForeColor = Color.White;
            lblPV.Location = new Point(1673, 20);
            lblPV.Name = "lblPV";
            lblPV.Size = new Size(174, 29);
            lblPV.TabIndex = 19;
            lblPV.Text = "Point de Vie : 3";
            lblPV.Visible = false;
            // 
            // listViewSauvegarde
            // 
            listViewSauvegarde.Location = new Point(1162, 530);
            listViewSauvegarde.Name = "listViewSauvegarde";
            listViewSauvegarde.Size = new Size(194, 283);
            listViewSauvegarde.TabIndex = 22;
            listViewSauvegarde.UseCompatibleStateImageBehavior = false;
            listViewSauvegarde.Visible = false;
            // 
            // btnOuvrir
            // 
            btnOuvrir.Location = new Point(1162, 819);
            btnOuvrir.Name = "btnOuvrir";
            btnOuvrir.Size = new Size(92, 47);
            btnOuvrir.TabIndex = 23;
            btnOuvrir.Text = "Ouvrir";
            btnOuvrir.UseVisualStyleBackColor = true;
            btnOuvrir.Visible = false;
            btnOuvrir.Click += btnOuvrir_Click;
            // 
            // btnSuprimer
            // 
            btnSuprimer.Location = new Point(1264, 819);
            btnSuprimer.Name = "btnSuprimer";
            btnSuprimer.Size = new Size(92, 47);
            btnSuprimer.TabIndex = 24;
            btnSuprimer.Text = "Suprimer";
            btnSuprimer.UseVisualStyleBackColor = true;
            btnSuprimer.Visible = false;
            btnSuprimer.Click += BtnSuprimer_Click;
            // 
            // btnSauvegarder
            // 
            btnSauvegarder.BackgroundImage = Properties.Resources.imgSave2;
            btnSauvegarder.Location = new Point(1835, 805);
            btnSauvegarder.Name = "btnSauvegarder";
            btnSauvegarder.Size = new Size(75, 75);
            btnSauvegarder.TabIndex = 25;
            btnSauvegarder.UseVisualStyleBackColor = true;
            btnSauvegarder.Visible = false;
            btnSauvegarder.Click += btnSauvegarder_Click;
            // 
            // textBoxUtilisateur
            // 
            textBoxUtilisateur.ForeColor = SystemColors.WindowText;
            textBoxUtilisateur.Location = new Point(772, 285);
            textBoxUtilisateur.MaxLength = 15;
            textBoxUtilisateur.Name = "textBoxUtilisateur";
            textBoxUtilisateur.Size = new Size(163, 23);
            textBoxUtilisateur.TabIndex = 26;
            textBoxUtilisateur.Text = "Nom utilisateur";
            // 
            // btnComfirmee
            // 
            btnComfirmee.Location = new Point(772, 350);
            btnComfirmee.Name = "btnComfirmee";
            btnComfirmee.Size = new Size(75, 23);
            btnComfirmee.TabIndex = 27;
            btnComfirmee.Text = "Confirmée";
            btnComfirmee.UseVisualStyleBackColor = true;
            btnComfirmee.Click += btnComfirmee_Click;
            // 
            // textBoxCouriel
            // 
            textBoxCouriel.Location = new Point(773, 320);
            textBoxCouriel.Name = "textBoxCouriel";
            textBoxCouriel.Size = new Size(162, 23);
            textBoxCouriel.TabIndex = 28;
            textBoxCouriel.Text = "Couriel";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = Properties.Resources.unnamed;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1928, 1100);
            Controls.Add(textBoxCouriel);
            Controls.Add(btnComfirmee);
            Controls.Add(textBoxUtilisateur);
            Controls.Add(btnSauvegarder);
            Controls.Add(btnSuprimer);
            Controls.Add(btnOuvrir);
            Controls.Add(listViewSauvegarde);
            Controls.Add(lblPV);
            Controls.Add(lblVague);
            Controls.Add(lblScore);
            Controls.Add(btnCommencer);
            Controls.Add(LblArgent);
            Controls.Add(lblOr);
            Controls.Add(LblAmelioration);
            Controls.Add(btnAmeliore);
            Controls.Add(btnDetruire);
            Controls.Add(btnElec);
            Controls.Add(btnBombe);
            Controls.Add(btnMagie);
            Controls.Add(btnGlace);
            Controls.Add(btnFeu);
            Controls.Add(BtnCharger);
            Controls.Add(BtnFerme);
            Controls.Add(LblTitre);
            Controls.Add(BtnNP);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Form1";
            Paint += Form1_Paint;
            MouseDown += Form1_MouseDown;
            MouseMove += Form1_MouseMove;
            MouseUp += Form1_MouseUp;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label LblTitre;
        private Button BtnNP;
        private Button BtnFerme;
        private Button BtnCharger;
        private System.Windows.Forms.Timer timerPrincipal;
        private Button btnFeu;
        private Button btnGlace;
        private Button btnMagie;
        private Button btnBombe;
        private Button btnElec;
        private Button btnDetruire;
        private Button btnAmeliore;
        private Label LblAmelioration;
        private Label lblOr;
        private System.Windows.Forms.Timer timerAnimation;
        private Label LblArgent;
        private System.Windows.Forms.Timer timerAttaqueTour;
        private System.Windows.Forms.Timer timerApparition;
        private Button btnCommencer;
        private Label lblScore;
        private System.Windows.Forms.Timer timerFinVague;
        private Label lblVague;
        private Label lblPV;
        private ListView listViewSauvegarde;
        private Button btnOuvrir;
        private Button btnSuprimer;
        private Button btnSauvegarder;
        private TextBox textBoxUtilisateur;
        private Button btnComfirmee;
        private TextBox textBoxCouriel;
    }
}
