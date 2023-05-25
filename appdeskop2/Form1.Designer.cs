namespace appdeskop2
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBoxnom = new System.Windows.Forms.TextBox();
            this.textBoxprenom = new System.Windows.Forms.TextBox();
            this.textBoxemail = new System.Windows.Forms.TextBox();
            this.textBoxphone = new System.Windows.Forms.TextBox();
            this.textBoxgroupe = new System.Windows.Forms.TextBox();
            this.textBoxpromotion = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 326);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(931, 210);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // textBoxnom
            // 
            this.textBoxnom.Location = new System.Drawing.Point(152, 71);
            this.textBoxnom.Name = "textBoxnom";
            this.textBoxnom.Size = new System.Drawing.Size(200, 22);
            this.textBoxnom.TabIndex = 1;
            // 
            // textBoxprenom
            // 
            this.textBoxprenom.Location = new System.Drawing.Point(152, 140);
            this.textBoxprenom.Name = "textBoxprenom";
            this.textBoxprenom.Size = new System.Drawing.Size(200, 22);
            this.textBoxprenom.TabIndex = 2;
            // 
            // textBoxemail
            // 
            this.textBoxemail.Location = new System.Drawing.Point(475, 71);
            this.textBoxemail.Name = "textBoxemail";
            this.textBoxemail.Size = new System.Drawing.Size(200, 22);
            this.textBoxemail.TabIndex = 3;
            // 
            // textBoxphone
            // 
            this.textBoxphone.Location = new System.Drawing.Point(475, 140);
            this.textBoxphone.Name = "textBoxphone";
            this.textBoxphone.Size = new System.Drawing.Size(200, 22);
            this.textBoxphone.TabIndex = 4;
            // 
            // textBoxgroupe
            // 
            this.textBoxgroupe.Location = new System.Drawing.Point(719, 71);
            this.textBoxgroupe.Name = "textBoxgroupe";
            this.textBoxgroupe.Size = new System.Drawing.Size(200, 22);
            this.textBoxgroupe.TabIndex = 5;
            // 
            // textBoxpromotion
            // 
            this.textBoxpromotion.Location = new System.Drawing.Point(719, 140);
            this.textBoxpromotion.Name = "textBoxpromotion";
            this.textBoxpromotion.Size = new System.Drawing.Size(200, 22);
            this.textBoxpromotion.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(180, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 46);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(475, 220);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 46);
            this.button2.TabIndex = 8;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 536);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxpromotion);
            this.Controls.Add(this.textBoxgroupe);
            this.Controls.Add(this.textBoxphone);
            this.Controls.Add(this.textBoxemail);
            this.Controls.Add(this.textBoxprenom);
            this.Controls.Add(this.textBoxnom);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxnom;
        private System.Windows.Forms.TextBox textBoxprenom;
        private System.Windows.Forms.TextBox textBoxemail;
        private System.Windows.Forms.TextBox textBoxphone;
        private System.Windows.Forms.TextBox textBoxgroupe;
        private System.Windows.Forms.TextBox textBoxpromotion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

