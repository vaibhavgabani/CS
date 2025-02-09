using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Assignment_1
{
    public partial class P04 : Form
    {
        private string infixString = "";
        private bool resultDisplayed = false;

        public P04()
        {
            InitializeComponent();
            pictureBox.SendToBack();
        }

        private void inputBtns(object sender, EventArgs e)
        {
            Button inputButton = sender as Button;
            if (inputButton != null)
            {
                string input = inputButton.Text;
                if (resultDisplayed)
                {
                    if (char.IsDigit(input[0]) || input == ".")
                        infixString = "";
                    resultDisplayed = false;
                }
                infixString += input;
                textBoxInfix.Text = infixString;
            }
        }

        private void equalBtn(object sender, EventArgs e)
        {
            try
            {
                double result = ComputeExpression(infixString);
                textBoxAns.Text = result.ToString();
                infixString = result.ToString();
                textBoxInfix.Text = infixString;
                resultDisplayed = true;
            }
            catch
            {
                textBoxAns.Text = "ERROR";
            }
        }

        private double ComputeExpression(string expression)
        {
            DataTable dt = new DataTable();
            object computed = dt.Compute(expression, "");
            return Convert.ToDouble(computed);
        }

        private void clearBtn(object sender, EventArgs e)
        {
            infixString = "";
            textBoxInfix.Text = "";
            textBoxAns.Text = "";
            resultDisplayed = false;
        }
    }
}
