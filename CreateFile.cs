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
    public partial class CreateFile : Form
    {
        public CreateFile()
        {
            InitializeComponent();
        }

        private void Create_Load(object sender, EventArgs e)
        {
            DriveInfo[] drInfo = DriveInfo.GetDrives();
            foreach (DriveInfo dr in drInfo)
                comboBox1.Items.Add(dr.Name);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(comboBox1.Text);
            DirectoryInfo[] dir = dirInfo.GetDirectories();
            foreach (DirectoryInfo d in dir)
                comboBox2.Items.Add(d.Name);
            textBox3.Text = comboBox1.Text;
            label2.Text = "Directories at "+comboBox1.Text;
            label3.Text = "Directories";
            label4.Text = "Directories";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(comboBox1.Text+comboBox2.Text);
            DirectoryInfo[] dir = dirInfo.GetDirectories();
            foreach (DirectoryInfo d in dir)
                comboBox3.Items.Add(d.Name);
            textBox3.Text = comboBox1.Text + comboBox2.Text;
            label3.Text = "Directories at " + comboBox1.Text + comboBox2.Text;
            label4.Text = "Directories";
        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(comboBox1.Text + comboBox2.Text+"\\"+comboBox3.Text);
            DirectoryInfo[] dir = dirInfo.GetDirectories();
            foreach (DirectoryInfo d in dir)
                comboBox4.Items.Add(d.Name);
            textBox3.Text = comboBox1.Text + comboBox2.Text+"\\"+comboBox3.Text;
            label4.Text = "Directories at " + comboBox1.Text + comboBox2.Text + "\\" + comboBox3.Text;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = comboBox1.Text + comboBox2.Text + "\\" + comboBox3.Text+"\\"+comboBox4.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox2.Text != "")
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox2.Text != "")
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked)
                button1.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked)
                button1.Enabled = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked)
                button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = textBox3.Text + "\\" + textBox2.Text + ".txt";
            if (File.Exists(path))
                MessageBox.Show("File already exists, try a different name!");

            else if (radioButton1.Checked)
            {
                File.WriteAllText(path, textBox1.Text);
                MessageBox.Show("File created!");
                this.Close();
                (new CreateFile()).Show();
            }
            else if (radioButton2.Checked)
            {
                byte[] bb = new byte[1000];
                char[] cc = new char[1000];
                cc = textBox1.Text.ToCharArray();
                FileStream fs = new FileStream(path, FileMode.Truncate);
                Encoder ee = Encoding.UTF8.GetEncoder();
                ee.GetBytes(cc, 0, cc.Length, bb, 0, true);
                fs.Write(bb, 0, bb.Length);
                fs.Close();
                MessageBox.Show("File created!");
                this.Close();
                (new CreateFile()).Show();
            }
            else if (radioButton3.Checked)
            {
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine(textBox1.Text);
                sw.Close();
                MessageBox.Show("File created!");
                this.Close();
                (new CreateFile()).Show();
            }
        }
    }
}
