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
    public partial class CopyDirectory : Form
    {
        string dirName;
        bool driveSelect1;
        bool driveSelect2;
        public CopyDirectory()
        {
            InitializeComponent();
        }

        private void CopyMoveDirectory_Load(object sender, EventArgs e)
        {
            DriveInfo[] drInfo = DriveInfo.GetDrives();
            foreach (DriveInfo dr in drInfo)
            {
                comboBox1.Items.Add(dr.Name);
                comboBox5.Items.Add(dr.Name);
            }
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
            driveSelect1 = true;
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
            driveSelect1 = false;
            textBox1.Text = comboBox1.Text + comboBox2.Text;
            dirName = comboBox2.Text;
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
            dirName = comboBox3.Text;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.Text + comboBox2.Text + "\\" + comboBox3.Text + "\\" + comboBox4.Text;
            dirName = comboBox4.Text;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox7.Items.Clear();
            comboBox7.Text = "";
            DirectoryInfo dirInfo = new DirectoryInfo(comboBox5.Text);
            DirectoryInfo[] dir = dirInfo.GetDirectories();
            foreach (DirectoryInfo d in dir)
                comboBox7.Items.Add(d.Name);
            comboBox8.Items.Clear();
            comboBox6.Items.Clear();
            comboBox8.Text = "";
            comboBox6.Text = "";
            label8.Text = "Directories";
            label9.Text = "Directories";
            label7.Text = "Directories at " + comboBox1.Text;
            driveSelect2 = false;
            textBox2.Text = comboBox5.Text;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox8.Items.Clear();
            comboBox8.Text = "";
            DirectoryInfo dirInfo = new DirectoryInfo(comboBox5.Text + comboBox7.Text);
            DirectoryInfo[] dir = dirInfo.GetDirectories();
            foreach (DirectoryInfo d in dir)
                comboBox8.Items.Add(d.Name);
            label9.Text = "Directories at " + comboBox5.Text + comboBox7.Text;
            label8.Text = "Directories";
            comboBox6.Text = "";
            comboBox6.Items.Clear();
            driveSelect2 = false;
            textBox2.Text = comboBox5.Text + comboBox7.Text;
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            comboBox6.Text = "";
            DirectoryInfo dirInfo = new DirectoryInfo(comboBox5.Text + comboBox7.Text + "\\" + comboBox8.Text);
            DirectoryInfo[] dir = dirInfo.GetDirectories();
            foreach (DirectoryInfo d in dir)
                comboBox6.Items.Add(d.Name);
            label8.Text = "Directories at " + comboBox5.Text + comboBox7.Text + "\\" + comboBox8.Text;
            textBox2.Text = comboBox5.Text + comboBox7.Text + "\\" + comboBox8.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && !driveSelect1 && !driveSelect2)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(textBox2.Text);
            if(Directory.Exists(textBox2.Text+"\\"+dirName))
                MessageBox.Show("A Directory already exist with the same name!");
            else
            {
                d.CreateSubdirectory(dirName);
                copyDirectory(textBox1.Text, textBox2.Text+"\\"+dirName);
                MessageBox.Show("Directory copied!");
                this.Close();
                (new CopyDirectory()).Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Directory.Move(textBox1.Text,textBox2.Text);
        }

        private void copyDirectory(string strSource, string strDestination)
        {
            if (!Directory.Exists(strDestination))
            {
                Directory.CreateDirectory(strDestination);
            }

            DirectoryInfo dirInfo = new DirectoryInfo(strSource);
            FileInfo[] files = dirInfo.GetFiles();
            foreach (FileInfo tempfile in files)
            {
                tempfile.CopyTo(Path.Combine(strDestination, tempfile.Name));
            }

            DirectoryInfo[] directories = dirInfo.GetDirectories();
            foreach (DirectoryInfo tempdir in directories)
            {
                copyDirectory(Path.Combine(strSource, tempdir.Name), Path.Combine(strDestination, tempdir.Name));
            }

        }
    }
}
