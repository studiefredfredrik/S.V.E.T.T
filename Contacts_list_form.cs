using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;

namespace MDB_readerClass
{
    public partial class Contacts_list_form : Form
    {
        public Contacts_list_form()
        {
            InitializeComponent();
        }

        public static DataTable contacts = new DataTable();

        private void Form1_Load(object sender, EventArgs e)
        {
            // Method gets contents of the Contacts table in the database, then fills in the data grid
            try
            {
            contacts = MainForm.Database.readContactsTable();

                dataGridView1.DataSource = contacts;
                // Set proper column sizes
                dataGridView1.Columns[0].Width = 30;
                dataGridView1.Columns[1].Width = 170;
                dataGridView1.Columns[2].Width = 170;
                dataGridView1.Columns[3].Width = 90;
                //Don't allow the user to resize the form (it's perfect as is)
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                //This goes for maximize button as well
                this.MaximizeBox = false;
            }
            catch (Exception ex)
            {
                //Errors here will have been caught already, so no need to write to the error log again
                MessageBox.Show(ex.Message, "Error reading from database");
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Clicking button sends data table back to Database class to update the table there
            MainForm.Database.updateContactsTable(contacts);
            this.Dispose();
        }
    }
}
