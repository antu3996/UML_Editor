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

        public Circle SelectedCircle { get; set; }

        public Resizer(UML_Class_Object rect)
        {
            this.TopLeft = new Circle(rect.X, rect.Y);
            this.TopRight = new Circle(rect.X + rect.Width, rect.Y);
            this.BottomLeft = new Circle(rect.X, rect.Y + rect.Height);
            this.BottomRight = new Circle(rect.X + rect.Width, rect.Y + rect.Height);
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

        public void MouseDrag(UML_Class_Object caller, int mouseX, int mouseY)
        {
            if (this.SelectedCircle != null)
            {
                this.SelectedCircle.MouseDrag(mouseX, mouseY);

                if (this.SelectedCircle == this.TopLeft)
                {
                    int newWidth = this.TopRight.X - this.TopLeft.X;
                    int newHeight = this.BottomLeft.Y - this.TopLeft.Y;
                    
                    this.SelectedCircle.Refresh(this.TopRight.X - Math.Max(newWidth, caller.MinWidth),
                        this.BottomLeft.Y - Math.Max(newHeight, caller.MinHeight));

                    this.TopRight.FullRefresh(this.TopRight.X, this.TopLeft.Y);
                    this.BottomLeft.FullRefresh(this.TopLeft.X, this.BottomLeft.Y);

                    
                }
                else if (this.SelectedCircle == this.TopRight)
                {
                    int newWidth = this.TopRight.X - this.TopLeft.X;
                    int newHeight = this.BottomRight.Y - this.TopRight.Y;

                    this.SelectedCircle.Refresh(this.TopLeft.X + Math.Max(newWidth, caller.MinWidth),
                        this.BottomRight.Y - Math.Max(newHeight, caller.MinHeight));

                    this.TopLeft.FullRefresh(this.TopLeft.X, this.TopRight.Y);
                    this.BottomRight.FullRefresh(this.TopRight.X, this.BottomRight.Y);

                }
                else if (this.SelectedCircle == this.BottomLeft)
                {
                    int newWidth = this.BottomRight.X - this.BottomLeft.X;
                    int newHeight = this.BottomLeft.Y - this.TopLeft.Y;

                    this.SelectedCircle.Refresh(this.BottomRight.X - Math.Max(newWidth, caller.MinWidth),
                        this.TopLeft.Y + Math.Max(newHeight, caller.MinHeight));

                    this.TopLeft.Refresh(this.BottomLeft.X, this.TopLeft.Y);
                    this.BottomRight.Refresh(this.BottomRight.X, this.BottomLeft.Y);
                }
                else if (this.SelectedCircle == this.BottomRight)
                {
                    int newWidth = this.BottomRight.X - this.BottomLeft.X;
                    int newHeight = this.BottomRight.Y - this.TopRight.Y;

                    this.SelectedCircle.Refresh(this.BottomLeft.X + Math.Max(newWidth, caller.MinWidth),
                        this.TopRight.Y + Math.Max(newHeight, caller.MinHeight));

                    this.TopRight.Refresh(this.BottomRight.X, this.TopRight.Y);
                    this.BottomLeft.Refresh(this.BottomLeft.X, this.BottomRight.Y);
                  
                }

                caller.RefreshOrigin(this.TopLeft.X, this.TopLeft.Y, this.TopRight.X - this.TopLeft.X, this.BottomLeft.Y - this.TopLeft.Y);

            }
        }

        public bool IsMouseInArea(int mouseX, int mouseY)
        {
            return this.TopLeft.IsMouseInArea(mouseX, mouseY) || this.TopRight.IsMouseInArea(mouseX, mouseY)
                || this.BottomLeft.IsMouseInArea(mouseX, mouseY) || this.BottomRight.IsMouseInArea(mouseX, mouseY);
        }

        public void Refresh(UML_Class_Object caller)
        {
            this.TopLeft.FullRefresh(caller.X, caller.Y);
            this.TopRight.FullRefresh(caller.X + caller.Width, caller.Y);
            this.BottomLeft.FullRefresh(caller.X, caller.Y + caller.Height);
            this.BottomRight.FullRefresh(caller.X + caller.Width, caller.Y + caller.Height);
        }

        public void ImportData(Resizer other)
        {
            this.TopLeft.ImportData(other.TopLeft);
            this.BottomRight.ImportData(other.BottomRight);
            this.TopRight.ImportData(other.TopRight);
            this.BottomLeft.ImportData(other.BottomLeft);
        }
    }
}
