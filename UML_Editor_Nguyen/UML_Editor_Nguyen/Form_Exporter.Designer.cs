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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_SaveToFile = new System.Windows.Forms.Button();
            this.btn_SaveToPicture = new System.Windows.Forms.Button();
            this.txt_Namespace = new System.Windows.Forms.TextBox();
            this.btn_ExportToCode = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btn_Back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(90, 9);
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
            // txt_Namespace
            // 
            this.txt_Namespace.Location = new System.Drawing.Point(12, 177);
            this.txt_Namespace.Name = "txt_Namespace";
            this.txt_Namespace.Size = new System.Drawing.Size(230, 23);
            this.txt_Namespace.TabIndex = 3;
            // 
            // btn_ExportToCode
            // 
            this.btn_ExportToCode.Location = new System.Drawing.Point(248, 176);
            this.btn_ExportToCode.Name = "btn_ExportToCode";
            this.btn_ExportToCode.Size = new System.Drawing.Size(179, 23);
            this.btn_ExportToCode.TabIndex = 4;
            this.btn_ExportToCode.Text = "Exportovat do kódu";
            this.btn_ExportToCode.UseVisualStyleBackColor = true;
            this.btn_ExportToCode.Click += new System.EventHandler(this.btn_ExportToCode_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Namespace:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(9, 12);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(75, 23);
            this.btn_Back.TabIndex = 6;
            this.btn_Back.Text = "Zpět";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // Form_Exporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(439, 242);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_ExportToCode);
            this.Controls.Add(this.txt_Namespace);
            this.Controls.Add(this.btn_SaveToPicture);
            this.Controls.Add(this.btn_SaveToFile);
            this.Controls.Add(this.label1);
            this.Name = "Form_Exporter";
            this.Text = "Form_Exporter";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button btn_SaveToFile;
        private Button btn_SaveToPicture;
        private TextBox txt_Namespace;
        private Button btn_ExportToCode;
        private Label label2;
        private ErrorProvider errorProvider1;
        private Button btn_Back;
    }
}