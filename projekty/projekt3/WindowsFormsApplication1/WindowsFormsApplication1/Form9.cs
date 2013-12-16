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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void car_dealerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.car_dealerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsienkiewiczDataSet);

        }

        private void Form9_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsienkiewiczDataSet.car_dealer' table. You can move, or remove it, as needed.
            this.car_dealerTableAdapter.Fill(this.dsienkiewiczDataSet.car_dealer);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form7 connectionMode = new Form7();
            connectionMode.Show();
        }
    }
}
