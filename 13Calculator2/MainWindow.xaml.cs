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

namespace _13Calculator2
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
            btnAC.Click += BtnAC_Click;
            btnPlusMinus.Click += BtnPlusMinus_Click;
            btnPercent.Click += BtnPercent_Click;
            btnResult.Click += BtnResult_Click;
        }

        private void BtnResult_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(lblResult.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = simpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Subtraction:
                        result = simpleMath.Subtract(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = simpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = simpleMath.Divide(lastNumber, newNumber);
                        break;

                }
                lblResult.Content = result.ToString();
            }

        }

        private void BtnPercent_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lblResult.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber / 100;
                lblResult.Content = lastNumber.ToString();
            }
        }

        private void BtnPlusMinus_Click(object sender, RoutedEventArgs e)
        {
         if(double.TryParse(lblResult.Content.ToString(), out lastNumber))
            {
                lastNumber = -1 * lastNumber;
                lblResult.Content = lastNumber.ToString();
            }   
        }

        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = int.Parse((sender as Button).Content.ToString());
            //int selectedValue = sender.ToString()[sender.ToString().Length - 1] - 48;
            
            if (lblResult.Content.ToString() == "0")
            {
                lblResult.Content=$"{selectedValue}";
            }
            else
            {
                lblResult.Content = $"{lblResult.Content}{selectedValue}";
            }
        }

        private void btnOperation_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lblResult.Content.ToString(), out lastNumber))
            {
                //lastNumber = lastNumber;
                lblResult.Content = "";
            }

            if (sender == btnProduct)
                selectedOperator = SelectedOperator.Multiplication;
            if (sender == btnDivision)
                selectedOperator = SelectedOperator.Division;
            if (sender == btnSum)
                selectedOperator = SelectedOperator.Addition;
            if (sender == btnDifference)
                selectedOperator = SelectedOperator.Subtraction;

        }

        private void btnDecimal_Click(object sender, RoutedEventArgs e)
        {
            if(!lblResult.Content.ToString().Contains("."))
                lblResult.Content = $"{lblResult.Content}.";
        }

        private void BtnAC_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = "0";
        }
    }
    public enum  SelectedOperator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public class simpleMath
    {
        public static double Add(double n1, double n2)
        { return n1 + n2; }
        public static double Subtract(double n1, double n2)
        { return n1 - n2; }
        public static double Multiply(double n1, double n2)
        { return n1 * n2; }
        public static double Divide(double n1, double n2)
        { return n1 / n2; }
    }
}
