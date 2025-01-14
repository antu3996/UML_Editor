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
            this.chck_ToggleRelCreation = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_EditDataTypes = new System.Windows.Forms.Button();
            this.btn_Export = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.editor_Box)).BeginInit();
            this.SuspendLayout();
            // 
            // editor_Box
            // 
            this.editor_Box.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btn_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Add.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Add.Location = new System.Drawing.Point(12, 573);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 1;
            this.btn_Add.Text = "Přidat třídu";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Delete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Delete.Location = new System.Drawing.Point(104, 573);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(75, 23);
            this.btn_Delete.TabIndex = 2;
            this.btn_Delete.Text = "Smazat";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // chck_ToggleRelCreation
            // 
            this.chck_ToggleRelCreation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chck_ToggleRelCreation.AutoSize = true;
            this.chck_ToggleRelCreation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chck_ToggleRelCreation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chck_ToggleRelCreation.Location = new System.Drawing.Point(200, 575);
            this.chck_ToggleRelCreation.Name = "chck_ToggleRelCreation";
            this.chck_ToggleRelCreation.Size = new System.Drawing.Size(114, 20);
            this.chck_ToggleRelCreation.TabIndex = 3;
            this.chck_ToggleRelCreation.Text = "Vytvořit vazbu";
            this.chck_ToggleRelCreation.UseVisualStyleBackColor = true;
            this.chck_ToggleRelCreation.CheckedChanged += new System.EventHandler(this.chck_ToggleRelCreation_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(505, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 27);
            this.label1.TabIndex = 4;
            this.label1.Text = "Vyberte 2 třídy";
            this.label1.Visible = false;
            // 
            // btn_EditDataTypes
            // 
            this.btn_EditDataTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_EditDataTypes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_EditDataTypes.Location = new System.Drawing.Point(941, 575);
            this.btn_EditDataTypes.Name = "btn_EditDataTypes";
            this.btn_EditDataTypes.Size = new System.Drawing.Size(109, 23);
            this.btn_EditDataTypes.TabIndex = 5;
            this.btn_EditDataTypes.Text = "Upravit dat. typy";
            this.btn_EditDataTypes.UseVisualStyleBackColor = true;
            this.btn_EditDataTypes.Click += new System.EventHandler(this.btn_EditDataTypes_Click);
            // 
            // btn_Export
            // 
            this.btn_Export.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Export.Location = new System.Drawing.Point(1056, 575);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(89, 23);
            this.btn_Export.TabIndex = 6;
            this.btn_Export.Text = "Exportovat";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // Form_Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 608);
            this.Controls.Add(this.btn_Export);
            this.Controls.Add(this.btn_EditDataTypes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chck_ToggleRelCreation);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.editor_Box);
            this.Name = "Form_Editor";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Editor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.editor_Box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox editor_Box;
        private Button btn_Add;
        private Button btn_Delete;
        private CheckBox chck_ToggleRelCreation;
        private Label label1;
        private Button btn_EditDataTypes;
        private Button btn_Export;
    }
}