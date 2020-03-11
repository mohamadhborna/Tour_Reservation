namespace Tour.Domain.Entities
{
    public abstract class EntityBase
    {
        public long Id { get; set; }

        public override bool Equals(object obj)
        { 
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            EntityBase entity = (EntityBase) obj;
            return Id == entity.Id;
        }
        
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}