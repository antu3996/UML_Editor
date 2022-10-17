namespace UML_Editor_Nguyen
{
    partial class Form_Relationship
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Relationship));
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Multiplicity_Sec = new System.Windows.Forms.TextBox();
            this.txt_Multiplicity_Prim = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_RelStereotype = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ch_Comp = new System.Windows.Forms.RadioButton();
            this.ch_Aggre = new System.Windows.Forms.RadioButton();
            this.ch_Dep = new System.Windows.Forms.RadioButton();
            this.ch_Real = new System.Windows.Forms.RadioButton();
            this.ch_Inhe = new System.Windows.Forms.RadioButton();
            this.ch_Association = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(333, 309);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 31;
            this.btn_Save.Text = "Uložit";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(252, 309);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 30;
            this.btn_Cancel.Text = "Storno";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(165, 262);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 2);
            this.label4.TabIndex = 29;
            // 
            // txt_Multiplicity_Sec
            // 
            this.txt_Multiplicity_Sec.Location = new System.Drawing.Point(231, 252);
            this.txt_Multiplicity_Sec.Name = "txt_Multiplicity_Sec";
            this.txt_Multiplicity_Sec.Size = new System.Drawing.Size(49, 23);
            this.txt_Multiplicity_Sec.TabIndex = 28;
            // 
            // txt_Multiplicity_Prim
            // 
            this.txt_Multiplicity_Prim.Location = new System.Drawing.Point(110, 252);
            this.txt_Multiplicity_Prim.Name = "txt_Multiplicity_Prim";
            this.txt_Multiplicity_Prim.Size = new System.Drawing.Size(49, 23);
            this.txt_Multiplicity_Prim.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 25;
            this.label2.Text = "Multiplicita:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(110, 78);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(277, 162);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // txt_RelStereotype
            // 
            this.txt_RelStereotype.Location = new System.Drawing.Point(134, 15);
            this.txt_RelStereotype.Name = "txt_RelStereotype";
            this.txt_RelStereotype.Size = new System.Drawing.Size(240, 23);
            this.txt_RelStereotype.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Stereotyp (volitelné):";
            // 
            // ch_Comp
            // 
            this.ch_Comp.AutoSize = true;
            this.ch_Comp.Location = new System.Drawing.Point(6, 147);
            this.ch_Comp.Name = "ch_Comp";
            this.ch_Comp.Size = new System.Drawing.Size(95, 19);
            this.ch_Comp.TabIndex = 23;
            this.ch_Comp.Text = "Composition";
            this.ch_Comp.UseVisualStyleBackColor = true;
            // 
            // ch_Aggre
            // 
            this.ch_Aggre.AutoSize = true;
            this.ch_Aggre.Location = new System.Drawing.Point(6, 122);
            this.ch_Aggre.Name = "ch_Aggre";
            this.ch_Aggre.Size = new System.Drawing.Size(92, 19);
            this.ch_Aggre.TabIndex = 22;
            this.ch_Aggre.Text = "Aggregation";
            this.ch_Aggre.UseVisualStyleBackColor = true;
            // 
            // ch_Dep
            // 
            this.ch_Dep.AutoSize = true;
            this.ch_Dep.Location = new System.Drawing.Point(6, 97);
            this.ch_Dep.Name = "ch_Dep";
            this.ch_Dep.Size = new System.Drawing.Size(92, 19);
            this.ch_Dep.TabIndex = 21;
            this.ch_Dep.Text = "Dependency";
            this.ch_Dep.UseVisualStyleBackColor = true;
            // 
            // ch_Real
            // 
            this.ch_Real.AutoSize = true;
            this.ch_Real.Location = new System.Drawing.Point(6, 72);
            this.ch_Real.Name = "ch_Real";
            this.ch_Real.Size = new System.Drawing.Size(83, 19);
            this.ch_Real.TabIndex = 20;
            this.ch_Real.Text = "Realization";
            this.ch_Real.UseVisualStyleBackColor = true;
            // 
            // ch_Inhe
            // 
            this.ch_Inhe.AutoSize = true;
            this.ch_Inhe.Location = new System.Drawing.Point(6, 47);
            this.ch_Inhe.Name = "ch_Inhe";
            this.ch_Inhe.Size = new System.Drawing.Size(85, 19);
            this.ch_Inhe.TabIndex = 19;
            this.ch_Inhe.Text = "Inheritance";
            this.ch_Inhe.UseVisualStyleBackColor = true;
            // 
            // ch_Association
            // 
            this.ch_Association.AutoSize = true;
            this.ch_Association.Location = new System.Drawing.Point(6, 22);
            this.ch_Association.Name = "ch_Association";
            this.ch_Association.Size = new System.Drawing.Size(87, 19);
            this.ch_Association.TabIndex = 18;
            this.ch_Association.Text = "Association";
            this.ch_Association.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ch_Association);
            this.groupBox1.Controls.Add(this.ch_Comp);
            this.groupBox1.Controls.Add(this.ch_Inhe);
            this.groupBox1.Controls.Add(this.ch_Aggre);
            this.groupBox1.Controls.Add(this.ch_Real);
            this.groupBox1.Controls.Add(this.ch_Dep);
            this.groupBox1.Location = new System.Drawing.Point(2, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(106, 176);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Typ vazby:";
            // 
            // Form_Relationship
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 353);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_Multiplicity_Sec);
            this.Controls.Add(this.txt_Multiplicity_Prim);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txt_RelStereotype);
            this.Controls.Add(this.label1);
            this.Name = "Form_Relationship";
            this.Text = "Form_Relationship";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_Save;
        private Button btn_Cancel;
        private Label label4;
        private TextBox txt_Multiplicity_Sec;
        private TextBox txt_Multiplicity_Prim;
        private Label label2;
        private PictureBox pictureBox1;
        private TextBox txt_RelStereotype;
        private Label label1;
        private RadioButton ch_Comp;
        private RadioButton ch_Aggre;
        private RadioButton ch_Dep;
        private RadioButton ch_Real;
        private RadioButton ch_Inhe;
        private RadioButton ch_Association;
        private GroupBox groupBox1;
    }
}