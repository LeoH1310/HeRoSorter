
namespace HeRoSorter
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.btnSort = new System.Windows.Forms.Button();
            this.rbFilm = new System.Windows.Forms.RadioButton();
            this.rbSerie = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(633, 77);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 50);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Pfad..";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbPath
            // 
            this.tbPath.Enabled = false;
            this.tbPath.Location = new System.Drawing.Point(53, 91);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(500, 22);
            this.tbPath.TabIndex = 1;
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(53, 181);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(100, 40);
            this.btnSort.TabIndex = 2;
            this.btnSort.Text = "HeRoSort!";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // rbFilm
            // 
            this.rbFilm.AutoSize = true;
            this.rbFilm.Location = new System.Drawing.Point(121, 135);
            this.rbFilm.Name = "rbFilm";
            this.rbFilm.Size = new System.Drawing.Size(54, 21);
            this.rbFilm.TabIndex = 3;
            this.rbFilm.Text = "Film";
            this.rbFilm.UseVisualStyleBackColor = true;
            // 
            // rbSerie
            // 
            this.rbSerie.AutoSize = true;
            this.rbSerie.Checked = true;
            this.rbSerie.Location = new System.Drawing.Point(53, 135);
            this.rbSerie.Name = "rbSerie";
            this.rbSerie.Size = new System.Drawing.Size(62, 21);
            this.rbSerie.TabIndex = 4;
            this.rbSerie.TabStop = true;
            this.rbSerie.Text = "Serie";
            this.rbSerie.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 450);
            this.Controls.Add(this.rbSerie);
            this.Controls.Add(this.rbFilm);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.btnSearch);
            this.Name = "MainForm";
            this.Text = "HeRoSorter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.RadioButton rbFilm;
        private System.Windows.Forms.RadioButton rbSerie;
    }
}

