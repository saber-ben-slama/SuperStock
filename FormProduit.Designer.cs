namespace PFA
{
    partial class FormProduit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.code_prd = new System.Windows.Forms.TextBox();
            this.Lsproduit = new System.Windows.Forms.ListBox();
            this.button5 = new System.Windows.Forms.Button();
            this.AddbtnChauffeur = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nom_prd = new System.Windows.Forms.TextBox();
            this.Nom = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // code_prd
            // 
            this.code_prd.Enabled = false;
            this.code_prd.Location = new System.Drawing.Point(131, 40);
            this.code_prd.Name = "code_prd";
            this.code_prd.Size = new System.Drawing.Size(122, 20);
            this.code_prd.TabIndex = 0;
            // 
            // Lsproduit
            // 
            this.Lsproduit.FormattingEnabled = true;
            this.Lsproduit.Location = new System.Drawing.Point(317, 40);
            this.Lsproduit.Name = "Lsproduit";
            this.Lsproduit.Size = new System.Drawing.Size(120, 186);
            this.Lsproduit.TabIndex = 1;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImage = global::PFA.Properties.Resources.png_transparent_x_red_mark_incorrect_thumbnail;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.Transparent;
            this.button5.Location = new System.Drawing.Point(455, 40);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(23, 23);
            this.button5.TabIndex = 27;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // AddbtnChauffeur
            // 
            this.AddbtnChauffeur.BackColor = System.Drawing.Color.Transparent;
            this.AddbtnChauffeur.BackgroundImage = global::PFA.Properties.Resources.vector_flecha;
            this.AddbtnChauffeur.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddbtnChauffeur.Cursor = System.Windows.Forms.Cursors.Default;
            this.AddbtnChauffeur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddbtnChauffeur.ForeColor = System.Drawing.Color.Transparent;
            this.AddbtnChauffeur.Location = new System.Drawing.Point(270, 40);
            this.AddbtnChauffeur.Name = "AddbtnChauffeur";
            this.AddbtnChauffeur.Size = new System.Drawing.Size(27, 22);
            this.AddbtnChauffeur.TabIndex = 26;
            this.AddbtnChauffeur.UseVisualStyleBackColor = false;
            this.AddbtnChauffeur.Click += new System.EventHandler(this.AddbtnChauffeur_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 18);
            this.label3.TabIndex = 28;
            this.label3.Text = "Code Produit";
            // 
            // nom_prd
            // 
            this.nom_prd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nom_prd.Location = new System.Drawing.Point(131, 83);
            this.nom_prd.Name = "nom_prd";
            this.nom_prd.Size = new System.Drawing.Size(122, 20);
            this.nom_prd.TabIndex = 29;
            // 
            // Nom
            // 
            this.Nom.AutoSize = true;
            this.Nom.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nom.Location = new System.Drawing.Point(12, 83);
            this.Nom.Name = "Nom";
            this.Nom.Size = new System.Drawing.Size(109, 18);
            this.Nom.TabIndex = 30;
            this.Nom.Text = "Nom Produit";
            // 
            // FormProduit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.ClientSize = new System.Drawing.Size(488, 249);
            this.Controls.Add(this.Nom);
            this.Controls.Add(this.nom_prd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.AddbtnChauffeur);
            this.Controls.Add(this.Lsproduit);
            this.Controls.Add(this.code_prd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormProduit";
            this.Text = "FormProduit";
            this.Load += new System.EventHandler(this.FormProduit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox code_prd;
        private System.Windows.Forms.ListBox Lsproduit;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button AddbtnChauffeur;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nom_prd;
        private System.Windows.Forms.Label Nom;
    }
}