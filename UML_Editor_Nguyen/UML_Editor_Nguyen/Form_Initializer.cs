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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UML_Editor_Nguyen
{
    public partial class Form_Initializer : Form
    {
        public Form_Initializer()
        {
            InitializeComponent();
        }

        private void btn_OpenExisting_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Vyberte soubor UML";
            fdlg.InitialDirectory = @"C:\";
            fdlg.Filter = "UML File (*.umlwin)|*.umlwin";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;

            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                UML_Objects_Wrapper currentData = UML_Import_Export.ImportFromFile(fdlg.FileName);

                DataTypeStorage.Instance.LoadData(currentData.dataTypes);

                Form_Editor main_form = new Form_Editor(currentData.EngineData);

                this.Hide();
                if (main_form.ShowDialog() == DialogResult.Cancel)
                {
                    this.Show();
                }
            }
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            DataTypeStorage.Instance.LoadDefault();

            Form_Editor main_form = new Form_Editor(null);

            this.Hide();
            if (main_form.ShowDialog() == DialogResult.Cancel)
            {
                this.Show();
            }
        }
    }
}
