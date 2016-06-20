using System;

namespace Tweakers.Models
{
    /// <summary>
    /// Model class for Review
    /// </summary>
    public abstract class Review : DbContext
    {
        public int ID { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
        public Shop Shop { get; set; }
        public DateTime Date { get; set; }

        #region Constructors
        /// <summary>
        /// Constructor for getting a Review out of the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <param name="date"></param>
        protected Review(int id, User user, DateTime date)
        {
            ID = id;
            User = user;
            Date = date;
        }

        /// <summary>
        /// Constructor for inserting a ProductReview into the database
        /// </summary>
        /// <param name="user"></param>
        /// <param name="product"></param>
        /// <param name="date"></param>
        protected Review(User user, Product product, DateTime date)
        {
            User = user;
            Product = product;
            Date = date;
        }

        /// <summary>
        /// Constructor for getting a ShopReview out of the database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <param name="shop"></param>
        /// <param name="date"></param>
        protected Review(int id, User user, Shop shop, DateTime date)
        {
            ID = id;
            User = user;
            Shop = shop;
            Date = date;
        }

        /// <summary>
        /// Constructor for inserting a ShopReview into the database
        /// </summary>
        /// <param name="user"></param>
        /// <param name="shop"></param>
        /// <param name="date"></param>
        protected Review(User user, Shop shop, DateTime date)
        {
            User = user;
            Shop = shop;
            Date = date;
        }
        #endregion
    }
}