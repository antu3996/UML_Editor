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
using UML_Editor_Nguyen.Services;

namespace UML_Editor_Nguyen
{
    public partial class Class_Method_Form : Form
    {
        public Class_Method newMethod { get; set; }
        public BindingList<Method_Parameter> newParemeters { get; set; }
        public Class_Method_Form(Class_Method newMethod)
        {
            InitializeComponent();

            this.newParemeters = new BindingList<Method_Parameter>(new List<Method_Parameter>(newMethod.Parameters));

            this.newMethod = newMethod;
            this.txt_MethodName.Text = newMethod.MethodName;
            //this.txt_Parameters.Text = newMethod.Parameters;
            //this.grid_Parameters.DataSource = this.newParemeters;
            this.list_Parameters.DataSource = this.newParemeters;
            this.cb_ParamDataType.DataSource = new List<DataType>(DataTypeStorage.Instance.GetData());
            this.cb_DataType.DataSource = DataTypeStorage.Instance.GetData();

            if (newMethod.IsVoid)
            {
                this.chck_ReturnVoid.Checked = true;
            }
            else
            {
                this.cb_DataType.SelectedItem = newMethod.ReturnType;
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
                //this.newMethod.Parameters = this.txt_Parameters.Text;
                this.newMethod.Parameters = this.newParemeters.ToList();

                if (this.chck_ReturnVoid.Checked)
                {
                    this.newMethod.IsVoid = true;
                }
                else
                {
                    this.newMethod.ReturnType = this.cb_DataType.SelectedItem as DataType;
                    this.newMethod.IsVoid = false;
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
                this.errorProvider1.SetError(this.cb_DataType, null);
            }
        }

        private void btn_AddParameter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_ParameterName.Text))
            {
                this.errorProvider1.SetError(this.txt_ParameterName, "Název nesmí být prázdný");
            }
            else if (this.cb_ParamDataType.SelectedIndex == -1)
            {
                this.errorProvider1.SetError(this.cb_ParamDataType, "Datový typ nesmí být prázdný nebo nepatřící do seznamu");
            }
            else
            {
                if (this.errorProvider1.GetError(this.txt_ParameterName) == String.Empty
                && this.errorProvider1.GetError(this.cb_ParamDataType) == String.Empty)
                {
                    this.newParemeters.Add(new Method_Parameter()
                    { ParameterName = this.txt_ParameterName.Text, DataType = this.cb_ParamDataType.SelectedItem as DataType });

                    this.list_Parameters.DataSource = null;
                    this.list_Parameters.DataSource = this.newParemeters;

                    this.txt_ParameterName.Clear();
                }
            }
        }

        private void btn_DeleteParameter_Click(object sender, EventArgs e)
        {
            int index = this.list_Parameters.SelectedIndex;
            if (index > -1)
            {
                this.newParemeters.RemoveAt(index);
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            this.errorProvider1.SetError(textBox, null);

            if (!string.IsNullOrEmpty(textBox.Text) && !Regex.IsMatch(textBox.Text, "^[a-zA-Z_0-9]+$"))
            {
                this.errorProvider1.SetError(textBox, "Pouze písmena");

                e.Cancel = true;
            }
            else
            {
                foreach (Method_Parameter item in this.newParemeters)
                {
                    if (item.ParameterName == textBox.Text)
                    {
                        this.errorProvider1.SetError(textBox, "Název už existuje");
                        e.Cancel = true;
                        break;
                    }
                }
            }
            
        }

        private void cb_ParamDataType_Validating(object sender, CancelEventArgs e)
        {
            this.errorProvider1.SetError(this.cb_ParamDataType, null);

            if (this.cb_ParamDataType.SelectedIndex == -1)
            {
                this.errorProvider1.SetError(this.cb_ParamDataType, "Pole nesmí být prázdné");

                e.Cancel = true;
            }
        }

        private void cb_DataType_SelectedValueChanged(object sender, EventArgs e)
        {
            this.chck_ReturnVoid.Checked = false;
        }

        private void cb_DataType_Validating(object sender, CancelEventArgs e)
        {
            this.errorProvider1.SetError(this.cb_DataType, null);

            if (!this.chck_ReturnVoid.Checked && this.cb_DataType.SelectedIndex == -1)
            {
                this.errorProvider1.SetError(this.cb_DataType, "Pole nesmí být prázdné");

                e.Cancel = true;
            }
        }
    }
}
