﻿using System.ComponentModel.DataAnnotations.Schema;

namespace WDAB7.Models
{
    public class OrderItem
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName ="decimal(10,2)")]
        public decimal Tax { get; set; }
    }
}
