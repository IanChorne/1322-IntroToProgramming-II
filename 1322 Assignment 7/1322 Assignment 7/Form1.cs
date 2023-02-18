using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1322_Assignment_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double payment = 0.0;
            double LoanAmount = Convert.ToDouble(maskedTextBox1.Text);
            int years = Convert.ToInt32(listBox1.SelectedItem);
            double interestRate = Convert.ToDouble(comboBox1.SelectedItem);
            interestRate = interestRate / 100;
            bool defermentYes = Yes.Checked;
            bool defermentNo = No.Checked;
            bool missedPaymentsNo = checkBox1.Checked;
            bool missedPaymentsYes = checkBox2.Checked;

            if(missedPaymentsNo)
            {
                interestRate -= 0.0025;

            }
            if(missedPaymentsYes)
            {
                interestRate -= 0.0025;
            }
            if(defermentYes)
            {
                payment = 0.0;
            }
            else if(defermentNo)
            {
                payment = (interestRate * LoanAmount) / (1 - Math.Pow(1 + interestRate, -years));
            }
            label5.Text = Convert.ToString(payment);
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Yes_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
