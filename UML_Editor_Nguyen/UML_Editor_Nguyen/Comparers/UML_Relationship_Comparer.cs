using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UML_Editor_Nguyen.Relationship_Components;

namespace UML_Editor_Nguyen.Comparers
{
    public class UML_Relationship_Comparer : IComparer<UML_Relationship>
    {
        public int Compare(UML_Relationship? x, UML_Relationship? y)
        {
            return x!.Layer_Index.CompareTo(y!.Layer_Index);
        }
    }
}
