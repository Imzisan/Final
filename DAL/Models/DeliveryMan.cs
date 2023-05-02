using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class DeliveryMan
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Uname { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        [Required]
        [StringLength(15)]
        public string Password { get; set; }

        [ForeignKey("deliverymanreview")]
        public int DMR_id { get; set; }
        public virtual DeliveryManReview deliverymanreview { get; set; }

        [ForeignKey("ReciveProducts")]
        public int rp_id { get; set; }
        public virtual ReciveProduct ReciveProducts { get; set; }
        [ForeignKey("orderinformations")]
        public int orinfo_id { get; set; }
        public virtual orderinformation orderinformations { get; set; }

        //ForeignKey("User_Order")]
        //ublic int UOR_id { get; set; }
        //ublic virtual User_Order User_Order { get; set; }

        //ForeignKey("user")]
        //ublic int user_id { get; set; }

        //ublic virtual User user { get; set; }

    }
}
