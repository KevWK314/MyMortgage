using System;
using System.Windows.Input;

namespace MyMortgage.Wpf.Core.Common.ViewModel
{
    public class ViewModelCommand<T> : IViewModelCommand where T : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public string Name { get; private set; }
        public T Command { get; private set; }

        internal ViewModelCommand(string name, T command)
        {
            this.Name = name;
            this.Command = command;
            this.Command.CanExecuteChanged += (s, a) => this.OnCanExecuteChanged();
        }

        public bool CanExecute(object parameter)
        {
            return this.Command.CanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.Command.Execute(parameter);
        }

        public string GetSnapshot()
        {
            return string.Format("[CanExecute:{0}]", this.CanExecute(null));
        }

        private void OnCanExecuteChanged()
        {
            if (this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
