using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using Test_Assignment.Models;
using Test_Assignment.Views;
using TestAssignment;

namespace Test_Assignment.ViewModels
{
    class MainViewModel
    {
        private string code;
        public Request request = new Request();
        public List<LanguageForAPI> Languages { get; set; }
        public ICommand CallMemoryLimitWindowCommand { get; set; }
        public ICommand CallTimeLimitWindowCommand { get; set; }
        public ICommand CodeFieldCommand { get; set; }

        public Process currentProcess = Process.GetCurrentProcess();

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        private LanguageForAPI selectedLanguage;
        public MainViewModel()
        {
            Languages = LanguageForAPI.GetLanguages();
            CallMemoryLimitWindowCommand = new RelayCommand(ShowWindow, true);
            CallTimeLimitWindowCommand = new RelayCommand(CallWindow, true);
            CodeFieldCommand = new RelayCommand(ConvertRichTextBoxContentsToString, true);
        }


        private void ConvertRichTextBoxContentsToString( )
        {
            MainWindow window = new MainWindow();
            RichTextBox rtb = window.CodeField;
            TextRange textRange = new TextRange(rtb.Document.ContentStart,
            rtb.Document.ContentEnd);
            Code = textRange.Text;
            request.CreateRequest();
        }

        private void CallWindow()
        {
            TimeLimitWindow timeLimitWindow = new TimeLimitWindow();
            timeLimitWindow.Show();
        }

        private void ShowWindow()
        {
            MemoryLimitWindow memoryLimitWindow = new MemoryLimitWindow();
            memoryLimitWindow.Show();
        }

        // Geting Argument of Language for API request
        public LanguageForAPI SelectedLanguageForAPI
        {
            get { return selectedLanguage; }
            set
            {
                selectedLanguage = value;
            }

        }

    }
}
