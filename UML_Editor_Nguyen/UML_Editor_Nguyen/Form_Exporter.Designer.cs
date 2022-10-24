namespace UML_Editor_Nguyen
{
    partial class Form_Exporter
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_SaveToFile = new System.Windows.Forms.Button();
            this.btn_SaveToPicture = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(80, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Uložení projektu";
            // 
            // btn_SaveToFile
            // 
            this.btn_SaveToFile.Location = new System.Drawing.Point(12, 82);
            this.btn_SaveToFile.Name = "btn_SaveToFile";
            this.btn_SaveToFile.Size = new System.Drawing.Size(179, 49);
            this.btn_SaveToFile.TabIndex = 1;
            this.btn_SaveToFile.Text = "Uložit do souboru";
            this.btn_SaveToFile.UseVisualStyleBackColor = true;
            this.btn_SaveToFile.Click += new System.EventHandler(this.btn_SaveToFile_Click);
            // 
            // btn_SaveToPicture
            // 
            this.btn_SaveToPicture.Location = new System.Drawing.Point(248, 82);
            this.btn_SaveToPicture.Name = "btn_SaveToPicture";
            this.btn_SaveToPicture.Size = new System.Drawing.Size(179, 49);
            this.btn_SaveToPicture.TabIndex = 2;
            this.btn_SaveToPicture.Text = "Exportovat do obrázku";
            this.btn_SaveToPicture.UseVisualStyleBackColor = true;
            this.btn_SaveToPicture.Click += new System.EventHandler(this.btn_SaveToPicture_Click);
            // 
            // Form_Exporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 143);
            this.Controls.Add(this.btn_SaveToPicture);
            this.Controls.Add(this.btn_SaveToFile);
            this.Controls.Add(this.label1);
            this.Name = "Form_Exporter";
            this.Text = "Form_Exporter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button btn_SaveToFile;
        private Button btn_SaveToPicture;
    }
}