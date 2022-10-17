using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Editor_Nguyen.Relationship_Components.LineTypes
{
    public class Ln_Composition : ILineType
    {
        public override string TypeName { get; set; } = "Composition";
        public override void DrawLine(Graphics g, Pen p, int startX, int startY, int endX, int endY)
        {

            g.DrawLine(p, startX, startY, endX, endY);
        }

        public override void DrawArrow(Graphics g, int x, int y, int direction)
        {
            PointF p1 = new PointF(x, y);

            if (direction == 1)
            {
                PointF p2 = new PointF(x - 10, y + 20);
                PointF p3 = new PointF(x + 10, y + 20);
                PointF p4 = new PointF(x, y + 40);

                g.FillPolygon(Brushes.Black, new PointF[] { p2, p1, p3, p4 });
            }
            if (direction == 2)
            {
                PointF p2 = new PointF(x - 20, y - 10);
                PointF p3 = new PointF(x - 20, y + 10);
                PointF p4 = new PointF(x - 40, y);

                g.FillPolygon(Brushes.Black, new PointF[] { p2, p1, p3, p4 });
            }
            if (direction == 3)
            {
                PointF p2 = new PointF(x - 10, y - 20);
                PointF p3 = new PointF(x + 10, y - 20);
                PointF p4 = new PointF(x, y - 40);

                g.FillPolygon(Brushes.Black, new PointF[] { p2, p1, p3, p4 });
            }
            if ( direction == 4)
            {
                PointF p2 = new PointF(x + 20, y - 10);
                PointF p3 = new PointF(x + 20, y + 10);
                PointF p4 = new PointF(x + 40, y);

                g.FillPolygon(Brushes.Black, new PointF[] { p2, p1, p3, p4 });
            }
        }
    }
}
