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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {

            int index = listBoxNum.SelectedIndex;

            if (index != -1 && int.TryParse(txtAge2.Text, out int age) && int.TryParse(txtNum.Text, out int id))
            {
                listBox4Gender.Items[index] = radioMale.Checked ? "ذكر" : "أنثى";
                listBox3Age.Items[index] = age;
                listBox2Name.Items[index] = txtName2.Text;
                listBoxNum.Items[index] = id;


                txtNum.Clear();
                txtAge2.Clear();
                txtName2.Clear();
                radiofemale.Checked = false;
                radioMale.Checked = false;

                txtNum.Focus();
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            listBoxNum.Items.Clear();
            listBox2Name.Items.Clear();
            listBox3Age.Items.Clear();
            listBox4Gender.Items.Clear();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int index = listBoxNum.SelectedIndex;

            if (index != -1)
            {
                listBoxNum.Items.RemoveAt(index);
                listBox2Name.Items.RemoveAt(index);
                listBox3Age.Items.RemoveAt(index);
                listBox4Gender.Items.RemoveAt(index);
            }
        }

        private void btncloseForm2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            if(txtNum.Text.Trim() != null && txtAge2.Text.Trim() !=null && txtName2.Text.Trim() !=null && (radiofemale.Checked || radioMale.Checked))
            {
                listBoxNum.Items.Add(txtNum.Text.Trim());
                listBox2Name.Items.Add(txtName2.Text.Trim());
                listBox3Age.Items.Add(txtAge2.Text.Trim());
                
                if(radiofemale.Checked)
                listBox4Gender.Items.Add(radiofemale.Text);
                else
                    listBox4Gender.Items.Add(radioMale.Text);

                txtNum.Clear();
                txtAge2.Clear();
                txtName2.Clear();
                radiofemale.Checked = false;
                radioMale.Checked = false;

                txtNum.Focus();
            }
        }

       
    }
}




