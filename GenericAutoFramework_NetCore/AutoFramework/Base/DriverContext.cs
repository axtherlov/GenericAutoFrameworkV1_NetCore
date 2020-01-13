namespace AutoFramework.Base
{
    public class DriverContext
    {
        private readonly ParallelConfig _parallelConfig;

        public static Browser Browser { get; set; }

        public DriverContext(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }
        
        public void GoToUrl(string url)
        {
            _parallelConfig.Driver.Url = url;
        }
    }
}
