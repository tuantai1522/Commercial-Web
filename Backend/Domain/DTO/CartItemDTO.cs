using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class CartItemDTO : BaseEntity
    {
        public int CartId {  get; set; }
        public int Quantity {  get; set; }
        public int ProductId {  get; set; }
        public string ProductName { get; set; }
        public string Description {  get; set; }
        public double Price {  get; set; }
        public string ImageUrl {  get; set; }

        public string CategoryName { get; set; }
    }
}
