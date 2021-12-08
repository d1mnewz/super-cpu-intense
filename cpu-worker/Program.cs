// See https://aka.ms/new-console-template for more information

using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

Console.WriteLine("Hello, Portainer!");
Console.WriteLine("Will I crash?");
const int percentage = 80;

for (var i = 0; i < Environment.ProcessorCount; i++)
{
    new Thread(() =>
    {
        var s = "s";
        Stopwatch watch = new();
        watch.Start();
        while (true)
            // Make the loop go on for "percentage" milliseconds then sleep the 
            // remaining percentage milliseconds. So 40% utilization means work 40ms and sleep 60ms
            if (watch.ElapsedMilliseconds > percentage)
            {
                Console.WriteLine("It's high CPU & RAM if you can read it... Save your laptop friend");
                s += string.Join('.', Enumerable.Range(0,100).Select(x => x.ToString()));
                Thread.Sleep(100 - percentage);
                watch.Reset();
                watch.Start();
            }
    }).Start();
}
