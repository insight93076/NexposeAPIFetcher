using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace InternalSchedulingTool
{
    public partial class ScanForm : Form
    {
        public ScanForm (string username, string password)
        {
            this.username = username;
            this.password = password;
            InitializeComponent();
            var templateList = new List<string>();
            //Add your templates here. replace spaces with dashes, replace dashes with underscores.
            templateList.Add("test-_-template");
            cmbTemplate.DataSource = templateList.ToList();
            cmbTemplate.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbTemplate.AutoCompleteSource = AutoCompleteSource.ListItems;
            NexposeAPIFetcher nexpose = new NexposeAPIFetcher(username, password);
            token = nexpose.getToken();
            sites = nexpose.getSites();
            Dictionary<string, string> sortedSites = new Dictionary<string, string>();
            var list = sites.Keys.ToList();
            list.Sort();
            foreach (var key in list)
            {
                sortedSites.Add(key, sites[key]);
            }
            cmbSelectSite.DataSource = sortedSites.Keys.ToList();
            cmbSelectSite.Size = new System.Drawing.Size(220, 21);
            cmbSelectSite.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbSelectSite.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            dtpscanTime.Format = DateTimePickerFormat.Custom;
            dtpscanTime.CustomFormat = "yyyy MM dd HH mm ss";
            cmbSelectSite.Refresh();
            dtpscanTime.Refresh();
        }
        string token;
        public string scanid;
        public static string error;
        Dictionary<string, string> sites;
        string username;
        string password;

        public string getCurrentDateTime()
        {
            var minute = DateTime.UtcNow.Minute+2;
            var currentdate =
            DateTime.UtcNow.Year.ToString() +
            DateTime.UtcNow.Month.ToString().PadLeft(2, '0') +
            DateTime.UtcNow.Day.ToString().PadLeft(2, '0') +
            "T" +
            DateTime.UtcNow.Hour.ToString().PadLeft(2, '0') +
            minute.ToString().PadLeft(2, '0') +
            DateTime.UtcNow.Second.ToString().PadLeft(2, '0') +
            "000";
            return currentdate;
        }
        public ScanForm()
        {
            var templateList = new List<string>();
            //Add your templates here. replace spaces with dashes, replace dashes with underscores.
            templateList.Add("test-_-template");
            cmbTemplate.DataSource = templateList.ToList();
            cmbTemplate.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbTemplate.AutoCompleteSource = AutoCompleteSource.ListItems;

            NexposeAPIFetcher nexpose = new NexposeAPIFetcher(username, password);
            token = nexpose.getToken();
            sites = nexpose.getSites();
            Dictionary<string, string> sortedSites = new Dictionary<string, string>();
            var list = sites.Keys.ToList();
            list.Sort();
            foreach(var key in list)
            {
                sortedSites.Add(key, sites[key]);
            }
            InitializeComponent();
            cmbSelectSite.DataSource = sortedSites.Keys.ToList();
            cmbSelectSite.Size = new System.Drawing.Size(220, 21);
            dtpscanTime.Format = DateTimePickerFormat.Custom;
            dtpscanTime.CustomFormat = "yyyy MM dd HH mm ss";
            cmbSelectSite.Refresh();
            dtpscanTime.Refresh();
        }

        public void btnScan_Click(object _sender, EventArgs e)
        {
            string tofromIPpattern = @"((?:\d{1,3}\.){3}\d{1,3})\s*-\s*((?:\d{1,3}\.){3}\d{1,3})";
            string duration;
            // Set duration
            // If empty, set to arbitary high number
            if(string.IsNullOrWhiteSpace(txtDuration.Text.ToString()))
            {
                duration = "100000";
            }
            else
            {
                duration = txtDuration.Text.ToString();
            }
            //set date. Date is sent to console in UTC.
            string datestring =
                dtpscanTime.Value.Year.ToString() +
                dtpscanTime.Value.Month.ToString().PadLeft(2, '0') +
                dtpscanTime.Value.Day.ToString().PadLeft(2, '0') +
                "T" +
                dtpscanTime.Value.Hour.ToString().PadLeft(2, '0') +
                dtpscanTime.Value.Minute.ToString().PadLeft(2, '0') +
                dtpscanTime.Value.Second.ToString().PadLeft(2, '0') +
                "000";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://10.82.16.31:3780/api/1.1/xml");
            req.ContentType = "text/xml";
            req.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => { return true; };
            req.Method = "Post";
            //create our HTTP request in XML
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UTF8Encoding(false);
            //Request is sent on the creation of XmlWriter
            using (XmlWriter writer = XmlWriter.Create(req.GetRequestStream(), settings))
            {
                writer.WriteStartElement("SiteDevicesScanRequest");
                writer.WriteAttributeString("session-id", token);
                writer.WriteAttributeString("site-id", sites[cmbSelectSite.SelectedValue.ToString()]);
                writer.WriteStartElement("hosts");
                foreach (string line in txtIPsToScan.Lines)
                {
                    writer.WriteStartElement("range");

                    if (line.Contains("-"))
                    {
                        Regex rgx = new Regex(tofromIPpattern, RegexOptions.IgnoreCase);
                        MatchCollection matches = rgx.Matches(line);
                        GroupCollection groups = matches[0].Groups;
                        writer.WriteAttributeString(null, "from", null,groups[1].ToString());
                        writer.WriteAttributeString(null, "to", null, groups[2].ToString());
                    }
                    else if (line != null)
                        writer.WriteAttributeString(null, "from", null, line);
                    writer.WriteEndElement();
                    
                }
                // Set force=true to go during a blackout
                writer.WriteEndElement();
                if (cbScanNow.Checked == false)
                {
                    writer.WriteStartElement("Schedules");
                    writer.WriteStartElement("AdHocSchedule");
                    writer.WriteAttributeString(null, "start", null, datestring);
                    if(cmbTemplate.SelectedValue.ToString() == "_wyndham-full-audit-master-_-10")
                        writer.WriteAttributeString(null, "template", null, "full-audit-_-whg");
                    else
                        writer.WriteAttributeString(null, "template", null, cmbTemplate.SelectedValue.ToString());
                    writer.WriteAttributeString(null, "maxDuration", null, duration);
                    writer.WriteAttributeString(null, "force", null, "true");
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                else
                {
                    writer.WriteStartElement("Schedules");
                    writer.WriteStartElement("Schedule");
                    writer.WriteAttributeString(null, "start", null, getCurrentDateTime());
                    if (cmbTemplate.SelectedValue.ToString() == "_wyndham-full-audit-master-_-10")
                        writer.WriteAttributeString(null, "template", null, "full-audit-_-whg");
                    else
                        writer.WriteAttributeString(null, "template", null, cmbTemplate.SelectedValue.ToString());
                    writer.WriteAttributeString(null, "maxDuration", null, duration);
                    writer.WriteAttributeString(null, "force", null, "true");
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    
                }
                writer.WriteEndElement();
            }
            HttpWebResponse response = req.GetResponse() as HttpWebResponse;
            XmlDocument xmlBack = new XmlDocument();
            //Gets the response
            xmlBack.Load(response.GetResponseStream());
            //Set up some objects to parse the response
            XmlElement root = xmlBack.DocumentElement;
            string _token = root.GetAttribute("success");
            if (cbScanNow.Checked == true)
            {
                XmlNodeList nodes = root.SelectNodes("Scan");
                foreach (XmlNode node in nodes)
                {
                    scanid = node.Attributes["scan-id"].Value;
                }
                this.generateReport(scanid);
            }
            if (_token != "1")
            {
                error = root.InnerText.ToString();
                ErrorForm errorForm = new ErrorForm();
                errorForm.ShowDialog();
            }
            else
            {
                error = "Scan scheduled successfully.";
                ErrorForm errorForm = new ErrorForm();
                errorForm.BringToFront();
                errorForm.ShowDialog();
                cmbSelectSite.Text = "";
            }
        }
        public void showConfirmation(string text)
        {
            error = text;
            ErrorForm errorForm = new ErrorForm();
            errorForm.ShowDialog();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        
        public void generateReport(string scanid)
        {
            //First, save the report configuration
           HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://10.10.10.10:3780/api/1.1/xml");
           req.ContentType = "text/xml";
           //Don't worry about bad certs. We know nexpose has one.
           req.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => { return true; };
           req.Method = "Post";
           XmlWriterSettings settings = new XmlWriterSettings();
           settings.Encoding = new UTF8Encoding(false);
            //Request is sent on the creation of XmlWriter
            using (XmlWriter writer = XmlWriter.Create(req.GetRequestStream(), settings))
            {
                writer.WriteStartElement("ReportAdhocGenerateRequest"); //
                writer.WriteAttributeString("session-id", token);
                writer.WriteAttributeString("generate-now", "true"); //This doesn't actually appear to work
                writer.WriteStartElement("ReportConfig"); //
                writer.WriteAttributeString("id", "-1");
                writer.WriteAttributeString("name", "++Test3");
                writer.WriteAttributeString("template-id", "wer_csv");
                writer.WriteAttributeString("format", "csv");
                writer.WriteStartElement("Filters");
                writer.WriteStartElement("filter");
                writer.WriteAttributeString("type", "scan");
                writer.WriteAttributeString("id", scanid);
                writer.WriteEndElement();
                writer.WriteEndElement();
                //writer.WriteStartElement("Generate");
                //writer.WriteAttributeString("after-scan", "true");
                //writer.WriteEndElement();
                //writer.WriteStartElement("Delivery");
                //writer.WriteStartElement("Storage");
                //writer.WriteAttributeString("storeOnServer", "1");
                //writer.WriteEndElement();
                //writer.WriteEndElement();
                //writer.WriteStartElement("Generate");
                //writer.WriteAttributeString("after-scan", "1");
                //writer.WriteEndElement(); //close
                writer.WriteEndElement(); //close reportconfig
                writer.WriteEndElement(); //close reportsaverequest
            }
            HttpWebResponse response = req.GetResponse() as HttpWebResponse;
            XmlDocument xmlBack = new XmlDocument();
            //Gets the response
            xmlBack.Load(response.GetResponseStream());
            //Set up some objects to parse the response
            XmlElement root = xmlBack.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("ReportAdhocGenerateResponse");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExceptionForm exceptionForm = new ExceptionForm(username, password);
            exceptionForm.ShowDialog();
        }

        private void btnGetSites_Click(object sender, EventArgs e)
        {

        }
    }
}
