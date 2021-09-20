using Base.Domain;

namespace Domain.Entities
{
    public class Customer : BaseEntity<int>
    {
        public virtual string Name { get; set; }
        public virtual string Phone { get; set; }
    }
}