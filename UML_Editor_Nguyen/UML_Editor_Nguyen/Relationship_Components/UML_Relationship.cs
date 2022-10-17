using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UML_Editor_Nguyen.Components;

namespace UML_Editor_Nguyen.Relationship_Components
{
    public class UML_Relationship
    {
        public Circle StartPoint { get; set; }
        public Circle EndPoint { get; set; }
        public LineVector_List Vectors { get; set; }

        public int Layer_Index { get; set; } = 1;
        
        public UML_Class_Object Primary_Class { get; set; }
        public UML_Class_Object Secondary_Class { get; set; }

        public bool StillAdding { get; set; } = true;
        public int CalculatedX { get; set; }
        public int CalculatedY { get; set; }
        public bool NotValidMousePos { get; set; } = false;
        public int InitialDirection { get; set; } = 1;
        public bool IsFirst { get; set; } = true;

        public LineVector selectedVector { get; set; } = null;

        public UML_Relationship_Description Description_Component { get; set; }

        public UML_Relationship(UML_Class_Object primary, UML_Class_Object secondary)
        {
            this.Primary_Class = primary;
            this.Secondary_Class = secondary;
            this.Vectors = new LineVector_List();

            this.Primary_Class.IsInBindingMode = true;
            this.Secondary_Class.IsInBindingMode = true;

            this.Description_Component = new UML_Relationship_Description(this);
        }

        public void Draw(Graphics g)
        {
            if (this.StartPoint != null)
            {
                this.Vectors.Draw(g, this.Description_Component.lineType);

                if (!this.StillAdding)
                {
                    this.Description_Component.Draw(g);

                    this.Description_Component.lineType.DrawArrow(g, this.Vectors.EndVector.Current_Object.EndPoint.X,
                        this.Vectors.EndVector.Current_Object.EndPoint.Y,
                        this.Vectors.EndVector.Current_Object.Direction);
                }

                Pen p = new Pen(Color.Black, 3f);


                if (this.IsFirst)
                {
                    g.DrawLine(p, this.StartPoint.X, this.StartPoint.Y, this.CalculatedX, this.CalculatedY);
                }
                else
                {
                    if (this.StillAdding)
                    {

                        int lastPointX = this.Vectors.EndVector.Current_Object.EndPoint.X;
                        int lastPointY = this.Vectors.EndVector.Current_Object.EndPoint.Y;

                        g.DrawLine(p, lastPointX, lastPointY, this.CalculatedX, this.CalculatedY);
                    }
                }
            }
        }

        public void RefreshOrigin()
        {
            this.Vectors.StartVector.Current_Object.MoveVector(this.StartPoint.X, this.StartPoint.Y);
            this.Vectors.EndVector.Current_Object.MoveVector(this.EndPoint.X, this.EndPoint.Y);
            this.Vectors.StartVector.RepositionStartPoint(this.StartPoint.X, this.StartPoint.Y);
            this.Vectors.EndVector.RepositionEndPoint(this.EndPoint.X, this.EndPoint.Y);
        }

        public void MouseMove(int mouseX, int mouseY)
        {
            if (this.StartPoint != null)
            {
                if (this.IsFirst)
                {
                    if (this.InitialDirection == 1 || this.InitialDirection == 3)
                    {
                        this.CalculatedX = this.StartPoint.X;
                        this.CalculatedY = mouseY;
                    }
                    if (this.InitialDirection == 2 || this.InitialDirection == 4)
                    {
                        this.CalculatedX = mouseX;
                        this.CalculatedY = this.StartPoint.Y;
                    }
                }
                else
                {
                    LineVector endVector = this.Vectors.EndVector.Current_Object;
                    int lastPointX = endVector.EndPoint.X;
                    int lastPointY = endVector.EndPoint.Y;

                    int diffX = Math.Abs(mouseX - lastPointX);
                    int diffY = Math.Abs(mouseY - lastPointY);

                    if (diffX >= diffY)
                    {
                        if (!(endVector.Direction == 2 || endVector.Direction == 4))
                        {
                            this.CalculatedX = mouseX;
                            this.CalculatedY = lastPointY;
                            this.NotValidMousePos = false;
                        }
                        else
                        {
                            this.NotValidMousePos = true;
                        }

                    }
                    if (diffY > diffX)
                    {
                        if (!(endVector.Direction == 1 || endVector.Direction == 3))
                        {
                            this.CalculatedX = lastPointX;
                            this.CalculatedY = mouseY;
                            this.NotValidMousePos = false;
                        }
                        else
                        {
                            this.NotValidMousePos = true;
                        }
                    }
                }
            }
            
            
            
        }

        public void MouseClick(int mouseX, int mouseY)
        {
            if (this.StartPoint != null)
            {
                if (this.IsFirst)
                {
                    this.Vectors.AddNewVector(
                        new LineVector(this.StartPoint.X, this.StartPoint.Y, this.CalculatedX, this.CalculatedY));

                    this.IsFirst = false;
                }
                else
                {
                    if (!this.NotValidMousePos)
                    {
                        int lastPointX = this.Vectors.EndVector.Current_Object.EndPoint.X;
                        int lastPointY = this.Vectors.EndVector.Current_Object.EndPoint.Y;

                        this.Vectors.AddNewVector(
                            new LineVector(lastPointX, lastPointY, this.CalculatedX, this.CalculatedY));

                        /*if(this.Secondary_Class.Binder_Component.CheckIfCalculatedPosIsInArea(this, mouseX, mouseY))
                        {
                            this.StillAdding = false;
                        }*/
                    }
                }
            }
            
        }

        public void DoubleClick()
        {
            this.Description_Component.OpenForm();
        }

        public void DoneAdding()
        {
            this.StillAdding = false;

            this.Vectors.StartVector.Current_Object.IsLocked = true;
            this.Vectors.EndVector.Current_Object.IsLocked = true;
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
    }
}
