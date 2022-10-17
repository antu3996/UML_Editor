using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Editor_Nguyen.Components
{
    public class Resizer
    {
        public Circle TopLeft { get; set; }
        public Circle TopRight { get; set; }
        public Circle BottomLeft { get; set; }
        public Circle BottomRight { get; set; }

        public int LeftToRight_Distance { get; set; }
        public int TopToBottom_Distance { get; set; }

        public Circle SelectedCircle { get; set; }

        public UML_Class_Object parent_rect { get; set; }

        public Resizer(UML_Class_Object rect)
        {
            this.parent_rect = rect;
            this.TopLeft = new Circle(rect.X, rect.Y);
            this.TopRight = new Circle(rect.X + rect.Width, rect.Y);
            this.BottomLeft = new Circle(rect.X, rect.Y + rect.Height);
            this.BottomRight = new Circle(rect.X + rect.Width, rect.Y + rect.Height);

            this.LeftToRight_Distance = rect.MinWidth;
            this.TopToBottom_Distance = rect.MinHeight;
        }

        public void Draw(Graphics g)
        {
            this.TopLeft.Draw(g);
            this.TopRight.Draw(g);
            this.BottomLeft.Draw(g);
            this.BottomRight.Draw(g);
        }

        public bool SetDragPoint(int mouseX, int mouseY)
        {
            if (this.TopLeft.SetDragPoint(mouseX, mouseY))
            {
                this.SelectedCircle = this.TopLeft;
                return true;
            }
            else if (this.TopRight.SetDragPoint(mouseX, mouseY))
            {
                this.SelectedCircle = this.TopRight;
                return true;
            }
            else if (this.BottomLeft.SetDragPoint(mouseX, mouseY))
            {
                this.SelectedCircle = this.BottomLeft;
                return true;
            }
            else if (this.BottomRight.SetDragPoint(mouseX, mouseY))
            {
                this.SelectedCircle = this.BottomRight;
                return true;
            }
            else
            {
                this.SelectedCircle = null;
                return false;
            }
        }

        public void ClearSelection()
        {
            this.SelectedCircle = null;
        }

        public void MouseDrag(int mouseX, int mouseY)
        {
            if (this.SelectedCircle != null)
            {
                this.SelectedCircle.MouseDrag(mouseX, mouseY);

                if (this.SelectedCircle == this.TopLeft)
                {
                    int newWidth = this.TopRight.X - this.TopLeft.X;
                    int newHeight = this.BottomLeft.Y - this.TopLeft.Y;
                    
                    this.SelectedCircle.Refresh(this.TopRight.X - Math.Max(newWidth, this.LeftToRight_Distance),
                        this.BottomLeft.Y - Math.Max(newHeight, this.TopToBottom_Distance));

                    this.TopRight.FullRefresh(this.TopRight.X, this.TopLeft.Y);
                    this.BottomLeft.FullRefresh(this.TopLeft.X, this.BottomLeft.Y);

                    
                }
                else if (this.SelectedCircle == this.TopRight)
                {
                    int newWidth = this.TopRight.X - this.TopLeft.X;
                    int newHeight = this.BottomRight.Y - this.TopRight.Y;

                    this.SelectedCircle.Refresh(this.TopLeft.X + Math.Max(newWidth, this.LeftToRight_Distance),
                        this.BottomRight.Y - Math.Max(newHeight, this.TopToBottom_Distance));

                    this.TopLeft.FullRefresh(this.TopLeft.X, this.TopRight.Y);
                    this.BottomRight.FullRefresh(this.TopRight.X, this.BottomRight.Y);

                }
                else if (this.SelectedCircle == this.BottomLeft)
                {
                    int newWidth = this.BottomRight.X - this.BottomLeft.X;
                    int newHeight = this.BottomLeft.Y - this.TopLeft.Y;

                    this.SelectedCircle.Refresh(this.BottomRight.X - Math.Max(newWidth, this.LeftToRight_Distance),
                        this.TopLeft.Y + Math.Max(newHeight, this.TopToBottom_Distance));

                    this.TopLeft.Refresh(this.BottomLeft.X, this.TopLeft.Y);
                    this.BottomRight.Refresh(this.BottomRight.X, this.BottomLeft.Y);
                }
                else if (this.SelectedCircle == this.BottomRight)
                {
                    int newWidth = this.BottomRight.X - this.BottomLeft.X;
                    int newHeight = this.BottomRight.Y - this.TopRight.Y;

                    this.SelectedCircle.Refresh(this.BottomLeft.X + Math.Max(newWidth, this.LeftToRight_Distance),
                        this.TopRight.Y + Math.Max(newHeight, this.TopToBottom_Distance));

                    this.TopRight.Refresh(this.BottomRight.X, this.TopRight.Y);
                    this.BottomLeft.Refresh(this.BottomLeft.X, this.BottomRight.Y);
                  
                }

                this.parent_rect.RefreshOrigin(this.TopLeft.X, this.TopLeft.Y, this.TopRight.X - this.TopLeft.X, this.BottomLeft.Y - this.TopLeft.Y);

            }
        }

        public bool IsMouseInArea(int mouseX, int mouseY)
        {
            return this.TopLeft.IsMouseInArea(mouseX, mouseY) || this.TopRight.IsMouseInArea(mouseX, mouseY)
                || this.BottomLeft.IsMouseInArea(mouseX, mouseY) || this.BottomRight.IsMouseInArea(mouseX, mouseY);
        }

        public void Refresh()
        {
            this.TopLeft.FullRefresh(this.parent_rect.X, this.parent_rect.Y);
            this.TopRight.FullRefresh(this.parent_rect.X + this.parent_rect.Width, this.parent_rect.Y);
            this.BottomLeft.FullRefresh(this.parent_rect.X, this.parent_rect.Y + this.parent_rect.Height);
            this.BottomRight.FullRefresh(this.parent_rect.X + this.parent_rect.Width, this.parent_rect.Y + this.parent_rect.Height);
        }
    }
}
