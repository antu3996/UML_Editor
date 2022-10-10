namespace UML_Editor_Nguyen
{
    partial class Class_Attribute_Form
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
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_DataType = new System.Windows.Forms.TextBox();
            this.txt_PropertyName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.rdb_private = new System.Windows.Forms.RadioButton();
            this.rdb_protected = new System.Windows.Forms.RadioButton();
            this.rdb_public = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(270, 169);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 17;
            this.btn_Cancel.Text = "Storno";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Location = new System.Drawing.Point(351, 169);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(75, 23);
            this.btn_Confirm.TabIndex = 16;
            this.btn_Confirm.Text = "Uložit";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Datový typ:";
            // 
            // txt_DataType
            // 
            this.txt_DataType.Location = new System.Drawing.Point(113, 61);
            this.txt_DataType.Name = "txt_DataType";
            this.txt_DataType.Size = new System.Drawing.Size(313, 23);
            this.txt_DataType.TabIndex = 14;
            this.txt_DataType.Validating += new System.ComponentModel.CancelEventHandler(this.txt_DataType_Validating);
            // 
            // txt_PropertyName
            // 
            this.txt_PropertyName.Location = new System.Drawing.Point(113, 23);
            this.txt_PropertyName.Name = "txt_PropertyName";
            this.txt_PropertyName.Size = new System.Drawing.Size(313, 23);
            this.txt_PropertyName.TabIndex = 10;
            this.txt_PropertyName.Validating += new System.ComponentModel.CancelEventHandler(this.txt_MethodName_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Název vlastnosti:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // rdb_private
            // 
            this.rdb_private.AutoSize = true;
            this.rdb_private.Location = new System.Drawing.Point(72, 22);
            this.rdb_private.Name = "rdb_private";
            this.rdb_private.Size = new System.Drawing.Size(65, 19);
            this.rdb_private.TabIndex = 11;
            this.rdb_private.TabStop = true;
            this.rdb_private.Text = "private";
            this.rdb_private.UseVisualStyleBackColor = true;
            // 
            // rdb_protected
            // 
            this.rdb_protected.AutoSize = true;
            this.rdb_protected.Location = new System.Drawing.Point(139, 22);
            this.rdb_protected.Name = "rdb_protected";
            this.rdb_protected.Size = new System.Drawing.Size(81, 19);
            this.rdb_protected.TabIndex = 12;
            this.rdb_protected.TabStop = true;
            this.rdb_protected.Text = "protected";
            this.rdb_protected.UseVisualStyleBackColor = true;
            // 
            // rdb_public
            // 
            this.rdb_public.AutoSize = true;
            this.rdb_public.Location = new System.Drawing.Point(8, 22);
            this.rdb_public.Name = "rdb_public";
            this.rdb_public.Size = new System.Drawing.Size(58, 19);
            this.rdb_public.TabIndex = 10;
            this.rdb_public.TabStop = true;
            this.rdb_public.Text = "public";
            this.rdb_public.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdb_protected);
            this.groupBox1.Controls.Add(this.rdb_public);
            this.groupBox1.Controls.Add(this.rdb_private);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 43);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modifikátory přístupu:";
            // 
            // Class_Attribute_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(444, 204);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Confirm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_DataType);
            this.Controls.Add(this.txt_PropertyName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Name = "Class_Attribute_Form";
            this.Text = "Class_Attribute_Form";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_Cancel;
        private Button btn_Confirm;
        private Label label3;
        private TextBox txt_DataType;
        private TextBox txt_PropertyName;
        private Label label1;
        private ErrorProvider errorProvider1;
        private GroupBox groupBox1;
        private RadioButton rdb_protected;
        private RadioButton rdb_public;
        private RadioButton rdb_private;
    }
}