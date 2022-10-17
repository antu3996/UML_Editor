using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UML_Editor_Nguyen.Components;
using UML_Editor_Nguyen.Relationship_Components;

namespace UML_Editor_Nguyen.Description_Components
{
    public class Class_Binder
    {
        public Action RefreshDependentRelationships { get; set; }

        public Circle Top { get; set; }
        public Circle Right { get; set; }
        public Circle Bottom { get; set; }
        public Circle Left { get; set; }

        public UML_Class_Object parent_rect { get; set; }

        public Class_Binder(UML_Class_Object rect)
        {
            int radius = 10;
            this.parent_rect = rect;
            this.Top = new Circle(rect.X + rect.Width / 2, rect.Y, radius);
            this.Right = new Circle(rect.X + rect.Width, rect.Y + rect.Height / 2, radius);
            this.Bottom = new Circle(rect.X + rect.Width / 2, rect.Y + rect.Height, radius);
            this.Left = new Circle(rect.X, rect.Y + rect.Height / 2, radius);
        }

        public void Draw(Graphics g)
        {
            this.Top.Draw(g);
            this.Right.Draw(g);
            this.Bottom.Draw(g);
            this.Left.Draw(g);
        }

        public void Refresh()
        {
            this.Top.FullRefresh(this.parent_rect.X + this.parent_rect.Width / 2, this.parent_rect.Y);
            this.Right.FullRefresh(this.parent_rect.X + this.parent_rect.Width, this.parent_rect.Y + this.parent_rect.Height / 2);
            this.Bottom.FullRefresh(this.parent_rect.X + this.parent_rect.Width / 2, this.parent_rect.Y + this.parent_rect.Height);
            this.Left.FullRefresh(this.parent_rect.X, this.parent_rect.Y + this.parent_rect.Height / 2);

            if (this.RefreshDependentRelationships != null)
            {
                this.RefreshDependentRelationships();
            }
        }

        public void SelectBindCircle(UML_Relationship relationship, int mouseX, int mouseY)
        {
            if (this.Top.IsMouseInArea(mouseX, mouseY))
            {
                if (relationship.IsFirst)
                {
                    relationship.StartPoint = this.Top;
                    relationship.InitialDirection = 1;
                }
                else
                {
                    relationship.EndPoint = this.Top;
                    relationship.DoneAdding();
                }
                this.RefreshDependentRelationships += relationship.RefreshOrigin;

            }
            if (this.Right.IsMouseInArea(mouseX, mouseY))
            {
                if (relationship.IsFirst)
                {
                    relationship.StartPoint = this.Right;
                    relationship.InitialDirection = 2;
                }
                else
                {
                    relationship.EndPoint = this.Right;
                    relationship.DoneAdding();
                }
                this.RefreshDependentRelationships += relationship.RefreshOrigin;

            }
            if (this.Bottom.IsMouseInArea(mouseX, mouseY))
            {
                if (relationship.IsFirst)
                {
                    relationship.StartPoint = this.Bottom;
                    relationship.InitialDirection = 3;
                }
                else
                {
                    relationship.EndPoint = this.Bottom;
                    relationship.DoneAdding();
                }
                this.RefreshDependentRelationships += relationship.RefreshOrigin;

            }
            if (this.Left.IsMouseInArea(mouseX, mouseY))
            {
                if (relationship.IsFirst)
                {
                    relationship.StartPoint = this.Left;
                    relationship.InitialDirection = 4;
                }
                else
                {
                    relationship.EndPoint = this.Left;
                    relationship.DoneAdding();
                }
                this.RefreshDependentRelationships += relationship.RefreshOrigin;

            }

        }

        

        public bool CheckIfCalculatedPosIsInArea(UML_Relationship relationship)
        {
            if (this.Top.IsMouseInArea(relationship.CalculatedX, relationship.CalculatedY))
            {
                relationship.EndPoint = this.Top;
                return true;
            }
            if (this.Right.IsMouseInArea(relationship.CalculatedX, relationship.CalculatedY))
            {
                relationship.EndPoint = this.Right;
                return true;
            }
            if (this.Bottom.IsMouseInArea(relationship.CalculatedX, relationship.CalculatedY))
            {
                relationship.EndPoint = this.Bottom;
                return true;
            }
            if (this.Left.IsMouseInArea(relationship.CalculatedX, relationship.CalculatedY))
            {
                relationship.EndPoint = this.Left;
                return true;
            }
            return false;
        }

        public Circle GetHoveredCircle(int mouseX, int mouseY) 
        {
            if (this.Top.IsMouseInArea(mouseX, mouseY))
            {
                return this.Top;
            }
            if (this.Right.IsMouseInArea(mouseX, mouseY))
            {
                return this.Right;
            }
            if (this.Bottom.IsMouseInArea(mouseX, mouseY))
            {
                return this.Bottom;
            }
            if (this.Left.IsMouseInArea(mouseX, mouseY))
            {
                return this.Left;
            }
            return null;
        }
    }
}
