namespace Domain.Entities
{
    public class BaseEntity<T>
    {
        public virtual T Id { get; set; }
    }
}