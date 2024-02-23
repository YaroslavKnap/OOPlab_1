using OOPlab1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPlab1
{
  
    public partial class Form1 : Form
    {
        public BinaryNumber number1;
        public BinaryNumber number2;
        public Form1()
        {
            number1 = new BinaryNumber();
            number2 = new BinaryNumber();   
            InitializeComponent();
            //------------------------------------------------------------------Код для дизайну---------------------------------------------------------------------------------------
            // Видалення стандартного вигляду кнопок
            foreach (var button in new[] { button1, button2, button3, button4, button5 })
            {
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.BackColor = Color.FromArgb(64, 64, 64); // Похмурий колір фону
                button.ForeColor = Color.White; // Колір тексту
                button.MouseEnter += Button_MouseEnter;
                button.MouseLeave += Button_MouseLeave;
            }
        }

        // Змінює колір кнопки при наведенні миші
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.BackColor = Color.FromArgb(0, 122, 204); // Голубий колір фону при наведенні
        }

        // Повертає колір кнопки до початкового при виїзді миші
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.BackColor = Color.FromArgb(64, 64, 64); // Похмурий колір фону
        }
        //---------------------------------------------------------------------------------------------------------------------------
        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            number1.Add(number2);
            label6.Text = number1.Add(number2).GetBinaryValue();   


        }

        private void button2_Click(object sender, EventArgs e)
        {
            number1.Subtract(number2);
            label6.Text = number1.Subtract(number2).GetBinaryValue();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            label6.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            number1.SetBinaryValue(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            number2.SetBinaryValue(textBox2.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            number1.Divide(number2);
            label6.Text = number1.Divide(number2).GetBinaryValue();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            number1.Multiply(number2);
            label6.Text = number1.Multiply(number2).GetBinaryValue();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
//1

public class BinaryNumber
{
    private string binaryValue;

    // Параметризований конструктор
    public BinaryNumber(string binaryValue)
    {
        SetBinaryValue(binaryValue);
    }

    // Непараметризований конструктор
    public BinaryNumber()
    {
        // За замовчуванням встановлюємо значення "0"
        SetBinaryValue("0");
    }

    // Закрите поле класу
    private string BinaryValue
    {
        get { return binaryValue; }
        set { binaryValue = value; }
    }

    // Метод, що перевіряє правильність двійкового числа
    private bool IsValidBinary(string binaryValue)
    {
        foreach (char bit in binaryValue)
        {
            if (bit != '0' && bit != '1')
            {
                return false;
            }
        }
        return true;
    }

    // Метод, що встановлює двійкове значення з перевіркою на правильність
    public void SetBinaryValue(string binaryValue)
    {
        if (IsValidBinary(binaryValue))
        {
            BinaryValue = binaryValue;
        }
        else
        {
            MessageBox.Show("Error");
            
        }
    }

    // Метод для отримання значення двійкового числа
    public string GetBinaryValue()
    {
        return BinaryValue;
    }

    // Метод для конвертації двійкового числа в десяткове
    public int ToDecimal()
    {
        return Convert.ToInt32(BinaryValue, 2);
    }

    // Метод для додавання двох двійкових чисел
    public BinaryNumber Add(BinaryNumber other)
    {
        int sum = ToDecimal() + other.ToDecimal();
        return new BinaryNumber(Convert.ToString(sum, 2));
    }

    // Метод для віднімання двох двійкових чисел
    public BinaryNumber Subtract(BinaryNumber other)
    {
        int difference = ToDecimal() - other.ToDecimal();
        if (difference < 0)
        {
            throw new ArgumentException("Від'ємне значення не може бути представлене у двійковій системі.");
        }
        return new BinaryNumber(Convert.ToString(difference, 2));
    }
    // Метод для виконання ділення двійкових чисел
    public BinaryNumber Divide(BinaryNumber divisor)
    {
        // Перетворення діленого та дільника в десяткові числа
        int dividendDecimal = Convert.ToInt32(binaryValue, 2);
        int divisorDecimal = Convert.ToInt32(divisor.binaryValue, 2);

        // Виконання ділення десяткових чисел
        int quotientDecimal = dividendDecimal / divisorDecimal;

        // Перетворення результату ділення назад у двійкове число
        string quotientBinary = Convert.ToString(quotientDecimal, 2);

        // Повернення результату у вигляді нового об'єкта BinaryNumber
        return new BinaryNumber(quotientBinary);
    }

    public BinaryNumber Multiply(BinaryNumber multiplicand)
    {
        // Перетворення множника та множенника в десяткові числа
        int multiplicandDecimal = Convert.ToInt32(binaryValue, 2);
        int multiplierDecimal = Convert.ToInt32(multiplicand.binaryValue, 2);

        // Виконання множення десяткових чисел
        int productDecimal = multiplicandDecimal * multiplierDecimal;

        // Перетворення результату множення назад у двійкове число
        string productBinary = Convert.ToString(productDecimal, 2);

        // Повернення результату у вигляді нового об'єкта BinaryNumber
        return new BinaryNumber(productBinary);
    }

}
