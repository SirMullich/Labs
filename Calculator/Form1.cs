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
                case "%":
                    operationResult_Click(btn, e);
                    state = State.WaitingForFirstNumber;
                    break;
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
    }
}
