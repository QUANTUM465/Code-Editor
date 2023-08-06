using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Test_Assignment.Views
{
    /// <summary>
    /// Interaction logic for MemoryLimitWindow.xaml
    /// </summary>
    public partial class MemoryLimitWindow : Window
    {
        public MemoryLimitWindow()
        {
            InitializeComponent();
        }
        
        private void CommandBinding_CanExecute_Close(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_Close(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
