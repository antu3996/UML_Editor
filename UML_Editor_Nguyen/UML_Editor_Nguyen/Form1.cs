using UML_Editor_Nguyen.Comparers;

namespace UML_Editor_Nguyen
{
    public partial class Form1 : Form
    {
        private List<UML_ClassRect> classes = new List<UML_ClassRect>();
        private bool IsMouseDown = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            this.classes.Add(new UML_ClassRect("Customer", 10, 10, 200, 250) { Layer_Index = 3});

            /*this.classes.Add(new UML_ClassRect("Customer", 130, 110, 170, 200) { Layer_Index = 2});

            this.classes.Add(new UML_ClassRect("Customer", 140, 130, 180, 240) { Layer_Index = 5});*/



            this.classes.Sort(new UML_ClassRect_Comparer());

            this.editor_Box.Refresh();
        }

        private void editor_Box_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            classes.ForEach(item => item.Draw(g));
        }


        private void editor_Box_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.IsMouseDown)
            {
                foreach (UML_ClassRect item in this.classes)
                {
                    item.MouseDrag(e.X, e.Y);
                }
                this.editor_Box.Refresh();

            }
        }

        private void editor_Box_MouseDown(object sender, MouseEventArgs e)
        {
            if (!this.IsMouseDown)
            {
                this.IsMouseDown = true;

                foreach (UML_ClassRect item in this.classes)
                {
                    item.SetDragPoint(e.X, e.Y);
                }
            }
        }

        private void editor_Box_MouseUp(object sender, MouseEventArgs e)
        {
            this.IsMouseDown = false;
        }
    }
}