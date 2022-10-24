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
    public partial class Form_Exporter : Form
    {
        UML_Objects_Wrapper currentDataToSave = new UML_Objects_Wrapper();
        public Form_Exporter(UML_Editor_Engine engineData)
        {
            InitializeComponent();

            this.currentDataToSave.EngineData = engineData;
            this.currentDataToSave.dataTypes = DataTypeStorage.Instance.GetData();
        }

        private void btn_SaveToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sdlg = new SaveFileDialog();
            sdlg.Title = "Zadejte název souboru";
            sdlg.InitialDirectory = @"C:\";
            sdlg.Filter = "UML File (*.umlwin)|*.umlwin";
            sdlg.FilterIndex = 2;
            sdlg.RestoreDirectory = true;

            if (sdlg.ShowDialog() == DialogResult.OK)
            {
                UML_Import_Export.ExportToFile(this.currentDataToSave, sdlg.FileName);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btn_SaveToPicture_Click(object sender, EventArgs e)
        {

        }
    }
}
