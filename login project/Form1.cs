using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // تعریف متغیر ها
        #region data
        string name;
        int age;
        bool gender;
        bool khedmat;

        //برای ذخیره اسامی به لیستی از نوع اسمی یا استرینگ نیاز داریم

        List<string> names = new List<string>();
        List<string> searchResult = new List<string>();

        
        #endregion

        #region method
        //حالا برای انجام عملیاتمون به افعال یا متد ها نیاز داریم

        // چون فعل ثبت نام ما باید خروجی بده بهمون میاییم از استرینگ استفاده میکنیم
        string register(string n, int a, bool g, bool kh)
        {
            if (age >= 18)
            {
                if (gender == true)
                {
                    if (khedmat)
                    {
                        names.Add(n);
                        return "تبریک آقای " + n + "شما ثبت نام شدید";

                    }
                    else
                    {
                        return "برای ثبت نام کارت پایان خدمت نیار دارین";
                    }
                }
                else
                {
                    names.Add(n);
                    return "تبریک خانم " + n + "شما ثبت نام شدید";
                }
            }
            else
            {
                return "سن شما مناسب ثبت نام نیست";
            }
        }

        //یک فعل برای تکراری نبودن میزاریم
        bool check(string n)
        {
            foreach (var item in names)
            {
                if (item == n)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        List<string> search(string s)
        {
            searchResult.Clear();
            foreach (var item in names)
            {
                if (item.Contains(s))
                {
                    searchResult.Add(item);
                }
            }
            return searchResult;
        }

        string delete(string n)
        {
            if (check(n))
            {
                name.Remove(n);
                return "کاربر از سیستم حذف شد";
            }
            else
            {
                return "چنین کاربری در سیستم نداریم";
            }
        }

        #endregion


        private void button1_Click(object sender, EventArgs e)
        {
            #region set data
            name = textBox2.Text;
            age = Convert.ToInt32(numericUpDown1.Value);
            if (comboBox1.Text == "مرد")
            {
                gender = true;
            }
            else
            {
                gender = false;
            }
            if (radioButton1.Checked)
            {
                khedmat = true;
            }
            else if (radioButton2.Checked)
            {
                khedmat = false;
            }
            #endregion

            if (check(name))
            {
                MessageBox.Show("نام شما قبلا در سیستم ثبت شده است");
            }
            else
            {
               MessageBox.Show(register(name, age, gender, khedmat));
                listBox1.DataSource = null;
                listBox1.DataSource = names;
                textBox2.Text = "";
                numericUpDown1.Value = 0;
                comboBox1.SelectedItem = null;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "مرد")
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
            }
            else
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //listBox1.DataSource = null;
            //listBox1.DataSource = search(textBox1.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            listBox1.DataSource = search(textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(delete(textBox1.Text));
            listBox1.DataSource = null;
            listBox1.DataSource = names;
        }
    }
} 