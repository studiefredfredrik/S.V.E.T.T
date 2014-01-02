using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MainForm
{
    public partial class MainForm : Form
    {
        public static decimal sensorValue = 20;
        private NotifyIcon m_notifyicon = new NotifyIcon();
        private ContextMenu m_menu = new ContextMenu();        
        int dataPointsInChart = 0;
        int yAxisMin = -20;
        int yAxisMax = 40;
        
        // default periods string:
        string[,] periods = new string[,] { { "Last 10 minutes", "61" }, { "Last hour", "361" }, { "Last day", "8641" } };
        public MainForm()
        {
            InitializeComponent();
            makeTrayIcon();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                
                pictureBox1.Image = Error.exclamationGet();
                populateSettingsDefault();
                // display graphics
                populateChart(dataPointsInChart);
                // remove unnessesary legend on top right of chart
                this.chart1.Legends.RemoveAt(0);
                // start timer 
                MainTimer.Interval = 10000 * Properties.Settings.Default.sensorReadInterval;
                MainTimer.Enabled = true;
                // disallow resizing
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;
            }
            catch (Exception ex)
            {
                Error.WriteLog("main form load", ex.Message, "");
            }
        }
// ----------------TRAY ICON RELATED----------------------------------------------
        private void makeTrayIcon()
        {
            try
            {
                this.m_menu.MenuItems.Add(0,
                    new MenuItem("Show", new System.EventHandler(Show_Click)));
                this.m_menu.MenuItems.Add(1,
                    new MenuItem("Hide", new System.EventHandler(Hide_Click)));
                this.m_menu.MenuItems.Add(2,
                    new MenuItem("Exit", new System.EventHandler(Exit_Click)));

                this.m_notifyicon.Text = "Right click for context menu";
                this.m_notifyicon.Visible = true;
                this.m_notifyicon.Icon = new Icon("3highres.ico");
                this.m_notifyicon.ContextMenu = m_menu;
                this.m_notifyicon.DoubleClick += new EventHandler(notifyIconDoubbleClicked);
                this.SizeChanged += new System.EventHandler(this.MainFormSizeChanged);
            }
            catch (Exception ex)
            {
                Error.WriteLog("makeTrayIcon", ex.Message, "");
            }
        }

        private void MainFormSizeChanged(Object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.m_notifyicon.ShowBalloonTip(500, "Programmet kjører fremdeles", "Klikk på ikonet for å få opp programvinduet igjen", ToolTipIcon.Info);
                Hide();
                this.ShowInTaskbar = false;
            }
        }
        protected void notifyIconDoubbleClicked(Object sender, System.EventArgs e)
        {
            if (this.Visible != true)
            {
                Show();
                this.WindowState = FormWindowState.Normal;
            }
            else if (this.Visible)
            {
                Hide();
            }
        }
        
        protected void Exit_Click(Object sender, System.EventArgs e)
        {
            Close();
        }
        protected void Hide_Click(Object sender, System.EventArgs e)
        {
            Hide();
        }
        protected void Show_Click(Object sender, System.EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                m_notifyicon.Dispose();
            }
            catch (Exception ex)
            {
                Error.WriteLog("form-closing", ex.Message, "");
            }
        }

// --------------end trayicon related------------------------------------------

//------------------------Chart-------------------------------------------
        private void populateChart(int period) // populates Chart1 with the last temperature readings from the MDB
        {
            try
            {
                int numPoints = Convert.ToInt32(periods[period,1]);
                int rows;
                decimal tempMax = -999;
                decimal tempMin = 9999;
                string tempID;
                decimal tempT;
                decimal tempSum = 0;
                // remove the default values
                this.chart1.Series.Clear();
                Series series1 = this.chart1.Series.Add("Temperature");
                // make a spline type chart (can be set to show different types)
                series1.ChartType = SeriesChartType.Spline;
                // add axis labels
                chart1.ChartAreas[0].AxisY.Title = "Temperature (°C)";
                chart1.ChartAreas[0].AxisX.Title = "Time";
                chart1.ChartAreas[0].AxisY.Minimum = yAxisMin;
                chart1.ChartAreas[0].AxisY.Maximum = yAxisMax;
                chart1.ChartAreas[0].AxisX.Minimum = 1;
                // change marker thickness
                series1.BorderWidth = 5;
                // add data points to the chart
                this.chart1.Series[0].XValueType = ChartValueType.String;
                DataTable points = Database.generatePlotPoints(numPoints);
                rows=points.Rows.Count;
                
                for (int i = 0; i < rows; i++)
                {
                    tempID = points.Rows[rows - 1 - i]["TimeString"].ToString();
                    tempT = Convert.ToDecimal(points.Rows[rows - 1 - i]["Temperature"].ToString());
                    tempSum += tempT;
                    tempMax = tempT > tempMax ? tempT : tempMax;
                    tempMin = tempT < tempMin ? tempT : tempMin;
                    series1.Points.AddXY(tempID, tempT);
                }
                lblCurrent.Text = points.Rows[0]["Temperature"].ToString() + " °C";


                yAxisMax = Convert.ToInt32((Math.Round(tempMax / 5, 0) + 2) * 5);
                yAxisMin = Convert.ToInt32((Math.Round(tempMin / 5, 0) - 3) * 5);


                // add a nice heading
                Font headingFont = new Font(FontFamily.GenericSansSerif, 14);
                this.chart1.Titles.Clear();
                this.chart1.Titles.Add(periods[period, 0]).Font = headingFont;

                this.txtHigh.Text = Convert.ToString(tempMax) + " °C";
                this.txtLowest.Text = Convert.ToString(tempMin) + " °C";
                tempSum = tempSum / rows;
                this.txtAvar.Text = tempSum.ToString("0.0") + " °C";
                
            }
            catch (Exception ex)
            {
                Error.WriteLog("Main form", ex.Message, "chart");
                MessageBox.Show(ex.Message, "Chart error");
            }
        }

        
// -----------------------------Timer----------------------------------------
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // read from Sensor
                sensorValue = Sensor.GetTemp();
                if (sensorValue >= -273)
                {
                    // save sensor data to database
                    Database.addSensorDataToMDB(sensorValue);
                    // update chart
                    populateChart(dataPointsInChart);
                }
                // check if, send warning
                ClientFeedback.determineNeedForWarning(sensorValue);
                // update status image 
                pictureBox1.Image = Error.exclamationGet();
                if (Error.HasError == true)
                {
                    MainTimer.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Error.WriteLog("Timer-tick", ex.Message, "");
            }
        }
//-----------------Settings-----------------------------------------------
        private void populateSettingsDefault()
        {
            try
            {
                // populate form with saved settings
                checkMail.Checked = Properties.Settings.Default.warnMail;
                checkSMS.Checked = Properties.Settings.Default.warnSMS;
                MainTimer.Interval = Properties.Settings.Default.sensorReadInterval * 1000;
                txtMax.Text = Convert.ToString(Properties.Settings.Default.tempMax);
                txtMin.Text = Convert.ToString(Properties.Settings.Default.tempMin);
            }
            catch (Exception ex)
            {
                // this error will never happen
                string errorMessage = "Could not set data to form: " + ex.Message;
                MessageBox.Show(errorMessage);
                Error.WriteLog("main form", ex.Message, "settings");
            }
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                // max temperature must be higher than minimum temperature
                // and interval must be 1 or higher
                if (Convert.ToInt16(txtMax.Text) > Convert.ToInt16(txtMin.Text))
                {
                    // read settings from form and save them to application settings
                    Properties.Settings.Default.warnMail = checkMail.Checked;
                    Properties.Settings.Default.warnSMS = checkSMS.Checked;
                    //MainTimer.Interval = Properties.Settings.Default.sensorReadInterval * 1000;
                    Properties.Settings.Default.tempMax = Convert.ToDecimal(txtMax.Text);
                    Properties.Settings.Default.tempMin = Convert.ToDecimal(txtMin.Text);
                    Properties.Settings.Default.Save();
                }
                //ID-Ten-T Errors, also seen as ID10T and ID107 ("idiot")
                else if (Convert.ToInt16(txtMin.Text) >= Convert.ToInt16(txtMax.Text))
                { MessageBox.Show("Temperature Minimum must be lower than the Maximum", "User error:"); }
            }
            catch (Exception ex)
            {
                // this will probably fail due to user error (datatype mismatch)
                string errorMessage = "Could not save settings: " + ex.Message;
                MessageBox.Show(errorMessage);
                Error.WriteLog("Main form", ex.Message, "settings");
            }
        }

        private void btnDefaults_Click(object sender, EventArgs e)
        {
            try
            {
                // populate form with defaults
                checkMail.Checked = true;
                checkSMS.Checked = false;
                txtMax.Text = "25";
                txtMin.Text = "15";
                // read settings from form and save them to application settings
                Properties.Settings.Default.warnMail = checkMail.Checked;
                Properties.Settings.Default.warnSMS = checkSMS.Checked;
                MainTimer.Interval = Properties.Settings.Default.sensorReadInterval * 1000;
                Properties.Settings.Default.tempMax = Convert.ToDecimal(txtMax.Text);
                Properties.Settings.Default.tempMin = Convert.ToDecimal(txtMin.Text);
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                // this error will never happen
                string errorMessage = "Could not set data to form: " + ex.Message;
                MessageBox.Show(errorMessage);
            }
        }
//-----------------------------end settings----------------------------------------------
        private void btnContacts_Click(object sender, EventArgs e)
        {
            // åpner kontaktlista
            MDB_readerClass.Contacts_list_form contacts = new MDB_readerClass.Contacts_list_form();
            contacts.ShowDialog();
        }


          private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            // -dobbeltklikk på gult utropstegn fjærner feilmeldingen og starter programet igjen.
            // vis relevant info om utropstegnet, f.eks hvilken error gul utropstegn varsler om
            if (Error.HasError == true)
            {
                MessageBox.Show(Database.getLastErrorMessage(), "Last reported error was:");
                Error.HasError = false;
                MainTimer.Enabled = true;
            }
            else
            {
                MessageBox.Show("Green - Temperature within limits" +
                "\nBlue - Temperature too low\nRed - Temperature too high\nYellow - Error detected"
                , "Exclamation marks explained:");
            }
        }

          private void cboPeriod_SelectedIndexChanged_1(object sender, EventArgs e)
          {
              // combobox for endring av antall datapunkter i plot
              dataPointsInChart = cboPeriod.SelectedIndex;
              populateChart(dataPointsInChart);
          }

          private void chart1_Click(object sender, EventArgs e)
          {

          }

    }
}
