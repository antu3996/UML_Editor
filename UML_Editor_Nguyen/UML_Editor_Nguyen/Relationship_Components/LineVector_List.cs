using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UML_Editor_Nguyen.Relationship_Components.LineTypes;

namespace UML_Editor_Nguyen.Relationship_Components
{
    public class LineVector_List
    {
        public LineVector_Node StartVector { get; set; }
        public LineVector_Node EndVector { get; set; }

        public LineVector_List()
        { 
            this.StartVector = new LineVector_Node();
            this.EndVector = this.StartVector;
        }

        public void AddNewVector(LineVector vector)
        {
            this.EndVector = this.StartVector.AddAndGetLast(vector);
        }

        public void Draw(Graphics g, ILineType lineType)
        {
            this.StartVector.Draw(g, lineType);
        }
    }
}
