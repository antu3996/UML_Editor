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
        public LineVector_List VectorList { get; set; }

        public int Layer_Index { get; set; } = 1;
        
        public UML_Class_Object Primary_Class { get; set; }
        public UML_Class_Object Secondary_Class { get; set; }

        public bool IsSelected { get; set; } = false;


        public UML_Relationship_Description Description_Component { get; set; }
        public RelationshipBoundGenerator VectorGen_Component { get; set; }
        
        public string RelationshipDirection { get; set; }
        public string CurrentPrimarySide { get; set; }
        public string CurrentSecondarySide { get; set; }

        public UML_Relationship(UML_Class_Object primary, UML_Class_Object secondary)
        {

            this.Primary_Class = primary;
            this.Secondary_Class = secondary;


            this.VectorList = new LineVector_List();


            this.Description_Component = new UML_Relationship_Description(this);

            this.VectorGen_Component = new RelationshipBoundGenerator();




        }
        public void Draw(Graphics g)
        {
            this.VectorList.Draw(g, this.Description_Component.lineType);
            this.Description_Component.Draw(g);
        }

        public void RefreshState()
        {
            this.VectorGen_Component.GeneratePoints(this);
        }



        public void DoubleClick()
        {
            if (this.IsSelected)
            {
                this.Description_Component.OpenForm();
            }
        }


        public void SelectVector(int mouseX, int mouseY)
        {
            if (this.VectorList.SelectVector(mouseX, mouseY))
            {
                this.IsSelected = true;
            }
            else
            {
                this.IsSelected = false;
            }
        }

        public void ClearSelection()
        {
            this.VectorList.ClearSelection();
        }
        public void CopyFromOther(UML_Relationship otherRel)
        {
            this.Description_Component = otherRel.Description_Component;
            otherRel.Description_Component.parent_rel = this;
            this.Layer_Index = otherRel.Layer_Index;
        }

        public void Delete()
        {
            if (this.IsSelected)
            {
                this.Primary_Class.Binder_Component.RemoveBindingCircleFromSide(this.Primary_Class, this.CurrentPrimarySide, this.StartPoint);
                this.Secondary_Class.Binder_Component.RemoveBindingCircleFromSide(this.Secondary_Class, this.CurrentSecondarySide, this.EndPoint);
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

        public void ImportData(UML_Relationship other)
        {

            this.CurrentPrimarySide = other.CurrentPrimarySide;
            this.CurrentSecondarySide = other.CurrentSecondarySide;
            this.Layer_Index = other.Layer_Index;

            this.Description_Component.ImportData(other.Description_Component);

            this.StartPoint = this.Primary_Class.Binder_Component.GetCircleById(other.StartPoint.ID,
                this.CurrentPrimarySide);
            this.EndPoint = this.Secondary_Class.Binder_Component.GetCircleById(other.EndPoint.ID,
                this.CurrentSecondarySide);
            this.VectorGen_Component.GeneratePoints(this);



        }
    }
}
