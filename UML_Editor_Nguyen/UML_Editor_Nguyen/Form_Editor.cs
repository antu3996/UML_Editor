using UML_Editor_Nguyen.Comparers;

namespace UML_Editor_Nguyen
{
    public partial class Form_Editor : Form
    {
        private List<UML_Class_Object> classes = new List<UML_Class_Object>();
        private bool IsMouseDown = false;
        private UML_Class_Object selectedClass = null;
        public Form_Editor()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            UML_Class_Object newClass = new UML_Class_Object(30, 30, 200, 250);

            for (int i = this.classes.Count - 1; i >= 0; i--)
            {
                UML_Class_Object current = this.classes[i];
                if (newClass.IsColliding(current)) {
                    newClass.Layer_Index = current.Layer_Index + 1;
                    break;
                }
            }

            this.classes.Add(newClass);

            this.classes.Sort(new UML_ClassRect_Comparer());

            this.editor_Box.Refresh();
        }

        private void editor_Box_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (UML_Class_Object item in this.classes)
            {
                item.Draw(g);
            }
        }


        private void editor_Box_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.IsMouseDown)
            {

                if (this.selectedClass != null)
                {
                    this.selectedClass.MouseDrag(e.X, e.Y);
                    this.CheckCollisions();
                }

                
                this.editor_Box.Refresh();

            }
        }

        private void editor_Box_MouseDown(object sender, MouseEventArgs e)
        {
            if (!this.IsMouseDown)
            {
                this.IsMouseDown = true;

                this.SelectClass(e.X, e.Y);


                if (this.selectedClass != null)
                {
                    this.selectedClass.SetDragPoint(e.X, e.Y);
                    this.CheckCollisions();
                }

                this.editor_Box.Refresh();
            }
        }

        private void editor_Box_MouseUp(object sender, MouseEventArgs e)
        {
            this.IsMouseDown = false;
        }

        private void CheckCollisions()
        {
            for (int i = this.classes.Count - 1; i >= 0; i--)
            {
                UML_Class_Object current = this.classes[i];
                if (this.selectedClass.IsColliding(current))
                {
                    this.selectedClass.Layer_Index = current.Layer_Index + 1;
                    break;
                }
                else
                {
                    this.selectedClass.Layer_Index = 1;
                }
            }

            this.classes.Sort(new UML_ClassRect_Comparer());
        }

        private void SelectClass(int mouseX, int mouseY)
        {
            UML_Class_Object newSelection = null;
            for (int i = this.classes.Count - 1; i >= 0; i--)
            {
                UML_Class_Object current = this.classes[i];
                bool isSelected = current.SelectClass(mouseX, mouseY);

                if (isSelected)
                {
                    newSelection = current;
                    break;
                }
            }
            if (this.selectedClass != null)
            {
                if (newSelection != this.selectedClass)
                {
                    this.selectedClass.ClearSelection();
                    this.selectedClass = newSelection;
                    return;
                }
            }
            else
            {
                this.selectedClass = newSelection;
            }
                
        }

        private void editor_Box_DoubleClick(object sender, EventArgs e)
        {
            if (this.selectedClass != null)
            {
                this.selectedClass.EditDescription();

                this.editor_Box.Refresh();
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (this.selectedClass != null)
            {
                this.classes.Remove(this.selectedClass);
                this.selectedClass = null;

                this.editor_Box.Refresh();
            }
        }
    }
}