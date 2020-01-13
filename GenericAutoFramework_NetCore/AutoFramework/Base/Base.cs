using System;

namespace AutoFramework.Base
{
    public class Base
    {
        protected readonly ParallelConfig parallelConfig;

        public Base(ParallelConfig parallelConfig)
        {
            this.parallelConfig = parallelConfig;
        }

        protected T GetInstance<T>() where T : BasePage, new()
        {
            return (T) Activator.CreateInstance(typeof(T));
        }

        public T As<T>() where T : BasePage => (T) this;
    }
}
