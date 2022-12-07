
namespace IPTVM3UGenerator
{
    partial class FrmGui
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
            this.LvCountries = new System.Windows.Forms.ListView();
            this.Pb = new System.Windows.Forms.ProgressBar();
            this.BtnGen = new System.Windows.Forms.Button();
            this.LblGen = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LvCountries
            // 
            this.LvCountries.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.LvCountries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LvCountries.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.LvCountries.CheckBoxes = true;
            this.LvCountries.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LvCountries.HideSelection = false;
            this.LvCountries.LabelWrap = false;
            this.LvCountries.Location = new System.Drawing.Point(12, 12);
            this.LvCountries.MultiSelect = false;
            this.LvCountries.Name = "LvCountries";
            this.LvCountries.Size = new System.Drawing.Size(724, 413);
            this.LvCountries.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.LvCountries.TabIndex = 0;
            this.LvCountries.UseCompatibleStateImageBehavior = false;
            this.LvCountries.View = System.Windows.Forms.View.List;
            this.LvCountries.SelectedIndexChanged += new System.EventHandler(this.LvCountries_SelectedIndexChanged);
            // 
            // Pb
            // 
            this.Pb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Pb.Location = new System.Drawing.Point(12, 431);
            this.Pb.Name = "Pb";
            this.Pb.Size = new System.Drawing.Size(643, 23);
            this.Pb.TabIndex = 1;
            // 
            // BtnGen
            // 
            this.BtnGen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGen.Location = new System.Drawing.Point(661, 431);
            this.BtnGen.Name = "BtnGen";
            this.BtnGen.Size = new System.Drawing.Size(75, 23);
            this.BtnGen.TabIndex = 2;
            this.BtnGen.Text = "Generate";
            this.BtnGen.UseVisualStyleBackColor = true;
            this.BtnGen.Click += new System.EventHandler(this.BtnGen_Click);
            // 
            // LblGen
            // 
            this.LblGen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblGen.AutoSize = true;
            this.LblGen.ForeColor = System.Drawing.SystemColors.Info;
            this.LblGen.Location = new System.Drawing.Point(12, 436);
            this.LblGen.Name = "LblGen";
            this.LblGen.Size = new System.Drawing.Size(260, 17);
            this.LblGen.TabIndex = 3;
            this.LblGen.Text = "Select some countries and clic on Generate button.";
            this.LblGen.UseCompatibleTextRendering = true;
            // 
            // FrmGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(748, 467);
            this.Controls.Add(this.LblGen);
            this.Controls.Add(this.BtnGen);
            this.Controls.Add(this.Pb);
            this.Controls.Add(this.LvCountries);
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "FrmGui";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IPTV M3U Generator";
            this.Shown += new System.EventHandler(this.FrmGui_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView LvCountries;
        private System.Windows.Forms.ProgressBar Pb;
        private System.Windows.Forms.Button BtnGen;
        private System.Windows.Forms.Label LblGen;
    }
}

