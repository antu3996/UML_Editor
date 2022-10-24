using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UML_Editor_Nguyen.Components;
using UML_Editor_Nguyen.Relationship_Components;

namespace UML_Editor_Nguyen.Description_Components
{
    public class Class_Binder
    {
        public Action<UML_Relationship> RefreshDependentRelationships { get; set; }

        public List<BindingCircle> TopSide { get; set; } = new List<BindingCircle>();
        public List<BindingCircle> RightSide { get; set; } = new List<BindingCircle>();
        public List<BindingCircle> BottomSide { get; set; } = new List<BindingCircle>();
        public List<BindingCircle> LeftSide { get; set; } = new List<BindingCircle>();

        public int TopSide_ActiveRelationships { get; set; } = 0;
        public int RightSide_ActiveRelationships { get; set; } = 0;
        public int BottomSide_ActiveRelationships { get; set; } = 0;
        public int LeftSide_ActiveRelationships { get; set; } = 0;


        public UML_Class_Object parent_rect { get; set; }

        public Class_Binder(UML_Class_Object rect)
        {
            this.parent_rect = rect;
        }

        public void Draw(Graphics g)
        {
            this.TopSide.ForEach(item => item.Draw(g));
            this.RightSide.ForEach(item => item.Draw(g));
            this.BottomSide.ForEach(item => item.Draw(g));
            this.LeftSide.ForEach(item => item.Draw(g));
        }

        public void Refresh(UML_Relationship caller)
        {
            this.RefreshTopSide();
            this.RefreshLeftSide();
            this.RefreshBottomSide();
            this.RefreshRightSide();

            if (this.RefreshDependentRelationships != null)
            {
                this.RefreshDependentRelationships(caller);
            }
        }


        public BindingCircle GetBindingCircleForAddedRelationship(UML_Relationship caller, string side)
        {
            if (side == "topside")
            {
                this.TopSide_ActiveRelationships += 1;

                BindingCircle newC = new BindingCircle(0, 0);
                this.TopSide.Add(newC);

                this.RefreshTopSide();

                if (this.RefreshDependentRelationships != null)
                {
                    this.RefreshDependentRelationships(caller);
                }

                return newC;
            }
            if (side == "rightside")
            {
                this.RightSide_ActiveRelationships += 1;

                BindingCircle newC = new BindingCircle(0, 0);
                this.RightSide.Add(newC);

                this.RefreshRightSide();


                if (this.RefreshDependentRelationships != null)
                {
                    this.RefreshDependentRelationships(caller);
                }

                return newC;
            }
            if (side == "bottomside")
            {
                this.BottomSide_ActiveRelationships += 1;

                BindingCircle newC = new BindingCircle(0, 0);
                this.BottomSide.Add(newC);

                this.RefreshBottomSide();

                if (this.RefreshDependentRelationships != null)
                {
                    this.RefreshDependentRelationships(caller);
                }

                return newC;
            }
            if (side == "leftside")
            {
                this.LeftSide_ActiveRelationships += 1;

                BindingCircle newC = new BindingCircle(0, 0);
                this.LeftSide.Add(newC);

                this.RefreshLeftSide();

                if (this.RefreshDependentRelationships != null)
                {
                    this.RefreshDependentRelationships(caller);
                }
                return newC;
            }

            

            return null;
        }

        public void RemoveBindingCircleFromSide(UML_Relationship caller, string side, BindingCircle removedCircle) 
        {
            if (side == "topside")
            {
                if (this.TopSide.Remove(removedCircle))
                {
                    this.TopSide_ActiveRelationships -= 1;
                    this.RefreshTopSide();
                }
                
            }
            if (side == "rightside")
            {
                if (this.RightSide.Remove(removedCircle))
                {
                    this.RightSide_ActiveRelationships -= 1;
                    this.RefreshRightSide();
                }
                
            }
            if (side == "bottomside")
            {
                if (this.BottomSide.Remove(removedCircle))
                {
                    this.BottomSide_ActiveRelationships -= 1;
                    this.RefreshBottomSide();
                }
                
            }
            if (side == "leftside")
            {
                if (this.LeftSide.Remove(removedCircle))
                {
                    this.LeftSide_ActiveRelationships -= 1;
                    this.RefreshLeftSide();
                }
                
            }

            if (this.RefreshDependentRelationships != null)
            {
                this.RefreshDependentRelationships(caller);
            }
        }


        public void RefreshTopSide()
        {
            int x_portion = this.parent_rect.Width / (this.TopSide_ActiveRelationships + 1);

            for (int i = 0; i < this.TopSide.Count; i++)
            {
                BindingCircle item = this.TopSide[i];

                item.FullRefresh(this.parent_rect.X + x_portion * (i + 1), this.parent_rect.Y);

            }
        }
        public void RefreshRightSide()
        {
            int y_portion = this.parent_rect.Height / (this.RightSide_ActiveRelationships + 1);
            for (int i = 0; i < this.RightSide.Count; i++)
            {
                BindingCircle item = this.RightSide[i];

                item.FullRefresh(this.parent_rect.X + this.parent_rect.Width, this.parent_rect.Y + y_portion * (i + 1));
            }

           
        }
        public void RefreshBottomSide()
        {
            int x_portion = this.parent_rect.Width / (this.BottomSide_ActiveRelationships + 1);
            for (int i = 0; i < this.BottomSide.Count; i++)
            {
                BindingCircle item = this.BottomSide[i];

                item.FullRefresh(this.parent_rect.X + x_portion * (i + 1), this.parent_rect.Y + this.parent_rect.Height);
            }
        }
        public void RefreshLeftSide()
        {
            int y_portion = this.parent_rect.Height / (this.LeftSide_ActiveRelationships + 1);
            for (int i = 0; i < this.LeftSide.Count; i++)
            {
                BindingCircle item = this.LeftSide[i];

                item.FullRefresh(this.parent_rect.X, this.parent_rect.Y + y_portion * (i + 1));
            }
        }
    }
}
