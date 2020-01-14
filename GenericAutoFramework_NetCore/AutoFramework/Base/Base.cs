using System;

namespace AutoFramework.Base
{
    public class Base
    {
        protected readonly DriverContext driverContext;

        protected Base(DriverContext driverContext)
        {
            this.driverContext = driverContext;
        }

        protected T GetInstance<T>(DriverContext driverContext) where T : BasePage, new()
        {
            return (T) Activator.CreateInstance(typeof(T), driverContext);
        }

        public T As<T>() where T : BasePage => (T) this;
    }
}
