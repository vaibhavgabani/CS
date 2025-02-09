using System;
using System.Windows.Forms;
using System.Drawing;

namespace Assignment_1
{
    public partial class P04 : Form
    {
        private string infixString = "";

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
                infixString += inputButton.Text;
                textBoxInfix.Text = infixString;
            }
        }

        private void equalBtn(object sender, EventArgs e)
        {
            try
            {
                double result = EvaluateLeftToRight(infixString);
                textBoxAns.Text = result.ToString();
                textBoxInfix.Text = result.ToString();
            }
            catch
            {
                textBoxAns.Text = "ERROR";
            }
        }

        private double EvaluateLeftToRight(string expression)
        {
            try
            {
                // Use only string arrays and double arrays for parsing and evaluating
                int expressionLength = expression.Length;
                string[] tokens = new string[expressionLength * 2];
                int tokenCount = 0;
                string currentNumber = "";

                // Tokenize the expression into numbers and operators
                for (int i = 0; i < expressionLength; i++)
                {
                    char c = expression[i];
                    if ((c >= '0' && c <= '9') || c == '.')
                    {
                        currentNumber += c;
                    }
                    else
                    {
                        if (currentNumber.Length > 0)
                        {
                            tokens[tokenCount] = currentNumber;
                            tokenCount++;
                            currentNumber = "";
                        }
                        tokens[tokenCount] = c.ToString();
                        tokenCount++;
                    }
                }

                // Add the last accumulated number if any
                if (currentNumber.Length > 0)
                {
                    tokens[tokenCount] = currentNumber;
                    tokenCount++;
                }

                // Prepare arrays for numbers and operators
                // For a sequence like "3+5", we have 2 tokens that are numbers and 1 operator
                double[] numbers = new double[(tokenCount + 1) / 2];
                string[] operators = new string[tokenCount / 2];

                int numIndex = 0;
                int opIndex = 0;

                // Separate tokens into numbers and operators
                for (int i = 0; i < tokenCount; i++)
                {
                    if (i % 2 == 0) // even index -> number
                    {
                        numbers[numIndex] = double.Parse(tokens[i]);
                        numIndex++;
                    }
                    else // odd index -> operator
                    {
                        operators[opIndex] = tokens[i];
                        opIndex++;
                    }
                }

                // Evaluate left to right
                double result = numbers[0];
                for (int i = 0; i < opIndex; i++)
                {
                    double nextNum = numbers[i + 1];
                    string op = operators[i];
                    switch (op)
                    {
                        case "+":
                            result += nextNum;
                            break;
                        case "-":
                            result -= nextNum;
                            break;
                        case "*":
                            result *= nextNum;
                            break;
                        case "/":
                            result /= nextNum;
                            break;
                    }
                }

                return result;
            }
            catch
            {
                return double.NaN;
            }
        }

        private void clearBtn(object sender, EventArgs e)
        {
            textBoxInfix.Text = string.Empty;
            textBoxAns.Text = string.Empty;
            infixString = "";
        }
    }
}
