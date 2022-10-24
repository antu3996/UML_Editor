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
        public LineVector_Node MiddleVector { get; set; }
        public LineVector_Node EndVector { get; set; }

        public int VectorsCount { get; set; } = 0;

        public LineVector_List()
        {
            this.CreateNewVectors();
        }

        public void AddNewVector(LineVector vector)
        {

            this.EndVector = this.StartVector.AddAndGetLast(vector);

            if (this.EndVector != this.StartVector)
            {
                this.VectorsCount += 1;
                this.EndVector.Vector_Index = this.VectorsCount;

                int middleIndex = this.VectorsCount / 2;
                this.MiddleVector = this.MiddleVector.GetNextUntilIndex(middleIndex);
            }

            
        }

        public void Draw(Graphics g, ILineType lineType)
        {
            this.StartVector.Draw(g, lineType);
            lineType.DrawArrow(g, this.EndVector.Current_Object.EndPoint.X, 
                this.EndVector.Current_Object.EndPoint.Y, this.EndVector.Current_Object.Direction);
        }

        public void CreateNewVectors()
        {
            this.StartVector = new LineVector_Node();
            this.EndVector = this.StartVector;
            this.StartVector.Vector_Index = this.VectorsCount;
            this.MiddleVector = this.StartVector;
        }
    }
}
