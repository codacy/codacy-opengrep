using System;
using System.Threading.Tasks;

namespace Tests.Bugs
{
    class Async
    {
        private async void ThrowExceptionAsync() // Noncompliant
        {
            await Task.Delay(1);
            throw new InvalidOperationException();
        }

        public async void button1_Click(object sender, EventArgs e)
        {
            await Task.Delay(1);
        }

        public async void OnClick(string data)
        {
            await Task.Delay(1);
        }

        private async Task FineAsync()
        {
            await Task.Delay(1);
        }
    }
}
