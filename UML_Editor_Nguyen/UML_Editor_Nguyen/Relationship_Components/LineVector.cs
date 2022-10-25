using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UML_Editor_Nguyen.Relationship_Components.LineTypes;
using static System.Windows.Forms.AxHost;

namespace UML_Editor_Nguyen.Relationship_Components
{
    public class LineVector
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public bool IsLocked { get; set; } = false;

        public bool IsSelected { get; set; } = false;

        public int I_X { get; set; }
        public int I_Y { get; set; }
        public int I_Width { get; set; }
        public int I_Height { get; set; }
        public int Layer_Index { get; set; } = 1;

        /* 1 = nahoru, 2 = doprava, 3 = dolů, 4 = doleva */
        public int Direction { get; set; } = 1;

        public LineVector(int startX, int startY, int endX, int endY)
        {
            this.StartPoint = new Point(startX, startY);
            this.EndPoint = new Point(endX, endY);

            this.SetDirection();

            this.SetImaginaryArea();
        }

        public void Draw(Graphics g, LineType lineType)
        {
            Pen p = new Pen(Color.Black, 2);

            if (this.IsSelected)
            {
                p.Color = Color.Yellow;
            }

            /*g.DrawLine(p, this.StartPoint, this.EndPoint);*/

            lineType.DrawLine(g, p, this.StartPoint.X, this.StartPoint.Y, this.EndPoint.X, this.EndPoint.Y);
        }

        public void DrawStringAroundVector(Graphics g, string str)
        {
            Font font = new Font(FontFamily.GenericMonospace, 12f, FontStyle.Bold);
            SizeF size = g.MeasureString(str, font);


            if (this.Direction == 1 || this.Direction == 3)
            {
                if (this.StartPoint.Y < this.EndPoint.Y)
                {
                    g.DrawString(str, font, Brushes.Black, this.StartPoint.X - size.Width - 2, this.StartPoint.Y 
                        + (this.EndPoint.Y - this.StartPoint.Y - size.Height) / 2);
                }
                else
                {
                    g.DrawString(str, font, Brushes.Black, this.StartPoint.X - size.Width - 2, this.EndPoint.Y
                        + (this.StartPoint.Y - this.EndPoint.Y - size.Height) / 2);
                }
            }
            if (this.Direction == 2 || this.Direction == 4)
            {
                if (this.StartPoint.X < this.EndPoint.X)
                {
                    g.DrawString(str, font, Brushes.Black, this.StartPoint.X
                        + (this.EndPoint.X - this.StartPoint.X - size.Width) / 2, this.StartPoint.Y - size.Height - 2);
                }
                else
                {
                    g.DrawString(str, font, Brushes.Black, this.EndPoint.X
                        + (this.StartPoint.X - this.EndPoint.X - size.Width) / 2, this.StartPoint.Y - size.Height - 2);
                }
            }
        }

        private void SetDirection()
        {
            int diffX = this.EndPoint.X - this.StartPoint.X;
            int diffY = this.EndPoint.Y - this.StartPoint.Y;

            if (diffX == 0 && diffY > 0)
            {
                this.Direction = 3;
            }
            if (diffX > 0 && diffY == 0)
            {
                this.Direction = 2;
            }
            if (diffX == 0 && diffY < 0)
            {
                this.Direction = 1;
            }
            if (diffX < 0 && diffY == 0)
            {
                this.Direction = 4;
            }
        }

        private void SetImaginaryArea()
        {
            if (this.Direction == 1)
            {
                this.I_Height = Math.Abs(this.EndPoint.Y - this.StartPoint.Y);
                this.I_Width = 20;
                this.I_X = this.EndPoint.X - this.I_Width / 2;
                this.I_Y = this.EndPoint.Y - 3;
            }
            if (this.Direction == 2)
            {
                this.I_Width = Math.Abs(this.EndPoint.X - this.StartPoint.X);
                this.I_Height = 20;
                this.I_X = this.StartPoint.X - 3;
                this.I_Y = this.StartPoint.Y - this.I_Height / 2;
            }
            if (this.Direction == 3)
            {
                this.I_Height = Math.Abs(this.EndPoint.Y - this.StartPoint.Y);
                this.I_Width = 20;
                this.I_X = this.StartPoint.X - this.I_Width / 2;
                this.I_Y = this.StartPoint.Y - 3;
            }
            if (this.Direction == 4)
            {
                this.I_Width = Math.Abs(this.EndPoint.X - this.StartPoint.X);
                this.I_Height = 20;
                this.I_X = this.EndPoint.X - 3;
                this.I_Y = this.EndPoint.Y - this.I_Height / 2;
            }
        }

        public bool IsColliding(LineVector otherVect)
        {
            if (this == otherVect)
            {
                return false;
            }


            if (this.I_X < (otherVect.I_X + otherVect.I_Width) && (this.I_X + this.I_Width) > otherVect.I_X &&
                this.I_Y < (otherVect.I_Y + otherVect.I_Height) && (this.I_Y + this.I_Height) > otherVect.I_Y)
            {
                return true;
            }
            return false;
        }

        public void MouseDrag(int mouseX, int mouseY)
        {
            if (this.IsSelected && !this.IsLocked)
            {
                if (this.Direction == 1 || this.Direction == 3)
                {
                    this.StartPoint = new Point(mouseX, this.StartPoint.Y);
                    this.EndPoint = new Point(mouseX, this.EndPoint.Y);
                }
                if (this.Direction == 2 || this.Direction == 4)
                {
                    this.StartPoint = new Point(this.StartPoint.X, mouseY);
                    this.EndPoint = new Point(this.EndPoint.X, mouseY);
                }

                this.SetImaginaryArea();
            }
        }

        public void ClearSelection()
        {
            this.IsSelected = false;
        }

        public bool SelectVector(int mouseX, int mouseY)
        {
            if(this.IsMouseInArea(mouseX, mouseY))
            {
                this.IsSelected = true;
                return true;
            }
            else
            {
                this.IsSelected = false;
                return false;
            }
        }

        public void MoveVector(int mouseX, int mouseY)
        {
            if (this.Direction == 1 || this.Direction == 3)
            {
                this.StartPoint = new Point(mouseX, this.StartPoint.Y);
                this.EndPoint = new Point(mouseX, this.EndPoint.Y);
            }
            if (this.Direction == 2 || this.Direction == 4)
            {
                this.StartPoint = new Point(this.StartPoint.X, mouseY);
                this.EndPoint = new Point(this.EndPoint.X, mouseY);
            }

            this.SetImaginaryArea();
        }

        private bool IsMouseInArea(int mouseX, int mouseY)
        {
            if ((mouseX > this.I_X && mouseX < (this.I_X + this.I_Width)) 
                && (mouseY > this.I_Y && mouseY < (this.I_Y + this.I_Height)))
            {
                return true;
            }
            return false;
        }

        public void RepositionStartPoint(int x, int y)
        {
            if (this.Direction == 1 || this.Direction == 3)
            {
                this.StartPoint = new Point(this.StartPoint.X, y);
            }
            if (this.Direction == 2 || this.Direction == 4)
            {
                this.StartPoint = new Point(x, this.StartPoint.Y);
            }

            this.SetDirection();
            this.SetImaginaryArea();
        }



        public void RepositionEndPoint(int x, int y)
        {
            if (this.Direction == 1 || this.Direction == 3)
            {
                this.EndPoint = new Point(this.EndPoint.X, y);
            }
            if (this.Direction == 2 || this.Direction == 4)
            {
                this.EndPoint = new Point(x, this.EndPoint.Y);
            }

            this.SetDirection();
            this.SetImaginaryArea();
        }
    }
}
