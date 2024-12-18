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
            //Console.WriteLine("numbers = " + numbers);
        }
        private void Action(object parameter)
        {
            string asdsad = parameter as string;
            if (parameter.ToString() == "Enter")
            {
                switch (actionChar)
                {
                    case '+':
                        numbers += sec_numbers;
                        break;
                    case '-':
                        numbers -= sec_numbers;
                        break;
                    case '*':
                        numbers *= sec_numbers;
                        break;
                    case '/':
                        numbers /= sec_numbers;
                        break;
                }
                sec_numbers = 0;
                actionChar = ' ';
                return;
            } else if (parameter.ToString() == "Clear")
            {
                numbers = 0;
                actionChar = ' ';
                sec_numbers = 0;
                return;
            }
            actionChar = Convert.ToChar(parameter);
            Console.WriteLine("p - " + parameter.ToString());
            Console.WriteLine("q - "+ Convert.ToChar(parameter.ToString()));
            sec_numbers = numbers;
            numbers = 0;
        }

    }
   
}
