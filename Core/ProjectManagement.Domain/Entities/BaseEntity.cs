namespace ProjectManagement.Domain.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.IsActive = true;
            this.IsDeleted = false;
            this.CreatedDate = DateTime.UtcNow;
        }
        public virtual Guid Id { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }


    }
}
