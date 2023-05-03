using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class AssignProduct
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductType { get; set; }
        public DateTime DeliveryDate { get; set; }
        public virtual ICollection<ReciveProduct> ReciveProducts { get; set; }
        public virtual ICollection<Moderator> Moderators { get; set; }




        public AssignProduct()
        {
            ReciveProducts = new List<ReciveProduct>();
            Moderators = new List<Moderator>();



        }

    }
}
