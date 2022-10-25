using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UML_Editor_Nguyen.Relationship_Components;

namespace UML_Editor_Nguyen.Description_Components
{
    public class RelationshipBoundGenerator
    {
        public bool GeneratePoints(UML_Relationship caller)
        {
            //dodělat

            LineVector_List newVectors = new LineVector_List();

            UML_Class_Object primaryC = caller.Primary_Class;
            UML_Class_Object secondaryC = caller.Secondary_Class;

            string primSide = caller.CurrentPrimarySide;
            string secondarySide = caller.CurrentSecondarySide;


            int center1_X = primaryC.X + primaryC.Width / 2;
            int center1_Y = primaryC.Y + primaryC.Height / 2;
            int center2_X = secondaryC.X + secondaryC.Width / 2;
            int center2_Y = secondaryC.Y + secondaryC.Height / 2;

            int diffX = center2_X - center1_X;
            int diffY = center2_Y - center1_Y;

            string currentRelDir = caller.RelationshipDirection;

            if (/*currentAngle == 0*/ diffY == 0 && diffX > 0 /*&& currentRelDir != "E"*/)
            {
                int x_diff, y_diff;

                if (primSide != "rightside" && secondarySide != "leftside")
                {
                    primaryC.Binder_Component.RemoveBindingCircleFromSide(primaryC, primSide, caller.StartPoint);
                    secondaryC.Binder_Component.RemoveBindingCircleFromSide(secondaryC, secondarySide, caller.EndPoint);

                    BindingCircle newStartpoint = primaryC.Binder_Component.GetBindingCircleForAddedRelationship(primaryC, "rightside");
                    BindingCircle newEndpoint = secondaryC.Binder_Component.GetBindingCircleForAddedRelationship(secondaryC,  "leftside");

                    caller.RelationshipDirection = "E";
                    caller.StartPoint = newStartpoint;
                    caller.EndPoint = newEndpoint;
                    caller.CurrentPrimarySide = "rightside";
                    caller.CurrentSecondarySide = "leftside";

                    x_diff = newEndpoint.X - newStartpoint.X;
                    y_diff = newEndpoint.Y - newStartpoint.Y;
                }
                else
                {
                    x_diff = caller.EndPoint.X - caller.StartPoint.X;
                    y_diff = caller.EndPoint.Y - caller.StartPoint.Y;
                }



                if (y_diff == 0)
                {
                    LineVector v1 = new LineVector(
                    caller.StartPoint.X, caller.StartPoint.Y,
                    caller.EndPoint.X, caller.EndPoint.Y
                    );

                    v1.IsLocked = true;
                    v1.IsSelected = caller.IsSelected;

                    newVectors.AddNewVector(v1);
                }
                else
                {
                    LineVector v1 = new LineVector(
                        caller.StartPoint.X, caller.StartPoint.Y,
                        caller.StartPoint.X + x_diff / 2, caller.StartPoint.Y
                    );
                    LineVector v2 = new LineVector(
                        caller.StartPoint.X + x_diff / 2, caller.StartPoint.Y,
                        caller.StartPoint.X + x_diff / 2, caller.StartPoint.Y + y_diff
                        );
                    LineVector v3 = new LineVector(
                        caller.StartPoint.X + x_diff / 2, caller.StartPoint.Y + y_diff,
                        caller.EndPoint.X, caller.EndPoint.Y
                        );

                    v1.IsLocked = true;
                    v3.IsLocked = true;

                    v1.IsSelected = caller.IsSelected;
                    v2.IsSelected = caller.IsSelected;
                    v3.IsSelected = caller.IsSelected;


                    newVectors.AddNewVector(v1);
                    newVectors.AddNewVector(v2);
                    newVectors.AddNewVector(v3);
                }



                caller.VectorList = newVectors;

                return true;
            }
            if (/*currentAngle == 90*/ diffX == 0 && diffY < 0 /*&& currentRelDir != "N"*/)
            {
                int x_diff, y_diff;

                if (primSide != "topside" && secondarySide != "bottomside" )
                {

                    primaryC.Binder_Component.RemoveBindingCircleFromSide(primaryC, primSide, caller.StartPoint);
                    secondaryC.Binder_Component.RemoveBindingCircleFromSide(secondaryC, secondarySide, caller.EndPoint);

                    BindingCircle newStartpoint = primaryC.Binder_Component.GetBindingCircleForAddedRelationship(primaryC, "topside");
                    BindingCircle newEndpoint = secondaryC.Binder_Component.GetBindingCircleForAddedRelationship(secondaryC, "bottomside");

                    caller.RelationshipDirection = "N";
                    caller.StartPoint = newStartpoint;
                    caller.EndPoint = newEndpoint;
                    caller.CurrentPrimarySide = "topside";
                    caller.CurrentSecondarySide = "bottomside";

                    x_diff = newEndpoint.X - newStartpoint.X;
                    y_diff = newEndpoint.Y - newStartpoint.Y;


                }
                else
                {
                    x_diff = caller.EndPoint.X - caller.StartPoint.X;
                    y_diff = caller.EndPoint.Y - caller.StartPoint.Y;
                }



                if (x_diff == 0)
                {
                    LineVector v1 = new LineVector(
                    caller.StartPoint.X, caller.StartPoint.Y,
                    caller.EndPoint.X, caller.EndPoint.Y
                    );

                    v1.IsLocked = true;
                    v1.IsSelected = caller.IsSelected;

                    newVectors.AddNewVector(v1);
                }
                else
                {
                    LineVector v1 = new LineVector(
                        caller.StartPoint.X, caller.StartPoint.Y,
                        caller.StartPoint.X, caller.StartPoint.Y + y_diff / 2
                    );
                    LineVector v2 = new LineVector(
                        caller.StartPoint.X, caller.StartPoint.Y + y_diff / 2,
                        caller.StartPoint.X + x_diff, caller.StartPoint.Y + y_diff / 2
                        );
                    LineVector v3 = new LineVector(
                        caller.StartPoint.X + x_diff, caller.StartPoint.Y + y_diff / 2,
                        caller.EndPoint.X, caller.EndPoint.Y
                        );

                    v1.IsLocked = true;
                    v3.IsLocked = true;

                    v1.IsSelected = caller.IsSelected;
                    v2.IsSelected = caller.IsSelected;
                    v3.IsSelected = caller.IsSelected;

                    newVectors.AddNewVector(v1);
                    newVectors.AddNewVector(v2);
                    newVectors.AddNewVector(v3);
                }

                caller.VectorList = newVectors;

                return true;
            }
            if (/*currentAngle > 90 && currentAngle <= 135*/ ((diffX < 0 && diffY < 0 && Math.Abs(diffY) >= Math.Abs(diffX))
                || (diffX < Math.Abs(diffY) && diffY < 0 && diffX > 0)) /*&& currentRelDir != "NNW-NNE"*/)
            {
                int x_diff, y_diff;

                if (primSide != "topside" && secondarySide != "bottomside" )
                {

                    primaryC.Binder_Component.RemoveBindingCircleFromSide(primaryC, primSide, caller.StartPoint);
                    secondaryC.Binder_Component.RemoveBindingCircleFromSide(secondaryC, secondarySide, caller.EndPoint);

                    BindingCircle newStartpoint = primaryC.Binder_Component.GetBindingCircleForAddedRelationship(primaryC, "topside");
                    BindingCircle newEndpoint = secondaryC.Binder_Component.GetBindingCircleForAddedRelationship(secondaryC, "bottomside");

                    caller.RelationshipDirection = "NNW-NNE";
                    caller.StartPoint = newStartpoint;
                    caller.EndPoint = newEndpoint;
                    caller.CurrentPrimarySide = "topside";
                    caller.CurrentSecondarySide = "bottomside";

                    x_diff = newEndpoint.X - newStartpoint.X;
                    y_diff = newEndpoint.Y - newStartpoint.Y;


                }
                else
                {
                    x_diff = caller.EndPoint.X - caller.StartPoint.X;
                    y_diff = caller.EndPoint.Y - caller.StartPoint.Y;
                }


                if (x_diff == 0)
                {
                    LineVector v1 = new LineVector(
                    caller.StartPoint.X, caller.StartPoint.Y,
                    caller.EndPoint.X, caller.EndPoint.Y
                    );

                    v1.IsLocked = true;
                    v1.IsSelected = caller.IsSelected;

                    newVectors.AddNewVector(v1);
                }
                else
                {
                    LineVector v1 = new LineVector(
                        caller.StartPoint.X, caller.StartPoint.Y,
                        caller.StartPoint.X, caller.StartPoint.Y + y_diff / 2
                    );
                    LineVector v2 = new LineVector(
                        caller.StartPoint.X, caller.StartPoint.Y + y_diff / 2,
                        caller.StartPoint.X + x_diff, caller.StartPoint.Y + y_diff / 2
                        );
                    LineVector v3 = new LineVector(
                        caller.StartPoint.X + x_diff, caller.StartPoint.Y + y_diff / 2,
                        caller.EndPoint.X, caller.EndPoint.Y
                        );

                    v1.IsLocked = true;
                    v3.IsLocked = true;

                    v1.IsSelected = caller.IsSelected;
                    v2.IsSelected = caller.IsSelected;
                    v3.IsSelected = caller.IsSelected;

                    newVectors.AddNewVector(v1);
                    newVectors.AddNewVector(v2);
                    newVectors.AddNewVector(v3);
                }

                caller.VectorList = newVectors;

                return true;
            }
            if (/*currentAngle == 180*/ diffX < 0 && diffY == 0 /*&& currentRelDir != "W"*/)
            {
                int x_diff, y_diff;
                if (primSide != "leftside" && secondarySide != "rightside" )
                {
                    primaryC.Binder_Component.RemoveBindingCircleFromSide(primaryC, primSide, caller.StartPoint);
                    secondaryC.Binder_Component.RemoveBindingCircleFromSide(secondaryC, secondarySide, caller.EndPoint);

                    BindingCircle newStartpoint = primaryC.Binder_Component.GetBindingCircleForAddedRelationship(primaryC, "leftside");
                    BindingCircle newEndpoint = secondaryC.Binder_Component.GetBindingCircleForAddedRelationship(secondaryC, "rightside");

                    caller.RelationshipDirection = "W";
                    caller.StartPoint = newStartpoint;
                    caller.EndPoint = newEndpoint;
                    caller.CurrentPrimarySide = "leftside";
                    caller.CurrentSecondarySide = "rightside";


                    x_diff = newEndpoint.X - newStartpoint.X;
                    y_diff = newEndpoint.Y - newStartpoint.Y;
                }
                else
                {
                    x_diff = caller.EndPoint.X - caller.StartPoint.X;
                    y_diff = caller.EndPoint.Y - caller.StartPoint.Y;
                }



                if (y_diff == 0)
                {
                    LineVector v1 = new LineVector(
                    caller.StartPoint.X, caller.StartPoint.Y,
                    caller.EndPoint.X, caller.EndPoint.Y
                    );

                    v1.IsLocked = true;
                    v1.IsSelected = caller.IsSelected;

                    newVectors.AddNewVector(v1);
                }
                else
                {
                    LineVector v1 = new LineVector(
                        caller.StartPoint.X, caller.StartPoint.Y,
                        caller.StartPoint.X + x_diff / 2, caller.StartPoint.Y
                    );
                    LineVector v2 = new LineVector(
                        caller.StartPoint.X + x_diff / 2, caller.StartPoint.Y,
                        caller.StartPoint.X + x_diff / 2, caller.StartPoint.Y + y_diff
                        );
                    LineVector v3 = new LineVector(
                        caller.StartPoint.X + x_diff / 2, caller.StartPoint.Y + y_diff,
                        caller.EndPoint.X, caller.EndPoint.Y
                        );

                    v1.IsLocked = true;
                    v3.IsLocked = true;

                    v1.IsSelected = caller.IsSelected;
                    v2.IsSelected = caller.IsSelected;
                    v3.IsSelected = caller.IsSelected;

                    newVectors.AddNewVector(v1);
                    newVectors.AddNewVector(v2);
                    newVectors.AddNewVector(v3);
                }


                caller.VectorList = newVectors;

                return true;
            }
            if (/*currentAngle > 180 && currentAngle <= 225*/ ((diffX < 0 && diffY > 0 && Math.Abs(diffX) >= diffY)
                || (diffX < 0 && diffY < 0 && Math.Abs(diffY) < Math.Abs(diffX))) /*&& currentRelDir != "WNW-WSW"*/)
            {
                int x_diff, y_diff;
                if (primSide != "leftside" && secondarySide != "rightside" )
                {
                    primaryC.Binder_Component.RemoveBindingCircleFromSide(primaryC, primSide, caller.StartPoint);
                    secondaryC.Binder_Component.RemoveBindingCircleFromSide(secondaryC, secondarySide, caller.EndPoint);

                    BindingCircle newStartpoint = primaryC.Binder_Component.GetBindingCircleForAddedRelationship(primaryC, "leftside");
                    BindingCircle newEndpoint = secondaryC.Binder_Component.GetBindingCircleForAddedRelationship(secondaryC, "rightside");

                    caller.RelationshipDirection = "WNW-WSW";
                    caller.StartPoint = newStartpoint;
                    caller.EndPoint = newEndpoint;
                    caller.CurrentPrimarySide = "leftside";
                    caller.CurrentSecondarySide = "rightside";


                    x_diff = newEndpoint.X - newStartpoint.X;
                    y_diff = newEndpoint.Y - newStartpoint.Y;
                }
                else
                {
                    x_diff = caller.EndPoint.X - caller.StartPoint.X;
                    y_diff = caller.EndPoint.Y - caller.StartPoint.Y;
                }



                if (y_diff == 0)
                {
                    LineVector v1 = new LineVector(
                    caller.StartPoint.X, caller.StartPoint.Y,
                    caller.EndPoint.X, caller.EndPoint.Y
                    );

                    v1.IsLocked = true;
                    v1.IsSelected = caller.IsSelected;


                    newVectors.AddNewVector(v1);
                }
                else
                {
                    LineVector v1 = new LineVector(
                        caller.StartPoint.X, caller.StartPoint.Y,
                        caller.StartPoint.X + x_diff / 2, caller.StartPoint.Y
                    );
                    LineVector v2 = new LineVector(
                        caller.StartPoint.X + x_diff / 2, caller.StartPoint.Y,
                        caller.StartPoint.X + x_diff / 2, caller.StartPoint.Y + y_diff
                        );
                    LineVector v3 = new LineVector(
                        caller.StartPoint.X + x_diff / 2, caller.StartPoint.Y + y_diff,
                        caller.EndPoint.X, caller.EndPoint.Y
                        );

                    v1.IsLocked = true;
                    v3.IsLocked = true;

                    v1.IsSelected = caller.IsSelected;
                    v2.IsSelected = caller.IsSelected;
                    v3.IsSelected = caller.IsSelected;

                    newVectors.AddNewVector(v1);
                    newVectors.AddNewVector(v2);
                    newVectors.AddNewVector(v3);
                }

                caller.VectorList = newVectors;

                return true;
            }
            if (/*currentAngle == 270*/ diffX == 0 && diffY > 0 /*&& currentRelDir != "S"*/)
            {
                int x_diff, y_diff;
                if (primSide != "bottomside" && secondarySide != "topside" )
                {
                    primaryC.Binder_Component.RemoveBindingCircleFromSide(primaryC, primSide, caller.StartPoint);
                    secondaryC.Binder_Component.RemoveBindingCircleFromSide(secondaryC, secondarySide, caller.EndPoint);

                    BindingCircle newStartpoint = primaryC.Binder_Component.GetBindingCircleForAddedRelationship(primaryC, "bottomside");
                    BindingCircle newEndpoint = secondaryC.Binder_Component.GetBindingCircleForAddedRelationship(secondaryC, "topside");

                    caller.RelationshipDirection = "S";
                    caller.StartPoint = newStartpoint;
                    caller.EndPoint = newEndpoint;
                    caller.CurrentPrimarySide = "bottomside";
                    caller.CurrentSecondarySide = "topside";


                    x_diff = newEndpoint.X - newStartpoint.X;
                    y_diff = newEndpoint.Y - newStartpoint.Y;


                }
                else
                {
                    x_diff = caller.EndPoint.X - caller.StartPoint.X;
                    y_diff = caller.EndPoint.Y - caller.StartPoint.Y;
                }


                if (x_diff == 0)
                {
                    LineVector v1 = new LineVector(
                    caller.StartPoint.X, caller.StartPoint.Y,
                    caller.EndPoint.X, caller.EndPoint.Y
                    );

                    v1.IsLocked = true;
                    v1.IsSelected = caller.IsSelected;


                    newVectors.AddNewVector(v1);
                }
                else
                {
                    LineVector v1 = new LineVector(
                        caller.StartPoint.X, caller.StartPoint.Y,
                        caller.StartPoint.X, caller.StartPoint.Y + y_diff / 2
                    );
                    LineVector v2 = new LineVector(
                        caller.StartPoint.X, caller.StartPoint.Y + y_diff / 2,
                        caller.StartPoint.X + x_diff, caller.StartPoint.Y + y_diff / 2
                        );
                    LineVector v3 = new LineVector(
                        caller.StartPoint.X + x_diff, caller.StartPoint.Y + y_diff / 2,
                        caller.EndPoint.X, caller.EndPoint.Y
                        );

                    v1.IsLocked = true;
                    v3.IsLocked = true;

                    v1.IsSelected = caller.IsSelected;
                    v2.IsSelected = caller.IsSelected;
                    v3.IsSelected = caller.IsSelected;

                    newVectors.AddNewVector(v1);
                    newVectors.AddNewVector(v2);
                    newVectors.AddNewVector(v3);
                }

                caller.VectorList = newVectors;
                return true;
            }
            if (/*currentAngle > 270 && currentAngle <= 315*/ ((diffX > 0 && diffY > 0 && diffY >= diffX)
                || (diffX < 0 && diffY > 0 && Math.Abs(diffX) < diffY)) /*&& currentRelDir != "SSW-SSE"*/)
            {
                int x_diff, y_diff;
                if (primSide != "bottomside" && secondarySide != "topside" )
                {
                    primaryC.Binder_Component.RemoveBindingCircleFromSide(primaryC, primSide, caller.StartPoint);
                    secondaryC.Binder_Component.RemoveBindingCircleFromSide(secondaryC, secondarySide, caller.EndPoint);

                    BindingCircle newStartpoint = primaryC.Binder_Component.GetBindingCircleForAddedRelationship(primaryC, "bottomside");
                    BindingCircle newEndpoint = secondaryC.Binder_Component.GetBindingCircleForAddedRelationship(secondaryC, "topside");

                    caller.RelationshipDirection = "SSW-SSE";
                    caller.StartPoint = newStartpoint;
                    caller.EndPoint = newEndpoint;
                    caller.CurrentPrimarySide = "bottomside";
                    caller.CurrentSecondarySide = "topside";


                    x_diff = newEndpoint.X - newStartpoint.X;
                    y_diff = newEndpoint.Y - newStartpoint.Y;


                }
                else
                {
                    x_diff = caller.EndPoint.X - caller.StartPoint.X;
                    y_diff = caller.EndPoint.Y - caller.StartPoint.Y;
                }


                if (x_diff == 0)
                {
                    LineVector v1 = new LineVector(
                    caller.StartPoint.X, caller.StartPoint.Y,
                    caller.EndPoint.X, caller.EndPoint.Y
                    );

                    v1.IsLocked = true;
                    v1.IsSelected = caller.IsSelected;

                    newVectors.AddNewVector(v1);
                }
                else
                {
                    LineVector v1 = new LineVector(
                        caller.StartPoint.X, caller.StartPoint.Y,
                        caller.StartPoint.X, caller.StartPoint.Y + y_diff / 2
                    );
                    LineVector v2 = new LineVector(
                        caller.StartPoint.X, caller.StartPoint.Y + y_diff / 2,
                        caller.StartPoint.X + x_diff, caller.StartPoint.Y + y_diff / 2
                        );
                    LineVector v3 = new LineVector(
                        caller.StartPoint.X + x_diff, caller.StartPoint.Y + y_diff / 2,
                        caller.EndPoint.X, caller.EndPoint.Y
                        );

                    v1.IsLocked = true;
                    v3.IsLocked = true;

                    v1.IsSelected = caller.IsSelected;
                    v2.IsSelected = caller.IsSelected;
                    v3.IsSelected = caller.IsSelected;

                    newVectors.AddNewVector(v1);
                    newVectors.AddNewVector(v2);
                    newVectors.AddNewVector(v3);
                }

                caller.VectorList = newVectors;

                return true;
            }
            if (/*currentAngle > 315 && currentAngle < 360*/ ((diffX > 0 && diffY > 0 && diffY < diffX)
                || (diffX >= Math.Abs(diffY) && diffY < 0 && diffX > 0)) /*&& currentRelDir != "ENE-ESE"*/)
            {
                int x_diff, y_diff;
                if (primSide != "rightside" && secondarySide != "leftside")
                {
                    primaryC.Binder_Component.RemoveBindingCircleFromSide(primaryC, primSide, caller.StartPoint);
                    secondaryC.Binder_Component.RemoveBindingCircleFromSide(secondaryC, secondarySide, caller.EndPoint);

                    BindingCircle newStartpoint = primaryC.Binder_Component.GetBindingCircleForAddedRelationship(primaryC, "rightside");
                    BindingCircle newEndpoint = secondaryC.Binder_Component.GetBindingCircleForAddedRelationship(secondaryC, "leftside");

                    caller.RelationshipDirection = "ENE-ESE";
                    caller.StartPoint = newStartpoint;
                    caller.EndPoint = newEndpoint;
                    caller.CurrentPrimarySide = "rightside";
                    caller.CurrentSecondarySide = "leftside";

                    x_diff = newEndpoint.X - newStartpoint.X;
                    y_diff = newEndpoint.Y - newStartpoint.Y;
                }
                else
                {
                    x_diff = caller.EndPoint.X - caller.StartPoint.X;
                    y_diff = caller.EndPoint.Y - caller.StartPoint.Y;
                }



                if (y_diff == 0)
                {
                    LineVector v1 = new LineVector(
                    caller.StartPoint.X, caller.StartPoint.Y,
                    caller.EndPoint.X, caller.EndPoint.Y
                    );

                    v1.IsLocked = true;
                    v1.IsSelected = caller.IsSelected;

                    newVectors.AddNewVector(v1);
                }
                else
                {
                    LineVector v1 = new LineVector(
                        caller.StartPoint.X, caller.StartPoint.Y,
                        caller.StartPoint.X + x_diff / 2, caller.StartPoint.Y
                    );
                    LineVector v2 = new LineVector(
                        caller.StartPoint.X + x_diff / 2, caller.StartPoint.Y,
                        caller.StartPoint.X + x_diff / 2, caller.StartPoint.Y + y_diff
                        );
                    LineVector v3 = new LineVector(
                        caller.StartPoint.X + x_diff / 2, caller.StartPoint.Y + y_diff,
                        caller.EndPoint.X, caller.EndPoint.Y
                        );

                    v1.IsLocked = true;
                    v3.IsLocked = true;

                    v1.IsSelected = caller.IsSelected;
                    v2.IsSelected = caller.IsSelected;
                    v3.IsSelected = caller.IsSelected;


                    newVectors.AddNewVector(v1);
                    newVectors.AddNewVector(v2);
                    newVectors.AddNewVector(v3);
                }

                caller.VectorList = newVectors;

                return true;
            }

            return false;
        }
    }
}
