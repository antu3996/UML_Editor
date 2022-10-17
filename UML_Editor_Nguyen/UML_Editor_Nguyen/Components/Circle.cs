using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Editor_Nguyen.Components
{
    public class Circle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; set; }
        public Point Initial_Point { get; set; }
        public Point Drag_Point { get; set; }
        public bool IsSelected { get; set; } = false;

        public Circle(int x, int y, int radius = 10)
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;
        }

        public void Draw(Graphics g)
        {
            int diameter = this.Radius * 2;
            Brush b = this.IsSelected ? Brushes.White : Brushes.MediumSlateBlue;
            Pen p = new Pen(Color.Black, 2f);
            g.FillEllipse(b, this.X - this.Radius, this.Y - this.Radius, diameter, diameter);
            g.DrawEllipse(p, this.X - this.Radius - p.Width / 2, this.Y - this.Radius - p.Width / 2,
                diameter + p.Width / 2, diameter + p.Width / 2);
        }

        public bool SetDragPoint(int mouseX, int mouseY)
        {
            if (this.IsMouseInArea(mouseX, mouseY))
            {
                this.Initial_Point = new Point(this.X, this.Y);
                this.Drag_Point = new Point(mouseX, mouseY);

                this.IsSelected = true;

                return true;
            }
            else
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
                int distanceX = this.Drag_Point.X - this.Initial_Point.X;
                int distanceY = this.Drag_Point.Y - this.Initial_Point.Y;

                this.X = mouseX - distanceX;
                this.Y = mouseY - distanceY;
            }
        }

        public bool IsMouseInArea(int mouseX, int mouseY)
        {
            if (Math.Sqrt(Math.Pow(mouseX - this.X, 2) + Math.Pow(mouseY - this.Y, 2)) <= this.Radius)
            {
                return true;
            }
            return false;
        }

        public virtual void Refresh(int newX, int newY)
        {
            this.X = newX;
            this.Y = newY;
        }
        public void FullRefresh(int newX, int newY)
        {
            this.X = newX;
            this.Y = newY;
            this.Initial_Point = default;
            this.Drag_Point = default;
            this.IsSelected = false;
        }
    }
}
