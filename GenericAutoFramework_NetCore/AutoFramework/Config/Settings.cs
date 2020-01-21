using System.Data.SqlClient;
using AutoFramework.Browser;

namespace AutoFramework.Config
{
    public class Settings
    {
        public static string TestType { get; set; }
        public static string AUT { get; set; }
        public static string BuildName { get; set; }
        public static BrowserType BrowserType { get; set; }
        public static SqlConnection SqlConnection { get; set; }
        public static string AutConnectionString { get; set; } 
        public static string IsLog { get; set; }
        public static string LogPath { get; set; }
        public static string IsReporting { get; set; }
    }
}
