namespace Class06.EF.CodeFirst.Domain
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PizzaId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public decimal Discount { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Pizza Pizza { get; set; } = null!;
    }
}
