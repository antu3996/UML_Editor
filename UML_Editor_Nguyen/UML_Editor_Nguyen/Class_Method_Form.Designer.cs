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
            this.list_Parameters = new System.Windows.Forms.ListBox();
            this.btn_DeleteParameter = new System.Windows.Forms.Button();
            this.btn_AddParameter = new System.Windows.Forms.Button();
            this.txt_ParameterName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_ParamDataType = new System.Windows.Forms.ComboBox();
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
            this.chck_ReturnVoid.Location = new System.Drawing.Point(408, 341);
            this.chck_ReturnVoid.Name = "chck_ReturnVoid";
            this.chck_ReturnVoid.Size = new System.Drawing.Size(50, 19);
            this.chck_ReturnVoid.TabIndex = 4;
            this.chck_ReturnVoid.Text = "Void";
            this.chck_ReturnVoid.UseVisualStyleBackColor = true;
            this.chck_ReturnVoid.CheckedChanged += new System.EventHandler(this.chck_ReturnVoid_CheckedChanged);
            // 
            // txt_ReturnType
            // 
            this.txt_ReturnType.Location = new System.Drawing.Point(104, 339);
            this.txt_ReturnType.Name = "txt_ReturnType";
            this.txt_ReturnType.Size = new System.Drawing.Size(274, 23);
            this.txt_ReturnType.TabIndex = 5;
            this.txt_ReturnType.Validating += new System.ComponentModel.CancelEventHandler(this.txt_ReturnType_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 342);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Návratový typ:";
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Confirm.Location = new System.Drawing.Point(676, 465);
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
            this.btn_Cancel.Location = new System.Drawing.Point(595, 465);
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
            this.groupBox1.Location = new System.Drawing.Point(13, 383);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 43);
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
            // list_Parameters
            // 
            this.list_Parameters.FormattingEnabled = true;
            this.list_Parameters.ItemHeight = 15;
            this.list_Parameters.Location = new System.Drawing.Point(104, 59);
            this.list_Parameters.Name = "list_Parameters";
            this.list_Parameters.Size = new System.Drawing.Size(543, 184);
            this.list_Parameters.TabIndex = 21;
            // 
            // btn_DeleteParameter
            // 
            this.btn_DeleteParameter.Location = new System.Drawing.Point(653, 59);
            this.btn_DeleteParameter.Name = "btn_DeleteParameter";
            this.btn_DeleteParameter.Size = new System.Drawing.Size(98, 23);
            this.btn_DeleteParameter.TabIndex = 22;
            this.btn_DeleteParameter.Text = "Smazat";
            this.btn_DeleteParameter.UseVisualStyleBackColor = true;
            this.btn_DeleteParameter.Click += new System.EventHandler(this.btn_DeleteParameter_Click);
            // 
            // btn_AddParameter
            // 
            this.btn_AddParameter.Location = new System.Drawing.Point(653, 258);
            this.btn_AddParameter.Name = "btn_AddParameter";
            this.btn_AddParameter.Size = new System.Drawing.Size(98, 23);
            this.btn_AddParameter.TabIndex = 23;
            this.btn_AddParameter.Text = "Přidat";
            this.btn_AddParameter.UseVisualStyleBackColor = true;
            this.btn_AddParameter.Click += new System.EventHandler(this.btn_AddParameter_Click);
            // 
            // txt_ParameterName
            // 
            this.txt_ParameterName.Location = new System.Drawing.Point(210, 259);
            this.txt_ParameterName.Name = "txt_ParameterName";
            this.txt_ParameterName.Size = new System.Drawing.Size(127, 23);
            this.txt_ParameterName.TabIndex = 24;
            this.txt_ParameterName.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 15);
            this.label4.TabIndex = 26;
            this.label4.Text = "Název parametru:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(387, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 27;
            this.label5.Text = "Datový typ:";
            // 
            // cb_ParamDataType
            // 
            this.cb_ParamDataType.FormattingEnabled = true;
            this.cb_ParamDataType.Location = new System.Drawing.Point(460, 259);
            this.cb_ParamDataType.Name = "cb_ParamDataType";
            this.cb_ParamDataType.Size = new System.Drawing.Size(135, 23);
            this.cb_ParamDataType.TabIndex = 28;
            this.cb_ParamDataType.Validating += new System.ComponentModel.CancelEventHandler(this.cb_ParamDataType_Validating);
            // 
            // Class_Method_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(763, 500);
            this.Controls.Add(this.cb_ParamDataType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_ParameterName);
            this.Controls.Add(this.btn_AddParameter);
            this.Controls.Add(this.btn_DeleteParameter);
            this.Controls.Add(this.list_Parameters);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Confirm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_ReturnType);
            this.Controls.Add(this.chck_ReturnVoid);
            this.Controls.Add(this.label2);
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
        private Label label5;
        private Label label4;
        private TextBox txt_ParameterName;
        private Button btn_AddParameter;
        private Button btn_DeleteParameter;
        private ListBox list_Parameters;
        private ComboBox cb_ParamDataType;
    }
}