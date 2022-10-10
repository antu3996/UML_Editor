namespace UML_Editor_Nguyen
{
    partial class Class_Method_Form
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
            this.txt_MethodName = new System.Windows.Forms.TextBox();
            this.txt_Parameters = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chck_ReturnVoid = new System.Windows.Forms.CheckBox();
            this.txt_ReturnType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdb_protected = new System.Windows.Forms.RadioButton();
            this.rdb_public = new System.Windows.Forms.RadioButton();
            this.rdb_private = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Název metody:";
            // 
            // txt_MethodName
            // 
            this.txt_MethodName.Location = new System.Drawing.Point(104, 22);
            this.txt_MethodName.Name = "txt_MethodName";
            this.txt_MethodName.Size = new System.Drawing.Size(313, 23);
            this.txt_MethodName.TabIndex = 1;
            this.txt_MethodName.Validating += new System.ComponentModel.CancelEventHandler(this.txt_MethodName_Validating);
            // 
            // txt_Parameters
            // 
            this.txt_Parameters.Location = new System.Drawing.Point(104, 56);
            this.txt_Parameters.Name = "txt_Parameters";
            this.txt_Parameters.Size = new System.Drawing.Size(313, 23);
            this.txt_Parameters.TabIndex = 2;
            this.txt_Parameters.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Parameters_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Parametry:";
            // 
            // chck_ReturnVoid
            // 
            this.chck_ReturnVoid.AutoSize = true;
            this.chck_ReturnVoid.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chck_ReturnVoid.Location = new System.Drawing.Point(367, 97);
            this.chck_ReturnVoid.Name = "chck_ReturnVoid";
            this.chck_ReturnVoid.Size = new System.Drawing.Size(50, 19);
            this.chck_ReturnVoid.TabIndex = 4;
            this.chck_ReturnVoid.Text = "Void";
            this.chck_ReturnVoid.UseVisualStyleBackColor = true;
            this.chck_ReturnVoid.CheckedChanged += new System.EventHandler(this.chck_ReturnVoid_CheckedChanged);
            // 
            // txt_ReturnType
            // 
            this.txt_ReturnType.Location = new System.Drawing.Point(104, 93);
            this.txt_ReturnType.Name = "txt_ReturnType";
            this.txt_ReturnType.Size = new System.Drawing.Size(233, 23);
            this.txt_ReturnType.TabIndex = 5;
            this.txt_ReturnType.Validating += new System.ComponentModel.CancelEventHandler(this.txt_ReturnType_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Návratový typ:";
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Confirm.Location = new System.Drawing.Point(342, 213);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(75, 23);
            this.btn_Confirm.TabIndex = 7;
            this.btn_Confirm.Text = "Uložit";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Cancel.Location = new System.Drawing.Point(261, 213);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 8;
            this.btn_Cancel.Text = "Storno";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdb_protected);
            this.groupBox1.Controls.Add(this.rdb_public);
            this.groupBox1.Controls.Add(this.rdb_private);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 43);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modifikátory přístupu:";
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
            // Class_Method_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(444, 248);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Confirm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_ReturnType);
            this.Controls.Add(this.chck_ReturnVoid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Parameters);
            this.Controls.Add(this.txt_MethodName);
            this.Controls.Add(this.label1);
            this.Name = "Class_Method_Form";
            this.Text = "Class_Method_Form";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox txt_MethodName;
        private TextBox txt_Parameters;
        private Label label2;
        private CheckBox chck_ReturnVoid;
        private TextBox txt_ReturnType;
        private Label label3;
        private Button btn_Confirm;
        private Button btn_Cancel;
        private ErrorProvider errorProvider1;
        private GroupBox groupBox1;
        private RadioButton rdb_protected;
        private RadioButton rdb_public;
        private RadioButton rdb_private;
    }
}