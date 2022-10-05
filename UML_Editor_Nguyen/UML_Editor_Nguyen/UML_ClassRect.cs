using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Editor_Nguyen
{
    public class UML_ClassRect
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string ClassName { get; set; }
        public int Layer_Index { get; set; }
        public Point Initial_Point { get; set; }
        public Point Drag_Point { get; set; }

        public UML_ClassRect(string classname, int x, int y, int width, int height)
        {
            this.ClassName = classname;
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Layer_Index = 1;
        }
        public void Draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 3f);
            Brush b = Brushes.CadetBlue;

            g.DrawRectangle(p, this.X, this.Y, this.Width, this.Height);
            g.FillRectangle(b, this.X + 2, this.Y + 2, this.Width - 3, this.Height - 3);
        }

        public bool IsMouseInArea(int mouseX, int mouseY)
        {
            if ((mouseX > this.X && mouseX < (this.X + this.Width)) && (mouseY > this.Y && mouseY < (this.Y + this.Height)))
            {
                return true;
            }
            return false;
        }

        public void SetDragPoint(int mouseX, int mouseY)
        {
            if (this.IsMouseInArea(mouseX, mouseY))
            {
                this.Initial_Point = new Point(this.X, this.Y);
                this.Drag_Point = new Point(mouseX, mouseY);
            }
        }
        public void MouseDrag(int mouseX, int mouseY)
        {
            int distanceX = this.Drag_Point.X - this.Initial_Point.X;
            int distanceY = this.Drag_Point.Y - this.Initial_Point.Y;

            this.X = mouseX - distanceX;
            this.Y = mouseY - distanceY;
        }

        public bool IsColliding(UML_ClassRect otherRect)
        { 
            if ((this.Y+this.Height) < otherRect.Y &&
                this.Y > (otherRect.Y+otherRect.Height) &&
                this.X > (otherRect.X + otherRect.Width) &&
                (this.X + this.Width) < otherRect.X)
            {
                return true;
            }                

            return false;
        }
    }
}
