namespace Base.Domain
{
    public class BaseEntity<T>
    {
        public virtual T Id { get; set; }
    }
}