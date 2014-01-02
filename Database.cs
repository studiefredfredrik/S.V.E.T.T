using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.Data;

namespace MainForm
{
    class Database
    {
        const string dataMDB = "Data.mdb";
        static OleDbConnection lConn;
//-------------------CONTACTS--------------------------------------------------
        public static DataTable readContactsTable()
        {
            try
            {
                // Method used by program to open contact list and when sending out warnings.
                string sql = "Select ID, Name, Email, PhoneNumber from Contacts"; 
                //Where 'Contacts' is the name of the table in the MDB file 
                DataTable contacts = new DataTable();
                contacts = passSQLstringToMDB(sql);

                return contacts;
            }
            catch (Exception ex)
            {
                // if an exception is thrown, a empty table is returned, with one column named "Error"
                Error.WriteLog("Database", ex.Message, "readContactsTable");
                DataTable errorTable = new DataTable();
                errorTable.Columns.Add("Error!", typeof(string));
                return errorTable;
            }
        }
      
        public static void updateContactsTable(DataTable contacts) // update entire table
        {
            try
            {
                // Method used to save contacts table to database
                lConn = CreateLocalConnection(dataMDB);
                lConn.Open();

                // getting the table, so i can count the rows later on
                string lSQL = "Select ID, Name, Email, PhoneNumber from Contacts";
                OleDbDataAdapter dadapt = new OleDbDataAdapter(lSQL, lConn); 
                //This assigns the Select statement and connection of the data adapter 
                dadapt.UpdateCommand = new OleDbCommandBuilder(dadapt).GetUpdateCommand();
                
                // Save to the MDB file
                dadapt.Update(contacts);

                // close the connection
                lConn.Close();
            }
            catch (Exception ex)
            {
                // if an exception is thrown, save to error log
                Error.WriteLog("Database", ex.Message, "passStringToMDB");
            }
        }
    
    


//------------------SENSOR DATA----------------------------
        public static void addSensorDataToMDB(decimal temperature)
        {
            try
            {
                // Method used to save temperature readings to the database
                // add sensordata and timestamp with comment
                string lSQL = "INSERT INTO SensorData (Temperature, DateString, TimeString) VALUES ('" +
                    temperature.ToString() + "','" +
                    DateTime.Now.ToShortDateString().ToString() + "','" +
                    DateTime.Now.ToShortTimeString().ToString() + "')";
                passSQLstringToMDB(lSQL);
            }
            catch (Exception ex)
            {
                Error.WriteLog("Database", ex.Message, "addSensorDataToMDB");
            }
        }


        public static DataTable generatePlotPoints(int numberOfPoints)
        {
            try
            {
                // Return any number of temperature recordings from the end of the SensorData table
                string lSQL = "SELECT TOP " + numberOfPoints + " * " +
                    "FROM SensorData " +
                    "Order By ID DESC";
                DataTable plotpoints = passSQLstringToMDB(lSQL);
                return plotpoints;
            }
            catch (Exception ex)
            {
                // if an exception is thrown, a empty table is returned, with one column named "Error"
                Error.WriteLog("Database", ex.Message, "generate plot points");
                DataTable errorTable = new DataTable();
                errorTable.Columns.Add("Error!", typeof(string));
                return errorTable;
            }
        }


        // ------------------- ERRORS ---------------------------------------

        
        public static string getLastErrorMessage()
        {
            try
            {
                // Method retrieves latest recorded error message from the ErrorLog table
                string message = "";
                string lSQL = "SELECT TOP 1 * " +
                    "FROM ErrorLog " +
                    "Order By ID DESC";
                DataTable messages = passSQLstringToMDB(lSQL);
                foreach (DataRow row in messages.Rows)
                {
                    message += row["ErrorMsg"].ToString();
                }
                return message;
            }
            catch (Exception ex)
            {
                // if an exception is thrown, a empty table is returned, with one column named "Error"
                Error.WriteLog("Database", ex.Message, "generate plot points");
                DataTable errorTable = new DataTable();
                errorTable.Columns.Add("Error!", typeof(string));
                return "Could not get any info on the error, sorry";
            }
        }


        // ------------------- GENERAL---------------------------------------


        public static DataTable passSQLstringToMDB(string sql)
        {
            try
            {
                // Generic method used to pass sql-strings to the database
                lConn = CreateLocalConnection(dataMDB);
                lConn.Open();

                // passing inncomming SQL string
                OleDbDataAdapter dadapt = new OleDbDataAdapter(sql, lConn);
                //This assigns the Select statement and connection of the data adapter 

                // the datatable retains column headers
                DataTable MyDataTable = new DataTable();
                // populate datatable
                dadapt.Fill(MyDataTable);

                //Then save to the MDB file 
                dadapt.Update(MyDataTable);
                dadapt.Dispose();
                lConn.Close();

                return MyDataTable;
            }
            catch (Exception ex)
            {
                // if an exception is thrown, a empty table is returned, with one column named "Error"
                Error.WriteLog("Database", ex.Message, "passStringToMDB");
                DataTable errorTable = new DataTable();
                errorTable.Columns.Add("Error!", typeof(string));
                return errorTable;
            }
        }


        public static OleDbConnection CreateLocalConnection(string mdb)
        {
            // using an ridiculously long connection string, only reluctant to change it since it works
            string provider = "Provider=Microsoft.Jet.OLEDB.4.0;User ID=Admin;";
            //string opt1 = "Mode=Share Deny None;Extended Properties='';Jet OLEDB:System database='';Jet OLEDB:Registry Path='';";
            //string opt2 = "Jet OLEDB:Engine Type=4;Jet OLEDB:Database Locking Mode=0;Jet OLEDB:Global Partial Bulk Ops=2;";
            //string opt3 = "Jet OLEDB:Global Bulk Transactions=1;Jet OLEDB:Create System Database=False;Jet OLEDB:Encrypt Database=False;";
            //string opt4 = "Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SFP=False";
            OleDbConnection lConn = new OleDbConnection(provider + "Data Source=" + mdb + ";");
            //OleDbConnection lConn = new OleDbConnection(provider + "Data Source=" + mdb + ";" + opt1 + opt2 + opt3 + opt4);
            return lConn;
        }
    }
}
