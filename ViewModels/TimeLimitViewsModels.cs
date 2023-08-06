using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Test_Assignment.ViewModels
{
    public class TimeLimitViewsModels
    {
        Thread currentThread = Thread.CurrentThread;
        public async Task<string> GetHello()
        {
            var cts = new CancellationTokenSource();
            var task = Task.Run(async () =>
            {
                // await something long running and pass/use cts.Token here too
                TimeLimit();
                return "Hello";
            }, cts.Token);

            var delay = Task.Delay(3000, cts.Token);

            var finishedFirst = await Task.WhenAny(task, delay);
            cts.Cancel();
            if (finishedFirst == task)
            {
                return MessageBox.Show(task.Result).ToString();
            }
            else
            {
                throw new TimeoutException("Timed out.");
            }
        }
        private async void TimeLimit()
        {
            string result = await GetHello();
        }
    }
}
