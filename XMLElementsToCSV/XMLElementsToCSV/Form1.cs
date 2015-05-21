using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace XMLElementsToCSV
{
    public partial class Form1 : Form
    {
        public delegate void _UpdateProgressBar(int percent, String message);
        private _UpdateProgressBar updPB;


        public Form1()
        {
            InitializeComponent();
            updPB = new _UpdateProgressBar(UpdateProgressBar);
        }
        private void btnChooseRoot_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtChooseRoot.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        public void UpdateProgressBar(int percent, string message)
        {
            pbOverallProgress.Maximum = 100;
            pbOverallProgress.Minimum = 0;
            pbOverallProgress.Value = percent;
            lblProgress.Text = message;
        }
        private void btnChooseOutput_Click(object sender, EventArgs e)
        {
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.CreatePrompt = true;
            saveFileDialog1.DefaultExt = ".csv";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtChooseOutput.Text = saveFileDialog1.FileName;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            backgroundWorker1.DoWork +=backgroundWorker1_DoWork;
            backgroundWorker1.WorkerReportsProgress= true;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.RunWorkerAsync();
        }

        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            updPB.Invoke(e.ProgressPercentage, e.UserState.ToString());
        }
        void writeColumnsToOutputFile(string outputFile, ArrayList columns)
        {
            string output = "";
            foreach (String s in columns)
            {
                if (output.Length > 0)
                {
                    output += ",";
                }
                output += "\"" + s + "\"";
            }
            File.WriteAllText(outputFile, output + "\r\n");
        }
        void writeValuesToOutputFile(String outputFile, ArrayList values, ArrayList columns)
        {
            String output = "";
            String rowOutput = "";
            foreach (Dictionary<String, String> rowValues in values)
            {
                foreach (Object s in columns)
                {
                    if (rowOutput.Length > 0)
                    {
                        rowOutput += ",";
                    }
                    String columnName = s.ToString();
                    if (rowValues.Keys.Contains(columnName))
                    {
                        String value = rowValues[columnName];
                        if (value != null)
                        {
                            rowOutput += "\"" + value.Replace("\"", "\"\"") + "\"";
                        }
                        else
                        {
                            rowOutput += "\"\"";
                        }
                    }
                    else
                    {
                        rowOutput += "\"\"";
                    }
                }
                output += rowOutput + "\r\n";
                rowOutput = "";
            }
            File.AppendAllText(outputFile, output);
        }
        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            String rootFolder = txtChooseRoot.Text;
            String outputFile = txtChooseOutput.Text;
            Int32 writeOutAt = Convert.ToInt32(numWriteEvery.Value);
            DirectoryInfo di = new DirectoryInfo(rootFolder);
            FileInfo[] files = di.GetFiles("*.xml", SearchOption.AllDirectories);
            int totalFiles = files.Length;
            int currentFileIteration = 0;
            ArrayList columns = new ArrayList();
            ArrayList values = new ArrayList();

            // Sadly we need to get all column names first........ so this means two iterations through the files .... so we dont overload memory
            foreach (FileInfo fi in files)
            {
                String s = File.ReadAllText(fi.FullName);
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(s);
                String xpath = "documents/document/element";
                XmlNodeList nodes = xdoc.SelectNodes(xpath);
                Dictionary<String, String> xmlValues = new Dictionary<String, String>();
                foreach (XmlNode childNode in nodes)
                {
                    try
                    {
                        String columnName = childNode.Attributes["name"].Value;
                        if (!columns.Contains(columnName))
                        {
                            columns.Add(columnName);
                        }
                    }
                    catch (Exception exception)
                    {

                    }
                }
                currentFileIteration++;
                backgroundWorker1.ReportProgress(((currentFileIteration / totalFiles) * 100), "Analyzing column names");
            }
            writeColumnsToOutputFile(outputFile, columns);
            currentFileIteration = 0;
            backgroundWorker1.ReportProgress(0, "Loading file " + (currentFileIteration + 1).ToString() + " of " + totalFiles.ToString());

            // Now process everything
            foreach (FileInfo fi in files) 
            {
                backgroundWorker1.ReportProgress(((currentFileIteration / totalFiles) * 100), "Loading file " + (currentFileIteration + 1).ToString() + " of " + totalFiles.ToString());
                String s = File.ReadAllText(fi.FullName);
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(s);
                String xpath = "documents/document/element";
                XmlNodeList nodes = xdoc.SelectNodes(xpath);
                Dictionary<String,String> xmlValues = new Dictionary<String,String>();
                foreach (XmlNode childNode in nodes)
                {
                    try
                    {
                        String columnName = childNode.Attributes["name"].Value;
                        String value = childNode.ChildNodes.Item(0).InnerText;
                        xmlValues.Add(columnName, value);
                    }
                    catch (Exception exception)
                    {

                    }
                }
                values.Add(xmlValues);
                currentFileIteration++;
                if (currentFileIteration == totalFiles || currentFileIteration >= writeOutAt)
                {
                    writeValuesToOutputFile(outputFile, values, columns);
                    values.Clear();
                    if (currentFileIteration == totalFiles)
                    {
                        backgroundWorker1.CancelAsync();
                    }
                }
            }
        }
    }
}
