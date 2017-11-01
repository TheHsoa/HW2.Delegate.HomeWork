namespace HomeWork.Data.Model
{
    public class Contact : IOrderedEntity
    {
        public long Id { get; set; }
        public virtual string Value { get; set; }

        public int OrderNumber { get; set; }
        public override string ToString()
        {
            return $"Id={Id}, Value={Value}";
        }

        public long UserId { get; set; }
    }
}
