using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();

            resultLabel.Content = "0";
        }

        private void numberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = int.Parse((sender as Button).Content.ToString());


            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }
        }
        private void operationButton_Click(object sender, EventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }
            if (sender == multiplyButton)
                selectedOperator = SelectedOperator.Multiplication;
            if (sender == additionButton)
                selectedOperator = SelectedOperator.Addition;
            if (sender == subtractionButton)
                selectedOperator= SelectedOperator.Subtraction;
            if (sender == divideButton)
                selectedOperator = SelectedOperator.Division;
        }

        private void acButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
            result = 0;

        }

        private void percentButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;

            if (double.TryParse(resultLabel.Content.ToString(), out tempNumber))
            {
                tempNumber = (tempNumber / 100);
                if (lastNumber != 0)
                    tempNumber *= lastNumber;
                resultLabel.Content = tempNumber.ToString();
            }
        }

        private void equalButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;

            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Subtraction(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiplication(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Division(lastNumber, newNumber);
                        break;
                }

                resultLabel.Content = result.ToString();
            }

        }

        private void decimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString().Contains("."))
            {
                return;
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
            
        }

        private void negativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }
    }

    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
    public class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }
        public static double Subtraction(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double Multiplication(double n1, double n2)
        {
            return n1 * n2;
        }
        public static double Division(double n1, double n2) 
        {
            if(n2 == 0)
            {
                MessageBox.Show("Division by 0 is not supported", "Wrong Operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return n1 / n2;
        }
    }

}
