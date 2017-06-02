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
    public partial class DeleteDirectory : Form
    {
        bool driveSelect;
        public DeleteDirectory()
        {
            InitializeComponent();
        }

        private void DeleteDirectory_Load(object sender, EventArgs e)
        {
            DriveInfo[] drInfo = DriveInfo.GetDrives();
            foreach (DriveInfo dr in drInfo)
                comboBox1.Items.Add(dr.Name);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            DirectoryInfo dirInfo = new DirectoryInfo(comboBox1.Text);
            DirectoryInfo[] dir = dirInfo.GetDirectories();
            foreach (DirectoryInfo d in dir)
                comboBox2.Items.Add(d.Name);
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox3.Text = "";
            comboBox4.Text = "";
            label3.Text = "Directories";
            label4.Text = "Directories";
            label2.Text = "Directories at " + comboBox1.Text;
            driveSelect = true;
            textBox1.Text = comboBox1.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            DirectoryInfo dirInfo = new DirectoryInfo(comboBox1.Text + comboBox2.Text);
            DirectoryInfo[] dir = dirInfo.GetDirectories();
            foreach (DirectoryInfo d in dir)
                comboBox3.Items.Add(d.Name);
            label3.Text = "Directories at " + comboBox1.Text + comboBox2.Text;
            label4.Text = "Directories";
            comboBox4.Text = "";
            comboBox4.Items.Clear();
            driveSelect = false;
            textBox1.Text = comboBox1.Text + comboBox2.Text;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            comboBox4.Text = "";
            DirectoryInfo dirInfo = new DirectoryInfo(comboBox1.Text + comboBox2.Text + "\\" + comboBox3.Text);
            DirectoryInfo[] dir = dirInfo.GetDirectories();
            foreach (DirectoryInfo d in dir)
                comboBox4.Items.Add(d.Name);
            label4.Text = "Directories at " + comboBox1.Text + comboBox2.Text + "\\" + comboBox3.Text;
            textBox1.Text = comboBox1.Text + comboBox2.Text + "\\" + comboBox3.Text;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.Text + comboBox2.Text + "\\" + comboBox3.Text + "\\" + comboBox4.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && !driveSelect)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteDir(textBox1.Text);
            MessageBox.Show("Diectory Deleted successfully!");
            this.Close();
            (new DeleteDirectory()).Show();
        }

       private void DeleteDir(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDir(dir);
            }

            Directory.Delete(target_dir, false);
        }
    }
}
