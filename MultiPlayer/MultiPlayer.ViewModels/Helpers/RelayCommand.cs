using System;
using System.Windows.Input;

namespace MultiPlayer.ViewModels.Helpers
{
	public class RelayCommand : ICommand
	{
		readonly Action TargetExecuteMethod;
		readonly Func<bool> TargetCanExecuteMethod;

		public RelayCommand(Action executeMethod)
		{
			TargetExecuteMethod = executeMethod;
		}

		public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
		{
			TargetExecuteMethod = executeMethod;
			TargetCanExecuteMethod = canExecuteMethod;
		}

		public void RaiseCanExecuteChanged()
		{
			CanExecuteChanged(this, EventArgs.Empty);
		}

		bool ICommand.CanExecute(object parameter)
		{

			if (TargetCanExecuteMethod != null)
			{
				return TargetCanExecuteMethod();
			}

			if (TargetExecuteMethod != null)
			{
				return true;
			}

			return false;
		}

		public event EventHandler CanExecuteChanged = delegate { };

		void ICommand.Execute(object parameter)
		{
			TargetExecuteMethod?.Invoke();
		}
	}
}
