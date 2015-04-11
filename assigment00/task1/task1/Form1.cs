using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task1
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
           
        }

        private void bYotX_Click(object sender, EventArgs e)
        {
            
                LinerFunction func;
                func = new LinerFunction();
                int a,b,x;
                if (Int32.TryParse(a_value.Text, out a)&&(Int32.TryParse(b_value.Text, out b))&&(Int32.TryParse(x_value.Text,out x)))
                {
                    func.A = a;
                    func.B = b;
                    AnswerY.Text = "Ответ: y=" + func.YotX(x);
                }
                else
                {
                    MessageBox.Show("Не верно введены данные");
                }
           
           
        }

        private void a_value_KeyPress(object sender, KeyPressEventArgs e)
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
