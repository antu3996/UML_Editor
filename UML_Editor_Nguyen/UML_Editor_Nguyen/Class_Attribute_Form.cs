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
    public partial class Class_Attribute_Form : Form
    {
        public Class_Property newProperty { get; set; }
        public Class_Attribute_Form(Class_Property property)
        {
            InitializeComponent();

            this.newProperty = property;

            this.txt_PropertyName.Text = property.PropertyName;
            this.txt_DataType.Text = property.DataType;

            if (property.Modifier == "public")
            {
                this.rdb_public.Checked = true;
            }
            else if (property.Modifier == "private")
            {
                this.rdb_private.Checked = true;
            }
            else if (property.Modifier == "protected")
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

        private void txt_DataType_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            this.errorProvider1.SetError(textBox, null);

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

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                this.newProperty.PropertyName = this.txt_PropertyName.Text;
                this.newProperty.DataType = this.txt_DataType.Text;
                
                if (this.rdb_public.Checked)
                {
                    this.newProperty.Modifier = "public";
                }
                if (this.rdb_private.Checked)
                {
                    this.newProperty.Modifier = "private";
                }
                if (this.rdb_protected.Checked)
                {
                    this.newProperty.Modifier = "protected";
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
