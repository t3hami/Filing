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
    public partial class OpenEditFile : Form
    {
        string path;

        public OpenEditFile()
        {
            InitializeComponent();
        }

        private void Open_Load(object sender, EventArgs e)
        {
            DriveInfo[] drInfo = DriveInfo.GetDrives();
            foreach (DriveInfo dr in drInfo)
                comboBox1.Items.Add(dr.Name);
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
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
            label2.Text = "Directories";
            label3.Text = "Files";
            label4.Text = "Directories";
            label5.Text = "Files";
            label6.Text = "Directories";
            label7.Text = "Files";
            DirectoryInfo dirInfo = new DirectoryInfo(comboBox1.Text);
            DirectoryInfo[] dir = dirInfo.GetDirectories();
            foreach (DirectoryInfo d in dir)
                comboBox2.Items.Add(d.Name);

            FileInfo[] fInfo = dirInfo.GetFiles("*.txt");
            foreach (FileInfo f in fInfo)
                comboBox3.Items.Add(f.Name);
            label2.Text += " at "+comboBox1.Text;
            label3.Text += " at " + comboBox1.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();
            comboBox7.Items.Clear();
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";
            label4.Text = "Directories";
            label5.Text = "Files";
            label6.Text = "Directories";
            label7.Text = "Files";
            DirectoryInfo dirInfo = new DirectoryInfo(comboBox1.Text + comboBox2.Text);
            DirectoryInfo[] dir = dirInfo.GetDirectories();
            foreach (DirectoryInfo d in dir)
                comboBox4.Items.Add(d.Name);

            FileInfo[] fInfo = dirInfo.GetFiles("*.txt");
            foreach (FileInfo f in fInfo)
                comboBox5.Items.Add(f.Name);
            label4.Text += " at " + comboBox1.Text + comboBox2.Text;
            label5.Text += " at " + comboBox1.Text + comboBox2.Text;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            comboBox7.Items.Clear();
            comboBox6.Text = "";
            comboBox7.Text = "";
            label6.Text = "Directories";
            label7.Text = "Files";
            DirectoryInfo dirInfo = new DirectoryInfo(comboBox1.Text + comboBox2.Text + "\\" + comboBox4.Text);
            DirectoryInfo[] dir = dirInfo.GetDirectories();
            foreach (DirectoryInfo d in dir)
                comboBox6.Items.Add(d.Name);

            FileInfo[] fInfo = dirInfo.GetFiles("*.txt");
            foreach (FileInfo f in fInfo)
                comboBox7.Items.Add(f.Name);
            label6.Text += " at " + comboBox1.Text + comboBox2.Text + "\\" + comboBox4.Text;
            label7.Text += " at " + comboBox1.Text + comboBox2.Text + "\\" + comboBox4.Text;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Cannot find further!");
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text != "")
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
                label8.Text = "File Name : "+comboBox3.Text;
                comboBox5.Text = "";
                comboBox7.Text = "";
                path = comboBox1.Text + comboBox3.Text;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text != "")
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
                label8.Text = "File Name : " + comboBox5.Text;
                comboBox3.Text = "";
                comboBox7.Text = "";
                path = comboBox1.Text + comboBox2.Text + "\\" + comboBox5.Text;
            }    
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.Text != "")
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
                label8.Text = "File Name : " + comboBox7.Text;
                comboBox3.Text = "";
                comboBox5.Text = "";
                path = comboBox1.Text + comboBox2.Text + "\\" + comboBox4.Text + comboBox7.Text;
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

        private void fileSelect()
        {
            if (radioButton1.Checked)
                radioButton1.Checked = false;
            else if (radioButton1.Checked)
                radioButton2.Checked = false;
            else if (radioButton1.Checked)
                radioButton3.Checked = false;
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox1.Text = File.ReadAllText(path);
            }
            else if (radioButton2.Checked)
            {
                textBox1.Text = "";
                byte[] bb = new byte[1000];
                char[] cc = new char[1000];
                FileStream fs = new FileStream(path,FileMode.Open);
                fs.Read(bb,0,1000);
                Decoder d = Encoding.UTF8.GetDecoder();
                d.GetChars(bb, 0, bb.Length, cc, 0);
                foreach (char c in cc)
                    textBox1.Text += c;
                fs.Close();
            }
            else if (radioButton3.Checked)
            {
                StreamReader sr = new StreamReader(path);
                textBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
            button2.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            (new OpenEditFile()).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                File.WriteAllText(path,textBox1.Text);
            else if (radioButton2.Checked)
            {
                byte[] bb = new byte[1000];
                char[] cc = new char[1000];
                cc = textBox1.Text.ToCharArray();
                FileStream fs = new FileStream(path,FileMode.Truncate);
                Encoder ee = Encoding.UTF8.GetEncoder();
                ee.GetBytes(cc,0,cc.Length,bb,0,true);
                fs.Write(bb,0,bb.Length);
                fs.Close();
            }
            else if (radioButton3.Checked)
            {
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine(textBox1.Text);
                sw.Close();
            }
        }
    }
    
}