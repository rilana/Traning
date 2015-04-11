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
            if (triangl.change_side(Convert.ToInt32(_a.Text), Convert.ToInt32(_b.Text), Convert.ToInt32(_c.Text)))
            {
                MessageBox.Show(triangl.Typetringle.ToString());
            }
            else
            {
                MessageBox.Show("треугольник с такими длинами сторон не может быть создан!");
                _a.Text = triangl.A.ToString();
                _b.Text = triangl.B.ToString();
                _c.Text = triangl.C.ToString();

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
