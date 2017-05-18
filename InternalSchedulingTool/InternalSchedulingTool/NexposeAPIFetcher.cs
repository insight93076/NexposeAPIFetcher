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

namespace InternalSchedulingTool
{
    public class Exception
    {
        public string vulnid;
        public string exceptionid;
        public string submitter;
        public string reviewer;
        public string status;
        public string reason;
        public string scope;
        public string deviceid;
        public string portno;
        public string expirationdate;
        public string vulnkey;
    }
    class Device
    {
        public string id;
        public string siteid;
        public string ip;
        public string riskfactor;
        public string riskscore;
    }
    public class Vulnerability
    {
        public string id;
        public string title;
        public string severity;
        public string pciSeverity;
        public string cvssScore;
        public string cvssVector;
        public string publishedDate;
        public string summary;
        public string modified;
    }
    class NexposeAPIFetcher
    {
        public NexposeAPIFetcher (string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public string token;
        public string scanid;
        public string username;
        public string password;

        public string getToken()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://10.82.16.31:3780/api/1.1/xml");
            req.ContentType = "text/xml";
            //Don't worry about bad certs. We know nexpose has one.
            req.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => { return true; };
            req.Method = "Post";
            //create our HTTP request in XML
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UTF8Encoding(false);
            //Request is sent on the creation of XmlWriter
            using (XmlWriter writer = XmlWriter.Create(req.GetRequestStream(), settings))
            {
                writer.WriteStartElement("LoginRequest");
                //writer.WriteAttributeString("user-id", "test_service_account");
                //writer.WriteAttributeString("password", "Rapid6ateRapid7");
                writer.WriteAttributeString("user-id", username);
                writer.WriteAttributeString("password", password);
                writer.WriteEndElement();
            }

            HttpWebResponse response = req.GetResponse() as HttpWebResponse;
            XmlDocument xmlBack = new XmlDocument();
            //Gets the response
            xmlBack.Load(response.GetResponseStream());

            //Set up some objects to parse the response
            XmlElement root = xmlBack.DocumentElement;
            string token = root.GetAttribute("session-id");
            return token;
        }
        public List<Exception> exceptionList()
        {
            List<Exception> exps = new List<Exception>();
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://10.82.16.31:3780/api/1.1/xml");
            req.ContentType = "text/xml";
            //Don't worry about bad certs. We know nexpose has one.
            req.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => { return true; };
            req.Method = "Post";
            //create our HTTP request in XML
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UTF8Encoding(false);
            //Request is sent on the creation of XmlWriter
            using (XmlWriter writer = XmlWriter.Create(req.GetRequestStream(), settings))
            {
                writer.WriteStartElement("<VulnerabilityExceptionListingRequest");
                writer.WriteAttributeString("session-id", this.getToken());
            }
            HttpWebResponse response = req.GetResponse() as HttpWebResponse;
            XmlDocument xmlBack = new XmlDocument();
            //Gets the response
            xmlBack.Load(response.GetResponseStream());

            //Set up some objects to parse the response
            XmlElement root = xmlBack.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("//VulnerabilityException");
            foreach (XmlNode node in nodes)
            {
                Exception exception = new Exception();
                exception.status = node.Attributes["status"].Value;
                exception.expirationdate = node.Attributes["expiration-date"].Value;
                exception.deviceid = node.Attributes["device-id"].Value;
                exception.exceptionid = node.Attributes["exception-id"].Value;
                exps.Add(exception);
            }
            return exps;

        }
        public List<Device> siteDeviceList(string siteid)
        {
            List<Device> devices = new List<Device>();
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://10.82.16.31:3780/api/1.1/xml");
            req.ContentType = "text/xml";
            //Don't worry about bad certs. We know nexpose has one.
            req.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => { return true; };
            req.Method = "Post";
            //create our HTTP request in XML
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UTF8Encoding(false);
            //Request is sent on the creation of XmlWriter
            using (XmlWriter writer = XmlWriter.Create(req.GetRequestStream(), settings))
            {
                writer.WriteStartElement("SiteDeviceListingRequest");
                writer.WriteAttributeString("session-id", this.getToken());
                writer.WriteAttributeString("site-id", siteid);
            }
            HttpWebResponse response = req.GetResponse() as HttpWebResponse;
            XmlDocument xmlBack = new XmlDocument();
            //Gets the response
            xmlBack.Load(response.GetResponseStream());

            //Set up some objects to parse the response
            XmlElement root = xmlBack.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("//device");
            foreach (XmlNode node in nodes)
            {
                Device device = new Device();
                device.id = node.Attributes["id"].Value;
                device.ip = node.Attributes["address"].Value;
                device.riskfactor = node.Attributes["riskfactor"].Value;
                device.riskscore = node.Attributes["riskscore"].Value;
                devices.Add(device);
            }
            return devices;

        }
        public Dictionary<string, string> getSites()
        {
            Dictionary<string, string> siteList = new Dictionary<string, string>();
            string sitename;
            string siteid;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://10.82.16.31:3780/api/1.1/xml");
            req.ContentType = "text/xml";
            //Don't worry about bad certs. We know nexpose has one.
            req.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => { return true; };
            req.Method = "Post";
            //create our HTTP request in XML
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UTF8Encoding(false);
            //Request is sent on the creation of XmlWriter
            using (XmlWriter writer = XmlWriter.Create(req.GetRequestStream(), settings))
            {
                writer.WriteStartElement("SiteListingRequest");
                writer.WriteAttributeString("session-id", this.getToken());
                writer.WriteEndElement();
            }
            HttpWebResponse response = req.GetResponse() as HttpWebResponse;
            XmlDocument xmlResponse = new XmlDocument();
            //Gets the response
            xmlResponse.Load(response.GetResponseStream());
            XmlElement root = xmlResponse.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("SiteSummary");
            foreach (XmlNode node in nodes)
            {
                siteid = node.Attributes["id"].Value;
                sitename = node.Attributes["name"].Value;
                siteList.Add(sitename, siteid);
            }
            return siteList;
        }
        public List<Vulnerability> getVulnerabilities()
        {
            List<Vulnerability> vulnerabilities = new List<Vulnerability>();
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://10.82.16.31:3780/api/1.1/xml");
            req.ContentType = "text/xml";
            //Don't worry about bad certs. We know nexpose has one.
            req.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => { return true; };
            req.Method = "Post";
            //create our HTTP request in XML
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UTF8Encoding(false);
            //Request is sent on the creation of XmlWriter
            using (XmlWriter writer = XmlWriter.Create(req.GetRequestStream(), settings))
            {
                writer.WriteStartElement("VulnerabilityListingRequest");
                writer.WriteAttributeString("session-id", this.getToken());
                writer.WriteEndElement();
            }
            HttpWebResponse response = req.GetResponse() as HttpWebResponse;
            XmlDocument xmlResponse = new XmlDocument();
            //Gets the response
            xmlResponse.Load(response.GetResponseStream());
            XmlElement root = xmlResponse.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("VulnerabilitySummary");
            Vulnerability vuln = new Vulnerability();
            foreach (XmlNode node in nodes)
            {
                vuln = new Vulnerability();
                vuln.id = node.Attributes["id"].Value;
                vuln.title = node.Attributes["title"].Value;
                vulnerabilities.Add(vuln);
            }
            return vulnerabilities;
        }
        public void generateReport(string scanid)
        {
            //First, save the report configuration
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://10.82.16.31:3780/api/1.1/xml");
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
                writer.WriteStartElement("Generate");
                writer.WriteAttributeString("after-scan", "true");
                writer.WriteEndElement();
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
        public string createException(string deviceid, string vulnid, string reason, string comment)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://10.82.16.31:3780/api/1.2/xml");
            req.ContentType = "text/xml";
            //Don't worry about bad certs. We know nexpose has one.
            req.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => { return true; };
            req.Method = "Post";
            //create our HTTP request in XML
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UTF8Encoding(false);
            //Request is sent on the creation of XmlWriter
            using (XmlWriter writer = XmlWriter.Create(req.GetRequestStream(), settings))
            {
                writer.WriteStartElement("VulnerabilityExceptionCreateRequest");
                writer.WriteAttributeString("session-id", this.getToken());
                writer.WriteAttributeString("vuln-id", vulnid);
                writer.WriteAttributeString("reason", reason);
                writer.WriteAttributeString("device-id", deviceid);
                writer.WriteAttributeString("scope", "All Instances on a Specific Asset");
                writer.WriteStartElement("comment");
                writer.WriteString(comment);
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
            using (XmlWriter writer = XmlWriter.Create(@"C:\Users\604398\Desktop\exceptioncreate.xml"))
            {
                writer.WriteStartElement("VulnerabilityExceptionCreateRequest");
                writer.WriteAttributeString("session-id", this.getToken());
                writer.WriteAttributeString("vuln-id", vulnid);
                writer.WriteAttributeString("reason", reason);
                writer.WriteAttributeString("device-id", deviceid);
                writer.WriteAttributeString("scope", "All Instances on a Specific Asset");
                writer.WriteStartElement("comment");
                writer.WriteString(comment);
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
            HttpWebResponse response = req.GetResponse() as HttpWebResponse;
            XmlDocument xmlResponse = new XmlDocument();
            //Gets the response
            xmlResponse.Load(response.GetResponseStream());
            XmlElement root = xmlResponse.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("VulnerabilityExceptionCreateResponse");
            string exceptionid = root.GetAttribute("exception-id");
            return exceptionid;
        }
        //ADD EXP TO THIS FUNCTION
        public string approveException(string exceptionid, string comment, string exp)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://10.82.16.31:3780/api/1.2/xml");
            req.ContentType = "text/xml";
            //Don't worry about bad certs. We know nexpose has one.
            req.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => { return true; };
            req.Method = "Post";
            //create our HTTP request in XML
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UTF8Encoding(false);
            //Request is sent on the creation of XmlWriter
            using (XmlWriter writer = XmlWriter.Create(req.GetRequestStream(), settings))
            {
                writer.WriteStartElement("VulnerabilityExceptionApproveRequest");
                writer.WriteAttributeString("session-id", this.getToken());
                writer.WriteAttributeString("exception-id", exceptionid);
                writer.WriteAttributeString("expiration-date", exp);
                writer.WriteStartElement("comment");
                writer.WriteString(comment);
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
            using (XmlWriter writer = XmlWriter.Create(@"C:\Users\604398\Desktop\exceptionapprove.xml"))
            {
                writer.WriteStartElement("VulnerabilityExceptionApproveRequest");
                writer.WriteAttributeString("session-id", this.getToken());
                writer.WriteAttributeString("exception-id", exceptionid);
                writer.WriteAttributeString("expiration-date", exp);
                writer.WriteStartElement("comment");
                writer.WriteString(comment);
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
            HttpWebResponse response = req.GetResponse() as HttpWebResponse;
            XmlDocument xmlResponse = new XmlDocument();
            //Gets the response
            xmlResponse.Load(response.GetResponseStream());
            XmlElement root = xmlResponse.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("VulnerabilityExceptionApproveResponse");
            return exceptionid;
        }
    }
}
