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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form7 connectionMode = new Form7();
            connectionMode.Show();
        }

        private void customerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsienkiewiczDataSet);

        }

        private void Form8_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsienkiewiczDataSet.customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.dsienkiewiczDataSet.customer);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            Form7 connectionMode = new Form7();
            connectionMode.Show();
        }
    }
}
