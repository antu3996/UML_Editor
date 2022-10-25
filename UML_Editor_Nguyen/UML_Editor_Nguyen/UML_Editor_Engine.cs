using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using UML_Editor_Nguyen.Comparers;
using UML_Editor_Nguyen.Relationship_Components;

namespace UML_Editor_Nguyen
{
    public class UML_Editor_Engine
    {


        public bool IsCreatingRelationshipMode { get; set; } = false;
        
        public bool BothSelected { get; set; } = false;

        public UML_Class_Object firstSelection { get; set; }
        public UML_Class_Object secondSelection { get; set; }

        public List<UML_Relationship> relationships { get; set; } = new List<UML_Relationship>();

        public UML_Relationship selectedRelationship { get; set; } = null;


        public List<UML_Class_Object> classes { get; set; } = new List<UML_Class_Object>();
        
        public bool IsMouseDown { get; set; } = false;

        public UML_Class_Object selectedClass { get; set; } = null;

        public UML_Editor_Engine()
        {
        }
        public void Draw(Graphics g)
        {
            foreach (UML_Class_Object item in this.classes)
            {
                item.Draw(g);
            }



            foreach (UML_Relationship item in this.relationships)
            {
                item.RefreshState();
                item.Draw(g);
            }
        }

        public void ButtonAddClick(Form_Editor parent)
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
                newClass.ID = this.classes.Count;
                this.classes.Add(newClass);

                this.classes.Sort(new UML_ClassRect_Comparer());
            }
        }

        public void MouseMove(Form_Editor parent, int mouseX, int mouseY)
        {
            if (!this.IsCreatingRelationshipMode)
            {
                if (this.IsMouseDown)
                {

                    if (this.selectedClass != null)
                    {
                        this.selectedClass.MouseDrag(mouseX, mouseY);
                        this.CheckCollisions();
                    }

                }
            }
        }

        public void MouseDown(Form_Editor parent, int mouseX, int mouseY)
        {
            if (!this.IsCreatingRelationshipMode)
            {
                if (!this.IsMouseDown)
                {
                    this.IsMouseDown = true;


                    this.SelectClass(mouseX, mouseY);

                    this.SelectVector(mouseX, mouseY);


                    if (this.selectedClass != null)
                    {
                        this.selectedClass.SetDragPoint(mouseX, mouseY);
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
                        this.MultiSelect(parent, mouseX, mouseY);

                    }
                }
            }
        }

        public void MouseUp()
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

                if (current.IsSelected)
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

        private void MultiSelect(Form_Editor parent, int mouseX, int mouseY)
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

                                UML_Relationship newRelationship = null;

                                foreach (UML_Relationship item in this.relationships)
                                {
                                    if (item.CheckIfRelationshipExistsBetweenClasses(this.firstSelection, this.secondSelection))
                                    {
                                        newRelationship = item;

                                        break;
                                    }
                                }

                                if (newRelationship == null)
                                {
                                 
                                    this.relationships.Add(new UML_Relationship(this.firstSelection, this.secondSelection));
                                }


                                parent.ChangeCheckbox(false);


                                break;
                            }
                        }
                    }
                }

                
            }


        }

        public void ClearSelection()
        {
            this.CheckboxChange(false);

            if (this.selectedClass != null)
            {
                this.selectedClass.ClearSelection();
            }
            if (this.selectedRelationship != null)
            {
                this.selectedRelationship.ClearSelection();
            }
        }

        public void MouseDoubleClick(Form_Editor parent)
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
        }

        public void ButtonDeleteClick(Form_Editor parent)
        {
            if (!this.IsCreatingRelationshipMode)
            {
                if (this.selectedClass != null)
                {
                    this.classes.Remove(this.selectedClass);
                    this.selectedClass = null;

                }

                if (this.selectedRelationship != null)
                {
                    this.relationships.Remove(this.selectedRelationship);
                    this.selectedRelationship.Delete();
                    this.selectedRelationship = null;
                }
            }
        }

        public void CheckboxChange(bool isChecked)
        {
            if (isChecked)
            {
                this.IsCreatingRelationshipMode = true;

                if (this.selectedClass != null)
                {
                    this.selectedClass.ClearSelection();
                    this.selectedClass = null;
                }

            }
            else
            {
                this.IsCreatingRelationshipMode = false;
                this.BothSelected = false;

                if (firstSelection != null)
                {
                    this.firstSelection.ClearSelection();
                    this.firstSelection = null;

                }
                if (secondSelection != null)
                {
                    this.secondSelection.ClearSelection();
                    this.secondSelection = null;
                }
            }
        }

        public void ImportData(UML_Editor_Engine other)
        {

            for (int i = 0; i < other.classes.Count; i++)
            {
                UML_Class_Object newClass = new UML_Class_Object(0,0,0,0);
                newClass.ImportData(other.classes[i]);

                this.classes.Add(newClass);
            }

            for (int i = 0; i < other.relationships.Count; i++)
            {
                UML_Class_Object first = this.classes.Where(item => item.ID == other.relationships[i].Primary_Class.ID).FirstOrDefault();
                UML_Class_Object second = this.classes.Where(item => item.ID == other.relationships[i].Secondary_Class.ID).FirstOrDefault();

                UML_Relationship newRel = new UML_Relationship(first, second);

                if (newRel.Primary_Class != null && newRel.Secondary_Class != null)
                {
                   
                    newRel.ImportData(other.relationships[i]);

                
                    this.relationships.Add(newRel);
                }
            }


            
    }
    }
}
