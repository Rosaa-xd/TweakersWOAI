using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tweakers.Models
{
    /// <summary>
    /// Class for defining all the Dictionaries used
    /// </summary>
    public static class Dictionaries
    {
        //Dictionary for all products
        public static Dictionary<int, Product> Products =
            new Dictionary<int, Product>();
        //Dictionary for all shops
        public static Dictionary<int, Shop> Shops =
            new Dictionary<int, Shop>();
        //Dictionary for all categories
        public static Dictionary<int, Category> Categories =
            new Dictionary<int, Category>();
        //Dictionary for all shopPrices
        public static Dictionary<int, ShopPrice> ShopPrices =
            new Dictionary<int, ShopPrice>();
        //Dictionary for productReviews
        public static Dictionary<int, ProductReview> ProductReviews =
            new Dictionary<int, ProductReview>();
        //Dictionary for assets
        public static Dictionary<int, Asset> Assets =
            new Dictionary<int, Asset>();
        //Dictionary for productSpecification
        public static Dictionary<int, ProductSpecification> ProductSpecifications =
            new Dictionary<int, ProductSpecification>();
        //Dictionary for productPicture
        public static Dictionary<int, ProductPicture> ProductPictures =
            new Dictionary<int, ProductPicture>();
        //Dictionary for userList
        public static Dictionary<int, UserList> UserLists =
            new Dictionary<int, UserList>();
        //Dictionary for user
        public static Dictionary<int, User> Users =
            new Dictionary<int, User>();
    }
}