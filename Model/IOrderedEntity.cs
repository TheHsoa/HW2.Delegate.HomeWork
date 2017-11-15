namespace HomeWork.Data.Model
{
    public interface IOrderedEntity : IEntity
    {
        int OrderNumber { get; set; }
    }
}
