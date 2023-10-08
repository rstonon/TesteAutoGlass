namespace TesteAutoGlass.Core.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity() { }
        public int Codigo { get; private set; }
    }
}
