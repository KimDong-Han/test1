using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;

using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;
namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        DataTable table = new DataTable();
        public int send = 0;
        public int kb = 0;
        //private static DataGridView dbv = new DataGridView(dataGridView1);
        public Form1()
        {
            InitializeComponent();
            //setupgrid();
           
        }
        private static Random random = new Random();
        
        private static Stopwatch stp = new Stopwatch();
        private void setupgrid()
        {
            this.Controls.Add(dataGridView1);
            table.Columns.Add("User", typeof(string));
   

            dataGridView1.DataSource = table;
        }
        private void adddata(string u_name,string result, string time)
        {
            string i_name = u_name;
            string i_num = result;
            string i_time = time;
            //listBox1.Items.Add(textBox3.Text.ToString());
            //dataGridView1.Rows.Add(textBox3.Text.ToString(),1,"dd");
            dataGridView1.Rows.Add(i_name, result, i_time);
        }
        public static string Rand_String(int length) //make Random string
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        static string com_sha_256(string rawdata) //SHA256 
        {
            DataTable table = new DataTable();
            using (SHA256 sha256Hash = SHA256.Create())
             {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawdata));
                StringBuilder builder = new StringBuilder();
                for(int i =0; i<bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
              
                
                return builder.ToString();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        
        public int matchfun() //check hash = target value

        {
            //실제 알고리즘대로 구현시키기 어려움 => 경우의 수가 너무많음
            String m_string = @"^00";

            String m_string2 = @"^01";
            String m_string3 = @"^02";
            String m_string4 = @"^fg";
            String m_string5 = @"^af";
            //이렇게 넣어도 매칭 시키기 힘듬
            if (Regex.IsMatch(textBox3.Text, m_string))
            {
                stp.Stop();
                textBox5.Text = "MATCH";
                timer1.Enabled = false;
                TimeSpan tt = stp.Elapsed;
                string foo = "Mining Time" + tt.ToString(@"m\:ss\.ffff");
                listBox1.Items.Add(tt.ToString() + ":" + textBox3.Text.ToString());
                MessageBox.Show("Congratulations\n"+foo);
               
                return 3;
            }
            else
            {
                textBox5.Text = "NO";
                return 4;
            }
        }


        private void button1_Click(object sender, EventArgs e) //button Action
        {


            var tim = new Stopwatch();

            string user = textBox1.ToString();
            string non = textBox2.ToString();

            string sum = user + non;
            tim.Start();
            textBox3.Clear();
            textBox3.Text = com_sha_256(sum);
            
            tim.Stop();

            TimeSpan tt = tim.Elapsed;
            string foo = "Time Taken" + tt.ToString(@"m\:ss\.ffffff");
            this.textBox4.Text = foo;
           

            matchfun();
           
            textBox2.Text = Rand_String(textBox2.Text.Length);
           //adddata("asdasas",123,"dasdsadasd");
          //  listBox1.Items.Add(textBox3.Text.ToString());
        }
      
        private void button2_Click(object sender, EventArgs e)//Auto
        {
            stp.Start();
            timer1.Enabled = true;
                     
        }
        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e) //STOP
        {
            timer1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string user1 = "user1";
            string user2 = "user2";
            for (int i = 0; i < 10; i++)
            {
                
                Delay(1000);
                string A = DateTime.Now.ToString("mm시dd분ss초");
              switch(i%2)
                {
                    case 1:
                        button1_Click(sender, e);
                        adddata("User1","Match", A);
                        send++;
                        label8.Text = send.ToString();
                        break;
                    case 0:
                        button1_Click(sender, e);
                        adddata("User2", "Match", A);
                        kb++;
                        label9.Text = kb.ToString();
                        break;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            
            Form2 dlg = new Form2(this);
            //dlg.ch(1);
           dlg.Show();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 dlg = new Form3(this);
            //dlg.ch(2);
            dlg.Show();
            
        }
    }
}
