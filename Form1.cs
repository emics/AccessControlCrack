using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace AccessControlCrack
{
    public partial class frmDoorCrack : Form
    {
        public frmDoorCrack()
        {
            InitializeComponent();
        }

        private void btnOpenDatabase_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectDatabaseFile = new OpenFileDialog();
            selectDatabaseFile.Title = "Open Database File";
            selectDatabaseFile.Filter = "Access Control Database|iCCard3000.mdb";
            selectDatabaseFile.InitialDirectory = @"C:\AccessControl";
            if (selectDatabaseFile.ShowDialog() == DialogResult.OK)
            {
                string strPass = "168168";
                string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + selectDatabaseFile.FileName + ";Jet OLEDB:Database Password=" + strPass + ";";
                OleDbConnection myConn = new OleDbConnection(connectionString);
                OleDbCommand cmd = new OleDbCommand("UPDATE t_a_SystemParam SET t_a_SystemParam.f_EName = \"" + DateTime.Now.ToString("yyyy-MM-dd") + "\" WHERE t_a_SystemParam.f_Name = \"PD\";", myConn);
                myConn.Open();
                int temp = cmd.ExecuteNonQuery();
                if (temp > 0)
                {
                    MessageBox.Show("Successfully Activated!");
                }
                else
                {
                    MessageBox.Show("Error occured!");
                }
                myConn.Close();
                Application.Exit();
            }
        }
    }
}
