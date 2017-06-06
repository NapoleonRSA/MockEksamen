using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eksamen2
{
    public partial class View1 : Form
    {
        public View1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void listToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DataBaseForm dataView = new DataBaseForm();
            dataView.MdiParent = this;
            dataView.Show();
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBaseForm dataView = new DataBaseForm();
            dataView.MdiParent = this;
            dataView.Show();
        }
    }
}
