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
        private bool CanAddNumber(object parameter)
        {
            return true;
        }
        private bool CanAction(object parameter)
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
    }
}

