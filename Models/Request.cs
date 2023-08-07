using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using Test_Assignment.ViewModels;
using TestAssignment;

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

       public Request( string lang, string source, string input, int memory_limit, int time_limit, string context, string callback)
        {
           
            this.lang = lang;
            this.input = input;
            this.memory_limit = memory_limit;
            this.time_limit = time_limit;
            this.context = context;
            this.callback = callback;
            this.source = source;
        }


        public void CreateRequest(Request request)
        {

            //TODO::Make API request

            var content = new
            {
                source = this.source,
                lang = this.lang,
                input = this.input,
                memory_limit = this.memory_limit,
                time_limit = this.time_limit,
                context = this.context,
                callback = this.callback,
                id = "client-001" // Replace this with a unique id for your request
            };
            var CLIENT_SECRET = "d831da60a033e2024c29644361e48b866064ca62";
            var url = "https://api.hackerearth.com/v4/partner/code-evaluation/submissions/";
            string headers = $"client-secret: {CLIENT_SECRET}";

            //Creating json that contains data for API request

            
            //File.WriteAllText(@"D:\Projects\VIsualStudio\Test Assignment\Test Assignment.csproj", json);
            var client = new HttpClient();
            var response = client.PostAsJsonAsync(url, content);
            var text = response.Result.ToString();
        }
    }
}
