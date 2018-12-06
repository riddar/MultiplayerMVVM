﻿using System;
using System.Windows.Input;

namespace MultiPlayer.UI.Helpers
{
	public class RelayCommand : ICommand
	{
		Action _TargetExecuteMethod;
		Func<bool> _TargetCanExecuteMethod;

		public RelayCommand(Action executeMethod)
		{
			_TargetExecuteMethod = executeMethod;
		}

		public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
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
				return _TargetCanExecuteMethod();
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
			_TargetExecuteMethod?.Invoke();
		}
	}

	public class RelayCommand<T> : ICommand
	{
		Action<T> _TargetExecuteMethod;
		Func<T, bool> _TargetCanExecuteMethod;
		private Action onSave;

		public RelayCommand(Action<T> executeMethod)
		{
			_TargetExecuteMethod = executeMethod;
		}

		public RelayCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
		{
			_TargetExecuteMethod = executeMethod;
			_TargetCanExecuteMethod = canExecuteMethod;
		}

		public RelayCommand(Action onSave)
		{
			this.onSave = onSave;
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
