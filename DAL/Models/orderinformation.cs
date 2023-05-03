using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class orderinformation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Orders")]
        public int or_id { get; set; }
        public virtual Order Orders { get; set; }
        public virtual ICollection<DeliveryMan> DeliveryMan { get; set; }

        public orderinformation()
        {
            DeliveryMan = new List<DeliveryMan>();


        }

    }
}
