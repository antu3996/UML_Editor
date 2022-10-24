using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UML_Editor_Nguyen.Components;
using UML_Editor_Nguyen.Description_Components;

namespace UML_Editor_Nguyen.Relationship_Components
{
    public class UML_Relationship
    {
        public BindingCircle StartPoint { get; set; }
        public BindingCircle EndPoint { get; set; }
        public LineVector_List Vectors { get; set; }

        public int Layer_Index { get; set; } = 1;
        
        public UML_Class_Object Primary_Class { get; set; }
        public UML_Class_Object Secondary_Class { get; set; }

        public LineVector selectedVector { get; set; } = null;


        public UML_Relationship_Description Description_Component { get; set; }
        public RelationshipBoundGenerator VectorGen_Component { get; set; }
        
        public string RelationshipDirection { get; set; }
        public string CurrentPrimarySide { get; set; }
        public string CurrentSecondarySide { get; set; }

        public UML_Relationship(UML_Class_Object primary, UML_Class_Object secondary)
        {
            this.Primary_Class = primary;
            this.Secondary_Class = secondary;
            this.Vectors = new LineVector_List();

            

            this.Primary_Class.Binder_Component.RefreshDependentRelationships += this.RefreshOrigin;
            this.Secondary_Class.Binder_Component.RefreshDependentRelationships += this.RefreshOrigin;


            this.Description_Component = new UML_Relationship_Description(this);

            this.VectorGen_Component = new RelationshipBoundGenerator(this);

            this.VectorGen_Component.DidGeneratePoints();
        }
        public void Draw(Graphics g)
        {
            this.Vectors.Draw(g, this.Description_Component.lineType);
            this.Description_Component.Draw(g);
        }

        public void RefreshOrigin(UML_Relationship caller)
        {

            if (caller != this)
            {
                this.VectorGen_Component.DidGeneratePoints();
            }
        }



        public void DoubleClick()
        {
            if (this.selectedVector != null)
            {
                this.Description_Component.OpenForm();
            }
        }


        public void SelectVector(int mouseX, int mouseY)
        {
            LineVector_Node selected = this.Vectors.StartVector.SelectVector(mouseX, mouseY);

            if (selected != null)
            {
                 this.selectedVector = selected.Current_Object;
            }
            else
            {
                this.selectedVector = null;
            }
        }

        public bool IsColliding(LineVector vect)
        {
            return this.Vectors.StartVector.IsColliding(vect);
        }

        public void ClearSelection()
        {
            this.Vectors.StartVector.ClearSelection();
            this.selectedVector = null;
        }
        
        public void MouseDrag(int mouseX, int mouseY)
        {
            if (this.selectedVector != null)
            {
                this.Vectors.StartVector.MouseDrag(mouseX, mouseY);
            }
        }

        public void CopyFromOther(UML_Relationship otherRel)
        {
            this.Description_Component = otherRel.Description_Component;
            otherRel.Description_Component.parent_rel = this;
            this.Layer_Index = otherRel.Layer_Index;
        }

        public void Delete()
        {
            if (this.selectedVector != null)
            {
                this.Primary_Class.Binder_Component.RemoveBindingCircleFromSide(this, this.CurrentPrimarySide, this.StartPoint);
                this.Secondary_Class.Binder_Component.RemoveBindingCircleFromSide(this, this.CurrentSecondarySide, this.EndPoint);
            }
        }

        public bool CheckIfRelationshipExistsBetweenClasses(UML_Class_Object class1, UML_Class_Object class2)
        {
            if ((this.Primary_Class == class1 || this.Primary_Class == class2) &&
                                        (this.Secondary_Class == class1 || this.Secondary_Class == class2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
