using System;
using System.Text;
using System.Windows.Forms;
using CrcSharp;

namespace SWGCRC32Calc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                CrcSharp.CrcParameters prams = new CrcParameters(32, 0x4C11DB7, 0xFFFFFFFF, 0xFFFFFFFF, false, false);
                CrcSharp.Crc crc = new CrcSharp.Crc(prams);
                textBox2.Text = FormatCRC32Result(crc.CalculateCheckValue(Encoding.ASCII.GetBytes(textBox1.Text)));
            }
            else
            {
                MessageBox.Show("String textbox can not be empty!");
            }
        }

        public static string FormatCRC32Result(byte[] result)
        {
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(result);
            }
            return "0x" + BitConverter.ToUInt32(result, 0).ToString("x8").ToUpper();
        }
    }
}
