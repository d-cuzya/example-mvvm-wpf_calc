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
    public partial class MainWindow
    {
        public string NumberLabel { get { return numbers.ToString(); } }
        public ICommand AddNumberCommand { get; }
        public ICommand AddActionCommand { get; }
        private uint numbers = 0;
        
        private void AddNumber(object parameter)
        {
            numbers = numbers * 10 + Convert.ToUInt32(parameter.ToString());
            label1.Content = numbers.ToString();
            Console.WriteLine("numbers = " + numbers);
        }
        private void Action(object parameter)
        {
            switch (parameter.ToString()){
                case "+":
                    Console.WriteLine("action");
                    break;
                case "-":
                    Console.WriteLine("action");
                    break;
                case "*":
                    Console.WriteLine("action");
                    break;
                case "/":
                    Console.WriteLine("action");
                    break;
                case "Enter":
                    Console.WriteLine("action");
                    break;
                case "Clear":
                    Console.WriteLine("action");
                    break;
            }
        }
        private bool CanAddNumber(object parameter)
        {
            return true;
        }
        private bool CanAction(object parameter)
        {
            return true;
        }
    }
}

