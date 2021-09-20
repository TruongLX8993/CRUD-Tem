namespace Domain.Entities
{
    public class CustomerEntity : BaseEntity<int>
    {
        public virtual string Name { get; set; }
        public virtual string Phone { get; set; }
    }
}