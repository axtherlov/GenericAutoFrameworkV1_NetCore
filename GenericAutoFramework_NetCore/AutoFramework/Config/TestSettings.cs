using System.ComponentModel.DataAnnotations;

namespace AutoFramework.Config
{
    public class TestSettings
    {
        public string Name { get; set; }
        public string Aut { get; set; }
        public string TestType { get; set; }
        public string IsLog { get; set; }
        public string LogsPath { get; set; }
        public string ScreenShotsPath { get; set; }
        public string ReportsPath { get; set; }
        public string Browser { get; set; }
        public string AutConnectionString { get; set; }
        [Range(5, 30)]
        public int ImplicitWaitTimeout { get; set; }
        [Range(5, 120)]
        public int PageLoadTimeout { get; set; }
    }
}
