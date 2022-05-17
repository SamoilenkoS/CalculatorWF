using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            comboBoxOperator.SelectedIndex = 0;
        }

        private int CalculateResult(int a, int b, char operation)
        {
            int result = 0;
            checked
            {
                try
                {
                    switch (operation)
                    {
                        case '+':
                            result = a + b;
                            break;
                        case '-':
                            result = a - b;
                            break;
                        case '*':
                            result = a * b;
                            break;
                        case '/':
                            result = a / b;
                            break;
                        case '%':
                            result = a % b;
                            break;
                    }
                }
                catch (OverflowException)
                {
                    throw;
                }

                return result;
            }
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            if(!int.TryParse(textBoxA.Text, out var a)
                || !int.TryParse(textBoxB.Text, out var b))
            {
                MessageBox.Show("Incorrect");
                return;
            }

            var operation = comboBoxOperator.SelectedItem.ToString()[0];
            try
            {
                int result = CalculateResult(a, b, operation);
                labelResult.Text = result.ToString();
            }
            catch (OverflowException)
            {
                MessageBox.Show(
                      "Values too high",
                      "Warning",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Warning);
            }

            //var result = MessageBox.Show("Hello world!", "Caption", MessageBoxButtons.YesNoCancel);
            //if(result == DialogResult.Yes)
            //{
            //    MessageBox.Show("Yes");
            //}
        }

        private void textBoxB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonCalculate_Click(sender, e);
            }
        }
    }
}
