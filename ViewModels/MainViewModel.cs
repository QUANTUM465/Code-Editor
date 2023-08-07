
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
using Test_Assignment;
using System.Reflection.Metadata;
using System.Reflection;
using System.IO;
using System.Text;
using Microsoft.Win32;
using TestAssignment;

namespace Test_Assignment.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private string _dataFromTextBox;

        private LanguageForAPI selectedLanguage;
        public List<LanguageForAPI> Languages { get; set; }

        //Commands for buttons click
        public ICommand CallMemoryLimitWindowCommand { get; set; }
        public ICommand CallTimeLimitWindowCommand { get; set; }
        public ICommand CompiledCommand { get; set; }


        // Geting Argument of Language for API request 
        public LanguageForAPI SelectedLanguageForAPI
        {
            get { return selectedLanguage; }
            set
            {
                selectedLanguage = value;
            }

        }
        // Get Set for TextBox binding
        public string DataFromTextBox
        {
            get { return _dataFromTextBox; }
            set
            {
                _dataFromTextBox = value;
                OnPropertyChanged(nameof(_dataFromTextBox));
            }
        }

        public MainViewModel()
        {
            Languages = LanguageForAPI.GetLanguages();
            CallMemoryLimitWindowCommand = new RelayCommand(CallMemoryLimitWindow, true);
            CallTimeLimitWindowCommand = new RelayCommand(CallTimeLImitWindow, true);
            CompiledCommand = new RelayCommand(CallRequest, true);

        }

        // creating the object of Request class, for making API
        private void CallRequest()
        {

            Request request = new Request
            (
                lang: SelectedLanguageForAPI.GetSetArgument,
                source: DataFromTextBox,
                input: "",
                memory_limit: 262144,
                time_limit: 5,
                context: "",
                callback: ""
            );
            request.CreateRequest(request);


        }

        //Show new window to enter time limit
        private void CallTimeLImitWindow()
        {
            TimeLimitWindow timeLimitWindow = new TimeLimitWindow();
            timeLimitWindow.Show();
        }

        // Show new window to enter memory liit
        private void CallMemoryLimitWindow()
        {
            MemoryLimitWindow memoryLimitWindow = new MemoryLimitWindow();
            memoryLimitWindow.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}

