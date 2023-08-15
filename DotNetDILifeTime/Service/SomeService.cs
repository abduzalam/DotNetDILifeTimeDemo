namespace DotNetDILifeTime.Service
{
    /// <summary>
    /// The Transient services always create a new instance, every time we request for it
    /// 
    /// </summary>
    public class SomeService : IScopedService, ITransientService, ISingletonService
    {
        Guid id;
        public SomeService()
        {
            id = Guid.NewGuid();
        }
        public Guid GetID()
        {
            return id;
        }
    }
}
