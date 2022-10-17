using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Editor_Nguyen.Relationship_Components.LineTypes
{
    public abstract class ILineType
    {
        public abstract string TypeName { get; set; }
        public abstract void DrawLine(Graphics g, Pen p, int startX, int startY, int endX, int endY);
        public abstract void DrawArrow(Graphics g, int x, int y, int direction);
    }
}
