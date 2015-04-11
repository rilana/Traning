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
            func.A = Convert.ToInt32(a_value.Text);
            func.B = Convert.ToInt32(b_value.Text);
            AnswerY.Text = "Ответ: y=" + func.YotX(Convert.ToInt32(x_value.Text));
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
