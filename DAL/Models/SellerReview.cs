using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public  class SellerReview
    {

        [Key]
        public int ReviewId { get; set; }
        [ForeignKey("Seller")]
        public string Sname { get; set; }
        [ForeignKey("User")]
        public int Id  { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        [StringLength(15)]
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }


        public virtual Seller Seller { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Seller> Sellers { get; set; }

        public SellerReview()
        {
            Sellers = new List<Seller>();
        }
    }
}
