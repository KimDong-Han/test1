using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form3 : Form
    {
        Form1 f1;
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(Form1 fo)
        {
            InitializeComponent();
            f1 = fo;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int dd = int.Parse(textBox1.Text);
            f1.kb = f1.kb - dd;
            f1.send = f1.send + dd;
            f1.label8.Text = f1.send.ToString();
            f1.label9.Text = f1.kb.ToString();
            f1.listBox1.Items.Add("Transaction Success!!!(KB -> Sender)");
            Close();
        }
    }
}
