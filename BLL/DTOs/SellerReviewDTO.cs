using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class SellerReviewDTO
    {
        public int ReviewId { get; set; }
       
        public string Sname { get; set; }
        
        public int Id { get; set; }
       
        public int Rating { get; set; }
        
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
