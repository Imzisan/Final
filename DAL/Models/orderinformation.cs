using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class orderinformation
    {
        public int Id { get; set; }
        public virtual ICollection<DeliveryMan> DeliveryMan { get; set; }

        public orderinformation()
        {
            DeliveryMan = new List<DeliveryMan>();


        }

    }
}
