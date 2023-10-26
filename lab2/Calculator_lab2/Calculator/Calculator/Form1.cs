using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
	public partial class Form1 : Form
	{
		int currentNum = 1;
		double result, num1, num2,tmp;
		String op="";
		public Form1()
		{
			InitializeComponent();
		}

		public void button_show()
		{
			addition.Enabled = true;
			subtraction.Enabled = true;
			multiplication.Enabled = true;
			division.Enabled = true;
            decimalPoint.Enabled = true;
		}

        private void addition_Click(object sender, EventArgs e)
        {
            if (currentNum == 1)
            {
                num1 = Convert.ToDouble(textBox1.Text);
                addition.Enabled = false;
                op = "+";
                textBox1.Text = "";
                currentNum++;
                decimalPoint.Enabled = true;
            }
        }

        private void Number0_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void Number1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void Number2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void Number3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void Number4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void Number5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void Number6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void Number7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void Number8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void Number9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }
     

		private void button14_Click(object sender, EventArgs e)
		{
			textBox1.Text += "0";
		}

        private void subtraction_Click(object sender, EventArgs e)
        {
            if (currentNum == 1)
            {
                num1 = Convert.ToDouble(textBox1.Text);
                subtraction.Enabled = false;
                op = "-";
                textBox1.Text = "";
                currentNum++;
                decimalPoint.Enabled = true;
            }
        }

        private void multiplication_Click(object sender, EventArgs e)
        {
            if (currentNum == 1)
            {
                num1 = Convert.ToDouble(textBox1.Text);
                multiplication.Enabled = false;
                op = "*";
                textBox1.Text = "";
                currentNum++;
                decimalPoint.Enabled = true;
            }
        }

        private void division_Click(object sender, EventArgs e)
        {
            if (currentNum == 1)
            {
                num1 = Convert.ToDouble(textBox1.Text);
                division.Enabled = false;
                op = "/";
                textBox1.Text = "";
                currentNum++;
                decimalPoint.Enabled = true;
            }
        }

        private void decimalPoint_Click(object sender, EventArgs e)
        {
             textBox1.Text += ".";
            decimalPoint.Enabled = false;
            
        }

        private void equals_Click(object sender, EventArgs e)
        {
            if(op!="")
            {
                if (tmp == 0)
                {
                    num2 = Convert.ToDouble(textBox1.Text);
                    tmp = 1;
                }
                else
                {
                    num1 = Convert.ToDouble(textBox1.Text);

                }
                switch (op)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        result = num1 / num2;
                        break;
                }
                textBox1.Text = Convert.ToString(result);
                currentNum++;
                button_show();
            }
            
            
            
            
            return;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            button_show();
            num1 = 0;
            num2 = 0;
            tmp = 0;
            op = "";
            textBox1.Text = "";
            currentNum = 1;
        }
	}
}
