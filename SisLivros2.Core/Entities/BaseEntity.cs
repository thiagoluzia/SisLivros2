namespace SisLivros2.Core.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Id = 0;
        }

        public int Id { get; private set; }
    }
}
