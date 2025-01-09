using System.Windows;

namespace Calculator
{
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
