using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UML_Editor_Nguyen.Relationship_Components;
using UML_Editor_Nguyen.Relationship_Components.LineTypes;

namespace UML_Editor_Nguyen
{
    public partial class Form_Relationship : Form
    {
        public UML_Relationship_Description newDescription { get; set; }

        public Form_Relationship(UML_Relationship_Description newDescription)
        {
            InitializeComponent();

            this.newDescription = newDescription;
            this.txt_RelStereotype.Text = newDescription.Stereotype;
            this.txt_Multiplicity_Prim.Text = newDescription.Multiplicity1;
            this.txt_Multiplicity_Sec.Text = newDescription.Multiplicity2;
            
            if (this.newDescription.lineType.TypeName == "Association")
            {
                this.ch_Association.Checked = true;
            }
            if (this.newDescription.lineType.TypeName == "Aggregation")
            {
                this.ch_Aggre.Checked = true;
            }
            if (this.newDescription.lineType.TypeName == "Dependency")
            {
                this.ch_Dep.Checked = true;
            }
            if (this.newDescription.lineType.TypeName == "Realization")
            {
                this.ch_Real.Checked = true;
            }
            if (this.newDescription.lineType.TypeName == "Inheritance")
            {
                this.ch_Inhe.Checked = true;
            }
            if (this.newDescription.lineType.TypeName == "Composition")
            {
                this.ch_Comp.Checked = true;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            this.newDescription.Stereotype = this.txt_RelStereotype.Text;
            this.newDescription.Multiplicity1 = this.txt_Multiplicity_Prim.Text;
            this.newDescription.Multiplicity2 = this.txt_Multiplicity_Sec.Text;

            if(this.ch_Aggre.Checked)
            {
                this.newDescription.lineType = new Ln_Aggregation();

            }
            if (this.ch_Association.Checked)
            {
                this.newDescription.lineType = new Ln_Association();

            }
            if (this.ch_Comp.Checked)
            {
                this.newDescription.lineType = new Ln_Composition();

            }
            if (this.ch_Dep.Checked)
            {
                this.newDescription.lineType = new Ln_Dependency();

            }
            if (this.ch_Inhe.Checked)
            {
                this.newDescription.lineType = new Ln_Inheritance();

            }
            if (this.ch_Real.Checked)
            {
                this.newDescription.lineType = new Ln_Realization();

            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
