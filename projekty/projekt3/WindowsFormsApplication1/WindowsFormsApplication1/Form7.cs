using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 connectionMode = new Form1();
            connectionMode.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form8 connectionMode = new Form8();
            connectionMode.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form10 connectionMode = new Form10();
            connectionMode.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form9 connectionMode = new Form9();
            connectionMode.Show();
        }
    }
}
