using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       // для класса---------------------------------------------------------
        ArrayList arrayL_class = new ArrayList();
        private void bFill_arrayList_Click(object sender, EventArgs e) // заполняем коллекцию arrayL_class
        {
            arrayL_class.Clear();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < 100000; i++)
            {
                Random rr = new Random();
                Item itemcl = new Item() { Name = "item"+(i+1).ToString(), Count = rr.Next(100), Cost = rr.Next(10000,100000) };
                arrayL_class.Add(itemcl);
               
            }
            stopWatch.Stop();
            MessageBox.Show("Заполнено! Время заполнения - " +stopWatch.Elapsed.Milliseconds+" миллисекунд");
            
        }
        // вычиляем сумму
        private void bsum_class_Click(object sender, EventArgs e)
        {
            if (arrayL_class.Count == 0)
            {
                MessageBox.Show("Нет товаров");
            }
            else
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                int sum = 0;
                foreach (Item item in arrayL_class)
                {
                    sum += item.TotalCost;
                }
                stopWatch.Stop();

                MessageBox.Show("Общая стоимость всех товаров - " + sum + " руб. \n Время подсчета общей суммы - " + stopWatch.Elapsed.Milliseconds + " миллисекунд");
            }
        }
       
       
        // просмотр элементов коллекции,указав номер элемента
        private void tBNelement_Leave(object sender, EventArgs e)
        {
            if (arrayL_class.Count == 0)
            {
                MessageBox.Show("Нет товаров");
                tBNelement.Text = "0";
            }
            else
            {
                int nelement;
                if (Int32.TryParse(tBNelement.Text, out nelement))
                {
                    nelement--;
                    if ((nelement >= 0) && ((nelement) < arrayL_class.Count))
                    {

                        Item itt = arrayL_class[nelement] as Item;
                        tBname.Text = itt.Name;
                        tBcount.Text = itt.Count.ToString();
                        tBCost.Text = itt.Cost.ToString();
                        tBtotalCost.Text = itt.TotalCost + " руб.";
                    }
                    else
                    {
                        MessageBox.Show("Нет товара для данного номера");
                    }
                }
                else
                {

                    MessageBox.Show(" Неверно введены числовые данные");
                    tBNelement.Text = "0";
                     tBname.Text ="";
                    tBcount.Text = "";
                    tBCost.Text = "";
                    tBtotalCost.Text = "";
                }
            }
        }
        // сохраняем изменения в элементе
        private void bSaveClass_Click(object sender, EventArgs e)
        {
            int nelement=Convert.ToInt32(tBNelement.Text)-1;
            if ((nelement>=0)&&((nelement) <= arrayL_class.Count))
            {
                Item itemcl = new Item() { Name = tBname.Text, Count = Convert.ToInt32(tBcount.Text), Cost = Convert.ToInt32(tBCost.Text) };
                arrayL_class[nelement] = itemcl;
                tBtotalCost.Text = itemcl.TotalCost + " руб.";
            }
       
        }

        private void tBNelement_KeyPress(object sender, KeyPressEventArgs e)
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
         private void tBcount_Leave(object sender, EventArgs e)
        {
            int work;
            if (!Int32.TryParse((sender as TextBox).Text, out work))
            {
                 MessageBox.Show(" Неверно введены числовые данные");
                    tBNelement.Text = "0";
                     tBname.Text ="";
                    tBcount.Text = "";
                    tBCost.Text = "";
                    tBtotalCost.Text = "";
            }
        }
     //-------------------------------------------------------------------------------------
     //для структуры -----------------------------------------------------------------
        ArrayList arrayL_struct = new ArrayList();
        private void bfillArrayL_struct_Click(object sender, EventArgs e)
        {
            arrayL_struct.Clear();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < 100000; i++)
            {
                Random rr = new Random();
                Item_Struct itemcl = new Item_Struct("item" + (i + 1).ToString(),rr.Next(100),rr.Next(10000, 100000));
                arrayL_struct.Add(itemcl);

            }
            stopWatch.Stop();
            MessageBox.Show("Заполнено! Время заполнения - " + stopWatch.Elapsed.Milliseconds + " милисекунд");
        }

        private void bSum_struct_Click(object sender, EventArgs e)
        {
            if (arrayL_struct.Count == 0)
            {
                MessageBox.Show("Нет товаров");
            }
            else
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                int sum =0;
                foreach (Item_Struct item in arrayL_struct)
                {
                    sum += item.TotalCost;
                }
                stopWatch.Stop();

                MessageBox.Show("Общая стоимость всех товаров - " + sum + " руб. \n Время подсчета общей суммы - " + stopWatch.Elapsed.Milliseconds + " миллисекунд");
            }
        }

        private void tBNelementS_Leave(object sender, EventArgs e)
        {
            if (arrayL_struct.Count == 0)
            {
                MessageBox.Show("Нет товаров");
                tBNelementS.Text = "0";
            }
            else
            {
                int nelement;
                if (Int32.TryParse(tBNelementS.Text, out nelement))
                {

                    nelement--;
                    if ((nelement >= 0) && ((nelement) < arrayL_struct.Count))
                    {
                        Item_Struct itt = (Item_Struct)(arrayL_struct[nelement]);
                        tBnameS.Text = itt.Name;
                        tBcountS.Text = itt.Count.ToString();
                        tBCostS.Text = itt.Cost.ToString();
                        tBtotalCostS.Text = itt.TotalCost + " руб.";
                     }
                    else
                    {
                        MessageBox.Show("Нет товара для данного номера");
                    }
                }
                else
                {

                    MessageBox.Show(" Неверно введены числовые данные");
                    tBNelementS.Text = "0";
                     tBnameS.Text ="";
                    tBcountS.Text = "";
                    tBCostS.Text = "";
                    tBtotalCostS.Text = "";
                
                }
            }
        }

        private void bSaveStruct_Click(object sender, EventArgs e)
        {
            int nelement = Convert.ToInt32(tBNelementS.Text) - 1;
            if ((nelement >= 0) && ((nelement) <= arrayL_struct.Count))
            {
                Item_Struct itemcl = new Item_Struct(tBnameS.Text,Convert.ToInt32(tBcountS.Text),Convert.ToInt32(tBCostS.Text));
                arrayL_struct[nelement] = itemcl;
                tBtotalCostS.Text = itemcl.TotalCost + " руб.";
            }
        }

        private void tBcountS_Leave(object sender, EventArgs e)
        {
            int work;
            if (!Int32.TryParse((sender as TextBox).Text, out work))
            {
                MessageBox.Show(" Неверно введены числовые данные");
                tBNelementS.Text = "0";
                tBnameS.Text = "";
                tBcountS.Text = "";
                tBCostS.Text = "";
                tBtotalCostS.Text = "";
            }
        }

       
    }
    struct Item_Struct
    {
        public string Name;
        private int count;
        private int cost;
        private int totalCost;
        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                GettotalCost();
            }
        }
        public int Cost
        {
            get { return cost; }
            set
            {
                cost = value;
                GettotalCost();
            }
        }
        public int TotalCost
        {
            get
            {
                return totalCost;
            }
        }
        public void GettotalCost()
        {
            totalCost = count * cost;
        }
        public Item_Struct(string Name, int ccount, int ccost)
        {
            this.Name = Name;
            count = ccount;
            cost = ccost;
            totalCost = count * cost; ;
        }
       
    }
}
