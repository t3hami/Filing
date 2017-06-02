using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FilesDirectories
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DriveInfo[] di = DriveInfo.GetDrives();
            foreach (DriveInfo drInfo in di)
            {
                comboBox1.Items.Add(drInfo.Name);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            textBox1.Clear();
            try
            {
                DirectoryInfo dir = new DirectoryInfo(comboBox1.Text);
                DirectoryInfo[] dirInfo = dir.GetDirectories();
                foreach (DirectoryInfo d in dirInfo)
                    comboBox2.Items.Add(d.Name);
                FileInfo[] fInfo = dir.GetFiles();
                int i = 1;
                foreach (FileInfo f in fInfo)
                {
                    textBox1.Text += i + "). " + f.Name + Environment.NewLine;
                    i++;
                }
            }
            catch (UnauthorizedAccessException ue)
            {
                MessageBox.Show(ue.Message);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox3.Text = "";
            comboBox4.Text = "";
            label3.Text += " at "+comboBox1.Text;
            label1.Text += " at " + comboBox1.Text;
            label4.Text = "Directories";
            label5.Text = "Directories";

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Enabled = true;
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            textBox1.Clear();
            try
            {
                DirectoryInfo dir = new DirectoryInfo(comboBox1.Text + comboBox2.Text);
                DirectoryInfo[] dirInfo = dir.GetDirectories();
                foreach (DirectoryInfo d in dirInfo)
                    comboBox3.Items.Add(d.Name);
                FileInfo[] fInfo = dir.GetFiles();
                int i = 1;
                foreach (FileInfo f in fInfo)
                {
                    textBox1.Text += i + "). " + f.Name + Environment.NewLine;
                    i++;
                }
                comboBox4.Items.Clear();
                comboBox4.Enabled = false;
                comboBox4.Text = "";
                label4.Text = "Directories at " + comboBox1.Text+comboBox2.Text;
                label1.Text = "Files at " + comboBox1.Text+comboBox2.Text;
                label5.Text = "Directories";
            }
            catch (UnauthorizedAccessException ue)
            {
                MessageBox.Show(ue.Message);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Enabled = true;
            comboBox4.Items.Clear();
            comboBox4.Text = "";
            textBox1.Clear();
            try
            {
                DirectoryInfo dir = new DirectoryInfo(comboBox1.Text + comboBox2.Text + "\\" + comboBox3.Text);
                DirectoryInfo[] dirInfo = dir.GetDirectories();
                foreach (DirectoryInfo d in dirInfo)
                    comboBox4.Items.Add(d.Name);
                FileInfo[] fInfo = dir.GetFiles();
                int i = 1;
                foreach (FileInfo f in fInfo)
                {
                    textBox1.Text += i + "). " + f.Name + Environment.NewLine;
                    i++;
                }
                label5.Text = "Directories at " + comboBox1.Text + comboBox2.Text+"\\"+comboBox3.Text;
                label1.Text = "Files at " + comboBox1.Text + comboBox2.Text+"\\"+comboBox3.Text;
            }
            catch (UnauthorizedAccessException ue)
            {
                MessageBox.Show(ue.Message);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            
        }
    }
}
