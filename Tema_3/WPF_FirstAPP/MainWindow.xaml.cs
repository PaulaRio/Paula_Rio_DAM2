using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_FirstAPP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double result;
        private string _operator;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            textBox.Text += button.Content.ToString();
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(textBox.Text, out double number))
            {
                result = number;
                Button button = sender as Button;
                _operator = button.Content.ToString();
                textBox.Clear();
            }
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(textBox.Text, out double number))
            {
                switch (_operator)
                {
                    case "+":
                        result += number;
                        break;
                    case "-":
                        result -= number;
                        break;
                    case "x":
                        result *= number;
                        break;
                    case "÷":
                        if (number != 0)
                            result /= number;
                        else
                            MessageBox.Show("No se puede dividir por cero.");
                        break;
                }
                textBox.Text = result.ToString();
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            textBox.Clear();
            result = 0;
            _operator = string.Empty;
        }
    }
}