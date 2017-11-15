using HomeWork.Data.Model;

namespace HomeWork.UI.Model
{
    public class OrderModel
    {
        public OrderModel(Order order)
        {
            Total = order.Quantity * order.Price;
        }
        public decimal Total { get; set; }
    }
}
