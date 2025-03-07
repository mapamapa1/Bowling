using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public sealed class SingletonLogger
    {
        private static readonly SingletonLogger _instance = new();
        private SingletonLogger() { }
        private string _filePath = "C:\\Users\\mrbab\\source\\repos\\Bowling\\Bowling\\Log.txt";
        public static SingletonLogger Instance => _instance;

        public void Log(string message)
        {
            
            using (StreamWriter writer = new StreamWriter(_filePath, append: false))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }

        }
    }




}

