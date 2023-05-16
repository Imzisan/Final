using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserSellerReviewDTO
    {

        public List<UserDTO> Users { get; set; }

        public SellerReviewDTO SellerReview { get; set; }

        public UserSellerReviewDTO()
        {
            Users = new List<UserDTO>();
        }
    }

}

