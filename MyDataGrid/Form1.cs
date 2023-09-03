using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDataGrid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
                dsStudent1.Clear();
                sqlDataAdapter1.Fill(dsStudent1);
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.MediumVioletRed;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow;
        
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            btn_save.Enabled = true;
            btn_add.Enabled = false;
            btn_delete.Enabled = false;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to delete this row ?", "Delete", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    sqlDataAdapter1.Update(dsStudent1);
                }
            }
            catch
            {
                MessageBox.Show("Please select the whole row instead of a cell");
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            sqlDataAdapter1.Update(dsStudent1);
            dataGridView1.ReadOnly = true;
            btn_save.Enabled = false;
            btn_add.Enabled = true;
            btn_delete.Enabled = true;
        }
    }
}
