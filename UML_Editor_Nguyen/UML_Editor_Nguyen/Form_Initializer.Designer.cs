namespace UML_Editor_Nguyen
{
    partial class Form_Initializer
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
            this.btn_OpenExisting = new System.Windows.Forms.Button();
            this.btn_New = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(66, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "UML Class Diagram";
            // 
            // btn_OpenExisting
            // 
            this.btn_OpenExisting.Location = new System.Drawing.Point(12, 75);
            this.btn_OpenExisting.Name = "btn_OpenExisting";
            this.btn_OpenExisting.Size = new System.Drawing.Size(161, 55);
            this.btn_OpenExisting.TabIndex = 1;
            this.btn_OpenExisting.Text = "Otevřít";
            this.btn_OpenExisting.UseVisualStyleBackColor = true;
            this.btn_OpenExisting.Click += new System.EventHandler(this.btn_OpenExisting_Click);
            // 
            // btn_New
            // 
            this.btn_New.Location = new System.Drawing.Point(273, 75);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(161, 55);
            this.btn_New.TabIndex = 2;
            this.btn_New.Text = "Nový";
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // Form_Initializer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 142);
            this.Controls.Add(this.btn_New);
            this.Controls.Add(this.btn_OpenExisting);
            this.Controls.Add(this.label1);
            this.Name = "Form_Initializer";
            this.Text = "Form_Initializer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button btn_OpenExisting;
        private Button btn_New;
    }
}