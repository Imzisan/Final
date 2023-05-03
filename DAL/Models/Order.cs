using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public  class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderType { get; set; }
        [Required]
        public string OrderQuantity { get; set; }

        [Required]
        public string Location { get; set; }
        [ForeignKey("Seller")]
        public string SelleBy { get; set; }

        public virtual Seller Seller { get; set; }
        public int productby { get; set; }
        [ForeignKey("productby")]
        public Product Product { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
        public virtual ICollection<orderinformation> orderinformations { get; set; }


        public Order ()
        {
            ProductOrders = new List<ProductOrder> ();
            orderinformations = new List<orderinformation>();
        }
    }
}