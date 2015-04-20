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
       private Dictionary<TypeTr, string> RussianType = new Dictionary<TypeTr, string>()
        {
           {TypeTr.AcuteAngled,"-остроугольный"},
           {TypeTr.Obtuse,"-тупоугольный"},
           {TypeTr.Orthogonal,"-прямоугольный"},
           {TypeTr.None,"не существует с такими сторонами!"},
        };
        private Triangle triangl;
        private void button1_Click(object sender, EventArgs e)
        {
            int aa,bb,cc;
            if ((Int32.TryParse(_a.Text, out aa)) && (Int32.TryParse(_b.Text, out bb)) && (Int32.TryParse(_c.Text, out cc)))
            {
                triangl.change_side(aa, bb, cc);
                MessageBox.Show("Треугольник "+RussianType[triangl.Typetringle]);
               
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
