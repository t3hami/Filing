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
    public partial class CreateDirectory : Form
    {
        public CreateDirectory()
        {
            InitializeComponent();
        }

        private void CreateDirectory_Load(object sender, EventArgs e)
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
            textBox1.Text = comboBox1.Text;
            check();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            DirectoryInfo dirInfo = new DirectoryInfo(comboBox1.Text+comboBox2.Text);
            DirectoryInfo[] dir = dirInfo.GetDirectories();
            foreach (DirectoryInfo d in dir)
                comboBox3.Items.Add(d.Name);
            label3.Text = "Directories at " + comboBox1.Text + comboBox2.Text;
            label4.Text = "Directories";
            comboBox4.Text = "";
            comboBox4.Items.Clear();
            textBox1.Text = comboBox1.Text + comboBox2.Text;
            check();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            comboBox4.Text = "";
            DirectoryInfo dirInfo = new DirectoryInfo(comboBox1.Text + comboBox2.Text+"\\"+comboBox3.Text);
            DirectoryInfo[] dir = dirInfo.GetDirectories();
            foreach (DirectoryInfo d in dir)
                comboBox4.Items.Add(d.Name);
            label4.Text = "Directories at " + comboBox1.Text + comboBox2.Text + "\\" + comboBox3.Text;
            textBox1.Text = comboBox1.Text + comboBox2.Text + "\\" + comboBox3.Text;
            check();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text=comboBox1.Text + comboBox2.Text+"\\"+comboBox3.Text+"\\"+comboBox4.Text;
            check();
        }

        private void check()
        {
            if (textBox1.Text != "" && textBox2.Text != "")
                button1.Enabled = true;
            else
                button1.Enabled = false;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            check();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            (new CreateDirectory()).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(textBox1.Text);
            if (Directory.Exists(textBox1.Text + "\\" + textBox2.Text))
                MessageBox.Show("Directory already exist, try a different name!");
            else
            {
                dir.CreateSubdirectory(textBox2.Text);
                MessageBox.Show("Directory created!");
                this.Close();
                (new CreateDirectory()).Show();
            }
        }
    }
}
