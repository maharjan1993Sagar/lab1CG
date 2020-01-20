using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1CG
{
    public partial class Draw : Form
    {
        public Draw()
        {
            InitializeComponent();
        }
        public void DrawPolygon(Object sender,PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Red, 100);

        }
    }
}
