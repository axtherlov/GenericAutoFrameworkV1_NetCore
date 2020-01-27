using System.Data.SqlClient;
using AutoFramework.Browser;

namespace AutoFramework.Config
{
    public class Settings
    {
        public static string Name { get; set; }
        public static string Aut { get; set; }
        public static BrowserType BrowserType { get; set; }
        public static string TestType { get; set; }
        public static string LogsPath { get; set; }
        public static string ScreenShotsPath { get; set; }
        public static string ReportsPath { get; set; }
        public static string AutConnectionString { get; set; } 
        public static double ImplicitWaitTimeout { get; set; }
        public static double PageLoadTimeout { get; set; }
        public static SqlConnection SqlConnection { get; set; }
    }
}
