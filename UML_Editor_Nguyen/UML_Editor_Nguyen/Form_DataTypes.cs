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
    public partial class Form_DataTypes : Form
    {
        public BindingList<DataType> dataTypes; 
        public Form_DataTypes()
        {
            InitializeComponent();
            List<DataType> newList = new List<DataType>(DataTypeStorage.Instance.GetData());
            this.dataTypes = new BindingList<DataType>(newList);
            this.cb_DataTypes.DataSource = this.dataTypes;
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (this.cb_DataTypes.SelectedIndex > -1)
            {
                Form_DataTypeDetails frm = new Form_DataTypeDetails(this.dataTypes[this.cb_DataTypes.SelectedIndex]);
                frm.checkIfExistsInList += this.Exists;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.dataTypes[this.cb_DataTypes.SelectedIndex] = frm.currentDataType;
                }
            }
        }

        private void btn_AddNew_Click(object sender, EventArgs e)
        {
            Form_DataTypeDetails frm = new Form_DataTypeDetails(new DataType());
            frm.checkIfExistsInList += this.Exists;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.dataTypes.Add(frm.currentDataType);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            DataTypeStorage.Instance.LoadData(this.dataTypes.ToList());

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public bool Exists(DataType dataType)
        {
            foreach (DataType item in this.dataTypes)
            {
                if (item.Name == dataType.Name && item.Namespace == dataType.Namespace)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
