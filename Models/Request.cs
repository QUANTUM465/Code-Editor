using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Test_Assignment.ViewModels;
using TestAssignment;
using static System.Net.Mime.MediaTypeNames;

namespace Test_Assignment.Models
{

    class Request : INotifyPropertyChanged
    {
        MainViewModel MainViewModel { get; set; }
        private string lang { get; set; }
        private string source;
        private string input { get; set; }
        private int memory_limit { get; set; }
        private int time_limit { get; set; }
        private string context { get; set; }
        private string callback { get; set; }

        public string Source
        {
            get { return source; }
            set
            {
                source = value;
                OnPropertyChanged(nameof(Request));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

       public Request()
        {
            
        }

        public void CreateRequest()
        {
            LanguageForAPI forAPI = new LanguageForAPI();

            //TODO::Make API request

            Request request = new Request
            {
                lang = forAPI.GetArgument,
                source = MainViewModel.Code,
                input = "",
                memory_limit = 262144,
                time_limit = 5,
                context = "",
                callback = ""
            };
            var CLIENT_SECRET = "d831da60a033e2024c29644361e48b866064ca62";
            var url = "https://api.hackerearth.com/v4/partner/code-evaluation/submissions/";
            string headers = $"client-secret: {CLIENT_SECRET}";

            //Creating json that contains data for API request
            var json = JsonConvert.SerializeObject(request, Formatting.Indented);

            //File.WriteAllText(@"D:\Projects\VIsualStudio\Test Assignment\Test Assignment.csproj", json);
            var client = new HttpClient();
            var response = client.PostAsJsonAsync(url, json).ToString;

        }
    }
}
