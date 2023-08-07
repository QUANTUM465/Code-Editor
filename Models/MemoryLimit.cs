using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Test_Assignment.Models
{
    public class MemoryLimit : INotifyPropertyChanged
    {
        private long maxMemoryLimit; 
        private long newMemoryLimitBytes; 

        public long MaxMemoryLimit
        {
            get { return maxMemoryLimit; }
            set
            {
                maxMemoryLimit = value;
                OnPropertyChanged(nameof(maxMemoryLimit));
            }

        }
        public long NewMemoryLimitBytes
        {
            get { return newMemoryLimitBytes; }
            set
            {
                newMemoryLimitBytes = value;
                OnPropertyChanged(nameof(newMemoryLimitBytes));
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
