using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DS_Project
{
    public partial class PoligonDrawControl : UserControl
    {
        private List<Point> pointsList;
        private int paintMode;

        public PoligonDrawControl()
        {
            InitializeComponent();
            this.pointsList = new List<Point>();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(this.xInput.Value);
            int y = Convert.ToInt32(this.yInput.Value);

            this.pointsList.Add(new Point(x, y));
            this.refreshExistingPoints();
        }

        private void refreshExistingPoints()
        {
            this.existingPoints.Items.Clear();
            foreach (Point p in this.pointsList)
            {
                this.existingPoints.Items.Add(p);
            }
            this.paintMode = 0;
            this.polygonPaintArea.Refresh();
        }

        private void deletePoint_Click(object sender, EventArgs e)
        {

            var selectedItems = existingPoints.SelectedItems;

            if (selectedItems.Count > 0)
            {
                foreach (Point p in selectedItems)
                    this.pointsList.Remove(p);
                this.refreshExistingPoints();
            }
            else
            {
                if (this.pointsList.Count > 0)
                    MessageBox.Show("Моля изберете точката която желаете да изтриете.");
                else
                    MessageBox.Show("Нямате въведени точки, които да могат дабъдат изтрити.");
            }

        }

        private void colorInput_Click(object sender, EventArgs e)
        {
            DialogResult result = this.colorDialog.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                this.colorInput.BackColor = this.colorDialog.Color;

            }
        }

        private void brushReset_Click(object sender, EventArgs e)
        {
            Color col = Color.Red;
            this.thicknessInput.Value = 2;
            this.colorInput.BackColor = col;
        }

        private void polygonPaintArea_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(this.colorInput.BackColor, (float)this.thicknessInput.Value);
            switch (this.paintMode)
            {
                case 0:
                    Font font = new Font("Arial", 8);
                    SolidBrush brush = new SolidBrush(this.colorInput.BackColor);
                    for (int i = 0; i < this.pointsList.Count ; i++)
                    {
                        e.Graphics.DrawString(""+i,font,brush,(float)(this.pointsList[i].X), (float)(this.pointsList[i].Y));
                    }
                    break;
                case 1:
                    if (this.pointsList.Count > 2)
                        e.Graphics.DrawPolygon(pen, this.pointsList.ToArray());
                    break;
            }


        }

        private void drawPolybutton_Click(object sender, EventArgs e)
        {
            this.paintMode = 1;
            this.polygonPaintArea.Refresh();
        }

        private void polygonPaintArea_Click(object sender, EventArgs e)
        {
            Point clickPoint = this.polygonPaintArea.PointToClient(Cursor.Position);
            this.pointsList.Add(clickPoint);
            this.refreshExistingPoints();
        }

        private void cleanButton_Click(object sender, EventArgs e)
        {
            this.pointsList.Clear();
            this.refreshExistingPoints();
        }

    }
}
