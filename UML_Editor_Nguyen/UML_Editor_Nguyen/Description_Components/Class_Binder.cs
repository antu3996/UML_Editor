using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UML_Editor_Nguyen.Components;
using UML_Editor_Nguyen.Relationship_Components;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace UML_Editor_Nguyen.Description_Components
{
    public class Class_Binder
    {

        public List<BindingCircle> TopSide { get; set; }
        public List<BindingCircle> RightSide { get; set; }
        public List<BindingCircle> BottomSide { get; set; }
        public List<BindingCircle> LeftSide { get; set; }

        public int TopSide_ActiveRelationships { get; set; } = 0;
        public int RightSide_ActiveRelationships { get; set; } = 0;
        public int BottomSide_ActiveRelationships { get; set; } = 0;
        public int LeftSide_ActiveRelationships { get; set; } = 0;

        public Class_Binder()
        {
            this.TopSide = new List<BindingCircle>();
            this.RightSide = new List<BindingCircle>();
            this.BottomSide = new List<BindingCircle>();
            this.LeftSide = new List<BindingCircle>();
        }

        public void Draw(Graphics g)
        {
            this.TopSide.ForEach(item => item.Draw(g));
            this.RightSide.ForEach(item => item.Draw(g));
            this.BottomSide.ForEach(item => item.Draw(g));
            this.LeftSide.ForEach(item => item.Draw(g));
        }

        public void Refresh(UML_Class_Object parent)
        {
            this.RefreshTopSide(parent);
            this.RefreshLeftSide(parent);
            this.RefreshBottomSide(parent);
            this.RefreshRightSide(parent);
        }


        public BindingCircle GetBindingCircleForAddedRelationship(UML_Class_Object parent, string side)
        {
            if (side == "topside")
            {
                this.TopSide_ActiveRelationships += 1;

                BindingCircle newC = new BindingCircle(0, 0);
                this.TopSide.Add(newC);

                this.RefreshTopSide(parent);

                return newC;
            }
            if (side == "rightside")
            {
                this.RightSide_ActiveRelationships += 1;

                BindingCircle newC = new BindingCircle(0, 0);
                this.RightSide.Add(newC);

                this.RefreshRightSide(parent);

                return newC;
            }
            if (side == "bottomside")
            {
                this.BottomSide_ActiveRelationships += 1;

                BindingCircle newC = new BindingCircle(0, 0);
                this.BottomSide.Add(newC);

                this.RefreshBottomSide(parent);
                return newC;
            }
            if (side == "leftside")
            {
                this.LeftSide_ActiveRelationships += 1;

                BindingCircle newC = new BindingCircle(0, 0);
                this.LeftSide.Add(newC);

                this.RefreshLeftSide(parent);
                return newC;
            }

            

            return null;
        }

        public void RemoveBindingCircleFromSide(UML_Class_Object parent, string side, BindingCircle removedCircle) 
        {
            if (side == "topside")
            {
                if (this.TopSide.Remove(removedCircle))
                {
                    this.TopSide_ActiveRelationships -= 1;
                    this.RefreshTopSide(parent);
                }
                
            }
            if (side == "rightside")
            {
                if (this.RightSide.Remove(removedCircle))
                {
                    this.RightSide_ActiveRelationships -= 1;
                    this.RefreshRightSide(parent);
                }
                
            }
            if (side == "bottomside")
            {
                if (this.BottomSide.Remove(removedCircle))
                {
                    this.BottomSide_ActiveRelationships -= 1;
                    this.RefreshBottomSide(parent);
                }
                
            }
            if (side == "leftside")
            {
                if (this.LeftSide.Remove(removedCircle))
                {
                    this.LeftSide_ActiveRelationships -= 1;
                    this.RefreshLeftSide(parent);
                }
                
            }
        }


        public void RefreshTopSide(UML_Class_Object parent)
        {
            int x_portion = parent.Width / (this.TopSide_ActiveRelationships + 1);

            for (int i = 0; i < this.TopSide.Count; i++)
            {
                BindingCircle item = this.TopSide[i];
                item.ID = i;

                item.FullRefresh(parent.X + x_portion * (i + 1), parent.Y);

            }
        }
        public void RefreshRightSide(UML_Class_Object parent)
        {
            int y_portion = parent.Height / (this.RightSide_ActiveRelationships + 1);
            for (int i = 0; i < this.RightSide.Count; i++)
            {
                BindingCircle item = this.RightSide[i];
                item.ID = i;

                item.FullRefresh(parent.X + parent.Width, parent.Y + y_portion * (i + 1));
            }

           
        }
        public void RefreshBottomSide(UML_Class_Object parent)
        {
            int x_portion = parent.Width / (this.BottomSide_ActiveRelationships + 1);
            for (int i = 0; i < this.BottomSide.Count; i++)
            {
                BindingCircle item = this.BottomSide[i];
                item.ID = i;

                item.FullRefresh(parent.X + x_portion * (i + 1), parent.Y + parent.Height);
            }
        }
        public void RefreshLeftSide(UML_Class_Object parent)
        {
            int y_portion = parent.Height / (this.LeftSide_ActiveRelationships + 1);
            for (int i = 0; i < this.LeftSide.Count; i++)
            {
                BindingCircle item = this.LeftSide[i];
                item.ID = i;

                item.FullRefresh(parent.X, parent.Y + y_portion * (i + 1));
            }
        }

        public void ImportData(Class_Binder other)
        {
            for (int i = 0; i < other.TopSide.Count; i++)
            {
                BindingCircle newC = new BindingCircle(0,0);
                newC.ImportData(other.TopSide[i]);
                this.TopSide.Add(newC);
            }
            for (int i = 0; i < other.LeftSide.Count; i++)
            {
                BindingCircle newC = new BindingCircle(0, 0);
                newC.ImportData(other.LeftSide[i]);
                this.LeftSide.Add(newC);
            }
            for (int i = 0; i < other.BottomSide.Count; i++)
            {
                BindingCircle newC = new BindingCircle(0, 0);
                newC.ImportData(other.BottomSide[i]);
                this.BottomSide.Add(newC);
            }
            for (int i = 0; i < other.RightSide.Count; i++)
            {
                BindingCircle newC = new BindingCircle(0, 0);
                newC.ImportData(other.RightSide[i]);
                this.RightSide.Add(newC);
            }

            this.BottomSide_ActiveRelationships = this.BottomSide.Count;
            this.LeftSide_ActiveRelationships = this.LeftSide.Count;
            this.TopSide_ActiveRelationships = this.TopSide.Count;
            this.RightSide_ActiveRelationships = this.RightSide.Count;
        }

        public BindingCircle GetCircleById(int id, string side)
        {
            if (side == "topside")
            {
                return this.TopSide.Where(item => item.ID == id).FirstOrDefault();
            }
            if (side == "rightside")
            {
                return this.RightSide.Where(item => item.ID == id).FirstOrDefault();

            }
            if (side == "bottomside")
            {

                return this.BottomSide.Where(item => item.ID == id).FirstOrDefault();

            }
            if (side == "leftside")
            {
                return this.LeftSide.Where(item => item.ID == id).FirstOrDefault();

            }
            return null;
        }
    }
}
