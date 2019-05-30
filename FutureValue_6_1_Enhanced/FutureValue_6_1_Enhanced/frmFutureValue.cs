using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FutureValue_6_1_Enhanced
{
    /*

     Drew Watson
     Lab assignment 3
     6.1
     Friedman
     Component Spring 2018

    */
    public partial class frmFutureValue : Form
    {
        public frmFutureValue()
        {
            InitializeComponent();
        }

        //Performs calculations when button pressed
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //Variables
            decimal monthlyInvestment = 0, yearlyInterestRate = 0, futureValue = 0m, monthlyInterestRate = 0;
            int numberOfYears = 0, months = 0;

            //Taking input and converting to their repective data types
            monthlyInvestment = Convert.ToDecimal(txtMonthlyInvestment.Text);
            yearlyInterestRate = Convert.ToDecimal(txtYearlyInterestRate.Text);
            numberOfYears = Convert.ToInt32(txtNumberOfYears.Text);

            //Number of months in a given year
            months = numberOfYears * 12;

            //Monthly interest rate based off of yearly interest rate
            monthlyInterestRate = ((yearlyInterestRate / 12) / 100);

            //Called function calculates future value 
            calculateFutureValue(monthlyInvestment, monthlyInterestRate, months, ref futureValue);

            /*
             ref keyword used on futureValue so that the memory location is passed and not just the 
             value within the variable. When a function is void no value is returned, and methods
             usually pass data by value and not reference. So inorder for the variable to have the 
             correct value the memory location needs to be passed to that method.When the method is
             done manipulating that variable the value is then changed/manipulated within memory.
             */

            //Converts and formats futurevalue and places in txtbox
            txtFutureValue.Text = futureValue.ToString("c");
            txtMonthlyInvestment.Focus();

        }

        //Calculates the future value of investment
        private void calculateFutureValue( decimal monthlyInvestment, decimal monthlyInterestRate, int months, ref decimal futureValue)
        {
            //Calculates the future value
            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + monthlyInvestment) * (1 + monthlyInterestRate);
            }
        }

        //Generic event that clears future value txtbox
        private void clearFutureValue(object sender, EventArgs e)
        {
            txtFutureValue.Text = "";
        }

        //Closes form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
