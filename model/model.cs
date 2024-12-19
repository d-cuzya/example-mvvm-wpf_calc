using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Reflection.Emit;

namespace WpfApp2
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute) : this(execute, null)
        {
        }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
    public class Model: INotifyPropertyChanged
    {
        public string NumberLabel { get { return numbers.ToString(); } }
        public ICommand AddNumberCommand { get; }
        public ICommand AddActionCommand { get; }
        private double _numbers = 0;
        private double _sec_numbers = 0;
        private char _actionChar = ' ';
        protected double numbers { get { return _numbers; } set { _numbers = value; OnPropertyChanged("numbers"); } }
        protected double sec_numbers { get { return _sec_numbers; } set { _sec_numbers = value; OnPropertyChanged("sec_numbers"); } }
        protected char actionChar { get { return _actionChar; } set { _actionChar = value; OnPropertyChanged("actionChar"); } }
        public bool CanAddNumber(object parameter)
        {
            return true;
        }
        public bool CanAction(object parameter)
        {
            return true;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
                Console.Clear();
                switch (prop)
                {
                    case "numbers":
                        //label1.Content = Convert.ToString(numbers);
                        break;
                    case "sec_numbers":
                        //label2.Content = Convert.ToString(sec_numbers);
                        break;
                    case "actionChar":
                        //label3.Content = actionChar;
                        break;
                }
                Console.Write(Convert.ToString(numbers));

                Console.Write(actionChar); 
                Console.Write(Convert.ToString(sec_numbers));
            }
        }
        public void AddNumber(object parameter)
        {
            numbers = numbers * 10 + Convert.ToDouble(parameter.ToString());
            //Console.WriteLine("numbers = " + numbers);
        }
        public void Action(object parameter)
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
            }
            else if (parameter.ToString() == "Clear")
            {
                numbers = 0;
                actionChar = ' ';
                sec_numbers = 0;
                return;
            }
            actionChar = Convert.ToChar(parameter);
            Console.WriteLine("p - " + parameter.ToString());
            Console.WriteLine("q - " + Convert.ToChar(parameter.ToString()));
            sec_numbers = numbers;
            numbers = 0;
        }
        public Model()
        {
            AddNumberCommand = new RelayCommand(AddNumber, CanAddNumber);
            AddActionCommand = new RelayCommand(Action, CanAction);
        }
    }
}

