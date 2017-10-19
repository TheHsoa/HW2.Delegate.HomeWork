using HomeWork.Data.Model;

namespace HomeWork.UI.Model
{
    internal class OrderModel : IModel
    {
        public OrderModel(Order order)
        {
            Total = order.Quantity * order.Price;
        }
        public decimal Total { get; set; }
    }
}
