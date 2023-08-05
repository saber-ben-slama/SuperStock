namespace PFA
{
    partial class ListeFournisseur
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Listefourn = new System.Windows.Forms.ListBox();
            this.Recherch = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(227, 382);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 7;
            this.button1.Text = "Choisir";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "Recherche";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Listefourn
            // 
            this.Listefourn.BackColor = System.Drawing.Color.DarkGray;
            this.Listefourn.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Listefourn.ForeColor = System.Drawing.SystemColors.Info;
            this.Listefourn.FormattingEnabled = true;
            this.Listefourn.ItemHeight = 22;
            this.Listefourn.Location = new System.Drawing.Point(24, 64);
            this.Listefourn.Name = "Listefourn";
            this.Listefourn.Size = new System.Drawing.Size(278, 312);
            this.Listefourn.TabIndex = 5;
            this.Listefourn.SelectedIndexChanged += new System.EventHandler(this.Listefourn_SelectedIndexChanged);
            // 
            // Recherch
            // 
            this.Recherch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Recherch.Location = new System.Drawing.Point(127, 22);
            this.Recherch.Name = "Recherch";
            this.Recherch.Size = new System.Drawing.Size(118, 20);
            this.Recherch.TabIndex = 4;
            this.Recherch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Recherch.TextChanged += new System.EventHandler(this.Recherch_TextChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::PFA.Properties.Resources.plus_24844_960_720;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(267, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 23);
            this.button2.TabIndex = 8;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ListeFournisseur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(322, 429);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Listefourn);
            this.Controls.Add(this.Recherch);
            this.Name = "ListeFournisseur";
            this.Text = "ListeFournisseur";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox Listefourn;
        private System.Windows.Forms.TextBox Recherch;
        private System.Windows.Forms.Button button2;
    }
}