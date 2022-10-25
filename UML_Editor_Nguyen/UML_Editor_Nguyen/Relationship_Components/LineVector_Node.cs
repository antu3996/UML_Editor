using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using UML_Editor_Nguyen.Relationship_Components.LineTypes;

namespace UML_Editor_Nguyen.Relationship_Components
{
    public class LineVector_Node
    {/*
        public LineVector_Node Previous { get; set; }
        public LineVector_Node Next { get; set; }

        public int Vector_Index { get; set; }

        public LineVector Current_Object { get; set; }

        public LineVector_Node AddAndGetLast(LineVector vect)
        {
            if (this.Current_Object == null)
            {
                this.Current_Object = vect;
                return this;
            }
            else
            {
                if (this.Next == null)
                {
                    this.Next = new LineVector_Node();
                    this.Next.Current_Object = vect;
                    this.Next.Previous = this;
                    return this.Next;
                }
                else
                {
                    return this.Next.AddAndGetLast(vect);
                }
            }
        }

        public void Draw(Graphics g, LineType lineType)
        {
            if (this.Current_Object != null)
            {
                this.Current_Object.Draw(g, lineType);
            }

            if (this.Next != null)
            {
                this.Next.Draw(g, lineType);
            }
        }

        public LineVector_Node GetNextUntilIndex(int index)
        {
            if (this.Vector_Index == index)
            {
                return this;
            }
            else
            {
                if (this.Next != null)
                {
                    return this.Next.GetNextUntilIndex(index);
                }
                else
                {
                    return this;
                }
            }
        }

        public void MouseDrag(int mouseX, int mouseY)
        {
            if (this.Current_Object != null && this.Current_Object.IsSelected)
            {
                this.Current_Object.MouseDrag(mouseX, mouseY);


                if (this.Previous != null)
                    this.Previous.RepositionEndPoint(this.Current_Object.StartPoint.X, this.Current_Object.StartPoint.Y);

                if (this.Next != null)
                    this.Next.RepositionStartPoint(this.Current_Object.EndPoint.X, this.Current_Object.EndPoint.Y);
            }
            else
            {
                if (this.Next != null)
                {
                    this.Next.MouseDrag(mouseX, mouseY);
                }
            }
        }

        public void RepositionEndPoint(int x, int y)
        {
            if (this.Current_Object != null)
            {
                this.Current_Object.RepositionEndPoint(x, y);
            }

            if (this.Previous != null)
            {
                this.Previous.RepositionEndPoint(this.Current_Object.StartPoint.X, this.Current_Object.StartPoint.Y);
            }
        }

        public void RepositionStartPoint(int x, int y)
        {
            if (this.Current_Object != null)
            {
                this.Current_Object.RepositionStartPoint(x, y);
            }

            if (this.Next != null)
            {
                this.Next.RepositionStartPoint(this.Current_Object.EndPoint.X, this.Current_Object.EndPoint.Y);
            }
        }

        public LineVector_Node SelectVector(int mouseX, int mouseY)
        {
            if(!this.Current_Object.SelectVector(mouseX, mouseY))
            {
                if (this.Next != null)
                {
                    return this.Next.SelectVector(mouseX, mouseY);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return this;
            }
        }

        public bool IsColliding(LineVector otherVector)
        {
            if (this.Current_Object != null && this.Current_Object.IsColliding(otherVector))
            {
                return true;
            }
            else
            {
                if (this.Next != null)
                {
                    return this.Next.IsColliding(otherVector);
                }
                else
                {
                    return false;
                }
            }
        }

        public void ClearSelection()
        {
            if (this.Current_Object != null)
            {
                this.Current_Object.ClearSelection();
            }
           
            if (this.Next != null)
            {
                this.Next.ClearSelection();
            }
        }*/
    }
}
