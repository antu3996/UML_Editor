using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UML_Editor_Nguyen.Services;

namespace UML_Editor_Nguyen
{
    public partial class Form_Exporter : Form
    {
        UML_Objects_Wrapper currentDataToSave = new UML_Objects_Wrapper();
        PictureBox pictureBox;
        public Form_Exporter(PictureBox pictureBox, UML_Editor_Engine engineData)
        {
            InitializeComponent();
            this.pictureBox = pictureBox;
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

                MessageBox.Show("Export do souboru úspěšný");
            }
        }

        private void btn_SaveToPicture_Click(object sender, EventArgs e)
        {
            SaveFileDialog sdlg = new SaveFileDialog();
            sdlg.Title = "Zadejte název souboru";
            sdlg.InitialDirectory = @"C:\";
            sdlg.Filter = "JPG File (*.jpg)|*.jpg";
            sdlg.FilterIndex = 2;
            sdlg.RestoreDirectory = true;

            if (sdlg.ShowDialog() == DialogResult.OK)
            {
                UML_Import_Export.ExportToPicture(this.pictureBox, this.currentDataToSave.EngineData, sdlg.FileName);

                MessageBox.Show("Export do obrázku úspěšný");
            }
        }

        private void btn_ExportToCode_Click(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.txt_Namespace, null);

            if (string.IsNullOrEmpty(this.txt_Namespace.Text))
            {
                this.errorProvider1.SetError(this.txt_Namespace, "Název Namespace povinný");
            }
            else if (!Regex.IsMatch(this.txt_Namespace.Text, "^[a-zA-Z0-9_]+$"))
            {
                this.errorProvider1.SetError(this.txt_Namespace, "Pouze písmena s čísly");
            }
            else
            {
                UML_Class_Code_Exporter exporter = new UML_Class_Code_Exporter();

                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    string folderName = folderBrowserDialog1.SelectedPath;

                    exporter.ExportToCode(this.txt_Namespace.Text, folderName, this.currentDataToSave.EngineData);

                    MessageBox.Show("Export do kódu úspěšný");

                }
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
