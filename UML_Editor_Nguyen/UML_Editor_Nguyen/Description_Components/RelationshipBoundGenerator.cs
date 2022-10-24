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
        public UML_Relationship parent_rel { get; set; }

        public RelationshipBoundGenerator(UML_Relationship parent_rel)
        {
            this.parent_rel = parent_rel;
        }

        public bool DidGeneratePoints()
        {
            //dodělat

            LineVector_List newVectors = new LineVector_List();

            UML_Class_Object primaryC = this.parent_rel.Primary_Class;
            UML_Class_Object secondaryC = this.parent_rel.Secondary_Class;

            string primSide = this.parent_rel.CurrentPrimarySide;
            string secondarySide = this.parent_rel.CurrentSecondarySide;


            int center1_X = primaryC.X + primaryC.Width / 2;
            int center1_Y = primaryC.Y + primaryC.Height / 2;
            int center2_X = secondaryC.X + secondaryC.Width / 2;
            int center2_Y = secondaryC.Y + secondaryC.Height / 2;

            int diffX = center2_X - center1_X;
            int diffY = center2_Y - center1_Y;

            string currentRelDir = this.parent_rel.RelationshipDirection;

            if (/*currentAngle == 0*/ diffY == 0 && diffX > 0 /*&& currentRelDir != "E"*/)
            {
                int x_diff, y_diff;

                if (primSide != "rightside" && secondarySide != "leftside")
                {
                    primaryC.Binder_Component.RemoveBindingCircleFromSide(this.parent_rel, primSide, this.parent_rel.StartPoint);
                    secondaryC.Binder_Component.RemoveBindingCircleFromSide(this.parent_rel, secondarySide, this.parent_rel.EndPoint);

                    BindingCircle newStartpoint = primaryC.Binder_Component.GetBindingCircleForAddedRelationship(this.parent_rel, "rightside");
                    BindingCircle newEndpoint = secondaryC.Binder_Component.GetBindingCircleForAddedRelationship(this.parent_rel, "leftside");

                    this.parent_rel.RelationshipDirection = "E";
                    this.parent_rel.StartPoint = newStartpoint;
                    this.parent_rel.EndPoint = newEndpoint;
                    this.parent_rel.CurrentPrimarySide = "rightside";
                    this.parent_rel.CurrentSecondarySide = "leftside";

                    x_diff = newEndpoint.X - newStartpoint.X;
                    y_diff = newEndpoint.Y - newStartpoint.Y;
                }
                else
                {
                    x_diff = this.parent_rel.EndPoint.X - this.parent_rel.StartPoint.X;
                    y_diff = this.parent_rel.EndPoint.Y - this.parent_rel.StartPoint.Y;
                }



                if (y_diff == 0)
                {
                    LineVector v1 = new LineVector(
                    this.parent_rel.StartPoint.X, this.parent_rel.StartPoint.Y,
                    this.parent_rel.EndPoint.X, this.parent_rel.EndPoint.Y
                    );

                    v1.IsLocked = true;


                    newVectors.AddNewVector(v1);
                }
                else
                {
                    LineVector v1 = new LineVector(
                        this.parent_rel.StartPoint.X, this.parent_rel.StartPoint.Y,
                        this.parent_rel.StartPoint.X + x_diff / 2, this.parent_rel.StartPoint.Y
                    );
                    LineVector v2 = new LineVector(
                        this.parent_rel.StartPoint.X + x_diff / 2, this.parent_rel.StartPoint.Y,
                        this.parent_rel.StartPoint.X + x_diff / 2, this.parent_rel.StartPoint.Y + y_diff
                        );
                    LineVector v3 = new LineVector(
                        this.parent_rel.StartPoint.X + x_diff / 2, this.parent_rel.StartPoint.Y + y_diff,
                        this.parent_rel.EndPoint.X, this.parent_rel.EndPoint.Y
                        );

                    v1.IsLocked = true;
                    v3.IsLocked = true;


                    newVectors.AddNewVector(v1);
                    newVectors.AddNewVector(v2);
                    newVectors.AddNewVector(v3);
                }



                this.parent_rel.Vectors = newVectors;

                return true;
            }
            if (/*currentAngle == 90*/ diffX == 0 && diffY < 0 /*&& currentRelDir != "N"*/)
            {
                int x_diff, y_diff;

                if (primSide != "topside" && secondarySide != "bottomside")
                {

                    primaryC.Binder_Component.RemoveBindingCircleFromSide(this.parent_rel, primSide, this.parent_rel.StartPoint);
                    secondaryC.Binder_Component.RemoveBindingCircleFromSide(this.parent_rel, secondarySide, this.parent_rel.EndPoint);

                    BindingCircle newStartpoint = primaryC.Binder_Component.GetBindingCircleForAddedRelationship(this.parent_rel, "topside");
                    BindingCircle newEndpoint = secondaryC.Binder_Component.GetBindingCircleForAddedRelationship(this.parent_rel, "bottomside");

                    this.parent_rel.RelationshipDirection = "N";
                    this.parent_rel.StartPoint = newStartpoint;
                    this.parent_rel.EndPoint = newEndpoint;
                    this.parent_rel.CurrentPrimarySide = "topside";
                    this.parent_rel.CurrentSecondarySide = "bottomside";

                    x_diff = newEndpoint.X - newStartpoint.X;
                    y_diff = newEndpoint.Y - newStartpoint.Y;


                }
                else
                {
                    x_diff = this.parent_rel.EndPoint.X - this.parent_rel.StartPoint.X;
                    y_diff = this.parent_rel.EndPoint.Y - this.parent_rel.StartPoint.Y;
                }



                if (x_diff == 0)
                {
                    LineVector v1 = new LineVector(
                    this.parent_rel.StartPoint.X, this.parent_rel.StartPoint.Y,
                    this.parent_rel.EndPoint.X, this.parent_rel.EndPoint.Y
                    );

                    v1.IsLocked = true;


                    newVectors.AddNewVector(v1);
                }
                else
                {
                    LineVector v1 = new LineVector(
                        this.parent_rel.StartPoint.X, this.parent_rel.StartPoint.Y,
                        this.parent_rel.StartPoint.X, this.parent_rel.StartPoint.Y + y_diff / 2
                    );
                    LineVector v2 = new LineVector(
                        this.parent_rel.StartPoint.X, this.parent_rel.StartPoint.Y + y_diff / 2,
                        this.parent_rel.StartPoint.X + x_diff, this.parent_rel.StartPoint.Y + y_diff / 2
                        );
                    LineVector v3 = new LineVector(
                        this.parent_rel.StartPoint.X + x_diff, this.parent_rel.StartPoint.Y + y_diff / 2,
                        this.parent_rel.EndPoint.X, this.parent_rel.EndPoint.Y
                        );

                    v1.IsLocked = true;
                    v3.IsLocked = true;


                    newVectors.AddNewVector(v1);
                    newVectors.AddNewVector(v2);
                    newVectors.AddNewVector(v3);
                }

                this.parent_rel.Vectors = newVectors;

                return true;
            }
            if (/*currentAngle > 90 && currentAngle <= 135*/ ((diffX < 0 && diffY < 0 && Math.Abs(diffY) >= Math.Abs(diffX))
                || (diffX < Math.Abs(diffY) && diffY < 0 && diffX > 0)) /*&& currentRelDir != "NNW-NNE"*/)
            {
                int x_diff, y_diff;

                if (primSide != "topside" && secondarySide != "bottomside")
                {

                    primaryC.Binder_Component.RemoveBindingCircleFromSide(this.parent_rel, primSide, this.parent_rel.StartPoint);
                    secondaryC.Binder_Component.RemoveBindingCircleFromSide(this.parent_rel, secondarySide, this.parent_rel.EndPoint);

                    BindingCircle newStartpoint = primaryC.Binder_Component.GetBindingCircleForAddedRelationship(this.parent_rel, "topside");
                    BindingCircle newEndpoint = secondaryC.Binder_Component.GetBindingCircleForAddedRelationship(this.parent_rel, "bottomside");

                    this.parent_rel.RelationshipDirection = "NNW-NNE";
                    this.parent_rel.StartPoint = newStartpoint;
                    this.parent_rel.EndPoint = newEndpoint;
                    this.parent_rel.CurrentPrimarySide = "topside";
                    this.parent_rel.CurrentSecondarySide = "bottomside";

                    x_diff = newEndpoint.X - newStartpoint.X;
                    y_diff = newEndpoint.Y - newStartpoint.Y;


                }
                else
                {
                    x_diff = this.parent_rel.EndPoint.X - this.parent_rel.StartPoint.X;
                    y_diff = this.parent_rel.EndPoint.Y - this.parent_rel.StartPoint.Y;
                }


                if (x_diff == 0)
                {
                    LineVector v1 = new LineVector(
                    this.parent_rel.StartPoint.X, this.parent_rel.StartPoint.Y,
                    this.parent_rel.EndPoint.X, this.parent_rel.EndPoint.Y
                    );

                    v1.IsLocked = true;


                    newVectors.AddNewVector(v1);
                }
                else
                {
                    LineVector v1 = new LineVector(
                        this.parent_rel.StartPoint.X, this.parent_rel.StartPoint.Y,
                        this.parent_rel.StartPoint.X, this.parent_rel.StartPoint.Y + y_diff / 2
                    );
                    LineVector v2 = new LineVector(
                        this.parent_rel.StartPoint.X, this.parent_rel.StartPoint.Y + y_diff / 2,
                        this.parent_rel.StartPoint.X + x_diff, this.parent_rel.StartPoint.Y + y_diff / 2
                        );
                    LineVector v3 = new LineVector(
                        this.parent_rel.StartPoint.X + x_diff, this.parent_rel.StartPoint.Y + y_diff / 2,
                        this.parent_rel.EndPoint.X, this.parent_rel.EndPoint.Y
                        );

                    v1.IsLocked = true;
                    v3.IsLocked = true;


                    newVectors.AddNewVector(v1);
                    newVectors.AddNewVector(v2);
                    newVectors.AddNewVector(v3);
                }

                this.parent_rel.Vectors = newVectors;

                return true;
            }
            if (/*currentAngle == 180*/ diffX < 0 && diffY == 0 /*&& currentRelDir != "W"*/)
            {
                int x_diff, y_diff;
                if (primSide != "leftside" && secondarySide != "rightside")
                {
                    primaryC.Binder_Component.RemoveBindingCircleFromSide(this.parent_rel, primSide, this.parent_rel.StartPoint);
                    secondaryC.Binder_Component.RemoveBindingCircleFromSide(this.parent_rel, secondarySide, this.parent_rel.EndPoint);

                    BindingCircle newStartpoint = primaryC.Binder_Component.GetBindingCircleForAddedRelationship(this.parent_rel, "leftside");
                    BindingCircle newEndpoint = secondaryC.Binder_Component.GetBindingCircleForAddedRelationship(this.parent_rel, "rightside");

                    this.parent_rel.RelationshipDirection = "W";
                    this.parent_rel.StartPoint = newStartpoint;
                    this.parent_rel.EndPoint = newEndpoint;
                    this.parent_rel.CurrentPrimarySide = "leftside";
                    this.parent_rel.CurrentSecondarySide = "rightside";


                    x_diff = newEndpoint.X - newStartpoint.X;
                    y_diff = newEndpoint.Y - newStartpoint.Y;
                }
                else
                {
                    x_diff = this.parent_rel.EndPoint.X - this.parent_rel.StartPoint.X;
                    y_diff = this.parent_rel.EndPoint.Y - this.parent_rel.StartPoint.Y;
                }



                if (y_diff == 0)
                {
                    LineVector v1 = new LineVector(
                    this.parent_rel.StartPoint.X, this.parent_rel.StartPoint.Y,
                    this.parent_rel.EndPoint.X, this.parent_rel.EndPoint.Y
                    );

                    v1.IsLocked = true;


                    newVectors.AddNewVector(v1);
                }
                else
                {
                    LineVector v1 = new LineVector(
                        this.parent_rel.StartPoint.X, this.parent_rel.StartPoint.Y,
                        this.parent_rel.StartPoint.X + x_diff / 2, this.parent_rel.StartPoint.Y
                    );
                    LineVector v2 = new LineVector(
                        this.parent_rel.StartPoint.X + x_diff / 2, this.parent_rel.StartPoint.Y,
                        this.parent_rel.StartPoint.X + x_diff / 2, this.parent_rel.StartPoint.Y + y_diff
                        );
                    LineVector v3 = new LineVector(
                        this.parent_rel.StartPoint.X + x_diff / 2, this.parent_rel.StartPoint.Y + y_diff,
                        this.parent_rel.EndPoint.X, this.parent_rel.EndPoint.Y
                        );

                    v1.IsLocked = true;
                    v3.IsLocked = true;


                    newVectors.AddNewVector(v1);
                    newVectors.AddNewVector(v2);
                    newVectors.AddNewVector(v3);
                }


                this.parent_rel.Vectors = newVectors;

                return true;
            }
            if (/*currentAngle > 180 && currentAngle <= 225*/ ((diffX < 0 && diffY > 0 && Math.Abs(diffX) >= diffY)
                || (diffX < 0 && diffY < 0 && Math.Abs(diffY) < Math.Abs(diffX))) /*&& currentRelDir != "WNW-WSW"*/)
            {
                int x_diff, y_diff;
                if (primSide != "leftside" && secondarySide != "rightside")
                {
                    primaryC.Binder_Component.RemoveBindingCircleFromSide(this.parent_rel, primSide, this.parent_rel.StartPoint);
                    secondaryC.Binder_Component.RemoveBindingCircleFromSide(this.parent_rel, secondarySide, this.parent_rel.EndPoint);

                    BindingCircle newStartpoint = primaryC.Binder_Component.GetBindingCircleForAddedRelationship(this.parent_rel, "leftside");
                    BindingCircle newEndpoint = secondaryC.Binder_Component.GetBindingCircleForAddedRelationship(this.parent_rel, "rightside");

                    this.parent_rel.RelationshipDirection = "WNW-WSW";
                    this.parent_rel.StartPoint = newStartpoint;
                    this.parent_rel.EndPoint = newEndpoint;
                    this.parent_rel.CurrentPrimarySide = "leftside";
                    this.parent_rel.CurrentSecondarySide = "rightside";


                    x_diff = newEndpoint.X - newStartpoint.X;
                    y_diff = newEndpoint.Y - newStartpoint.Y;
                }
                else
                {
                    x_diff = this.parent_rel.EndPoint.X - this.parent_rel.StartPoint.X;
                    y_diff = this.parent_rel.EndPoint.Y - this.parent_rel.StartPoint.Y;
                }



                if (y_diff == 0)
                {
                    LineVector v1 = new LineVector(
                    this.parent_rel.StartPoint.X, this.parent_rel.StartPoint.Y,
                    this.parent_rel.EndPoint.X, this.parent_rel.EndPoint.Y
                    );

                    v1.IsLocked = true;


                    newVectors.AddNewVector(v1);
                }
                else
                {
                    LineVector v1 = new LineVector(
                        this.parent_rel.StartPoint.X, this.parent_rel.StartPoint.Y,
                        this.parent_rel.StartPoint.X + x_diff / 2, this.parent_rel.StartPoint.Y
                    );
                    LineVector v2 = new LineVector(
                        this.parent_rel.StartPoint.X + x_diff / 2, this.parent_rel.StartPoint.Y,
                        this.parent_rel.StartPoint.X + x_diff / 2, this.parent_rel.StartPoint.Y + y_diff
                        );
                    LineVector v3 = new LineVector(
                        this.parent_rel.StartPoint.X + x_diff / 2, this.parent_rel.StartPoint.Y + y_diff,
                        this.parent_rel.EndPoint.X, this.parent_rel.EndPoint.Y
                        );

                    v1.IsLocked = true;
                    v3.IsLocked = true;


                    newVectors.AddNewVector(v1);
                    newVectors.AddNewVector(v2);
                    newVectors.AddNewVector(v3);
                }

                this.parent_rel.Vectors = newVectors;

                return true;
            }
            if (/*currentAngle == 270*/ diffX == 0 && diffY > 0 /*&& currentRelDir != "S"*/)
            {
                int x_diff, y_diff;
                if (primSide != "bottomside" && secondarySide != "topside")
                {
                    primaryC.Binder_Component.RemoveBindingCircleFromSide(this.parent_rel, primSide, this.parent_rel.StartPoint);
                    secondaryC.Binder_Component.RemoveBindingCircleFromSide(this.parent_rel, secondarySide, this.parent_rel.EndPoint);

                    BindingCircle newStartpoint = primaryC.Binder_Component.GetBindingCircleForAddedRelationship(this.parent_rel, "bottomside");
                    BindingCircle newEndpoint = secondaryC.Binder_Component.GetBindingCircleForAddedRelationship(this.parent_rel, "topside");

                    this.parent_rel.RelationshipDirection = "S";
                    this.parent_rel.StartPoint = newStartpoint;
                    this.parent_rel.EndPoint = newEndpoint;
                    this.parent_rel.CurrentPrimarySide = "bottomside";
                    this.parent_rel.CurrentSecondarySide = "topside";


                    x_diff = newEndpoint.X - newStartpoint.X;
                    y_diff = newEndpoint.Y - newStartpoint.Y;


                }
                else
                {
                    x_diff = this.parent_rel.EndPoint.X - this.parent_rel.StartPoint.X;
                    y_diff = this.parent_rel.EndPoint.Y - this.parent_rel.StartPoint.Y;
                }


                if (x_diff == 0)
                {
                    LineVector v1 = new LineVector(
                    this.parent_rel.StartPoint.X, this.parent_rel.StartPoint.Y,
                    this.parent_rel.EndPoint.X, this.parent_rel.EndPoint.Y
                    );

                    v1.IsLocked = true;


                    newVectors.AddNewVector(v1);
                }
                else
                {
                    LineVector v1 = new LineVector(
                        this.parent_rel.StartPoint.X, this.parent_rel.StartPoint.Y,
                        this.parent_rel.StartPoint.X, this.parent_rel.StartPoint.Y + y_diff / 2
                    );
                    LineVector v2 = new LineVector(
                        this.parent_rel.StartPoint.X, this.parent_rel.StartPoint.Y + y_diff / 2,
                        this.parent_rel.StartPoint.X + x_diff, this.parent_rel.StartPoint.Y + y_diff / 2
                        );
                    LineVector v3 = new LineVector(
                        this.parent_rel.StartPoint.X + x_diff, this.parent_rel.StartPoint.Y + y_diff / 2,
                        this.parent_rel.EndPoint.X, this.parent_rel.EndPoint.Y
                        );

                    v1.IsLocked = true;
                    v3.IsLocked = true;


                    newVectors.AddNewVector(v1);
                    newVectors.AddNewVector(v2);
                    newVectors.AddNewVector(v3);
                }

                this.parent_rel.Vectors = newVectors;
                return true;
            }
            if (/*currentAngle > 270 && currentAngle <= 315*/ ((diffX > 0 && diffY > 0 && diffY >= diffX)
                || (diffX < 0 && diffY > 0 && Math.Abs(diffX) < diffY)) /*&& currentRelDir != "SSW-SSE"*/)
            {
                int x_diff, y_diff;
                if (primSide != "bottomside" && secondarySide != "topside")
                {
                    primaryC.Binder_Component.RemoveBindingCircleFromSide(this.parent_rel, primSide, this.parent_rel.StartPoint);
                    secondaryC.Binder_Component.RemoveBindingCircleFromSide(this.parent_rel, secondarySide, this.parent_rel.EndPoint);

                    BindingCircle newStartpoint = primaryC.Binder_Component.GetBindingCircleForAddedRelationship(this.parent_rel, "bottomside");
                    BindingCircle newEndpoint = secondaryC.Binder_Component.GetBindingCircleForAddedRelationship(this.parent_rel, "topside");

                    this.parent_rel.RelationshipDirection = "SSW-SSE";
                    this.parent_rel.StartPoint = newStartpoint;
                    this.parent_rel.EndPoint = newEndpoint;
                    this.parent_rel.CurrentPrimarySide = "bottomside";
                    this.parent_rel.CurrentSecondarySide = "topside";


                    x_diff = newEndpoint.X - newStartpoint.X;
                    y_diff = newEndpoint.Y - newStartpoint.Y;


                }
                else
                {
                    x_diff = this.parent_rel.EndPoint.X - this.parent_rel.StartPoint.X;
                    y_diff = this.parent_rel.EndPoint.Y - this.parent_rel.StartPoint.Y;
                }


                if (x_diff == 0)
                {
                    LineVector v1 = new LineVector(
                    this.parent_rel.StartPoint.X, this.parent_rel.StartPoint.Y,
                    this.parent_rel.EndPoint.X, this.parent_rel.EndPoint.Y
                    );

                    v1.IsLocked = true;


                    newVectors.AddNewVector(v1);
                }
                else
                {
                    LineVector v1 = new LineVector(
                        this.parent_rel.StartPoint.X, this.parent_rel.StartPoint.Y,
                        this.parent_rel.StartPoint.X, this.parent_rel.StartPoint.Y + y_diff / 2
                    );
                    LineVector v2 = new LineVector(
                        this.parent_rel.StartPoint.X, this.parent_rel.StartPoint.Y + y_diff / 2,
                        this.parent_rel.StartPoint.X + x_diff, this.parent_rel.StartPoint.Y + y_diff / 2
                        );
                    LineVector v3 = new LineVector(
                        this.parent_rel.StartPoint.X + x_diff, this.parent_rel.StartPoint.Y + y_diff / 2,
                        this.parent_rel.EndPoint.X, this.parent_rel.EndPoint.Y
                        );

                    v1.IsLocked = true;
                    v3.IsLocked = true;


                    newVectors.AddNewVector(v1);
                    newVectors.AddNewVector(v2);
                    newVectors.AddNewVector(v3);
                }

                this.parent_rel.Vectors = newVectors;

                return true;
            }
            if (/*currentAngle > 315 && currentAngle < 360*/ ((diffX > 0 && diffY > 0 && diffY < diffX)
                || (diffX >= Math.Abs(diffY) && diffY < 0 && diffX > 0)) /*&& currentRelDir != "ENE-ESE"*/)
            {
                int x_diff, y_diff;
                if (primSide != "rightside" && secondarySide != "leftside")
                {
                    primaryC.Binder_Component.RemoveBindingCircleFromSide(this.parent_rel, primSide, this.parent_rel.StartPoint);
                    secondaryC.Binder_Component.RemoveBindingCircleFromSide(this.parent_rel, secondarySide, this.parent_rel.EndPoint);

                    BindingCircle newStartpoint = primaryC.Binder_Component.GetBindingCircleForAddedRelationship(this.parent_rel, "rightside");
                    BindingCircle newEndpoint = secondaryC.Binder_Component.GetBindingCircleForAddedRelationship(this.parent_rel, "leftside");

                    this.parent_rel.RelationshipDirection = "ENE-ESE";
                    this.parent_rel.StartPoint = newStartpoint;
                    this.parent_rel.EndPoint = newEndpoint;
                    this.parent_rel.CurrentPrimarySide = "rightside";
                    this.parent_rel.CurrentSecondarySide = "leftside";

                    x_diff = newEndpoint.X - newStartpoint.X;
                    y_diff = newEndpoint.Y - newStartpoint.Y;
                }
                else
                {
                    x_diff = this.parent_rel.EndPoint.X - this.parent_rel.StartPoint.X;
                    y_diff = this.parent_rel.EndPoint.Y - this.parent_rel.StartPoint.Y;
                }



                if (y_diff == 0)
                {
                    LineVector v1 = new LineVector(
                    this.parent_rel.StartPoint.X, this.parent_rel.StartPoint.Y,
                    this.parent_rel.EndPoint.X, this.parent_rel.EndPoint.Y
                    );

                    v1.IsLocked = true;


                    newVectors.AddNewVector(v1);
                }
                else
                {
                    LineVector v1 = new LineVector(
                        this.parent_rel.StartPoint.X, this.parent_rel.StartPoint.Y,
                        this.parent_rel.StartPoint.X + x_diff / 2, this.parent_rel.StartPoint.Y
                    );
                    LineVector v2 = new LineVector(
                        this.parent_rel.StartPoint.X + x_diff / 2, this.parent_rel.StartPoint.Y,
                        this.parent_rel.StartPoint.X + x_diff / 2, this.parent_rel.StartPoint.Y + y_diff
                        );
                    LineVector v3 = new LineVector(
                        this.parent_rel.StartPoint.X + x_diff / 2, this.parent_rel.StartPoint.Y + y_diff,
                        this.parent_rel.EndPoint.X, this.parent_rel.EndPoint.Y
                        );

                    v1.IsLocked = true;
                    v3.IsLocked = true;


                    newVectors.AddNewVector(v1);
                    newVectors.AddNewVector(v2);
                    newVectors.AddNewVector(v3);
                }

                this.parent_rel.Vectors = newVectors;

                return true;
            }

            return false;
        }
    }
}
