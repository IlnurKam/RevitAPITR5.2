﻿namespace RevitAPITR5._2
{
    internal class DelegateCommand
    {
        private object onSaveCommand;

        public DelegateCommand(object onSaveCommand)
        {
            this.onSaveCommand = onSaveCommand;
        }
    }
}