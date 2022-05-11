namespace FarmerStore.Models
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }

        protected Entity(Guid? id = null)
        {
            Id = id != null ? id.Value : Guid.NewGuid();
        }
    }
}
