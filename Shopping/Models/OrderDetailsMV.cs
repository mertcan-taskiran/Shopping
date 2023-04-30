namespace Shopping.Models
{
    public class OrderDetailsMV
    {
        public OrderHeader OrderHeader { get; set; }
        public IEnumerable<OrderDetails> OrderDetails { get; set; }
    }
}
