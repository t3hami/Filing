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
    public partial class CopyMoveFile : Form
    {
        string file;
        public CopyMoveFile()
        {
            InitializeComponent();
        }

        private void CopyMove_Load(object sender, EventArgs e)
        {
            DriveInfo[] drInfo = DriveInfo.GetDrives();
            foreach (DriveInfo dr in drInfo)
            {
                comboBox1.Items.Add(dr.Name);
                comboBox9.Items.Add(dr.Name);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            DirectoryInfo dirInfo = new DirectoryInfo(comboBox1.Text);
            DirectoryInfo[] dir = dirInfo.GetDirectories();
            foreach (DirectoryInfo d in dir)
                comboBox2.Items.Add(d.Name);

            FileInfo[] fInfo = dirInfo.GetFiles();
            foreach (FileInfo f in fInfo)
                comboBox3.Items.Add(f.Name);
            label2.Text = "Directories  at " + comboBox1.Text;
            label3.Text = "Files at " + comboBox1.Text;
            label4.Text = "Directories";
            label5.Text = "Files";
            label6.Text = "Directories";
            label7.Text = "Files";
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();
            comboBox7.Items.Clear();
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            DirectoryInfo dirInfo = new DirectoryInfo(comboBox1.Text+comboBox2.Text);
            DirectoryInfo[] dir = dirInfo.GetDirectories();
            foreach (DirectoryInfo d in dir)
                comboBox4.Items.Add(d.Name);

            FileInfo[] fInfo = dirInfo.GetFiles();
            foreach (FileInfo f in fInfo)
                comboBox5.Items.Add(f.Name);
            label4.Text = "Directories at " + comboBox1.Text + comboBox2.Text;
            label5.Text = "Directories at " + comboBox1.Text + comboBox2.Text;
            label6.Text = "Directories";
            label7.Text = "Files";
            comboBox6.Items.Clear();
            comboBox7.Items.Clear();
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            comboBox7.Items.Clear();
            DirectoryInfo dirInfo = new DirectoryInfo(comboBox1.Text+comboBox2.Text+"\\"+comboBox4.Text);
            DirectoryInfo[] dir = dirInfo.GetDirectories();
            foreach (DirectoryInfo d in dir)
                comboBox6.Items.Add(d.Name);

            FileInfo[] fInfo = dirInfo.GetFiles();
            foreach (FileInfo f in fInfo)
                comboBox7.Items.Add(f.Name);
            label6.Text = "Directories at " + comboBox1.Text + comboBox2.Text + "\\" + comboBox4.Text;
            label7.Text = "Directories at " + comboBox1.Text + comboBox2.Text + "\\" + comboBox4.Text;
            comboBox6.Text = "";
            comboBox7.Text = "";
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.Text + comboBox3.Text;

            file = comboBox3.Text;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.Text + comboBox2.Text + "\\" + comboBox3.Text;
            file = comboBox5.Text;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.Text + comboBox2.Text + "\\" + comboBox4.Text+"\\"+comboBox7.Text;
            file = comboBox7.Text;
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox11.Items.Clear();
            DirectoryInfo dirInfo = new DirectoryInfo(comboBox9.Text);
            DirectoryInfo[] dir = dirInfo.GetDirectories();
            foreach (DirectoryInfo d in dir)
                comboBox11.Items.Add(d.Name);
            label11.Text = "Directories at "+comboBox9.Text;
            label12.Text = "Directories";
            label14.Text = "Directories";
            comboBox14.Items.Clear();
            comboBox10.Items.Clear();
            textBox2.Text = comboBox9.Text;
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox14.Items.Clear();
            DirectoryInfo dirInfo = new DirectoryInfo(comboBox9.Text+comboBox11.Text);
            DirectoryInfo[] dir = dirInfo.GetDirectories();
            foreach (DirectoryInfo d in dir)
                comboBox14.Items.Add(d.Name);
            label12.Text = "Directories";
            label14.Text = "Directories at " + comboBox9.Text + comboBox11.Text;
            comboBox10.Items.Clear();
            textBox2.Text = comboBox9.Text + comboBox11.Text;
        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox10.Items.Clear();
            DirectoryInfo dirInfo = new DirectoryInfo(comboBox9.Text + comboBox11.Text+"\\"+comboBox14.Text);
            DirectoryInfo[] dir = dirInfo.GetDirectories();
            foreach (DirectoryInfo d in dir)
                comboBox10.Items.Add(d.Name);
            label12.Text = "Directories at " + comboBox9.Text + comboBox11.Text + "\\" + comboBox14.Text;
            textBox2.Text = comboBox9.Text + comboBox11.Text + "\\" + comboBox14.Text;
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = comboBox9.Text + comboBox11.Text + "\\" + comboBox14.Text +"\\"+ comboBox10.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox2.Text + "\\" + file))
                MessageBox.Show("File already exist try a different destination directory!");
            else
            {
                try
                {
                    File.Copy(textBox1.Text, textBox2.Text+"\\"+file,true);
                    MessageBox.Show("File Copied Successfully!");
                    this.Close();
                    (new CopyMoveFile()).Show();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox2.Text + "\\" + file))
                MessageBox.Show("File already exist try a different destination directory!");
            else
            {
                try
                {
                    File.Move(textBox1.Text, textBox2.Text + "\\" + file);
                    MessageBox.Show("File Moved Successfully!");
                    this.Close();
                    (new CopyMoveFile()).Show();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            (new CopyMoveFile()).Show();
        }


    }
}
