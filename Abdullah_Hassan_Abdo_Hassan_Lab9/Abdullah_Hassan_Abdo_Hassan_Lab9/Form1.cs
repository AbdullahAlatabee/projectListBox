using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abdullah_Hassan_Abdo_Hassan_Lab9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void btnOpenForm_Click(object sender, EventArgs e)
        {
            if (this.Height == 251)
            {
                btnOpenForm.Text = "^";
                this.Height = 674;
            }
            else
            {
                btnOpenForm.Text = "v";
                this.Height = 251;
            }
        }

        // Button to add items to listBox
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isNumoric(textBoxNum.Text.Trim()))
            {
                if(!repeated(listBoxRight , textBoxNum.Text))
                {
                    listBoxRight.Items.Add(textBoxNum.Text);
                    textBoxNum.Clear();
                    textBoxNum.Focus();
                }
                else
                {
                    MessageBox.Show(" الرقم موجود مسبقا");
                    textBoxNum.Clear();
                    textBoxNum.Focus();
                }
            }
            else
            {
                MessageBox.Show(" يجب ان يكون المدخل رقم");
                textBoxNum.Clear();
                textBoxNum.Focus();
            }
        }

        private bool isNumoric(string v)
        {
            if (v == " ") return false;
            for (int i = 0; i< v.Length; i++)
            {
                if(v[i] < 48 || v[i] > 57)
                    return false;
            }
            return true;
        }
        private bool repeated(ListBox l , string s)
        {
            for (int i = 0;i< l.Items.Count; i++)
            {
                if(l.Items[i].ToString() == s)
                    return true;
            }
            return false;
        }

        private void listBoxRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnMoveSelect.Visible = true;
        }

        // move all the element from listbox1 to listbox2
        private void btnMoveSelect_Click(object sender, EventArgs e)
        {
            int x = listBoxRight.SelectedItems.Count;

            for(int i = 0;i< x; i++)
            {
                if(!repeated(listBoxLeft , listBoxRight.SelectedItems[0].ToString()))
                {
                    listBoxLeft.Items.Add(listBoxRight.Items[listBoxRight.SelectedIndex].ToString());
                    listBoxRight.Items.RemoveAt(listBoxRight.SelectedIndex);
                }
            }
        }

        // Move All element from first list to second list
        private void btnMove_Click(object sender, EventArgs e)
        {

           while(listBoxRight.Items.Count > 0)
            {
                listBoxLeft.Items.Add(listBoxRight.Items[0]);
                listBoxRight.Items.Remove(listBoxRight.Items[0]);
            }
        }

        // Sort first listBox 
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SortAnyListBox(listBoxRight);
        }

        private void SortAnyListBox(ListBox l)
        {
            int t;
            int x=l.Items.Count;
            for (int i = 0; i < x; i++)
            {
                for (int j = i+1; j<x; j++)
                {
                    int n1=Convert.ToInt32(l.Items[i]);
                    int n2 = Convert.ToInt32(l.Items[j]);
                    if(n1 < n2)
                    {
                        t = n1;
                        l.Items[i] = n2;
                        l.Items[j] = t;
                    }
                }
            }
        }

        // Move the revers element from the first lsit to the second list
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            int x = listBoxRight.Items.Count;
            for(int i = 0;i < x; i++)
            {
                listBoxLeft.Items.Add(listBoxRight.Items[listBoxRight.Items.Count-1]);
                listBoxRight.Items.Remove(listBoxRight.Items[listBoxRight.Items.Count-1]);
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            SortAnyListBox(listBoxLeft);
        }

        private void revers(ListBox l)
        {
            for(int i=l.Items.Count - 1; i>=0; i--)
            {
                l.Items.Add(l.Items[i]);
                l.Items.Remove(l.Items[i]);
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            revers(listBoxLeft);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            revers(listBoxRight);
        }

        private void radioButtonEven_CheckedChanged(object sender, EventArgs e)
        {
            listBoxRight.SelectedIndex = -1;
            if (radioButtonEven.Checked)
            {
                for (int i = 0; i < listBoxRight.Items.Count; i++)
                {
                    if(Convert.ToInt32(listBoxRight.Items[i]) % 2 == 0)
                        listBoxRight.SelectedIndex = i;
                }
            }
            if (listBoxRight.SelectedIndex == -1)
                MessageBox.Show("لا توجد عناصر زوجية");
        }

        private void radioButtonOdd_CheckedChanged(object sender, EventArgs e)
        {
            listBoxRight.SelectedIndex = -1;
            if (radioButtonOdd.Checked)
            {
                for (int i = 0; i < listBoxRight.Items.Count; i++)
                {
                    if (Convert.ToInt32(listBoxRight.Items[i]) % 2 != 0)
                        listBoxRight.SelectedIndex = i;
                }
            }
            if (listBoxRight.SelectedIndex == -1)
                MessageBox.Show("لا توجد عناصر فردية");
        }

        private void radioButtonPrime_CheckedChanged(object sender, EventArgs e)
        {
            listBoxRight.SelectedIndex = -1;
            bool flag = true;
            if (radioButtonPrime.Checked)
            {
                for (int i = 0; i < listBoxRight.Items.Count; i++)
                {
                    int n= Convert.ToInt32(listBoxRight.Items [i]);
                    flag = true;
                    for (int j = 2; j < n; j++)
                    {
                        if (n % j == 0)
                        {
                            flag = false;
                            break;
                        }
                        if (flag)
                            listBoxRight.SelectedIndex = i;
                    }
                    
                }
                if (listBoxRight.SelectedIndex == -1)
                    MessageBox.Show("لا توجد عناصر اولية");
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBoxRight.SelectedIndex != -1)
            {
                listBoxRight.Items.RemoveAt(listBoxRight.SelectedIndex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBoxRight.Items.Clear();
            //if(listBoxRight.Items.Count > 0)
            //{
            //    int x = listBoxRight.Items.Count;
            //    for (int i = 0; i < x; i++)
            //        listBoxRight.Items.Remove(listBoxRight.Items[0]);
            //}
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBoxRight.SelectedItems.Add(textBox1.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBoxRight.SelectedItems.Remove(textBox2.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox4.Text =listBoxRight.Items.Count.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox5.Text = listBoxRight.SelectedItems.Count.ToString();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (listBoxRight.Items.Count > 0)
            {
                for (int i = 0; i < listBoxRight.Items.Count; i++)
                {
                    listBoxRight.SelectedIndex = i;
                }
            }
            else
                MessageBox.Show("not found element");
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            listBoxRight.SelectedIndex = -1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBoxLeft.Items.Clear();
        }
    }
}
