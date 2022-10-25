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
        public LineVector MiddleVector { get; set; }

        public List<LineVector> Vectors { get; set; }

        public int VectorsCount { get; set; } = 0;

        public LineVector_List()
        {
            this.CreateNewVectors();
        }

        public void AddNewVector(LineVector vector)
        {
            this.Vectors.Add(vector);
            this.VectorsCount += 1;

            int middleIndex = this.VectorsCount / 2;
            this.MiddleVector = this.Vectors[middleIndex];

            
        }

        public bool SelectVector(int mouseX, int mouseY)
        {
            bool isWholeSelected = false;
            foreach (LineVector item in this.Vectors)
            {
                if (item.SelectVector(mouseX, mouseY))
                {
                    isWholeSelected = true;
                    break;
                }
            }

            this.Vectors.ForEach(item => item.IsSelected = isWholeSelected);

            return isWholeSelected;
        }


        public void Draw(Graphics g, LineType lineType)
        {
            foreach (LineVector item in this.Vectors)
            {
                item.Draw(g, lineType);
            }

            lineType.DrawArrow(g, this.Vectors.Last().EndPoint.X,
               this.Vectors.Last().EndPoint.Y, this.Vectors.Last().Direction);
        }

        public void CreateNewVectors()
        {
            this.Vectors = new List<LineVector>();
        }

        public void ClearSelection()
        {
            foreach (LineVector item in this.Vectors)
            {
                item.ClearSelection();
            }
        }
    }
}
