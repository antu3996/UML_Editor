using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Editor_Nguyen.Comparers
{
    public class UML_ClassRect_Comparer : IComparer<UML_Class_Object>
    {
        public int Compare(UML_Class_Object? x, UML_Class_Object? y)
        {
            return x!.Layer_Index.CompareTo(y!.Layer_Index);
        }
    }
}
