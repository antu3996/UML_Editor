﻿namespace UML_Editor_Nguyen
{
    partial class Form_Editor
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
            this.editor_Box = new System.Windows.Forms.PictureBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.editor_Box)).BeginInit();
            this.SuspendLayout();
            // 
            // editor_Box
            // 
            this.editor_Box.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.editor_Box.Location = new System.Drawing.Point(12, 12);
            this.editor_Box.Name = "editor_Box";
            this.editor_Box.Size = new System.Drawing.Size(1133, 555);
            this.editor_Box.TabIndex = 0;
            this.editor_Box.TabStop = false;
            this.editor_Box.Paint += new System.Windows.Forms.PaintEventHandler(this.editor_Box_Paint);
            this.editor_Box.DoubleClick += new System.EventHandler(this.editor_Box_DoubleClick);
            this.editor_Box.MouseDown += new System.Windows.Forms.MouseEventHandler(this.editor_Box_MouseDown);
            this.editor_Box.MouseMove += new System.Windows.Forms.MouseEventHandler(this.editor_Box_MouseMove);
            this.editor_Box.MouseUp += new System.Windows.Forms.MouseEventHandler(this.editor_Box_MouseUp);
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(12, 573);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 1;
            this.btn_Add.Text = "Přidat";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(104, 573);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(75, 23);
            this.btn_Delete.TabIndex = 2;
            this.btn_Delete.Text = "Smazat";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // Form_Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 608);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.editor_Box);
            this.Name = "Form_Editor";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.editor_Box)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox editor_Box;
        private Button btn_Add;
        private Button btn_Delete;
    }
}