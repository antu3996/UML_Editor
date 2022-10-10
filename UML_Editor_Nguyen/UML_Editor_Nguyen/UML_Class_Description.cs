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
        public string Specification { get; set; } = "";
        public BindingList<Class_Property> Properties { get; set; } = new BindingList<Class_Property>();
        public BindingList<Class_Method> Methods { get; set; } = new BindingList<Class_Method>();
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
            float parent_y = this.parent_rect.Y;
            int parent_width = this.parent_rect.Width;
            int parent_height = this.parent_rect.Height;

            float x_DrawPos = this.parent_rect.X + 3;
            float y_DrawPos = this.parent_rect.Y + 2;

            if (!string.IsNullOrEmpty(this.Specification))
            {
                y_DrawPos += this.DrawInCenter(y_DrawPos, g, $"<<{this.Specification}>>").Height + 1;
            }

            y_DrawPos += this.DrawInCenter(y_DrawPos, g, $"{this.ClassName}").Height + 1;

            g.DrawLine(Pens.Black, parent_x, y_DrawPos, parent_x + parent_width,  y_DrawPos);

            y_DrawPos += 1;
            if (y_DrawPos >= parent_y + parent_height) return;

            foreach (Class_Property item in this.Properties)
            {
                string currentString = item.ToString();
                SizeF currentSize = g.MeasureString(currentString, this.font);

                if (currentSize.Width >= parent_width)
                {
                    int shortenedLength = Convert.ToInt32(Math.Floor(currentString.Length * (parent_width / currentSize.Width)));
                    g.DrawString(currentString.Substring(0, shortenedLength), this.font, this.fontColor, x_DrawPos, y_DrawPos);
                }
                else
                {
                    g.DrawString(currentString, this.font, this.fontColor, x_DrawPos, y_DrawPos);

                }

                y_DrawPos += currentSize.Height + 1;
                if (y_DrawPos >= parent_y + parent_height) return;
            }

            g.DrawLine(Pens.Black, parent_x, y_DrawPos, parent_x + parent_width, y_DrawPos);

            foreach (Class_Method item in this.Methods)
            {
                string currentString = item.ToString();
                SizeF currentSize = g.MeasureString(currentString, this.font);

                if (currentSize.Width >= parent_width)
                {
                    int shortenedLength = Convert.ToInt32(Math.Floor(currentString.Length * (parent_width / currentSize.Width)));
                    g.DrawString(currentString.Substring(0, shortenedLength), this.font, this.fontColor, x_DrawPos, y_DrawPos);
                }
                else
                {
                    g.DrawString(currentString, this.font, this.fontColor, x_DrawPos, y_DrawPos);

                }

                y_DrawPos += currentSize.Height + 1;
                if (y_DrawPos >= parent_y + parent_height) return;
            }
        }

        public void OpenForm()
        {
            Class_Description_Form frm_Description = new Class_Description_Form(this);

            if (frm_Description.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Upraveno");
            }
        }
        private SizeF DrawInCenter(float y_draw, Graphics g, string s)
        {
            SizeF size = g.MeasureString(s, this.font);

            float newX = (this.parent_rect.Width - size.Width) / 2 + this.parent_rect.X;

            g.DrawString(s, this.font, this.fontColor, newX, y_draw);

            return size;

        }
    }
}
