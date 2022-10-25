
using UML_Editor_Nguyen.Comparers;
using UML_Editor_Nguyen.Components;
using UML_Editor_Nguyen.Relationship_Components;
using UML_Editor_Nguyen.Services;

namespace UML_Editor_Nguyen
{
    public partial class Form_Editor : Form
    {
        private UML_Editor_Engine engine;
        
        public Form_Editor(UML_Editor_Engine data)
        {
            InitializeComponent();

            
            this.engine = new UML_Editor_Engine();

            if (data != null)
            {
                this.engine.ImportData(data);
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {

            this.engine.ButtonAddClick(this);
            
            

            this.editor_Box.Refresh();
        }

        private void editor_Box_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            this.engine.Draw(g);

        }


        private void editor_Box_MouseMove(object sender, MouseEventArgs e)
        {
            this.engine.MouseMove(this, e.X, e.Y);

            this.editor_Box.Refresh();
        }

        private void editor_Box_MouseDown(object sender, MouseEventArgs e)
        {

            this.engine.MouseDown(this, e.X, e.Y);


            this.editor_Box.Refresh();

        }

        private void editor_Box_MouseUp(object sender, MouseEventArgs e)
        {
            this.engine.MouseUp();
        }

        

        

        private void editor_Box_DoubleClick(object sender, EventArgs e)
        {

            this.engine.MouseDoubleClick(this);
            
            this.editor_Box.Refresh();

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            this.engine.ButtonDeleteClick(this);
            this.editor_Box.Refresh();

        }

        private void chck_ToggleRelCreation_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chck_ToggleRelCreation.Checked)
            {
                this.btn_Add.Enabled = false;


                this.engine.CheckboxChange(true);

                this.label1.Enabled = true;
                this.label1.Visible = true;
            }
            else
            {
                this.engine.CheckboxChange(false);


                this.btn_Add.Enabled = true;

                this.label1.Enabled = false;
                this.label1.Visible = false;
            }

            this.editor_Box.Refresh();
        }

        public void ChangeCheckbox(bool isChecked)
        {
            this.chck_ToggleRelCreation.Checked = isChecked;
        }

        private void btn_EditDataTypes_Click(object sender, EventArgs e)
        {
            Form_DataTypes frm = new Form_DataTypes();
            frm.ShowDialog();
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            

            Form_Exporter export_form = new Form_Exporter(this.editor_Box, this.engine);

            this.Hide();
            if (export_form.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void Form_Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
    }
}