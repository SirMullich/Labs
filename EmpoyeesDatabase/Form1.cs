using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpoyeesDatabase
{
    public partial class Form1 : Form
    {
        DataConnection objConnect;
        string conString;

        DataSet ds;
        DataRow dRow;

        int maxRows;
        int inc = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                objConnect = new DataConnection();
                conString = Properties.Settings.Default.EmployeesConnectionString;

                objConnect.ConnectionString = conString;
                objConnect.Sql = Properties.Settings.Default.SQL;

                ds = objConnect.GetConnection;
                maxRows = ds.Tables[0].Rows.Count;

                NavigateRecords();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void NavigateRecords()
        {
            dRow = ds.Tables[0].Rows[inc];
            txtFirstName.Text = dRow.ItemArray.GetValue(1).ToString();
            txtSurname.Text = dRow.ItemArray.GetValue(2).ToString();
            txtJobTitle.Text = dRow.ItemArray.GetValue(3).ToString();
            txtDepartment.Text = dRow.ItemArray.GetValue(4).ToString();
            UpdateStatus();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (inc != maxRows - 1)
            {
                inc++;
                NavigateRecords();
            }
            else
            {
                MessageBox.Show("No more records");
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (inc != 0)
            {
                inc--;
                NavigateRecords();
            }
            else
            {
                MessageBox.Show("No more records");
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            inc = 0;
            NavigateRecords();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            inc = maxRows - 1;
            NavigateRecords();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtSurname.Clear();
            txtJobTitle.Clear();
            txtDepartment.Clear();

            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            NavigateRecords();

            btnAdd.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[0].NewRow();

            row[1] = txtFirstName.Text;
            row[2] = txtSurname.Text;
            row[3] = txtJobTitle.Text;
            row[4] = txtDepartment.Text;

            ds.Tables[0].Rows.Add(row);

            try
            {
                objConnect.UpdateDatabase(ds);
                maxRows++;
                inc = maxRows - 1;

                MessageBox.Show("Database updated");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            UpdateStatus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[0].Rows[inc];

            row[1] = txtFirstName.Text;
            row[2] = txtSurname.Text;
            row[3] = txtJobTitle.Text;
            row[4] = txtDepartment.Text;

            try
            {
                objConnect.UpdateDatabase(ds);
                MessageBox.Show("Record updated");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            UpdateStatus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ds.Tables[0].Rows[inc].Delete();
                objConnect.UpdateDatabase(ds);

                maxRows = ds.Tables[0].Rows.Count;
                inc--;
                NavigateRecords();
                MessageBox.Show("Record deleted");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            UpdateStatus();

        }

        private void UpdateStatus()
        {
            statusLabel.Text = string.Format("{0} of {1}", inc + 1, maxRows);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }   
    }
}
