using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ReciveProduct
    {
        public int ID { get; set; }
        [ForeignKey("AssignProduct")]
        public int ap_id { get; set; }
        public virtual AssignProduct AssignProduct { get; set; }
        public string status { get; set; }
        public virtual ICollection<DeliveryMan> DeliveryMans { get; set; }
        public ReciveProduct()
        {
            DeliveryMans = new List<DeliveryMan>();

        }

    }
}
