using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eksamen2
{
    public partial class DataBaseForm : Form
    {
        private string DBFile;
        private string connString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=";
        private OleDbConnection myDb;

        public DataBaseForm()
        {
            InitializeComponent();
        }

        private void DataBase_Load(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DBFile = openFileDialog1.FileName;
            }

            myDb = new OleDbConnection(connString + DBFile);
            OleDbDataAdapter adapter = new OleDbDataAdapter(@"Select * From Painting", myDb);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "List");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "List";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myDb.Open();
            OleDbDataAdapter cmd = new OleDbDataAdapter($@"Select * From Painting Where Gallery Like '%{ txtGallerySearch.Text}'",myDb);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            dataGridView1.DataSource = dt;
            myDb.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            myDb.Open();
            OleDbCommand insert = new OleDbCommand(@"Insert Into Painting (PaintingNumber, PaintingName, Gallery) Values('"+txtPNumber.Text+"','"+txtPName.Text+"','"+txtPGallery.Text+"')",myDb);
            insert.ExecuteNonQuery();
            MessageBox.Show("Hys in");
            myDb.Close();

            OleDbDataAdapter adapter = new OleDbDataAdapter(@"Select * From Painting", myDb);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "List");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "List";
        }
    }
}
