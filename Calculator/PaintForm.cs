using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class PaintForm : Form
    {
        private bool _isMoving;
        public PaintForm()
        {
            InitializeComponent();
        }

        private void pictureBoxPaint_MouseDown(object sender, MouseEventArgs e)
        {
            _isMoving = true;
        }

        private void pictureBoxPaint_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMoving)
            {
                var graphics = pictureBoxPaint.CreateGraphics();

                graphics.FillRectangle(Brushes.Black, e.X, e.Y, 1, 1);
            }
        }

        private void pictureBoxPaint_MouseUp(object sender, MouseEventArgs e)
        {
            _isMoving = false;
        }
    }
}
