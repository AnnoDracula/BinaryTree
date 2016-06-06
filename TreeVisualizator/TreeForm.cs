using System;
using System.Drawing;
using System.Windows.Forms;
using BinaryTree;

namespace TreeVisualizator
{
    public partial class TreeForm : Form
    {
        private Tree _tree;
        private readonly TreeDrower _drower;

        public TreeForm()
        {
            _tree = new Tree();
            _drower = new TreeDrower();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") return;
            try
            {
                var value = Int32.Parse(textBox1.Text);
                _tree.AddElement(value);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Wrong value");
            }
            drawingPanel.Refresh();
        }

        private Rectangle ResizePanel()
        {
            var size = _drower.GetSize(_tree);
            drawingPanel.Width = size.Width + 2;
            drawingPanel.Height = size.Height + 2;
            return new Rectangle(new Point(0, 0), size);
        }

        private void drawingPanel_Paint(object sender, PaintEventArgs e)
        {
            var graphics = drawingPanel.CreateGraphics();
            var rectangle = ResizePanel();

            _drower.Draw(graphics, _tree.GetTop(), rectangle);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            _tree = new Tree();
            drawingPanel.Refresh();
        }

    }
}
