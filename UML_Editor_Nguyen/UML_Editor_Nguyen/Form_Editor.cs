
using UML_Editor_Nguyen.Comparers;
using UML_Editor_Nguyen.Components;
using UML_Editor_Nguyen.Relationship_Components;

namespace UML_Editor_Nguyen
{
    public partial class Form_Editor : Form
    {
        private List<UML_Relationship> relationships = new List<UML_Relationship>();
        private UML_Relationship newRelationship;
        private UML_Relationship deletedRelationship;
        private bool IsCreatingRelationshipMode = false;
        private UML_Class_Object firstSelection;
        private UML_Class_Object secondSelection;
        private bool BothSelected = false;

        private UML_Relationship selectedRelationship = null;


        private List<UML_Class_Object> classes = new List<UML_Class_Object>();
        private bool IsMouseDown = false;
        private UML_Class_Object selectedClass = null;
        
        public Form_Editor()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (!this.IsCreatingRelationshipMode)
            {
                UML_Class_Object newClass = new UML_Class_Object(30, 30, 200, 250);

                for (int i = this.classes.Count - 1; i >= 0; i--)
                {
                    UML_Class_Object current = this.classes[i];
                    if (newClass.IsColliding(current))
                    {
                        newClass.Layer_Index = current.Layer_Index + 1;
                        break;
                    }
                }

                this.classes.Add(newClass);

                this.classes.Sort(new UML_ClassRect_Comparer());
            }
            
            
            

            this.editor_Box.Refresh();
        }

        private void editor_Box_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (UML_Class_Object item in this.classes)
            {
                item.Draw(g);
            }



            foreach (UML_Relationship item in this.relationships)
            {
                item.Draw(g);
            }

        }


        private void editor_Box_MouseMove(object sender, MouseEventArgs e)
        {
            if (!this.IsCreatingRelationshipMode)
            {
                if (this.IsMouseDown)
                {

                    if (this.selectedClass != null)
                    {
                        this.selectedClass.MouseDrag(e.X, e.Y);
                        this.CheckCollisions();
                    }

                    if (this.selectedRelationship != null)
                    {
                        this.selectedRelationship.MouseDrag(e.X, e.Y);
                        this.CheckCollisionsVector();
                    }

                }
            }
            else
            {
                int fixedMouseX = e.X;
                int fixedMouseY = e.Y;

                if (this.newRelationship != null && this.newRelationship.StillAdding)
                {
                    Circle hovered1 = this.firstSelection.Binder_Component.GetHoveredCircle(e.X, e.Y);
                    Circle hovered2 = this.secondSelection.Binder_Component.GetHoveredCircle(e.X, e.Y);

                    if (hovered1 != null)
                    {
                        fixedMouseX = hovered1.X;
                        fixedMouseY = hovered1.Y;
                    }
                    if (hovered1 == null && hovered2 != null)
                    {
                        fixedMouseX = hovered2.X;
                        fixedMouseY = hovered2.Y;
                    }

                    
                    this.newRelationship.MouseMove(fixedMouseX, fixedMouseY);
                }

            }

            this.editor_Box.Refresh();
        }

        private void editor_Box_MouseDown(object sender, MouseEventArgs e)
        {
            if (!this.IsCreatingRelationshipMode)
            {
                if (!this.IsMouseDown)
                {
                    this.IsMouseDown = true;


                    this.SelectClass(e.X, e.Y);

                    this.SelectVector(e.X, e.Y);


                    if (this.selectedClass != null)
                    {
                        this.selectedClass.SetDragPoint(e.X, e.Y);
                        this.CheckCollisions();
                    }
                }
            }
            else
            {
                if (!this.IsMouseDown)
                {
                    this.IsMouseDown = true;

                    if (!this.BothSelected)
                    {
                        this.MultiSelect(e.X, e.Y);

                    }


                    if (this.newRelationship != null && this.newRelationship.StillAdding)
                    {
                        if (this.newRelationship.StartPoint == null)
                        {
                            this.firstSelection.Binder_Component.SelectBindCircle(this.newRelationship,
                                e.X, e.Y);
                            

                        }
                        else
                        {
                            this.newRelationship.MouseClick(e.X, e.Y);

                            if (this.secondSelection.Binder_Component.CheckIfCalculatedPosIsInArea(this.newRelationship))
                            {
                                this.secondSelection.Binder_Component.SelectBindCircle(this.newRelationship, e.X, e.Y);
                            }
                        }

                        



                        /*if (!this.newRelationship.StillAdding)
                        {
                            this.chck_ToggleRelCreation.Checked = false;
                        }*/
                    }

                    

                }
            }
            this.editor_Box.Refresh();

        }

        private void editor_Box_MouseUp(object sender, MouseEventArgs e)
        {
            this.IsMouseDown = false;
        }

        private void CheckCollisions()
        {
            for (int i = this.classes.Count - 1; i >= 0; i--)
            {
                UML_Class_Object current = this.classes[i];
                if (this.selectedClass.IsColliding(current))
                {
                    this.selectedClass.Layer_Index = current.Layer_Index + 1;
                    break;
                }
                else
                {
                    this.selectedClass.Layer_Index = 1;
                }
            }

            this.classes.Sort(new UML_ClassRect_Comparer());
        }

        private void SelectClass(int mouseX, int mouseY)
        {
            UML_Class_Object newSelection = null;
            for (int i = this.classes.Count - 1; i >= 0; i--)
            {
                UML_Class_Object current = this.classes[i];
                bool isSelected = current.SelectClass(mouseX, mouseY);

                if (isSelected)
                {
                    newSelection = current;
                    break;
                }
            }
            if (this.selectedClass != null)
            {
                if (newSelection != this.selectedClass)
                {
                    this.selectedClass.ClearSelection();
                    this.selectedClass = newSelection;
                    return;
                }
            }
            else
            {
                this.selectedClass = newSelection;
            }
                
        }


        private void SelectVector(int mouseX, int mouseY)
        {
            UML_Relationship newSelection = null;
            for (int i = this.relationships.Count - 1; i >= 0; i--)
            {
                UML_Relationship current = this.relationships[i];
                current.SelectVector(mouseX, mouseY);

                if (current.selectedVector != null)
                {
                    newSelection = current;
                    break;
                }
            }
            if (this.selectedRelationship != null)
            {
                if (newSelection != this.selectedRelationship)
                {
                    this.selectedRelationship.ClearSelection();
                    this.selectedRelationship = newSelection;
                    return;
                }
            }
            else
            {
                this.selectedRelationship = newSelection;
            }

        }

        public void CheckCollisionsVector()
        {
            for (int i = this.relationships.Count - 1; i >= 0; i--)
            {
                UML_Relationship current = this.relationships[i];
                if (current.IsColliding(this.selectedRelationship.selectedVector))
                {
                    this.selectedRelationship.Layer_Index = current.Layer_Index + 1;
                    break;
                }
                else
                {
                    this.selectedRelationship.Layer_Index = 1;
                }
            }

            this.relationships.Sort(new UML_Relationship_Comparer());
        }

        private void editor_Box_DoubleClick(object sender, EventArgs e)
        {
            if (!this.IsCreatingRelationshipMode)
            {
                if (this.selectedClass != null)
                {
                    this.selectedClass.EditDescription();


                    UML_Class_Object lastOne = this.classes[this.classes.Count - 1];
                    if (this.selectedClass != lastOne)
                    {
                        this.selectedClass.Layer_Index = lastOne.Layer_Index + 1;
                        this.classes.Sort(new UML_ClassRect_Comparer());
                    }


                }

                if (this.selectedRelationship != null)
                {
                    this.selectedRelationship.DoubleClick();
                }
            }
            this.editor_Box.Refresh();

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (!this.IsCreatingRelationshipMode)
            {
                if (this.selectedClass != null)
                {
                    this.classes.Remove(this.selectedClass);
                    this.selectedClass = null;

                    this.editor_Box.Refresh();
                }
            }
            else
            {
                if (this.newRelationship != null)
                {
                    this.relationships.Remove(this.newRelationship);
                    this.deletedRelationship = this.newRelationship;
                    this.newRelationship = null;

                    this.newRelationship = new UML_Relationship(this.firstSelection, this.secondSelection);
                    this.relationships.Add(this.newRelationship);
                }
            }
        }

        private void chck_ToggleRelCreation_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chck_ToggleRelCreation.Checked)
            {
                this.btn_Add.Enabled = false;
                this.IsCreatingRelationshipMode = true;
                if (this.selectedClass != null)
                {
                    this.selectedClass.ClearSelection();
                    this.selectedClass = null;
                }
            }
            else
            {
                if (this.deletedRelationship != null)
                {
                    this.newRelationship.CopyFromOther(this.deletedRelationship);
                    this.deletedRelationship = null;
                }

                this.IsCreatingRelationshipMode = false;
                this.newRelationship = null;
                this.BothSelected = false;

                if (firstSelection != null)
                {
                    this.firstSelection.ClearSelection();
                    this.firstSelection.IsInBindingMode = false;
                    this.firstSelection = null;

                }
                if (secondSelection != null)
                {
                    this.secondSelection.ClearSelection();
                    this.secondSelection.IsInBindingMode = false;
                    this.secondSelection = null;
                }
                
                
            }

            this.editor_Box.Refresh();
        }

        private void MultiSelect(int mouseX, int mouseY)
        {
            if (!this.BothSelected)
            {
                for (int i = this.classes.Count - 1; i >= 0; i--)
                {
                    UML_Class_Object current = this.classes[i];

                    if (this.firstSelection == null)
                    {
                        bool isSelected = current.SelectClass(mouseX, mouseY);
                        if (isSelected)
                        {
                            this.firstSelection = current;
                            this.BothSelected = false;
                            break;
                        }
                    }
                    else
                    {

                        if (current != this.firstSelection)
                        {
                            bool isSelected = current.SelectClass(mouseX, mouseY);
                            if (isSelected)
                            {
                                this.secondSelection = current;
                                this.BothSelected = true;

                                foreach (UML_Relationship item in this.relationships)
                                {
                                    if ((item.Primary_Class == firstSelection || item.Primary_Class == secondSelection) &&
                                        (item.Secondary_Class == secondSelection || item.Secondary_Class == firstSelection))
                                    {
                                        this.newRelationship = item;

                                        this.secondSelection.IsInBindingMode = true;
                                        this.firstSelection.IsInBindingMode = true;
                                        break;
                                    }
                                }

                                if (this.newRelationship == null)
                                {
                                    this.newRelationship = new UML_Relationship(this.firstSelection, this.secondSelection);
                                    this.relationships.Add(this.newRelationship);
                                }

                                break;
                            }
                        }
                    }
                }

                this.editor_Box.Refresh();
            }

           
        }
    }
}