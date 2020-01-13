using System;
using System.IO;

namespace AutoFramework.Helpers
{
    public static class LogHelpers
    {
        private static readonly string LogFileName = $"{DateTime.Now:yyyymmddhhmmss}";
        private static StreamWriter _stream;

        public static void CreateLogFile()
        {
            //string directory = Settings.LogPath;
            //if (Directory.Exists(directory))
            //{
            //    _stream = File.AppendText($"{directory} {LogFileName} .log");
            //}
            //else
            //{
            //    Directory.CreateDirectory(directory);
            //    _stream = File.AppendText($"{directory} {LogFileName} .log");
            //}
        }

        public static void Write(string logMessage)
        {
            //_stream.Write($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            //_stream.WriteLine($" {logMessage}");
            //_stream.Flush();
        }
    }
}
