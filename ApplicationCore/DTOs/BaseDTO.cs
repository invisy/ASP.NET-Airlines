namespace Airlines.ApplicationCore.DTOs
{
    public abstract class BaseDto<T>
    {
        public virtual T Id { get; set; }
    }
}