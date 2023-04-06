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

namespace Assignment27
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreateFolder_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"D:\DotNet20Dec";
                if (Directory.Exists(path))
                {
                    MessageBox.Show("Directory already exist");
                }
                else
                {
                    Directory.CreateDirectory(path);
                    MessageBox.Show("Directory is Created");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"D:\DotNet20Dec\SampleFile.txt";
                if (File.Exists(path))
                {
                    MessageBox.Show("File already exist");
                }
                else
                {
                    File.Create(path);
                    MessageBox.Show("File is created");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"D:\DotNet20Dec\Dept.dat", FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(Convert.ToInt32(txtdepId.Text));
                bw.Write(txtdeptName.Text);
                bw.Write(txtloction.Text);
                bw.Close();
                fs.Close();
                MessageBox.Show("data added to file");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnread_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"D:\DotNet20Dec\Dept.dat", FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                txtdepId.Text = br.ReadInt32().ToString();
                txtdeptName.Text = br.ReadString();
                txtloction.Text = br.ReadString();
                br.Close();
                fs.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
