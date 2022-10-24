using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UML_Editor_Nguyen.Services;

namespace UML_Editor_Nguyen
{
    public partial class Form_DataTypeDetails : Form
    {
        public DataType currentDataType { get; set; }
        public Func<DataType, bool> checkIfExistsInList;
        public Form_DataTypeDetails(DataType dataType)
        {
            InitializeComponent();
            this.currentDataType = dataType;
            this.txt_Namespace.Text = dataType.Namespace;
            this.txt_Name.Text = dataType.Name;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            DataType dataType = new DataType();
            dataType.Name = this.txt_Name.Text;
            dataType.Namespace = this.txt_Namespace.Text;

            if (this.checkIfExistsInList(dataType))
            {
                this.errorProvider1.SetError(this.txt_Namespace, "Namespace a název už existují");
                this.errorProvider1.SetError(this.txt_Name, "Namespace a název už existují");

            }
            else
            {
                this.currentDataType = dataType;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /*public bool CheckIfDataTypeExists(DataType dataType)
        {
            string @namespace = dataType.Namespace;
            string @class = dataType.Name;

            var myClassType = Type.GetType(String.Format("{0}.{1}", @namespace, @class));

            if (myClassType == null)
            {
                return false;
            }
            else
            {
                return true;
            }

            return false;
        }*/

        private void txt_Namespace_TextChanged(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.txt_Namespace, null);
        }

        private void txt_Name_TextChanged(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.txt_Name, null);
        }
    }
}
