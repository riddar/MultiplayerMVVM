using System;
using System.Windows.Input;

namespace MultiPlayer.ViewModels.Helpers
{
	public class BindableBase<T> : ICommand
	{
		Action<T> _TargetExecuteMethod;
		Func<T, bool> _TargetCanExecuteMethod;

		public BindableBase(Action<T> executeMethod)
		{
			_TargetExecuteMethod = executeMethod;
		}

		public BindableBase(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
		{
			_TargetExecuteMethod = executeMethod;
			_TargetCanExecuteMethod = canExecuteMethod;
		}

		public void RaiseCanExecuteChanged()
		{
			CanExecuteChanged(this, EventArgs.Empty);
		}

		bool ICommand.CanExecute(object parameter)
		{

			if (_TargetCanExecuteMethod != null)
			{
				T tparm = (T)parameter;
				return _TargetCanExecuteMethod(tparm);
			}

			if (_TargetExecuteMethod != null)
			{
				return true;
			}

			return false;
		}

		public event EventHandler CanExecuteChanged = delegate { };

		void ICommand.Execute(object parameter)
		{
			_TargetExecuteMethod?.Invoke((T)parameter);
		}
	}
}
