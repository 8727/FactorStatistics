using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml;

namespace FactorStatistics
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        DateTime dateTime;
        bool newTable = true;
        void Form_Load(object sender, EventArgs e)
        {
            dateStart.Text = DateTime.Now.AddDays(-14).ToString("d.M.yyyy");
            dateStop.Text = DateTime.Now.ToString("d.M.yyyy");
            select.Items.Add("ALL - Cars");
            select.Items.Add("ALL - Violations");
            select.Items.Add("Speed");
            select.Items.Add("Roadside");
            select.Items.Add("Wrong Way");
            select.Items.Add("Seat Belt");
            select.Items.Add("Lights");
            select.Items.Add("Bus Lane");
            select.Items.Add("Stopping");
            select.Items.Add("Parking");
            //select.Items.Add("Red Light");
            //select.Items.Add("Stop Line");
            select.Items.Add("Phone In Hand");
            //select.Items.Add("Prohibited Maneuver");
            //select.Items.Add("Red Light Single Frontier");
            //select.Items.Add("Red Light Double Frontier");
            //select.Items.Add("Stop Line Single Frontier");
            //select.Items.Add("Stop Line Double Frontier");

            select.SelectedIndex = 0;
        }

        void clear_Click(object sender, EventArgs e)
        {
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();
            dateStart.Enabled = true;
            dateStop.Enabled = true;
            newTable = true;
        }

        void save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Application.StartupPath;
            saveFileDialog.Filter = "CSV|*.csv";
            saveFileDialog.FileName = "Statistics " + dateStart.Text + " - " + dateStop.Text + " " + DateTime.Now.ToString("dd.MM.yyyy HH.mm");

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fil = new FileInfo(saveFileDialog.FileName);
                using (StreamWriter sw = fil.AppendText())
                {
                    var headers = dataGridView.Columns.Cast<DataGridViewColumn>();
                    sw.WriteLine(string.Join(";", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));
                    sw.Close();
                }
                using (StreamWriter sw = fil.AppendText())
                {
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        var cells = row.Cells.Cast<DataGridViewCell>();
                        sw.WriteLine(string.Join(";", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
                    }
                    sw.Close();
                }
            }
        }

        void load_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "File with ip addresses (*.xml) | *.xml";
                openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    new Thread(() =>
                    {
                        XmlDocument xDoc = new XmlDocument();
                        xDoc.Load(AppDomain.CurrentDomain.BaseDirectory + @"\settings.xml");
                        XmlElement xRoot = xDoc.DocumentElement;
                        if (xRoot != null)
                        {
                            foreach (XmlElement xnode in xRoot)
                            {
                                if (xnode.Name == "ip")
                                {
                                    ip.Text = xnode.InnerText;
                                    getFactor();
                                }
                            }
                        }
                    }).Start();
                }
            }
        }

        void request_Click(object sender, EventArgs e)
        {
            getFactor();
        }

        void ip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getFactor();
            }
        }

        void date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getFactor();
            }
        }

        void Ui_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getFactor();
            }
        }

        int ВataМalidity()
        {
            int request = 0;
            Match match = Regex.Match(ip.Text, @"\b((([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])(\.)){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5]))\b");
            if (! match.Success)
            {
                MessageBox.Show("Invalid IP address specified.", "Invalid IP.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                request++;
            }

            if (newTable)
            {
                DateTime scheduleDate;
                if (!DateTime.TryParseExact(dateStart.Text, "d.M.yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out scheduleDate))
                {
                    MessageBox.Show("Invalid date format.", "Invalid Date.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    request++;
                }
                if (!DateTime.TryParseExact(dateStop.Text, "d.M.yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out scheduleDate))
                {
                    MessageBox.Show("Invalid date format.", "Invalid Date.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    request++;
                }
                DateTime stopDate = DateTime.ParseExact(dateStop.Text + " 00:00:00", "d.M.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                if (stopDate > DateTime.Now)
                {
                    MessageBox.Show("The date must be correct.", "Invalid Date.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    request++;
                }
                dateTime = DateTime.ParseExact(dateStart.Text + " 00:00:00", "d.M.yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                DateTime start = DateTime.Parse(dateStart.Text);
                DateTime end = DateTime.Parse(dateStop.Text);
                progressBar.Maximum = Convert.ToInt16((end - start).TotalDays);

                dataGridView.Columns.Add("Name", "Name");
                dataGridView.Columns[0].Width = 150;
                int i = 1;
                do
                {
                    dataGridView.Columns.Add("Date", dateTime.ToString("dd-MM-yyyy"));
                    dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[i].MinimumWidth = 70;
                    i++;
                    dateTime = dateTime.AddDays(1);
                } while (dateTime <= stopDate);
            }
            newTable = false;
            return request;
        }

        void getFactor()
        {
            ip.Enabled = false;
            dateStart.Enabled = false;
            dateStop.Enabled = false;
            select.Enabled = false;
            request.Enabled = false;
            load.Enabled = false;
            clear.Enabled = false;
            save.Enabled = false;
            progressBar.Value = 0;

            if (ВataМalidity() == 0)
            {
                int rowNumbe = dataGridView.Rows.Add();
                dataGridView.FirstDisplayedScrollingRowIndex = rowNumbe;

                PingReply pr = new Ping().Send(ip.Text, 5000);
                if (pr.Status == IPStatus.Success)
                {
                    try
                    {
                        HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create($"http://{ip.Text}/unitinfo/api/unitinfo");
                        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                        using (StreamReader stream = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                        {
                            string factorJson = stream.ReadToEnd();
                            var datajson = new JavaScriptSerializer().Deserialize<dynamic>(factorJson);
                            string factoryNumber = datajson["unit"]["factoryNumber"];
                            string serialNumber = datajson["certificate"]["serialNumber"];
                            dataGridView.Rows[rowNumbe].Cells[0].Value = serialNumber + " " + factoryNumber + " " + ip.Text;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Not a factor.", "IP unavailable.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    string factorZ = "%2B03%3A00";
                    try
                    {
                        HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create($"http://{ip.Text}/systemmanager/api/Time/timezones/current");
                        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                        using (StreamReader stream = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                        {
                            string factorJson = stream.ReadToEnd();
                            var datajson = new JavaScriptSerializer().Deserialize<dynamic>(factorJson);
                            string factorZone = datajson["description"];
                            factorZone = factorZone.Remove(factorZone.LastIndexOf(")"));
                            factorZone = factorZone.Substring(factorZone.LastIndexOf("C") + 1);
                            string zone = factorZone[0] == '+' ? "%2B" : "%2D";
                            factorZone = factorZone.Substring(1);
                            string factorH = factorZone.Remove(factorZone.LastIndexOf(":"));
                            string factorM = factorZone.Substring(factorZone.LastIndexOf(":") + 1);
                            factorZ = zone + factorH + "%3A" + factorM;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Not a factor.", "IP unavailable.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    string getcars = "&violationTypes=";
                    switch (select.Text)
                    {
                        case "ALL - Violations":
                            //getcars += "Speeding20%3BSpeeding40%3BSpeeding60%3BSpeeding80%3BRoadside%3BWrongWay%3BSeatBelt%3BLights%3BBusLane%3BStopping%3BParking%3BRedLightSingleFrontier%3BRedLightDoubleFrontier%3BStopLineSingleFrontier%3BStopLineDoubleFrontier%3BPhoneInHand%3BProhibitedManeuver";
                            getcars += "Speeding20%3BSpeeding40%3BSpeeding60%3BSpeeding80%3BRoadside%3BWrongWay%3BSeatBelt%3BLights%3BBusLane%3BStopping%3BParking%3BRedLight%3BStopLine%3BPhoneInHand%3BProhibitedManeuver";
                            break;
                        case "Speed":
                            getcars += "Speeding20%3BSpeeding40%3BSpeeding60%3BSpeeding80";
                            break;
                        case "Roadside":
                            getcars += "Roadside";
                            break;
                        case "Wrong Way":
                            getcars += "WrongWay";
                            break;
                        case "Seat Belt":
                            getcars += "SeatBelt";
                            break;
                        case "Lights":
                            getcars += "Lights";
                            break;
                        case "Bus Lane":
                            getcars += "BusLane";
                            break;
                        case "Stopping":
                            getcars += "Stopping";
                            break;
                        case "Parking":
                            getcars += "Parking";
                            break;
                        case "Red Light":
                            getcars += "RedLightSingleFrontier%3BRedLightDoubleFrontier";
                            break;
                        case "Stop Line":
                            getcars += "StopLineSingleFrontier%3BStopLineDoubleFrontier";
                            break;
                        case "Phone In Hand":
                            getcars += "PhoneInHand";
                            break;
                        case "Prohibited Maneuver":
                            getcars += "ProhibitedManeuver";
                            break;
                        case "Red Light Single Frontier":
                            getcars += "RedLightSingleFrontier";
                            break;
                        case "Red Light Double Frontier":
                            getcars += "RedLightDoubleFrontier";
                            break;
                        case "Stop Line Single Frontier":
                            getcars += "StopLineSingleFrontier";
                            break;
                        case "Stop Line Double Frontier":
                            getcars += "StopLineDoubleFrontier";
                            break;
                    }

                    if (select.Text == "ALL - Cars")
                    {
                        getcars = "";
                    }

                    int i = 0;
                    dateTime = DateTime.ParseExact(dateStart.Text + " 00:00:00", "d.M.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    DateTime stopDate = DateTime.ParseExact(dateStop.Text + " 00:00:00", "d.M.yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                    do
                    {
                        try
                        {
                            string startDate = dateTime.ToString("yyyy-MM-dd");
                            string endDate = dateTime.AddDays(1).ToString("yyyy-MM-dd");
                            string url = $"http://{ip.Text}/archive/tracks/count?dateStart={startDate}T00%3A00%3A00{factorZ}&dateEnd={endDate}T00%3A00%3A00{factorZ}{getcars}";
                            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                            using (StreamReader stream = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                            {
                                string factorJson = stream.ReadToEnd();
                                var datajson = new JavaScriptSerializer().Deserialize<dynamic>(factorJson);
                                dataGridView.Rows[rowNumbe].Cells[1 + i].Value = datajson["count"];
                                if (datajson["count"] < 1)
                                {
                                    dataGridView.Rows[rowNumbe].Cells[1 + i].Style.BackColor = Color.Red;
                                }

                                progressBar.PerformStep();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Factor request error not responding.", "Timed out.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            progressBar.PerformStep();
                        }
                        i++;
                        dateTime = dateTime.AddDays(1);
                    } while (dateTime <= stopDate);
                }
                else
                {
                    dataGridView.Rows[rowNumbe].Cells[0].Value = ip.Text + "  -  IP unavailable.";
                    dataGridView.Rows[rowNumbe].Cells[0].Style.BackColor = Color.Red;
                }
            }

            ip.Enabled = true;
            select.Enabled = true;
            request.Enabled = true;
            load.Enabled = true;
            clear.Enabled = true;
            save.Enabled = true;
        }
    }
}
