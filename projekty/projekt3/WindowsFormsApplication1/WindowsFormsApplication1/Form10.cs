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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void carsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.carsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsienkiewiczDataSet);

        }

        private void Form10_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsienkiewiczDataSet.cars' table. You can move, or remove it, as needed.
            this.carsTableAdapter.Fill(this.dsienkiewiczDataSet.cars);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form7 connectionMode = new Form7();
            connectionMode.Show();
        }
    }
}
