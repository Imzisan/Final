using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class AssignProduct
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductType { get; set; }
        public string DeliveryDate { get; set; }
        public virtual ICollection<ReciveProduct> ReciveProducts { get; set; }

        public AssignProduct()
        {
            ReciveProducts = new List<ReciveProduct>();


        }

    }
}
