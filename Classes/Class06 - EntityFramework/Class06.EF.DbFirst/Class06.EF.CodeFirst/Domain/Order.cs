using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Class06.EF.CodeFirst.Domain
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string? OrderName { get; set; }
        public string? OrderAddress { get; set; }
        public string? OrderCity { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
