﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizSolverV2.ViewModel
{
    class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private Action mAction;

        public  RelayCommand(Action action)
        {
            mAction=action;
        }


        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            mAction();
        }
    }
}
