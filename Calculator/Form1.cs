using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public enum State
    {
        WaitingForFirstNumber,
        WaitingForSecondNumber,
        WaitingForResult,
        WaitingForOperation
    }
    public partial class Form1 : Form
    {
        double firstNumber;
        double secondNumber;
        double result;
        string operation;
        State state;
        double ratio;
        double register;
        public Form1()
        {
            InitializeComponent();
            Init();
            state = State.WaitingForFirstNumber;
        }

        public void Init()
        {
            firstNumber = 0;
            secondNumber = 0;
            result = 0;
            ratio = 0;
            operation = "";
            display.Text = "0";
            state = State.WaitingForFirstNumber;
        }

        private void pad_Click(object sender, EventArgs e)
        {
            Button padButton = sender as Button;

            switch (state)
            {
                case State.WaitingForFirstNumber:
                    state = State.WaitingForOperation;
                    break;
                case State.WaitingForSecondNumber:
                    state = State.WaitingForResult;
                    display.Text = "";
                    break;
            }
            if (display.Text == "0")
            {
                display.Text = padButton.Text;
            }
            else
            {
                display.Text += padButton.Text;
            }
            

        }

        private void operation_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            operation = btn.Text;
            switch (operation)
            {
                case "sqrt":
                    operationResult_Click(btn, e);
                    state = State.WaitingForFirstNumber;
                    break;
                //case "%":
                //    ratio = double.Parse(display.Text);
                //    operationResult_Click(btn, e);
                //    state = State.WaitingForFirstNumber;
                //    break;
                default:
                    firstNumber = double.Parse(display.Text);
                    state = State.WaitingForSecondNumber;
                    break;
            }
        }

        private void operationResult_Click(object sender, EventArgs e)
        {
            secondNumber = double.Parse(display.Text);
            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    try
                    {
                        result = firstNumber / secondNumber;
                    }
                    catch (DivideByZeroException except)
                    {
                        display.Text = except.Message;
                    }
                    break;
                case "sqrt":
                    result = Math.Sqrt(secondNumber);
                    break;
            }
            display.Text = result.ToString();
        }

        private void functionality_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Text)
            {
                case "C":
                    Init();
                    break;
                case "CE":
                    display.Text = "";
                    break;
                case ".":
                    display.Text += ",";
                    break;
                case "1/x":
                    display.Text = (1 / double.Parse(display.Text)).ToString();
                    break;
                case "M+":
                    display.Text = (double.Parse(display.Text) + register).ToString();
                    break;
                case "MS":
                    register = double.Parse(display.Text);
                    break;
                case "MC":
                    register = 0;
                    break;
                case "MR":
                    display.Text = register.ToString();
                    break;
                case "Back":
                    if (display.Text.Length > 0)
                    {
                        display.Text = display.Text.Remove(display.Text.Length - 1);
                    }
                    else
                    {
                        display.Text = "0";
                    }
                    break;
            }
        }

        private void percent_Click(object sender, EventArgs e)
        {
            ratio = double.Parse(display.Text) / 100;
            switch (operation)
            {
                case "+":
                    result = firstNumber * (1 + ratio);
                    break;
                case "-":
                    result = firstNumber * (1 - ratio);
                    break;
                case "*":
                    result = firstNumber * firstNumber * ratio;
                    break;
                case "/":
                    try
                    {
                        result = firstNumber / (firstNumber * ratio);
                    }
                    catch (DivideByZeroException except)
                    {
                        display.Text = except.Message;
                    }
                    break;
            }
            display.Text = result.ToString();
        }
    }
}
