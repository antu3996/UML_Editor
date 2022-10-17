﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UML_Editor_Nguyen.Relationship_Components.LineTypes;

namespace UML_Editor_Nguyen.Relationship_Components
{
    public class UML_Relationship_Description
    {
        public string Stereotype { get; set; }
        public string Multiplicity1 { get; set; }
        public string Multiplicity2 { get; set; }
        public ILineType lineType { get; set; } = new Ln_Association();

        public UML_Relationship parent_rel { get; set; }
        public UML_Relationship_Description(UML_Relationship parent_rel)
        {
            this.parent_rel = parent_rel;
        }

        public void Draw(Graphics g)
        {
            Font font = new Font(FontFamily.GenericMonospace, 12f, FontStyle.Bold);

            

            int startDirection = parent_rel.Vectors.StartVector.Current_Object.Direction;
            int endDirection = parent_rel.Vectors.EndVector.Current_Object.Direction;

            if (startDirection == 1)
            {
                if (!string.IsNullOrEmpty(this.Stereotype))
                {
                    g.DrawString($"<<{this.Stereotype}>>",
                    font, Brushes.Black, parent_rel.StartPoint.X + 5, parent_rel.StartPoint.Y - 25);
                }
                g.DrawString($"{this.Multiplicity1}",
                font, Brushes.Black, parent_rel.StartPoint.X + 5, parent_rel.StartPoint.Y - 5);
            }
            if (startDirection == 2)
            {
                if (!string.IsNullOrEmpty(this.Stereotype))
                {
                    g.DrawString($"<<{this.Stereotype}>>",
                    font, Brushes.Black, parent_rel.StartPoint.X + 5, parent_rel.StartPoint.Y - 10);
                }
                g.DrawString($"{this.Multiplicity1}",
                font, Brushes.Black, parent_rel.StartPoint.X + 5, parent_rel.StartPoint.Y + 10);
            }
            if (startDirection == 3)
            {
                if (!string.IsNullOrEmpty(this.Stereotype))
                {
                    g.DrawString($"<<{this.Stereotype}>>",
                    font, Brushes.Black, parent_rel.StartPoint.X + 5, parent_rel.StartPoint.Y + 5);
                }
                g.DrawString($"{this.Multiplicity1}",
                font, Brushes.Black, parent_rel.StartPoint.X + 5, parent_rel.StartPoint.Y + 25);
            }
            if (startDirection == 4)
            {
                if (!string.IsNullOrEmpty(this.Stereotype))
                {
                    SizeF size = g.MeasureString($"<<{this.Stereotype}>>",
                    font);
                    g.DrawString($"<<{this.Stereotype}>>",
                    font, Brushes.Black, parent_rel.StartPoint.X - size.Width, parent_rel.StartPoint.Y - 10);
                }
                SizeF size2  = g.MeasureString($"{this.Multiplicity1}",
                    font);
                g.DrawString($"{this.Multiplicity1}",
                font, Brushes.Black, parent_rel.StartPoint.X - size2.Width, parent_rel.StartPoint.Y + 10);
            }

            

            

            if (endDirection == 1)
            {
                g.DrawString($"{this.Multiplicity2}",
                font, Brushes.Black, parent_rel.EndPoint.X + 5, parent_rel.EndPoint.Y - 5);
            }
            if (endDirection == 2)
            {
                g.DrawString($"{this.Multiplicity2}",
                font, Brushes.Black, parent_rel.EndPoint.X + 5, parent_rel.EndPoint.Y - 5);
            }
            if (endDirection == 3)
            {
                g.DrawString($"{this.Multiplicity2}",
                font, Brushes.Black, parent_rel.EndPoint.X + 5, parent_rel.EndPoint.Y + 5);
            }
            if (endDirection == 4)
            {
                SizeF size2 = g.MeasureString($"{this.Multiplicity2}",
                    font);
                g.DrawString($"{this.Multiplicity2}",
                font, Brushes.Black, parent_rel.EndPoint.X - size2.Width, parent_rel.EndPoint.Y - 5);
            }

        }

        public void OpenForm()
        {
            Form_Relationship frm = new Form_Relationship(this);
            frm.ShowDialog();
        }
    }
}