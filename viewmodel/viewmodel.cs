using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp2
{
    
    public partial class MainWindow
    {
        public ICommand IncrementAppearance { get; private set; }
        private void AddNumber(object parameter)
        {
            numbers = numbers * 10 + Convert.ToDouble(parameter.ToString());
            label1.Content = numbers.ToString();
            Console.WriteLine("numbers = " + numbers);
        }
        private void Action(object parameter)
        {
            if (parameter.ToString() == "Enter")
            {
                switch (label3.Content.ToString())
                {
                    case "+":
                        numbers += sec_numbers;
                        break;
                    case "-":
                        numbers -= sec_numbers;
                        break;
                    case "*":
                        numbers *= sec_numbers;
                        break;
                    case "/":
                        numbers /= sec_numbers;
                        break;
                }
                label1.Content = numbers;
                sec_numbers = 0;
                actionChar = ' ';
                label2.Content = "";
                label3.Content = actionChar;
                return;
            } else if (parameter.ToString() == "Clear")
            {
                numbers = 0;
                actionChar = ' ';
                sec_numbers = 0;
                label1.Content = numbers;
                label2.Content = "";
                label3.Content = actionChar;
                return;
            }
            actionChar = Convert.ToChar(parameter);
            sec_numbers = numbers;
            numbers = 0;
            label2.Content = sec_numbers;
            label1.Content = "";
            label3.Content = actionChar;
        }

    }
   
}
