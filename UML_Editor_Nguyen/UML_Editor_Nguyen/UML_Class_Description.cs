using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UML_Editor_Nguyen.Description_Components;

namespace UML_Editor_Nguyen
{
    public class UML_Class_Description
    {
        public string ClassName { get; set; } = "";
        public string Stereotype { get; set; } = "";
        public List<Class_Property> Properties { get; set; } = new List<Class_Property>();
        public List<Class_Method> Methods { get; set; } = new List<Class_Method>();
        public UML_Class_Object parent_rect { get; set; }

        private Font font = new Font(FontFamily.GenericMonospace, 12f, FontStyle.Bold);
        private Brush fontColor = Brushes.White;

        public UML_Class_Description(UML_Class_Object rect)
        {
            this.parent_rect = rect;
        }

        public void Draw(Graphics g)
        {

            float parent_x = this.parent_rect.X;
            int parent_width = this.parent_rect.Width;

            float x_DrawPos = this.parent_rect.X + 3;
            float y_DrawPos = this.parent_rect.Y + 2;


            if (!string.IsNullOrEmpty(this.Stereotype))
            {
                SizeF stereotype = g.MeasureString($"<<{this.Stereotype}>>", this.font);

                g.DrawString($"<<{this.Stereotype}>>", this.font, this.fontColor,
                    (parent_width - stereotype.Width) / 2 + parent_x, 
                    y_DrawPos);

                y_DrawPos += stereotype.Height + 1;

            }

            SizeF classname = g.MeasureString($"{this.ClassName}", this.font);

            g.DrawString($"{this.ClassName}", this.font, this.fontColor,
                (parent_width - classname.Width) / 2 + parent_x,
                y_DrawPos);

            y_DrawPos += classname.Height + 1;


            g.DrawLine(Pens.Black, parent_x, y_DrawPos, parent_x + parent_width,  y_DrawPos);

            y_DrawPos += 1;

            foreach (Class_Property item in this.Properties)
            {
                string currentString = item.ToString();
                SizeF currentSize = g.MeasureString(currentString, this.font);
                g.DrawString(currentString, this.font, this.fontColor, x_DrawPos, y_DrawPos);

                y_DrawPos += currentSize.Height + 1;
            }

            g.DrawLine(Pens.Black, parent_x, y_DrawPos, parent_x + parent_width, y_DrawPos);

            foreach (Class_Method item in this.Methods)
            {
                string currentString = item.ToString();
                SizeF currentSize = g.MeasureString(currentString, this.font);
                g.DrawString(currentString, this.font, this.fontColor, x_DrawPos, y_DrawPos);

                y_DrawPos += currentSize.Height + 1;
            }
        }

        public void OpenForm()
        {
            Class_Description_Form frm_Description = new Class_Description_Form(this);

            frm_Description.ShowDialog();
        }
        private SizeF DrawInCenter(float y_draw, Graphics g, string s)
        {
            SizeF size = g.MeasureString(s, this.font);

            float newX = (this.parent_rect.Width - size.Width) / 2 + this.parent_rect.X;

            g.DrawString(s, this.font, this.fontColor, newX, y_draw);

            return size;

        }

        public void RecalculateParentArea(Graphics g)
        {
            float parent_x = this.parent_rect.X;
            float parent_y = this.parent_rect.Y;
            int parent_width = this.parent_rect.Width;
            int parent_height = this.parent_rect.Height;

            float x_DrawPos = this.parent_rect.X + 3;
            float y_DrawPos = this.parent_rect.Y + 2;


            if (!string.IsNullOrEmpty(this.Stereotype))
            {
                SizeF stereotype = g.MeasureString($"<<{this.Stereotype}>>", this.font);

                if (stereotype.Width >= parent_width)
                {
                    parent_width = Convert.ToInt32(stereotype.Width + 2);
                }

                y_DrawPos += stereotype.Height + 1;
                if (y_DrawPos >= parent_y + parent_height)
                {
                    parent_height = Convert.ToInt32(y_DrawPos - parent_y);
                }

            }

            SizeF classname = g.MeasureString($"{this.ClassName}", this.font);

            if (classname.Width >= parent_width)
            {
                parent_width = Convert.ToInt32(classname.Width + 2);
            }

            y_DrawPos += classname.Height + 1;
            if (y_DrawPos >= parent_y + parent_height)
            {
                parent_height = Convert.ToInt32(y_DrawPos - parent_y);
            }

            //-----------------line

            y_DrawPos += 1;
            if (y_DrawPos >= parent_y + parent_height)
            {
                parent_height = Convert.ToInt32(y_DrawPos - parent_y);
            }

            foreach (Class_Property item in this.Properties)
            {
                string currentString = item.ToString();
                SizeF currentSize = g.MeasureString(currentString, this.font);

                if (x_DrawPos + currentSize.Width >= parent_x + parent_width)
                {
                    parent_width = Convert.ToInt32(x_DrawPos + currentSize.Width - parent_x);
                }

                y_DrawPos += currentSize.Height + 1;
                if (y_DrawPos >= parent_y + parent_height)
                {
                    parent_height = Convert.ToInt32(y_DrawPos - parent_y);
                }
            }

            //--------------line

            foreach (Class_Method item in this.Methods)
            {
                string currentString = item.ToString();
                SizeF currentSize = g.MeasureString(currentString, this.font);

                if (x_DrawPos + currentSize.Width >= parent_x + parent_width)
                {
                    parent_width = Convert.ToInt32(x_DrawPos + currentSize.Width - parent_x);
                }

                y_DrawPos += currentSize.Height + 1;
                if (y_DrawPos >= parent_y + parent_height)
                {
                    parent_height = Convert.ToInt32(y_DrawPos - parent_y);
                }
            }

            this.parent_rect.Width = parent_width;
            this.parent_rect.Height = parent_height;
        }
    }
}
