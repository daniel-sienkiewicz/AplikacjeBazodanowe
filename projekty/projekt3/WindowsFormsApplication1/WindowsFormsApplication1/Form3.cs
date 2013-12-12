using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        private ConnectionMode cMode = new ConnectionMode();
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Select.Clear();
            ArrayList all = cMode.selectAll();

            for (int i = 0; i < all.Count; i++)
            {
                Select.AppendText(all[i] + "\n");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form2 connectionMode = new Form2();
            connectionMode.Show();
        }
    }
}
