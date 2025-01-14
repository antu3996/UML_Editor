﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Editor_Nguyen.Relationship_Components.LineTypes
{
    public class Ln_Realization : LineType
    {
        public override string TypeName { get; set; } = "Realization";
        public override void DrawLine(Graphics g, Pen p, int startX, int startY, int endX, int endY)
        {
            float[] dashValues = { 5, 2, 5, 2 };
            p.DashPattern = dashValues;
            g.DrawLine(p, startX, startY, endX, endY);
        }

        public override void DrawArrow(Graphics g, int x, int y, int direction)
        {
            PointF p1 = new PointF(x, y);
            Pen p = new Pen(Color.Black, 3f);


            if (direction == 1)
            {
                PointF p2 = new PointF(x - 10, y + 20);
                PointF p3 = new PointF(x + 10, y + 20);

                g.DrawPolygon(p, new PointF[] { p1, p2, p3 });
            }
            if (direction == 2)
            {
                PointF p2 = new PointF(x - 20, y - 10);
                PointF p3 = new PointF(x - 20, y + 10);

                g.DrawPolygon(p, new PointF[] { p1, p2, p3 });
            }
            if (direction == 3)
            {
                PointF p2 = new PointF(x - 10, y - 20);
                PointF p3 = new PointF(x + 10, y - 20);

                g.DrawPolygon(p, new PointF[] { p1, p2, p3 });
            }
            if (direction == 4)
            {
                PointF p2 = new PointF(x + 20, y - 10);
                PointF p3 = new PointF(x + 20, y + 10);

                g.DrawPolygon(p, new PointF[] { p1, p2, p3 });
            }
        }
    }
}
