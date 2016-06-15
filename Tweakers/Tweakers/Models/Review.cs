using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tweakers.Models
{
    public abstract class Review : DbContext
    {
        public int ID { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
        public Shop Shop { get; set; }
        public DateTime Date { get; set; }

        #region Constructors
        protected Review(int id, User user, Product product, DateTime date)
        {
            ID = id;
            User = user;
            Product = product;
            Date = date;
        }

        protected Review(int id, User user, DateTime date)
        {
            ID = id;
            User = user;
            Date = date;
        }

        protected Review(User user, Product product, DateTime date)
        {
            User = user;
            Product = product;
            Date = date;
        }

        protected Review(int id, User user, Shop shop, DateTime date)
        {
            ID = id;
            User = user;
            Shop = shop;
            Date = date;
        }

        protected Review(User user, Shop shop, DateTime date)
        {
            User = user;
            Shop = shop;
            Date = date;
        }
        #endregion
    }
}