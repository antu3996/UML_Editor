using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UML_Editor_Nguyen.Description_Components;

namespace UML_Editor_Nguyen
{
    public partial class Class_Method_Form : Form
    {
        public Class_Method newMethod { get; set; }
        public Class_Method_Form(Class_Method newMethod)
        {
            InitializeComponent();

            this.newMethod = newMethod;
            this.txt_MethodName.Text = newMethod.MethodName;
            this.txt_Parameters.Text = newMethod.Parameters;

            if (newMethod.ReturnType == "void")
            {
                this.chck_ReturnVoid.Checked = true;
            }
            else
            {
                this.txt_ReturnType.Text = newMethod.ReturnType;
            }

            if (newMethod.Modifier == "public")
            {
                this.rdb_public.Checked = true;
            }
            else if (newMethod.Modifier == "private")
            {
                this.rdb_private.Checked = true;
            }
            else if (newMethod.Modifier == "protected")
            {
                this.rdb_protected.Checked = true;
            }
            else
            {
                this.rdb_public.Checked = true;
            }
        }

        private void txt_MethodName_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            this.errorProvider1.SetError(textBox, null);

            if (string.IsNullOrEmpty(textBox.Text))
            {
                this.errorProvider1.SetError(textBox, "Pole nesmí být prázdné");

                e.Cancel = true;
            }
            else if (!Regex.IsMatch(textBox.Text, "^[a-zA-Z_0-9]+$"))
            {
                this.errorProvider1.SetError(textBox, "Pouze písmena");

                e.Cancel = true;
            }
        }

        private void txt_Parameters_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            this.errorProvider1.SetError(textBox, null);

            if (!string.IsNullOrEmpty(textBox.Text) && !Regex.IsMatch(textBox.Text, "^(([a-zA-Z_0-9<>]+): ([a-zA-Z_0-9<>]+), )*(([a-zA-Z_0-9<>]+): ([a-zA-Z_0-9<>]+))$"))
            {
                this.errorProvider1.SetError(textBox, "Pouze písmena ve formátu - nazevPromenne: datovyTyp, nazevPromenne2: datovyTyp2");

                e.Cancel = true;
            }
        }

        private void txt_ReturnType_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            this.errorProvider1.SetError(textBox, null);
            
            if (!this.chck_ReturnVoid.Checked)
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    this.errorProvider1.SetError(textBox, "Pole nesmí být prázdné");

                    e.Cancel = true;
                }
                else if (!Regex.IsMatch(textBox.Text, "^[a-zA-Z_0-9<>]+$"))
                {
                    this.errorProvider1.SetError(textBox, "Pouze písmena");

                    e.Cancel = true;
                }
            }
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                this.newMethod.MethodName = this.txt_MethodName.Text;
                this.newMethod.Parameters = this.txt_Parameters.Text;

                if (this.chck_ReturnVoid.Checked)
                {
                    this.newMethod.ReturnType = "void";
                }
                else
                {
                    this.newMethod.ReturnType = this.txt_ReturnType.Text;
                }
                
                if (this.rdb_private.Checked)
                {
                    this.newMethod.Modifier = "private";
                }
                else if (this.rdb_protected.Checked)
                {
                    this.newMethod.Modifier = "protected";
                }
                else if (this.rdb_public.Checked)
                {
                    this.newMethod.Modifier = "public";
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void chck_ReturnVoid_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chck_ReturnVoid.Checked)
            {
                this.errorProvider1.SetError(this.txt_ReturnType, null);
                this.txt_ReturnType.Clear();
            }
        }
    }
}
