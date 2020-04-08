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

namespace lab6
{
    public partial class Form1 : Form
    {
        BindingList<Number> lista = new BindingList<Number>();

        int couter = 0;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = lista;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            var path = openFileDialog1.FileName;
            var content = File.ReadAllText(path);
            var numbers = content.Split(new[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach(var elem in numbers)
            {
                flowLayoutPanel1.Controls
                    .Add(GenerateTextBox(elem.ToString()));
            }
            textBox1.Visible = true;
            button2.Visible = true;
            
        }
        private TextBox GenerateTextBox(string text)
        {
            return new TextBox()
            {
                Text = text,
                Width = 25,
                ReadOnly = true
            };
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            var rand = new Random();
            var number = rand.Next(100).ToString();
            textBox1.Text = number.ToString();
            couter++;
            if(couter%10==0)
            {
                lista.Add(
                    new Number()
                        { Value = int.Parse(number) });
            }
            if(couter == 100)
            {
                timer1.Stop();
            }
        }  

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            timer1.Start();
        }
    } 
}
