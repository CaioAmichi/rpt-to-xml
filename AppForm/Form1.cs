using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using CrystalDecisions.CrystalReports.Engine;
using RptToXml;



namespace AppForm
{
    public partial class Form1 : Form
    {
        private ReportDocument _report;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath, "*.rpt", SearchOption.AllDirectories);

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = files.Length;

                    foreach (var item in files)
                    {

                        var writer = new RptDefinitionWriter(item);

                        var XML = Path.ChangeExtension(item, "xml");
                        writer.WriteToXml(XML);

                        progressBar1.Value++;

                        
                    }

                    MessageBox.Show("Fim do Processo");
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath, "*.xml", SearchOption.AllDirectories);

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = files.Length;

                    foreach (var item in files)
                    {

                        XmlDocument xml = new XmlDocument();
                        xml.Load(item);

                        foreach (XmlNode node in xml.DocumentElement.ChildNodes)
                        {
                            foreach (XmlNode child in node.SelectNodes("Table"))
                            {
                                
                            }


                            string text = node.InnerText; //or loop through its children as well
                            
                        }


                    }

                    MessageBox.Show("Fim do Processo");
                }
            }
        }
    }
}
