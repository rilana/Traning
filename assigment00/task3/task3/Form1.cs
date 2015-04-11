using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            triangl = new Triangle(Convert.ToInt32(_a.Text), Convert.ToInt32(_b.Text), Convert.ToInt32(_c.Text));
        }
        Triangle triangl;
        private void button1_Click(object sender, EventArgs e)
        {
            int aa,bb,cc;
            if ((Int32.TryParse(_a.Text, out aa)) && (Int32.TryParse(_b.Text, out bb)) && (Int32.TryParse(_c.Text, out cc)))
            {
                if (triangl.change_side(aa, bb, cc))
                {
                    switch (triangl.Typetringle)
                    {
                        case TypeTr.AcuteAngled:
                            MessageBox.Show("Треугольник - остроугольный");
                            break;
                        case TypeTr.Obtuse:
                            MessageBox.Show("Треугольник - тупоугольный");
                            break;
                        case TypeTr.Orthogonal:
                            MessageBox.Show("Треугольник - прямоугольный");
                            break;
                    }
                   
                }
                else
                {
                    MessageBox.Show("треугольник с такими длинами сторон не может быть создан!");
                    _a.Text = triangl.A.ToString();
                    _b.Text = triangl.B.ToString();
                    _c.Text = triangl.C.ToString();

                }
            }
            else
            {
                MessageBox.Show("Неверно введены числовые данные");
                _a.Text = "1";
                _b.Text ="1";
                _c.Text ="1";
            }
        }

        private void _a_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar == 13)
                {
                    System.Windows.Forms.SendKeys.Send("{TAB}");
                }
                if ((e.KeyChar != (char)Keys.Back))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
