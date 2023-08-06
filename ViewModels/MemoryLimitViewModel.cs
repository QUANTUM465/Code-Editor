using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Test_Assignment.Models;
using Test_Assignment.Views;

namespace Test_Assignment.ViewModels
{
    public class MemoryLimitViewModel
    {
        public MemoryLimit memoryLimit = new MemoryLimit();
        public Process currentProcess = Process.GetCurrentProcess();
        public ICommand CallMemoryLimitCommand { get; set; }

        public long CurrentMemoryLimit
        {
            get { return currentProcess.PagedMemorySize64/1024/1024; }
        }
        public long EnteredMemoryLimit
        {
            set { memoryLimit.NewMemoryLimitBytes = value; }
        }

        public MemoryLimitViewModel()
        {
            CallMemoryLimitCommand = new RelayCommand(SetMemoryLimitExecute, true);
            
        }



        private void SetMemoryLimitExecute()
        {
         
            try
            {
                // Перевіряємо, чи нове значення не перевищує максимальний ліміт
                if (memoryLimit.NewMemoryLimitBytes < currentProcess.PagedSystemMemorySize64 )
                {
                    // Встановлюємо новий ліміт пам'яті
                    IntPtr newMemoryLimit = new IntPtr(memoryLimit.NewMemoryLimitBytes );
                    currentProcess.MaxWorkingSet = newMemoryLimit;

                    // Оновлюємо властивість MaxMemoryLimit в ViewModel, щоб відображення вікна оновилося
                    memoryLimit.MaxMemoryLimit = memoryLimit.NewMemoryLimitBytes;

                    MessageBox.Show("New memory limit set successful");
                }
                else
                {
                    MessageBox.Show("New memory limit exceeds the maximum permissible limit.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}
