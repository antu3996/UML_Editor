using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using UML_Editor_Nguyen.Components;
using UML_Editor_Nguyen.Description_Components;
using UML_Editor_Nguyen.Relationship_Components;

namespace UML_Editor_Nguyen
{
    public class UML_Class_Object
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int MinWidth { get; set; } = 150;
        public int MinHeight { get; set; } = 75;
        public int Layer_Index { get; set; } = 1;
        public Point Initial_Point { get; set; }
        public Point Drag_Point { get; set; }
        public bool IsSelected { get; set; } = false;
        public Resizer Resizer_Component { get; set; }
        public UML_Class_Description Description_Component { get; set; }


        public bool IsInBindingMode { get; set; } = false;
        public Class_Binder Binder_Component { get; set; }
        
        
        public UML_Class_Object(int x, int y, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width > this.MinWidth ? width : this.MinWidth;
            this.Height = height > this.MinHeight ? height : this.MinHeight;
            this.Resizer_Component = new Resizer(this);
            this.Description_Component = new UML_Class_Description(this);

            this.Binder_Component = new Class_Binder(this);
        }
        public void Draw(Graphics g)
        {
            //Must be first to recalculate size for description
            this.Description_Component.RecalculateParentArea(g);
            this.Resizer_Component.Refresh();

            Pen p = new Pen(Color.Black, 2f);
            Brush b = Brushes.CornflowerBlue;

            g.DrawRectangle(p, this.X, this.Y, this.Width, this.Height);
            g.FillRectangle(b, this.X + p.Width / 2, this.Y + p.Width / 2, this.Width - p.Width, this.Height - p.Width);


            this.Description_Component.Draw(g);

            if (!this.IsInBindingMode)
            {
                if (this.IsSelected)
                {
                    this.Resizer_Component.Draw(g);
                }
            }
            else
            {
                this.Binder_Component.Draw(g);
            }
        }

        private bool IsMouseInArea(int mouseX, int mouseY)
        {
            if ((mouseX > this.X && mouseX < (this.X + this.Width)) && (mouseY > this.Y && mouseY < (this.Y + this.Height)))
            {
                return true;
            }
            return false;
        }

        public bool SetDragPoint(int mouseX, int mouseY)
        {
            if (this.IsSelected)
            {
                bool isSet = this.Resizer_Component.SetDragPoint(mouseX, mouseY);

                if (isSet)
                {
                    return true;
                }
                else
                {
                    this.Resizer_Component.SelectedCircle = null;
                }

                this.Initial_Point = new Point(this.X, this.Y);
                this.Drag_Point = new Point(mouseX, mouseY);

                this.IsSelected = true;

                return true;
            }


           /* if (this.IsMouseInArea(mouseX, mouseY))
            {
                this.Initial_Point = new Point(this.X, this.Y);
                this.Drag_Point = new Point(mouseX, mouseY);

                this.IsSelected = true;

                return true;
            }*/
            {
                this.Initial_Point = default;
                this.Drag_Point = default;
                this.IsSelected = false;
                return false;
            }
        }
        public void MouseDrag(int mouseX, int mouseY)
        {
            if (this.IsSelected)
            {
                if (this.Resizer_Component.SelectedCircle != null)
                {
                    this.Resizer_Component.MouseDrag(mouseX, mouseY);
                }
                else
                {
                    int distanceX = this.Drag_Point.X - this.Initial_Point.X;
                    int distanceY = this.Drag_Point.Y - this.Initial_Point.Y;

                    this.X = mouseX - distanceX;
                    this.Y = mouseY - distanceY;

                    this.Resizer_Component.Refresh();

                    this.Binder_Component.Refresh();
                }
            }
        }

        public void EditDescription()
        {
            if (this.IsSelected)
            {
                this.Description_Component.OpenForm();
            }
        }

        public bool SelectClass(int mouseX, int mouseY)
        {
            if (this.IsSelected && this.Resizer_Component.IsMouseInArea(mouseX, mouseY))
            {
                return true;
            }
            else if (this.IsSelected && this.IsMouseInArea(mouseX, mouseY))
            {
                return true;
            }
            else if (!this.IsSelected && this.IsMouseInArea(mouseX, mouseY))
            {
                this.IsSelected = true;
                return true;
            }
            else if (this.IsSelected && !this.IsMouseInArea(mouseX, mouseY))
            {
                this.IsSelected = false;
                this.Resizer_Component.SelectedCircle = null;
                return false;
            }
            return false;
        }

        public void ClearSelection()
        {
            this.IsSelected = false;
            this.Initial_Point = default;
            this.Drag_Point = default;
            this.Resizer_Component.ClearSelection();
        }

        public bool IsColliding(UML_Class_Object otherRect)
        { 
            if (this == otherRect)
            {
                return false;
            }


            if (this.X < (otherRect.X+otherRect.Width) && (this.X+this.Width) > otherRect.X &&
                this.Y < (otherRect.Y+otherRect.Height) && (this.Y+this.Height) > otherRect.Y)
            {
                return true;
            }
            return false;
        }

        public void RefreshOrigin(int newX, int newY, int newWidth, int newHeight)
        {
            this.X = newX;
            this.Y = newY;
            this.Width = newWidth;
            this.Height = newHeight;
            this.Initial_Point = default;
            this.Drag_Point = default;
        }
    }
}
