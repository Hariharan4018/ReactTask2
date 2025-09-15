using System;
using System.Collections.Generic;

namespace Ecommerce.DAL.Entities;

public partial class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string OrderStatus { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Payment? Payment { get; set; }
}
