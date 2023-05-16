using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class SellerRatingRepo : Repo, IRepo<SellerReview, int, bool>
    {
        public bool Create(SellerReview obj)
        {
            db.SellerReviews.Add(obj);
            if (db.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.SellerReviews.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<SellerReview> Read()
        {
            return db.SellerReviews.ToList();
        }

        public SellerReview Read(int id)
        {
            return db.SellerReviews.Find(id);
        }

        public bool Update(SellerReview Obj)
        {
            var ex = Read(Obj.ReviewId);
            db.Entry(ex).CurrentValues.SetValues(Obj);
            if (db.SaveChanges() > 0)
                return true;
            return false;
        }
    }
}
