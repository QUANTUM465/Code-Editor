﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Test_Assignment.Models
{
    class AppTheme
    {
        public static void ChangeTheme(Uri uri) 
        {
            ResourceDictionary Theme = new ResourceDictionary() { Source = uri };
            
            App.Current.Resources.Clear();
            App.Current.Resources.MergedDictionaries.Add(Theme);
        }
    }
}
