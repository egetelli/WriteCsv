using Microsoft.VisualBasic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace WriteCsv
{
    public partial class Form1 : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
                int nLeft,
                int nTop,
                int nRight,
                int nBottom,
                int nWidthEllipse,
                int nHeight
            );


        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    c.Text = textBox23.Text;
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

            string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd hh/mm");
            string tarih = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string saat = dateTimePicker1.Value.ToString("hh/mm");
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            StreamWriter writer = new StreamWriter(path + "\\" + theDate + ".csv");
            // Create an instance of the StreamWriter class
            //farklý bi loop denemesi
            //TextBox[] textBoxes = new TextBox[24];
            //for (int i = 0; i < textBoxes.Length; i++)
            //{
            //    textBox1= textBoxes[0]; textBox4= textBoxes[3]; textBox7= textBoxes[6]; textBox10= textBoxes[9];  textBox13= textBoxes[12]; 
            //    textBox2= textBoxes[1]; textBox5= textBoxes[4]; textBox8= textBoxes[7]; textBox11= textBoxes[10]; textBox14= textBoxes[13];  
            //    textBox3= textBoxes[2]; textBox6= textBoxes[5]; textBox9= textBoxes[8]; textBox12= textBoxes[11]; textBox15= textBoxes[14]; 
            //    textBox16= textBoxes[15]; textBox17= textBoxes[16]; textBox18= textBoxes[17]; textBox19= textBoxes[18]; textBox20= textBoxes[19]; textBox21= textBoxes[20];
            //    textBox22= textBoxes[21]; textBox24= textBoxes[22]; textBox25= textBoxes[23];

            //    if (textBoxes[i] == null)
            //    {
            //        textBoxes[i].Text = "160";
            //        MessageBox.Show("Lütfen Boþ Alanlara Bir Deðer Giriniz!");
            //        break;
            //    }
            //    else if (textBoxes[i].Text != null)
            //    {
            //        StringBuilder sb = new StringBuilder();
            //        sb.AppendLine("Deðerler, Tarih, Saat");
            //        // Get the text from the TextBox
            //        string text = textBoxes[i].Text;
            //        // Create an array from the text by splitting it
            //        // on line breaks
            //        string[] lines = text.Split(new string[] { "\r\n", "\n" },
            //        StringSplitOptions.None);
            //        // Write each line to the file
            //        foreach (string line in lines)
            //        {
            //            writer.WriteLine(String.Format("{0},{1},{2}", tarih, saat, Convert.ToDouble(line) * 10));
            //        }
            //    }
            //}
            //writer.Close();



            try
            {
                // Loop through all the text boxes in the form

                foreach (Control control in this.Controls)
                {
                    if (control is TextBox)
                    {
                        if (control.Text == "" || control.Text == null)
                        {
                            MessageBox.Show("Lütfen Boþ Alanlara Bir Deðer Giriniz!");
                            break;

                        }
                        else if (!string.IsNullOrEmpty(control.Text))
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine("Deðerler, Tarih, Saat");
                            // Get the text from the TextBox
                            string text = ((TextBox)control).Text;
                            // Create an array from the text by splitting it
                            // on line breaks
                            string[] lines = text.Split(new string[] { "\r\n", "\n" },
                            StringSplitOptions.None);
                            // Write each line to the file
                            foreach (string line in lines)
                            {
                                writer.WriteLine(String.Format("{0},{1},{2}", tarih, saat, Convert.ToDouble(line) * 10));


                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lütfen Sayý Giriniz");
            }

            // Close the file
            writer.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled= false;
            MessageBox.Show("Lütfen kaydet tuþuna basmadan önce bütün boþluklarý doldurunuz!");
            button1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 30, 30));
            button2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button2.Width, button2.Height, 30, 30));
            button3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button3.Width, button3.Height, 30, 30));
            //dateTimePicker1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 2, dateTimePicker1.Width, dateTimePicker1.Height, 30, 30));           
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Region = Region.FromHrgn(CreateRoundRectRgn(2, 3, c.Width, 23, 15, 15));


                }
            }


        }

        private void onlynumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                   (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void buttondisable(object sender, EventArgs e)
        {

            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    if(textBox1.Text == "")
                    {
                        button1.Enabled = false;
                    }

                    else if (c.Text == "")
                    {
                        button1.Enabled = false;
                    }
                    else if(c.Text != "")
                    {
                        button1.Enabled = true;
                    }
                }
            }
        }
    }
}
