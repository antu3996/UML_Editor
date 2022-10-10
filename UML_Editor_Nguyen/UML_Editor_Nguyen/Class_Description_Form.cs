﻿using System;
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
    public partial class Class_Description_Form : Form
    {
        public UML_Class_Description newDescription { get; set; }
        public Class_Description_Form(UML_Class_Description newDescription)
        {
            InitializeComponent();

            this.newDescription = newDescription;
            this.txt_ClassName.Text = newDescription.ClassName;
            this.txt_Specification.Text = newDescription.Specification;
            this.list_Methods.DataSource = newDescription.Methods;
            this.list_Properties.DataSource = newDescription.Properties;
        }

        private void txt_Specification_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            this.errorProvider1.SetError(textBox, null);

            if (!string.IsNullOrEmpty(textBox.Text) && !Regex.IsMatch(textBox.Text, "^[a-zA-Z_0-9]+$"))
            {
                this.errorProvider1.SetError(textBox, "Pouze písmena");

                e.Cancel = true;
            }
        }

        private void txt_ClassName_Validating(object sender, CancelEventArgs e)
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

        private void btn_Method_Add_Click(object sender, EventArgs e)
        {
            Class_Method_Form frm_Method = new Class_Method_Form(new Class_Method());

            if (frm_Method.ShowDialog() == DialogResult.OK)
            {
                this.newDescription.Methods.Add(frm_Method.newMethod);
            }
        }

        private void btn_Method_Delete_Click(object sender, EventArgs e)
        {
            int currentIndex = this.list_Methods.SelectedIndex;
            if (currentIndex > -1)
            {
                this.newDescription.Methods.RemoveAt(currentIndex);
            }
        }

        private void btn_Method_Edit_Click(object sender, EventArgs e)
        {
            int currentIndex = this.list_Methods.SelectedIndex;
            if (currentIndex > -1)
            {
                Class_Method selected = this.newDescription.Methods[currentIndex];
                Class_Method_Form edit_Method = new Class_Method_Form(selected);

                if(edit_Method.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Pozor", "Upraveno");
                }
            }

            this.list_Methods.DataSource = null;
            this.list_Methods.DataSource = this.newDescription.Methods;
        }

        private void btn_Prop_Add_Click(object sender, EventArgs e)
        {
            Class_Attribute_Form frm_Attrib = new Class_Attribute_Form(new Class_Property());

            if (frm_Attrib.ShowDialog() == DialogResult.OK)
            {
                this.newDescription.Properties.Add(frm_Attrib.newProperty);
            }


        }

        private void btn_Prop_Delete_Click(object sender, EventArgs e)
        {
            int currentIndex = this.list_Properties.SelectedIndex;
            if (currentIndex > -1)
            {
                this.newDescription.Properties.RemoveAt(currentIndex);
            }

        }

        private void btn_Prop_Edit_Click(object sender, EventArgs e)
        {
            int currentIndex = this.list_Methods.SelectedIndex;
            if (currentIndex > -1)
            {
                Class_Property selected = this.newDescription.Properties[currentIndex];
                Class_Attribute_Form edit_Property = new Class_Attribute_Form(selected);

                if (edit_Property.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Pozor", "Upraveno");
                }
            }

            this.list_Properties.DataSource = null;
            this.list_Properties.DataSource = this.newDescription.Properties;

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                this.newDescription.ClassName = this.txt_ClassName.Text;
                this.newDescription.Specification = this.txt_Specification.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}