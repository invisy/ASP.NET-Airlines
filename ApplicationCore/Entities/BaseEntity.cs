namespace Airlines.ApplicationCore.Entities
{
    public abstract class BaseEntity<T>
    {
        public virtual T Id { get; private set; }
    }
}