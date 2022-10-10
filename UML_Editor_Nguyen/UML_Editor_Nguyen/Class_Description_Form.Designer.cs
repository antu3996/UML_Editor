namespace UML_Editor_Nguyen
{
    partial class Class_Description_Form
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
            this.label2 = new System.Windows.Forms.Label();
            this.list_Methods = new System.Windows.Forms.ListBox();
            this.list_Properties = new System.Windows.Forms.ListBox();
            this.btn_Method_Add = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txt_ClassName = new System.Windows.Forms.TextBox();
            this.txt_Specification = new System.Windows.Forms.TextBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.btn_Method_Delete = new System.Windows.Forms.Button();
            this.btn_Method_Edit = new System.Windows.Forms.Button();
            this.btn_Prop_Edit = new System.Windows.Forms.Button();
            this.btn_Prop_Delete = new System.Windows.Forms.Button();
            this.btn_Prop_Add = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Specifikace (volitelné):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(21, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Název třídy:";
            // 
            // list_Methods
            // 
            this.list_Methods.FormattingEnabled = true;
            this.list_Methods.ItemHeight = 15;
            this.list_Methods.Location = new System.Drawing.Point(21, 130);
            this.list_Methods.Name = "list_Methods";
            this.list_Methods.Size = new System.Drawing.Size(445, 124);
            this.list_Methods.TabIndex = 2;
            // 
            // list_Properties
            // 
            this.list_Properties.FormattingEnabled = true;
            this.list_Properties.ItemHeight = 15;
            this.list_Properties.Location = new System.Drawing.Point(21, 334);
            this.list_Properties.Name = "list_Properties";
            this.list_Properties.Size = new System.Drawing.Size(445, 124);
            this.list_Properties.TabIndex = 3;
            // 
            // btn_Method_Add
            // 
            this.btn_Method_Add.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_Method_Add.Location = new System.Drawing.Point(21, 260);
            this.btn_Method_Add.Name = "btn_Method_Add";
            this.btn_Method_Add.Size = new System.Drawing.Size(125, 23);
            this.btn_Method_Add.TabIndex = 5;
            this.btn_Method_Add.Text = "Přidat";
            this.btn_Method_Add.UseVisualStyleBackColor = true;
            this.btn_Method_Add.Click += new System.EventHandler(this.btn_Method_Add_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // txt_ClassName
            // 
            this.txt_ClassName.Location = new System.Drawing.Point(96, 55);
            this.txt_ClassName.Name = "txt_ClassName";
            this.txt_ClassName.Size = new System.Drawing.Size(370, 23);
            this.txt_ClassName.TabIndex = 8;
            this.txt_ClassName.Validating += new System.ComponentModel.CancelEventHandler(this.txt_ClassName_Validating);
            // 
            // txt_Specification
            // 
            this.txt_Specification.Location = new System.Drawing.Point(155, 16);
            this.txt_Specification.Name = "txt_Specification";
            this.txt_Specification.Size = new System.Drawing.Size(311, 23);
            this.txt_Specification.TabIndex = 9;
            this.txt_Specification.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Specification_Validating);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Cancel.Location = new System.Drawing.Point(21, 521);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(208, 23);
            this.btn_Cancel.TabIndex = 10;
            this.btn_Cancel.Text = "Storno";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Edit
            // 
            this.btn_Edit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Edit.Location = new System.Drawing.Point(258, 521);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(208, 23);
            this.btn_Edit.TabIndex = 11;
            this.btn_Edit.Text = "Uložit";
            this.btn_Edit.UseVisualStyleBackColor = true;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_Method_Delete
            // 
            this.btn_Method_Delete.Location = new System.Drawing.Point(184, 261);
            this.btn_Method_Delete.Name = "btn_Method_Delete";
            this.btn_Method_Delete.Size = new System.Drawing.Size(125, 23);
            this.btn_Method_Delete.TabIndex = 12;
            this.btn_Method_Delete.Text = "Smazat";
            this.btn_Method_Delete.UseVisualStyleBackColor = true;
            this.btn_Method_Delete.Click += new System.EventHandler(this.btn_Method_Delete_Click);
            // 
            // btn_Method_Edit
            // 
            this.btn_Method_Edit.Location = new System.Drawing.Point(341, 261);
            this.btn_Method_Edit.Name = "btn_Method_Edit";
            this.btn_Method_Edit.Size = new System.Drawing.Size(125, 23);
            this.btn_Method_Edit.TabIndex = 13;
            this.btn_Method_Edit.Text = "Upravit";
            this.btn_Method_Edit.UseVisualStyleBackColor = true;
            this.btn_Method_Edit.Click += new System.EventHandler(this.btn_Method_Edit_Click);
            // 
            // btn_Prop_Edit
            // 
            this.btn_Prop_Edit.Location = new System.Drawing.Point(341, 465);
            this.btn_Prop_Edit.Name = "btn_Prop_Edit";
            this.btn_Prop_Edit.Size = new System.Drawing.Size(125, 23);
            this.btn_Prop_Edit.TabIndex = 16;
            this.btn_Prop_Edit.Text = "Upravit";
            this.btn_Prop_Edit.UseVisualStyleBackColor = true;
            this.btn_Prop_Edit.Click += new System.EventHandler(this.btn_Prop_Edit_Click);
            // 
            // btn_Prop_Delete
            // 
            this.btn_Prop_Delete.Location = new System.Drawing.Point(184, 465);
            this.btn_Prop_Delete.Name = "btn_Prop_Delete";
            this.btn_Prop_Delete.Size = new System.Drawing.Size(125, 23);
            this.btn_Prop_Delete.TabIndex = 15;
            this.btn_Prop_Delete.Text = "Smazat";
            this.btn_Prop_Delete.UseVisualStyleBackColor = true;
            this.btn_Prop_Delete.Click += new System.EventHandler(this.btn_Prop_Delete_Click);
            // 
            // btn_Prop_Add
            // 
            this.btn_Prop_Add.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_Prop_Add.Location = new System.Drawing.Point(21, 464);
            this.btn_Prop_Add.Name = "btn_Prop_Add";
            this.btn_Prop_Add.Size = new System.Drawing.Size(125, 23);
            this.btn_Prop_Add.TabIndex = 14;
            this.btn_Prop_Add.Text = "Přidat";
            this.btn_Prop_Add.UseVisualStyleBackColor = true;
            this.btn_Prop_Add.Click += new System.EventHandler(this.btn_Prop_Add_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(21, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "Seznam metod:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(21, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "Seznam vlastností:";
            // 
            // Class_Description_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(505, 561);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Prop_Edit);
            this.Controls.Add(this.btn_Prop_Delete);
            this.Controls.Add(this.btn_Prop_Add);
            this.Controls.Add(this.btn_Method_Edit);
            this.Controls.Add(this.btn_Method_Delete);
            this.Controls.Add(this.btn_Edit);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.txt_Specification);
            this.Controls.Add(this.txt_ClassName);
            this.Controls.Add(this.btn_Method_Add);
            this.Controls.Add(this.list_Properties);
            this.Controls.Add(this.list_Methods);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Class_Description_Form";
            this.Text = "Class_Description_Form";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private ListBox list_Methods;
        private ListBox list_Properties;
        private Button btn_Method_Add;
        private ErrorProvider errorProvider1;
        private TextBox txt_Specification;
        private TextBox txt_ClassName;
        private Button btn_Edit;
        private Button btn_Cancel;
        private Button btn_Prop_Edit;
        private Button btn_Prop_Delete;
        private Button btn_Prop_Add;
        private Button btn_Method_Edit;
        private Button btn_Method_Delete;
        private Label label4;
        private Label label3;
    }
}