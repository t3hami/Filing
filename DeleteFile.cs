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
    public partial class DeleteFile : Form
    {
        public DeleteFile()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            DriveInfo[] drInfo = DriveInfo.GetDrives();
            foreach (DriveInfo dr in drInfo)
                comboBox1.Items.Add(dr.Name);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox2.Text = "";
            comboBox3.Text = "";
            DirectoryInfo dirInfo = new DirectoryInfo(comboBox1.Text);
            DirectoryInfo[] dir = dirInfo.GetDirectories();
            foreach (DirectoryInfo d in dir)
                comboBox2.Items.Add(d.Name);

            FileInfo[] fInfo = dirInfo.GetFiles();
            foreach (FileInfo f in fInfo)
                comboBox3.Items.Add(f.Name);
            label2.Text = "Directories at "+comboBox1.Text;
            label3.Text = "Files at " + comboBox1.Text;
            label4.Text = "Directories";
            label5.Text = "Files";
            label6.Text = "Directories";
            label7.Text = "Files";
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();
            comboBox7.Items.Clear();
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox4.Text = "";
            comboBox5.Text = "";
            DirectoryInfo dirInfo = new DirectoryInfo(comboBox1.Text + comboBox2.Text);
            DirectoryInfo[] dir = dirInfo.GetDirectories();
            foreach (DirectoryInfo d in dir)
                comboBox4.Items.Add(d.Name);

            FileInfo[] fInfo = dirInfo.GetFiles();
            foreach (FileInfo f in fInfo)
                comboBox5.Items.Add(f.Name);
            label4.Text = "Directories at " + comboBox1.Text + comboBox2.Text;
            label5.Text = "Files at " + comboBox1.Text + comboBox2.Text;
            label6.Text = "Directories";
            label7.Text = "Directories";
            comboBox6.Items.Clear();
            comboBox7.Items.Clear();
            comboBox6.Text = "";
            comboBox7.Text = "";
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            comboBox7.Items.Clear();
            comboBox6.Text = "";
            comboBox7.Text = "";
            DirectoryInfo dirInfo = new DirectoryInfo(comboBox1.Text + comboBox2.Text + "\\" + comboBox4.Text);
            DirectoryInfo[] dir = dirInfo.GetDirectories();
            foreach (DirectoryInfo d in dir)
                comboBox6.Items.Add(d.Name);

            FileInfo[] fInfo = dirInfo.GetFiles();
            foreach (FileInfo f in fInfo)
                comboBox7.Items.Add(f.Name);
            label6.Text = "Directories at " + comboBox1.Text + comboBox2.Text + "\\" + comboBox4.Text;
            label7.Text = "Files at " + comboBox1.Text + comboBox2.Text + "\\" + comboBox4.Text;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text != "")
            {
                textBox1.Text = comboBox1.Text + comboBox3.Text;
                button1.Enabled = true;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text != "")
            {
                textBox1.Text = comboBox1.Text + comboBox2.Text + "\\" + comboBox5.Text;
                button1.Enabled = true;
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.Text != "")
            {
                textBox1.Text = comboBox1.Text + comboBox2.Text + "\\" + comboBox4.Text + "\\" + comboBox7.Text;
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.Delete(textBox1.Text);
            MessageBox.Show("File Deleted successfully!");
            this.Close();
            (new DeleteFile()).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            (new DeleteFile()).Show();
        }
    }
}
