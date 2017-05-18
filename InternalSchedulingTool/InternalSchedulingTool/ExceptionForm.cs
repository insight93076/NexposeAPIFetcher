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
using System.Text;
using System.Text.RegularExpressions;

/*So here's the flow:
First, get a listing of all sites (nexpose.getsites())
Then, get a list of all the assets in the site we want (select that via dropdown later)
Then, take the IPs we want to except and look them up in that list to get their device ID
submit an exceptioncreationrequest with deviceID
submit an exceptionapprovalrequest with expiry date
done!
 */
namespace InternalSchedulingTool
{
    public partial class ExceptionForm : Form
    {
        string username;
        string password;
        public List<Vulnerability> vulns;
        public ExceptionForm(string _username, string _password)
        {
            this.username = _username;
            this.password = _password;
            InitializeComponent();
            NexposeAPIFetcher nexpose = new NexposeAPIFetcher(username, password);
            vulns = nexpose.getVulnerabilities();
            cmbVulnTitle.DataSource = vulns.Select(f => f.title).ToList();
            cmbVulnTitle.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbVulnTitle.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            siteList = nexpose.getSites();
            List<String> exceptions = new List<String>();
            exceptions.Add("False Positive");
            exceptions.Add("Acceptable Use");
            exceptions.Add("Acceptable Risk");
            exceptions.Add("Compensating Control");
            expDate.CustomFormat = "yyyy MM dd HH mm ss";
            cmbExceptionType.DataSource = exceptions.ToList();
            cmbExceptionType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbExceptionType.AutoCompleteSource = AutoCompleteSource.ListItems;

            Dictionary<string, string> sortedSites = new Dictionary<string, string>();
            var list = siteList.Keys.ToList();
            list.Sort();
            foreach (var key in list)
            {
                sortedSites.Add(key, siteList[key]);
            }
            cmbSiteSelect.DataSource = sortedSites.Keys.ToList();
            cmbSiteSelect.Size = new System.Drawing.Size(220, 21);
            cmbSiteSelect.Refresh();
            cmbSiteSelect.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbSiteSelect.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbExceptionType.Refresh();
            expDate.Refresh();

        }
        public Dictionary<string, string> siteList;
        public ExceptionForm()
        {
            NexposeAPIFetcher nexpose = new NexposeAPIFetcher(username, password);
            siteList = nexpose.getSites();
            List<String> exceptions = new List<String>();
            exceptions.Add("False Positive");
            exceptions.Add("Acceptable Use");
            exceptions.Add("Acceptable Risk");
            exceptions.Add("Compensating Control"); 
            InitializeComponent();
            expDate.CustomFormat = "yyyy MM dd HH mm ss";
            cmbExceptionType.DataSource = exceptions.ToList();
            Dictionary<string, string> sortedSites = new Dictionary<string, string>();
            var list = siteList.Keys.ToList();
            list.Sort();
            foreach (var key in list)
            {
                sortedSites.Add(key, siteList[key]);
            }
            cmbSiteSelect.DataSource = sortedSites.Keys.ToList();
            cmbSiteSelect.Size = new System.Drawing.Size(220, 21);
            cmbSiteSelect.Refresh();
            cmbExceptionType.Refresh();
            expDate.Refresh();
        }

        public void btnSubmit_Click(object sender, EventArgs e)
        {
            var vulnid = vulns.Where(i => i.title == cmbVulnTitle.Text).FirstOrDefault().id;
            string exp = expDate.Value.Year.ToString() + "-" + expDate.Value.Month.ToString().PadLeft(2, '0') + "-" + expDate.Value.Day.ToString().PadLeft(2, '0'); 
            string comment = "Please reference " + txtTicket.Text.ToString() +". "+ cmbExceptionType.SelectedValue.ToString() +" requests in the attached form are approved as reported. Requested by "+txtRequestor.Text;
            List<string> ips = new List<string>();
            NexposeAPIFetcher nexpose = new NexposeAPIFetcher(username, password);
            List<Device> devices = nexpose.siteDeviceList(siteList[cmbSiteSelect.SelectedValue.ToString()]);
            List<string> exceptedDevices = new List<string>();
            List<string> successes = new List<string>();
            
            foreach (string line in txtIps.Lines)
            {
                ips.Add(line);
            }
            foreach (string ip in ips)
            {
                foreach (Device device in devices)
                {
                    if (ip == device.ip)
                    {
                        exceptedDevices.Add(device.id);
                        break;
                    }
                }
            }
            foreach (String asset in exceptedDevices)
            {
                //nexpose.approveException(nexpose.createException(asset, txtVulnID.Text, cmbExceptionType.SelectedValue.ToString(), comment),comment, exp);
                nexpose.createException(asset, vulnid, cmbExceptionType.SelectedValue.ToString(), comment);
            }
            ScanForm scan = new ScanForm("user", "pass");
            scan.showConfirmation("Exception requests sent to Nexpose.");
        }

        private void lblVulnName_Click(object sender, EventArgs e)
        {

        }
    }
}
