using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Test_Assignment.ViewModels;

//Програма повинна підтримувати такі функції:
// Використання MVVM
// Редактор коду, який включає:
//      Поле для введення коду.
//      Перемикання мови програмування.
//      Встановлення ліміту пам'яті.
//      Встановлення обмеження часу виконання.
//      Відображення прогресу: поточний стан(компіляція, виконання) і результат(помилка або вихід).


namespace TestAssignment
{
    public class LanguageForAPI
    {
        private string Language;
        private string Argument;

        public string GetSetLanguage 
        {
            get { return Language; }
            set { Language = value; }
        }
        public string GetSetArgument 
        {
            get { return Argument; }
            set { Argument = value; }
        }

        private static List<LanguageForAPI> _Languages = new List<LanguageForAPI>()
        {

                    new LanguageForAPI { Language = "C", Argument = "C" },
                    new LanguageForAPI { Language = "C++14", Argument = "CPP14" },
                    new LanguageForAPI { Language = "C++17", Argument = "CPP17" },
                    new LanguageForAPI { Language = "Clojure", Argument = "CLOJURE" },
                    new LanguageForAPI { Language = "C#", Argument = "CSHARP" },
                    new LanguageForAPI { Language = "Go", Argument = "GO" },
                    new LanguageForAPI { Language = "Haskell", Argument = "HASKELL" },
                    new LanguageForAPI { Language = "Java 8", Argument = "JAVA8" },
                    new LanguageForAPI { Language = "Java 14", Argument = "JAVA14" },
                    new LanguageForAPI { Language = "JavaScript(Nodejs)", Argument = "JAVASCRIPT_NODE" },
                    new LanguageForAPI { Language = "Kotlin", Argument = "KOTLIN" },
                    new LanguageForAPI { Language = "Objective C", Argument = "OBJECTIVEC" },
                    new LanguageForAPI { Language = "Pascal", Argument = "PASCAL" },
                    new LanguageForAPI { Language = "Perl", Argument = "PERL" },
                    new LanguageForAPI { Language = "PHP", Argument = "PHP" },
                    new LanguageForAPI { Language = "Python 2", Argument = "PYTHON" },
                    new LanguageForAPI { Language = "Python 3", Argument = "PYTHON3" },
                    new LanguageForAPI { Language = "Python 3.8", Argument = "PYTHON3_8" },
                    new LanguageForAPI { Language = "R", Argument = "R" },
                    new LanguageForAPI { Language = "Ruby", Argument = "RUBY" },
                    new LanguageForAPI { Language = "Rust", Argument = "RUST" },
                    new LanguageForAPI { Language = "Scala", Argument = "SCALA" },
                    new LanguageForAPI { Language = "Swift", Argument = "SWIFT" },
                    new LanguageForAPI { Language = "TypeScript", Argument = "TYPESCRIPT" }

        };
        public static List<LanguageForAPI> GetLanguages()
        {
            return _Languages;
        }
        public LanguageForAPI() { }

    }
}
