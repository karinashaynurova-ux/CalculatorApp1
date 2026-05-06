using System; 
using System.IO;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        double firstNumber = 0;
        string operation = "";
        bool operationPressed = false;
        bool darkTheme = false;

        public Form1()
        {
            InitializeComponent();
        }

        // Ввод цифр
        private void Number_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (txtDisplay.Text == "0" || operationPressed)
            {
                txtDisplay.Text = "";
            }

            operationPressed = false;
            txtDisplay.Text += btn.Text;
        }

        // Операции
        private void Operation_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            firstNumber = Convert.ToDouble(txtDisplay.Text);
            operation = btn.Text;
            operationPressed = true;
        }

        // =
        private void btnEqual_Click(object sender, EventArgs e)
        {
            try
            {
                double secondNumber = Convert.ToDouble(txtDisplay.Text);
                double result = 0;

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
                        if (secondNumber == 0)
                        {
                            MessageBox.Show("Деление на ноль невозможно!");
                            return;
                        }

                        result = firstNumber / secondNumber;
                        break;
                }

                txtDisplay.Text = result.ToString();
                firstNumber = result;
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }

        // Очистка
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            firstNumber = 0;
            operation = "";
        }

        // Сохранение
        private void btnSave_Click(object sender, EventArgs e)
        {
            File.WriteAllText("result.txt", txtDisplay.Text);
            MessageBox.Show("Сохранено!");
        }

        // Загрузка
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (File.Exists("result.txt"))
            {
                txtDisplay.Text = File.ReadAllText("result.txt");
                MessageBox.Show("Загружено!");
            }
            else
            {
                MessageBox.Show("Файл не найден!");
            }
        }

        // Тема
        private void btnTheme_Click(object sender, EventArgs e)
        {
            if (!darkTheme)
            {
                this.BackColor = System.Drawing.Color.Black;
                txtDisplay.BackColor = System.Drawing.Color.Gray;
                txtDisplay.ForeColor = System.Drawing.Color.White;

                darkTheme = true;
            }
            else
            {
                this.BackColor = System.Drawing.Color.White;
                txtDisplay.BackColor = System.Drawing.Color.White;
                txtDisplay.ForeColor = System.Drawing.Color.Black;

                darkTheme = false;
            }
        }
    }
}