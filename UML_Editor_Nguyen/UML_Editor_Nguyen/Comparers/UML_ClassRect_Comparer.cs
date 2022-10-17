using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UML_Editor_Nguyen.Relationship_Components;

namespace UML_Editor_Nguyen.Comparers
{
    public class UML_ClassRect_Comparer : IComparer<UML_Class_Object> /*IComparer<LineVector>*/
    {
        public int Compare(UML_Class_Object? x, UML_Class_Object? y)
        {
            return x!.Layer_Index.CompareTo(y!.Layer_Index);
        }

        /*public int Compare(LineVector? x, LineVector? y)
        {
            return x!.Layer_Index.CompareTo(y!.Layer_Index);
        }*/
    }
}
